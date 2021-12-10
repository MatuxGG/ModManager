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
            Directory.CreateDirectory(appDataPath + @"\localMods");
            Directory.CreateDirectory(appDataPath + @"\vanilla");
            Directory.CreateDirectory(appDataPath + @"\mods");
            Directory.CreateDirectory(appDataPath + @"\themes");
            Directory.CreateDirectory(appDataPath + @"\icons");
            Directory.CreateDirectory(tempPath);

            Utils.CleanLogs();

            // Disable multiple MM run
            if (System.Diagnostics.Process.GetProcessesByName("ModManager5").Length > 1 && args[0] != "force")
            {
                if (args.Count() == 0)
                {
                    MessageBox.Show("Mod Manager is already running.", "Mod Manager already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }


            if (args.Count() > 0)
            {
                if (args[0] == "force")
                {
                    args = new string[] { };
                } else
                {
                    silent = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
            }
            if (args.Count() <= 0) 
            {
                silent = false;
                ThemeList.load();
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
            await Updater.CheckRunUpdateOnStart();

            // Init classes
            ServerConfig.load();
            ConfigManager.load();

            ModList.load();
            await ModList.loadReleases();
            DependencyList.load();
            CategoryManager.load();
            if (args.Count() <= 0)
            {
                NewsList.load();
                FaqList.load();
                ServerManager.load();
            }
            ModWorker.load();

            if (args.Count() <= 0)
            {
                ContextMenu.init(this);
                ContextMenu.load();
            }

            if (args.Count() > 0)
            {
                InstalledMod im = ConfigManager.getInstalledModById(args[0]);
                Mod m = ModList.getModById(args[0]);
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
                    ModWorker.installAnyMod(m);

                    while (ModWorker.finished == false)
                    {
                        
                    }
                }

                ModWorker.startMod(m);

                Environment.Exit(0);
            }

            ModManagerUI.StatusLabel.Text = "Connecting...";
            MatuxAPI.CheckLogin();

            ModManagerUI.StatusLabel.Text = "Loading UI...";

            ModManagerUI.InitUI();
            ModManagerUI.InitListeners();

            ModManagerUI.hideMenuPanels();

            ModManagerUI.InitForm();

            Refresher.load(this);

            ModManagerUI.LoadingLabel.Visible = false;
            ModManagerUI.StatusLabel.Text = "";
        }

    }
}
