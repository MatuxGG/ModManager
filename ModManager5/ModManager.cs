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
using ModManager5.Forms;
using ModManager5.Classes;
using Microsoft.Win32;

namespace ModManager5
{
    public partial class ModManager : Form
    {
        public static string serverURL = "https://goodloss.fr";
        public static string apiURL = "https://goodloss.fr/api";
        public static string fileURL = "https://goodloss.fr/files";
        public static string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ModManager";
        public static string tempPath = Path.GetTempPath() + "ModManager";
        public static Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public static string visibleVersion = version.ToString().Substring(0, version.ToString().Length - 2);
        public static string token = System.IO.File.ReadAllText(appPath + @"\token.txt");

        public static Boolean silent;

        public ModManager(string[] args)
        {
            InitializeComponent();
            _ = this.Start(args);
        }

        public async Task Start(string[] args)
        {
            // Create folders if necessary
            
            Utils.DirectoryCreate(appDataPath);
            Utils.DirectoryCreate(appDataPath + @"\vanilla");
            Utils.DirectoryCreate(appDataPath + @"\mods");
            Utils.DirectoryCreate(appDataPath + @"\localMods");
            Utils.DirectoryCreate(appDataPath + @"\themes");
            Utils.DirectoryCreate(appDataPath + @"\icons");
            Utils.DirectoryCreate(tempPath);
            

            Utils.CleanLogs();

            Utils.logNewLine();
            Utils.log("ModManager Started", "ModManager");

            // Disable multiple MM run
            if (System.Diagnostics.Process.GetProcessesByName("ModManager5").Length > 1 && (args.Count() == 0 || args[0] != "force"))
            {
                if (args.Count() == 0)
                {
                    Utils.logE("Mod Manager already running", "ModManager");
                    MessageBox.Show("Mod Manager is already running.", "Mod Manager already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }

            // Check if shortcut or force restart
            if (args.Count() > 0)
            {
                if (args[0] == "force")
                {
                    Utils.log("Restart detected", "ModManager");
                    args = new string[] { };
                } else
                {
                    Utils.log("Silent mode detected", "ModManager");
                    silent = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
            }

            Utils.log("Loading global config", "ModManager");
            ConfigManager.loadGlobalConfig();
            ConfigManager.logGlobalConfig();

            // If not silent, load theme
            if (args.Count() <= 0) 
            {
                silent = false;
                Utils.log("Loading themes", "ModManager");
                ThemeList.load();
                Utils.log("Loading translations", "ModManager");
                Translator.load();
                Utils.log("Loading ModManager UI (1/2)", "ModManager");
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

            // Check update
            Utils.log("Looking for updates updates", "ModManager");
            await Updater.CheckRunUpdateOnStart();

            // Init classes
            Utils.log("Loading server config", "ModManager");
            ServerConfig.load();
            Utils.log("Loading config", "ModManager");
            ConfigManager.load();
            ConfigManager.logConfig();

            Utils.log("Loading mods", "ModManager");
            ModList.load();
            Utils.log("Loading local mods", "ModManager");
            ModList.loadLocalMods();
            Utils.log("Loading releases", "ModManager");
            await ModList.loadReleases();
            Utils.log("Loading dependencies", "ModManager");
            DependencyList.load();
            Utils.log("Loading categories", "ModManager");
            CategoryManager.load();
            if (args.Count() <= 0)
            {
                Utils.log("Loading servers", "ModManager");
                ServerManager.load();
            }

            Utils.log("Loading downloader", "ModManager");
            DownloadWorker.load(this);
            Utils.log("Loading installer", "ModManager");
            ModWorker.load();

            if (args.Count() <= 0)
            {
                Utils.log("Loading context menu", "ModManager");
                ContextMenu.init(this);
                ContextMenu.load();

                if (ConfigManager.globalConfig.startTime == 0)
                {
                    // First Use
                    ModList.createShortcut(ModList.getModById("Challenger"));
                    ModList.createShortcut(ModList.getModById("BetterCrewlink"));
                }
                ConfigManager.globalConfig.startTime++;
                ConfigManager.updateGlobalConfig();
            }

            if (args.Count() > 0)
            {
                Utils.log("Starting mod from a shortcut", "ModManager");
                InstalledMod im = ConfigManager.getInstalledModById(args[0]);
                Mod m = ModList.getModById(args[0]);
                Utils.log("Mod detected : " + m.name, "ModManager");

                if (m.id == "BetterCrewlink" && im == null)
                {
                    if (ConfigManager.isBetterCrewlinkInstalled())
                    {
                        InstalledMod bcl = new InstalledMod(m.id, "", "");
                        ConfigManager.config.installedMods.RemoveAll(im => im.id == m.id);
                        ConfigManager.config.installedMods.Add(bcl);
                        ConfigManager.update();
                        im = ConfigManager.getInstalledModById(m.id);
                    }
                }

                // If needs update or install
                if (im == null || (((m.type != "allInOne" || m.id == "Challenger") && im.version != m.release.TagName) || (m.type != "allInOne" && im.gameVersion != m.gameVersion)))
                {
                    Utils.log("Update needed", "ModManager");
                    Utils.log("Updating mod", "ModManager");
                    ModWorker.installAnyMod(m);

                    while (ModWorker.finished == false)
                    {
                        
                    }
                }
                Utils.log("Starting mod", "ModManager");
                ModWorker.startMod(m);

                Environment.Exit(0);
            }

            Utils.log("Loading Mod Manager UI (2/2)", "ModManager");
            ModManagerUI.StatusLabel.Text = Translator.get("Loading UI...");

            ModManagerUI.InitUI();

            Utils.log("Loading listeners", "ModManager");
            ModManagerUI.InitListeners();

            ModManagerUI.hideMenuPanels();

            ModManagerUI.InitForm();

            Utils.log("Loading data refresher", "ModManager");
            Refresher.load(this);

            Utils.log("Mod Manager ready", "ModManager");
            ModManagerUI.LoadingLabel.Visible = false;
            ModManagerUI.StatusLabel.Text = "";
        }
    }
}
