using Microsoft.Win32;
using ModManager4.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4
{
    public partial class ModManager : Form
    {
        public string serverURL;
        public string apiURL;
        public string appPath;
        public string appDataPath;
        public string tempPath;
        public Version version;
        public string token;

        public Utils utils;
        public Logger logs;
        public Updater updater;
        public ModWorker modWorker;

        public ServerConfig serverConfig;
        public Modlist modlist;
        public Newslist newslist;
        public Faqlist faqlist;
        public Categorylist categorylist;
        public Config config;
        public Componentlist componentlist;
        public Pagelist pagelist;
        public Serverlist serverlist;

        public ModManager(string[] args)
        {

            InitializeComponent();

            this.CenterToScreen();

            _ = this.Start(args);
        }

        public async Task Start(string[] args)
        {
            // Constants declaration
            this.serverURL = "https://mm.matux.fr/";
            this.apiURL = "https://api.matux.fr/";
            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            this.appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager";
            this.tempPath = Path.GetTempPath() + "ModManager";
            this.version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.token = System.IO.File.ReadAllText(this.appPath + "\\token.txt");

            // Create AppData folder if necessary
            Directory.CreateDirectory(this.appDataPath);
            Directory.CreateDirectory(this.appDataPath + "\\localMods");
            Directory.CreateDirectory(this.appDataPath + "\\allInOneMods");
            Directory.CreateDirectory(this.appDataPath + "\\modsData");
            //Create Temp folder if necessary
            Directory.CreateDirectory(this.tempPath);

            // Tools
            this.logs = new Logger();
            this.utils = new Utils();
            this.modWorker = new ModWorker(this);

            this.logs.log("Mod Manager loading\n");
            this.logs.log("- Version " + this.version.ToString().Remove(this.version.ToString().Length - 2));

            if (System.Diagnostics.Process.GetProcessesByName("ModManager4").Length > 1)
            {
                this.logs.log("Error : Mod Manager already running\n");
                MessageBox.Show("Mod Manager is already running.", "Mod Manager already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            //Check update
            this.updater = new Updater(this);
            await this.updater.checkUpdate();

            // Load remote config
            this.serverConfig = new ServerConfig(this);
            this.logs.log("Loading server config");
            this.serverConfig.load();
            this.logs.log("- Server config loaded successfully");

            // Load local config or create one (find AU folder if possible)
            this.config = new Config();
            this.logs.log("Loading config (1/2)");
            this.config.load(this);
            this.logs.log("- Config loaded successfully\n");

            if (args.Count() == 0)
            {
                this.Size = new Size(this.config.resolutionX, 30 + this.config.resolutionY);
                this.CenterToScreen();
                this.Show();

                double ratioX = (double)this.config.resolutionX / 2560.0;
                double ratioY = (double)this.config.resolutionY / 1600.0;
                this.InitProgressBar.Location = new System.Drawing.Point((int)(970 * ratioX), (int)(1140 * ratioY));
                this.InitProgressBar.Size = new System.Drawing.Size((int)(600 * ratioX), (int)(50 * ratioY));
            }

            if (args.Count() > 0)
            {
                this.modWorker.changeUI = false;
                ProgressBar progress = (ProgressBar)this.Controls["InitProgressBar"];
                progress.Visible = false;
            }

            // Load News from server
            this.newslist = new Newslist(this);
            this.newslist.load();

            // Load Faq from server
            this.faqlist = new Faqlist(this);
            this.faqlist.load();

            // Load categories from server
            this.categorylist = new Categorylist(this);
            this.categorylist.load();

            // Load mods from server
            this.modlist = new Modlist(this);
            this.modlist.load();
            await this.modlist.loadReleases();
            this.logs.log(this.modlist.toString());

            // Load local config or create one (find AU folder if possible)
            this.logs.log("Loading config (2/2)");
            this.config.check(this);
            this.logs.log(this.config.toString());

            this.componentlist = new Componentlist(this);

            if (args.Count() > 0)
            {
                List<string> modsToInstall = new List<string>() { };
                foreach (string arg in args)
                {
                    if (this.modlist.getAvailableModById(arg) != null && modsToInstall.Contains(arg) == false)
                    {
                        modsToInstall.Add(arg);
                    }
                }
                string code = this.modlist.getCodeFromList(modsToInstall);
                string configCode = this.modlist.getCode();
                if (code != configCode)
                {
                    this.modWorker.startAfterUpdate = true;
                    this.modWorker.installFromCode(code);
                } else
                {
                    this.componentlist.events.startGame();
                    Environment.Exit(0);
                }
                return;
            }

            this.serverlist = new Serverlist();
            this.serverlist.load(this);
            this.logs.log(this.serverlist.toString());

            // Load pages
            this.componentlist.load();
            this.logs.log(this.componentlist.toString());

            this.pagelist = new Pagelist(this);
            this.pagelist.load();
            this.logs.log(this.pagelist.toString());

            this.modlist.setCode();

            this.BackgroundImage = global::ModManager4.Properties.Resources.titlefond;

            this.Size = new Size(this.config.resolutionX, 30 + this.config.resolutionY);
            this.CenterToScreen();

            this.logs.log("Mod Manager loaded successfully\n");

            if (serverConfig.get("enabled").value == "false")
            {
                this.pagelist.renderPage("Disabled");
                return;
            }

            if (this.config.amongUsPath != null)
            {
                this.pagelist.renderPage("ModSelection");
            } else
            {
                this.pagelist.renderPage("FirstPathSelection");
            }
        }

        public void centerToScreenPub()
        {
            this.CenterToScreen();
        }

    }
}
