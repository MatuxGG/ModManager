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

        public static Boolean silent;

        public ModManager(string[] args)
        {
            InitializeComponent();
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

            Download.load(this);

            token = await Download.downloadString(apiURL + "/github/token");

            Log.log("ConfigManager component", "ModManager");
            ConfigManager.load();

            // If not silent, load theme
            if (args.Count() <= 0)
            {
                Log.log("Translator component", "ModManager");
                await Translator.load();

                Log.log("ThemeList component", "ModManager");
                ThemeList.load();

                Log.log("UI component", "ModManager");
                ModManagerUI.load(this);

                int width = (int)((80 * Screen.PrimaryScreen.Bounds.Width) / 100);
                if (width < this.MinimumSize.Width)
                    width = this.MinimumSize.Width;
                int height = (int)((80 * Screen.PrimaryScreen.Bounds.Height) / 100);
                if (height < this.MinimumSize.Height)
                    height = this.MinimumSize.Height;
                this.Size = new Size(width, height);
                this.CenterToScreen();
            }

            // Load Github Client
            githubClient = new GitHubClient(new ProductHeaderValue("ModManager"));
            githubClient.Credentials = new Credentials(ModManager.token);

            Log.log("Updater component", "ModManager");
            await Updater.CheckRunUpdateOnStart();

            ConfigManager.updateAmongUs();

        }
    }
}
