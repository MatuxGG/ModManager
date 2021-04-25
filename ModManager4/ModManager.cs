﻿using Microsoft.Win32;
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

        public ModManager()
        {
            InitializeComponent();

            this.Size = new Size(1300, 810);

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

            if (System.Diagnostics.Process.GetProcessesByName("ModManager4").Length > 1)
            {
                this.logs.log("Error : Mod Manager already running\n");
                MessageBox.Show("Mod Manager is already running.", "Mod Manager already opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

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

            //Check update
            this.updater = new Updater(this);
            await this.updater.checkUpdate();

            // Load mods from server
            this.modlist = new Modlist(this);
            await this.modlist.load();
            this.logs.log(this.modlist.toString());

            //Load tools from server
            this.toollist = new Toollist(this);
            this.toollist.load();
            this.logs.log(this.toollist.toString());

            // Load local config or create one (find AU folder if possible)
            this.config = new Config();
            this.config.setPath(this.appDataPath);
            this.config.load();
            this.config.check(this);
            this.logs.log(this.config.toString());

            // Load pages
            this.componentlist = new Componentlist(this);
            this.componentlist.load();
            this.logs.log(this.componentlist.toString());

            this.pagelist = new Pagelist(this);
            this.pagelist.load();
            this.logs.log(this.pagelist.toString());

            this.modlist.setCode();

            this.BackgroundImage = global::ModManager4.Properties.Resources.titlefond;

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


    }
}