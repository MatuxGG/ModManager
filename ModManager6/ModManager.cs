using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModManager6.Classes;
using Microsoft.Win32;
using System.Net.Http;
using Octokit;
using System.Net;
using Newtonsoft.Json;
using System.Threading;
using ModManager6.Forms;

namespace ModManager6
{
    public partial class ModManager : Form
    {
        public static string serverURL = "https://dev.goodloss.fr"; // TODO : Change to live
        public static string apiURL = "https://dev.goodloss.fr/api";
        public static string fileURL = "https://dev.goodloss.fr/files";
        public static string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ModManager";
        public static string tempPath = Path.GetTempPath() + "ModManager";
        public static Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public static string visibleVersion = version.ToString().Substring(0, version.ToString().Length - 2);
        public static string token;
        public static string supportIdChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
        public static GitHubClient githubClient;

        public static bool debug = false;

        public static bool silent;

        public ModManager(string[] args)
        {
            InitializeComponent();
            this.CenterToScreen();
            _ = this.Start(args);
        }

        public async Task Start(string[] args)
        {
            // Update from Mod Manager 5

            if (File.Exists(appDataPath + @"\config5.conf"))
            {
                await Task.Run(() =>
                {
                    string backupPath = appDataPath + @"\ModManager5Backup";
                    Directory.CreateDirectory(backupPath);

                    if (Directory.Exists(appDataPath + @"\mods"))
                    {
                        Directory.Move(appDataPath + @"\mods", backupPath + @"\mods");
                    }
                    if (Directory.Exists(appDataPath + @"\localMods"))
                    {
                        Directory.Move(appDataPath + @"\localMods", backupPath + @"\localMods");
                    }
                    if (Directory.Exists(appDataPath + @"\vanilla"))
                    {
                        Directory.Move(appDataPath + @"\vanilla", backupPath + @"\vanilla");
                    }
                    if (File.Exists(appDataPath + @"\config5.conf"))
                    {
                        Directory.Move(appDataPath + @"\config5.conf", backupPath + @"\config5.conf");
                    }
                    if (File.Exists(appDataPath + @"\globalConfig5.conf"))
                    {
                        Directory.Move(appDataPath + @"\globalConfig5.conf", backupPath + @"\globalConfig5.conf");
                    }
                });
            }

            // Create folders if necessary

            FileSystem.DirectoryCreate(appDataPath);
            FileSystem.DirectoryCreate(appDataPath + @"\themes");
            FileSystem.DirectoryCreate(appDataPath + @"\icons");
            FileSystem.DirectoryCreate(tempPath);

            Log.logNewLine();
            Log.log("ModManager version " + ModManager.visibleVersion, "ModManager");

            // Disable multiple MM run
            if (System.Diagnostics.Process.GetProcessesByName("ModManager6").Length > 1 && (args.Count() == 0 || args[0] != "force"))
            {
                if (args.Count() == 0)
                {
                    MessageBox.Show("Mod Manager is already running.", "Mod Manager already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }

            Downloader.load();

            Log.startTimer();
            token = await Downloader.downloadString(apiURL + "/github/token");
            Log.logTime("Initialisation", "ModManager");

            Log.startTimer();
            ConfigManager.load();
            Log.logTime("Config load", "ModManager");

            // Check if shortcut or force restart

            if (args.Count() > 0)
            {
                if (args[0].StartsWith("modmanager://")) // Handle browser URL ModManager://args0&args1&arg2&...
                {
                    args[0] = args[0].Trim();
                    args[0] = args[0].Substring(13);
                    args = args[0].Split("&");
                }
                if (args[0] == "force")
                {
                    args = new string[] { };
                }
                else if (args[0] == "startmod" && args.Count() >= 3) // startmod modId versionId [option1 option2] ...
                {
                    silent = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
                else if (args[0] == "startlocalmod" && args.Count() >= 7) // startlocalmod modId modName githubAuthor githubRepo version gameVersion
                {
                    silent = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
                else if (args[0] == "addsource")
                {
                    int i = 1;
                    while (args.Count() > i)
                    {
                        ConfigManager.config.sources.Add(args[i]);
                        i++;
                    }
                    ConfigManager.update();
                } else if (args[0] == "setsources")
                {
                    ConfigManager.config.sources.Clear();
                    int i = 1;
                    while (args.Count() > i)
                    {
                        ConfigManager.config.sources.Add(args[i]);
                        i++;
                    }
                    ConfigManager.update();
                }
                else
                {
                    restartApp();
                }
            }

            Log.startTimer();
            await Translator.load();
            Log.logTime("Translations load", "ModManager");

            Log.startTimer();
            ThemeList.load();
            Log.logTime("Themes load", "ModManager");

            Log.startTimer();
            int width = 500;
            int height = 300;
            if (silent)
            {
                ModManagerUI.loadMini(this);
                this.MinimumSize = new System.Drawing.Size(width, height);
            }
            else
            {
                ModManagerUI.load(this);
                this.MinimumSize = new System.Drawing.Size(1200, 480);
                width = (int)((80 * Screen.PrimaryScreen.Bounds.Width) / 100);
                if (width < this.MinimumSize.Width)
                    width = this.MinimumSize.Width;
                height = (int)((80 * Screen.PrimaryScreen.Bounds.Height) / 100);
                if (height < this.MinimumSize.Height)
                    height = this.MinimumSize.Height;
            }
            Log.logTime("UI load (1/2)", "ModManager");

            this.Size = new Size(width, height);
            this.CenterToScreen();

            Log.startTimer();
            // Load Github Client
            githubClient = new GitHubClient(new ProductHeaderValue("ModManager"));
            githubClient.Credentials = new Credentials(ModManager.token);
            Log.logTime("Github client load", "ModManager");

            Log.startTimer();
            await Updater.CheckRunUpdateOnStart();
            Log.logTime("Updater load", "ModManager");

            Log.startTimer();
            ModManagerUI.StatusLabel.Text = Translator.get("Loading Local Config...");
            ConfigManager.updateAmongUs();
            Log.logTime("AU folder load", "ModManager");

            Log.startTimer();
            ModManagerUI.StatusLabel.Text = Translator.get("Loading Mods...");
            await ModList.load();
            Log.logTime("Modlist load", "ModManager");

            Log.startTimer();
            ModManagerUI.StatusLabel.Text = Translator.get("Loading Releases...");
            await ModList.loadReleases();
            Log.logTime("Releases load", "ModManager");

            if (!silent)
            {
                Log.startTimer();
                ModManagerUI.StatusLabel.Text = Translator.get("Loading Among Us Servers...");
                ServerManager.load();
                Log.logTime("Servers load", "ModManager");
            }

            ModWorker.load();

            if (!silent)
            {
                Log.startTimer();
                ContextMenu.init(this);
                ContextMenu.load();
                Log.logTime("Context menu load", "ModManager");
            }

            VersionUpdater.applyUpdates(ConfigManager.config.ModManagerVersion, visibleVersion);


            string keyPath = @"Software\Classes\ModManager";
            string appName = "ModManager";

            // Setup Mod Manager registry actions if doesn't exist

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key == null)
                {
                    using (RegistryKey newKey = Registry.CurrentUser.CreateSubKey(keyPath))
                    {
                        newKey.SetValue("", appName);
                        newKey.SetValue("URL Protocol", "");

                        using (RegistryKey commandKey = newKey.CreateSubKey(@"shell\open\command"))
                        {
                            commandKey.SetValue("", $"\"{appPath}ModManager6.exe\" \"%V\"");
                        }
                    }
                }
            }

            if (silent)
            {
                if (args[0] == "startlocalmod")
                {
                    // Local mod

                    ModWorker.installAndStartLocalMod(args[1], args[2], args[3], args[4], args[5], args[6]);

                } else
                {
                    // Mod / Shortcut

                    await ModWorker.StartShortcut(args);
                }


            }
            else
            {
                Log.startTimer();
                ModManagerUI.StatusLabel.Text = Translator.get("Loading UI...");
                ModManagerUI.InitUI();
                ModManagerUI.InitListeners();
                ModManagerUI.hideMenuPanels();
                ModManagerUI.InitForm();
                Log.logTime("UI load (2/2)", "ModManager");

                ModManagerUI.LoadingLabel.Hide();
            }

            ModManagerUI.Alert(Translator.get("Mod Manager Started"));

            ModManagerUI.StatusLabel.Text = "";

            Log.log("Ready", "ModManager");
        }

        public static void restartApp()
        {
            string path = ModManager.appPath + "ModManager6.exe";
            Process.Start(path);
            Environment.Exit(0);
        }
    }
}
