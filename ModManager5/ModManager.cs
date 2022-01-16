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
        public static string serverURL = "https://mm.matux.fr/";
        public static string apiURL = "https://api.matux.fr/";
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
            Directory.CreateDirectory(appDataPath);
            Directory.CreateDirectory(appDataPath + @"\vanilla");
            Directory.CreateDirectory(appDataPath + @"\mods");
            Directory.CreateDirectory(appDataPath + @"\localMods");
            Directory.CreateDirectory(appDataPath + @"\themes");
            Directory.CreateDirectory(appDataPath + @"\icons");
            Directory.CreateDirectory(tempPath);

            Utils.CleanLogs();

            Utils.log("\nMod Manager Started");

            // Disable multiple MM run
            if (System.Diagnostics.Process.GetProcessesByName("ModManager5").Length > 1 && (args.Count() == 0 || args[0] != "force"))
            {
                if (args.Count() == 0)
                {
                    Utils.logE("Mod Manager already running");
                    MessageBox.Show("Mod Manager is already running.", "Mod Manager already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }

            // Check if shortcut or force restart
            if (args.Count() > 0)
            {
                if (args[0] == "force")
                {
                    Utils.log("Restart detected");
                    args = new string[] { };
                } else
                {
                    Utils.log("Silent mode detected");
                    silent = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
            }

            Utils.log("Loading global config");
            ConfigManager.loadGlobalConfig();
            ConfigManager.logConfig();

            // If not silent, load theme
            if (args.Count() <= 0) 
            {
                silent = false;
                Utils.log("Loading themes");
                ThemeList.load();
                Utils.log("Loading translations");
                Translator.load();
                Utils.log("Loading Mod Manager UI (1/2)");
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
            Utils.log("Looking for updates updates");
            await Updater.CheckRunUpdateOnStart();

            // Init classes
            Utils.log("Loading server config");
            ServerConfig.load();
            Utils.log("Loading config");
            ConfigManager.load();

            Utils.log("Loading mods");
            ModList.load();
            Utils.log("Loading local mods");
            ModList.loadLocalMods();
            Utils.log("Loading releases");
            await ModList.loadReleases();
            Utils.log("Loading dependencies");
            DependencyList.load();
            Utils.log("Loading categories");
            CategoryManager.load();
            if (args.Count() <= 0)
            {
                Utils.log("Loading news");
                NewsList.load();
                Utils.log("Loading FAQ");
                FaqList.load();
                Utils.log("Loading servers");
                ServerManager.load();
            }
            Utils.log("Loading installer");
            ModWorker.load();

            if (args.Count() <= 0)
            {
                Utils.log("Loading context menu");
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
                Utils.log("Starting mod from a shortcut");
                InstalledMod im = ConfigManager.getInstalledModById(args[0]);
                Mod m = ModList.getModById(args[0]);
                Utils.log("Mod detected : " + m.name);

                if (m.id == "BetterCrewlink" && im == null)
                {
                    object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);

                    if (o != null && System.IO.File.Exists(o.ToString() + @"\Better-CrewLink.exe"))
                    {
                        InstalledMod bcl = new InstalledMod(m.id, "", "");
                        ConfigManager.config.installedMods.Add(bcl);
                        ConfigManager.update();
                        im = ConfigManager.getInstalledModById(m.id);
                    }
                }

                // If needs update or install
                if (im == null || (((m.type != "allInOne" || m.id == "Challenger") && im.version != m.release.TagName) || (m.type != "allInOne" && im.gameVersion != m.gameVersion)))
                {
                    Utils.log("Update needed");
                    Utils.log("Updating mod");
                    ModWorker.installAnyMod(m);

                    while (ModWorker.finished == false)
                    {
                        
                    }
                }
                Utils.log("Starting mod");
                ModWorker.startMod(m);

                Environment.Exit(0);
            }

            Utils.log("Connecting to matux.fr");
            ModManagerUI.StatusLabel.Text = "Connecting...";
            MatuxAPI.CheckLogin();
            MatuxAPI.currentLg = ConfigManager.globalConfig.lg; // Configuration one day

            Utils.log("Loading Mod Manager UI (2/2)");
            ModManagerUI.StatusLabel.Text = "Loading UI...";

            ModManagerUI.InitUI();

            Utils.log("Loading listeners");
            ModManagerUI.InitListeners();

            ModManagerUI.hideMenuPanels();

            ModManagerUI.InitForm();

            Utils.log("Loading data refresher");
            Refresher.load(this);

            ModManagerUI.LoadingLabel.Visible = false;
            ModManagerUI.StatusLabel.Text = "";
        }

    }
}
