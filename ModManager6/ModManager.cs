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
            // Create folders if necessary

            FileSystem.DirectoryCreate(appDataPath);
            FileSystem.DirectoryCreate(appDataPath + @"\vanilla");
            FileSystem.DirectoryCreate(appDataPath + @"\mods");
            FileSystem.DirectoryCreate(appDataPath + @"\themes");
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

            // Check if shortcut or force restart
            if (args.Count() > 0)
            {
                if (args[0] == "force")
                {
                    args = new string[] { };
                }
                else
                {
                    silent = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
            }

            Downloader.load();

            Log.startTimer();
            token = await Downloader.downloadString(apiURL + "/github/token");
            Log.logTime("Initialisation", "ModManager");

            Log.startTimer();
            ConfigManager.load();
            Log.logTime("Config load", "ModManager");

            // If not silent, load theme
            if (args.Count() <= 0)
            {
                Log.startTimer();
                await Translator.load();
                Log.logTime("Translations load", "ModManager");

                Log.startTimer();
                ThemeList.load();
                Log.logTime("Themes load", "ModManager");

                Log.startTimer();
                ModManagerUI.load(this);
                Log.logTime("UI load (1/2)", "ModManager");

                this.MinimumSize = new System.Drawing.Size(1200, 480);
                int width = (int)((80 * Screen.PrimaryScreen.Bounds.Width) / 100);
                if (width < this.MinimumSize.Width)
                    width = this.MinimumSize.Width;
                int height = (int)((80 * Screen.PrimaryScreen.Bounds.Height) / 100);
                if (height < this.MinimumSize.Height)
                    height = this.MinimumSize.Height;
                this.Size = new Size(width, height);
                this.CenterToScreen();
            }

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

            Log.startTimer();
            ModManagerUI.StatusLabel.Text = Translator.get("Loading Among Us Servers...");
            ServerManager.load();
            Log.logTime("Servers load", "ModManager");

            ModWorker.load();

            if (args.Count() <= 0)
            {
                Log.startTimer();
                ContextMenu.init(this);
                ContextMenu.load();
                Log.logTime("Context menu load", "ModManager");
            }

            VersionUpdater.applyUpdates(ConfigManager.config.ModManagerVersion, visibleVersion);

            if (args.Count() > 0)
            {
                // TODO : shortcuts
            }

            Log.startTimer();
            ModManagerUI.StatusLabel.Text = Translator.get("Loading UI...");
            ModManagerUI.InitUI();
            ModManagerUI.InitListeners();
            ModManagerUI.hideMenuPanels();
            ModManagerUI.InitForm();
            Log.logTime("UI load (2/2)", "ModManager");

            ModManagerUI.LoadingLabel.Visible = false;
            ModManagerUI.StatusLabel.Text = "";

            Log.log("Ready", "ModManager");
        }
    }
}
