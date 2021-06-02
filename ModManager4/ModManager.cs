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
        public Toollist toollist;
        public Config config;
        public Componentlist componentlist;
        public Pagelist pagelist;
        public Serverlist serverlist;

        public ModManager()
        {
            InitializeComponent();

            this.CenterToScreen();

            _ = this.Start();
        }

        public async Task Start()
        {
            // Constants declaration
            this.serverURL = "https://mm.matux.fr/mm4/";
            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            this.appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager";
            this.tempPath = Path.GetTempPath() + "\\ModManager";
            this.version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.token = System.IO.File.ReadAllText(this.appPath + "\\token.txt");

            // Create AppData folder if necessary
            Directory.CreateDirectory(this.appDataPath);
            Directory.CreateDirectory(this.appDataPath + "\\localMods");
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

            //Get Server Config
            this.logs.log("ServerConfig");
            string config = "";

            try
            {
                using (var client = new WebClient())
                {
                    config = client.DownloadString(this.serverURL + "/serverConfig.json");
                }
            }
            catch
            {
                this.logs.log("Error : Disconnected when loading Server config\n");
                MessageBox.Show("Mod Manager's server is unreacheable.\n" +
                "\n" +
                "There are many possible reasons for this :\n" +
                "- You are disconnected from internet\n" +
                "- Your antivirus blocks Mod Manager\n" +
                "- Mod Manager server is down. Check its status on matux.fr\n" +
                "\n" +
                "If this problem persists, please send a ticket on Mod Manager's discord.", "Server unreacheable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            this.serverConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerConfig>(config);

            // Load local config or create one (find AU folder if possible)
            this.config = new Config();
            this.logs.log("Loading config (1/2)");
            this.config.load(this);
            this.logs.log("- Config loaded successfully\n");

            this.Size = new Size(this.config.resolutionX, this.config.resolutionY);
            this.CenterToScreen();
            this.Show();

            double ratioX = (double)this.config.resolutionX / 1300.0;
            double ratioY = (double)this.config.resolutionY / 810.0;
            this.InitProgressBar.Location = new System.Drawing.Point((int)(484 * ratioX), (int)(569 * ratioY));
            this.InitProgressBar.Size = new System.Drawing.Size((int)(313 * ratioX), (int)(23 * ratioY));

            // Load mods from server
            this.modlist = new Modlist(this);
            await this.modlist.load();
            this.logs.log(this.modlist.toString());

            //Load tools from server
            this.toollist = new Toollist(this);
            this.toollist.load();
            this.logs.log(this.toollist.toString());

            // Load local config or create one (find AU folder if possible)
            this.logs.log("Loading config (2/2)");
            this.config.check(this);
            this.logs.log(this.config.toString());
            this.serverlist = new Serverlist();
            this.serverlist.load(this);
            this.logs.log(this.serverlist.toString());

            // Load pages
            this.componentlist = new Componentlist(this);
            this.componentlist.load();
            this.logs.log(this.componentlist.toString());

            this.pagelist = new Pagelist(this);
            this.pagelist.load();
            this.logs.log(this.pagelist.toString());

            this.modlist.setCode();

            this.BackgroundImage = global::ModManager4.Properties.Resources.titlefond;

            this.Size = new Size(this.config.resolutionX, this.config.resolutionY);
            this.CenterToScreen();

            this.logs.log("Mod Manager loaded successfully\n");

            if (serverConfig.enabled == false)
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
