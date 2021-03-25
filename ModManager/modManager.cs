using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.IO.Compression;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Octokit;
using System.Web.Security;

namespace ModManager
{

    public partial class ModManager : Form
    {
        public string serverURL;
        public Version curVersion;
        public Version lastVersion;
        public string appPath;
        public ModList modlist;
        public Config config;
        public PageList pagelist;
        public Utils utils;
        public TextureList textureList;
        public ServerList serverList;
        public ServerConfig serverConfig;

        public Release currentRelease;
        public Release latestRelease;
        public bool isNewMods;
        public bool firstStart;
        public string token;
        public ModManager()
        {
            InitializeComponent();

            this.firstStart = true;

            this.Size = new Size(1300, 700);

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager");
            string tempPath = Path.GetTempPath() + "\\ModManager";
            Directory.CreateDirectory(tempPath);

            this.log("\nMod Manager starts");

            // Exit if Mod Manager already running
            if (System.Diagnostics.Process.GetProcessesByName("ModManager").Length > 1)
            {
                this.log("Mod Manager already running");
                MessageBox.Show("Mod Manager is already running", "Mod Manager running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            this.updateStatus("");

            this.serverURL = "https://mm.matux.fr";
            this.curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.utils = new Utils();

            string serverConfigPath = tempPath + "\\serverConfig.json";
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(this.serverURL+"/serverConfig.json", serverConfigPath);
                }
            }
            catch
            {
                this.log("Load ServerConfig > Server unreachable");
                MessageBox.Show("Can't reach Mod Manager server.\nPlease verify your internet connection and try again !", "Mod Manager server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            string json = System.IO.File.ReadAllText(serverConfigPath);
            this.serverConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerConfig>(json);
            File.Delete(serverConfigPath);

            if (serverConfig.enabled == false)
            {
                this.log("Mod Manager disabled");
                MessageBox.Show("Mod Manager has been disabled.\n\n" +
                    "This is most-likely related to an Among Us update. Mod Manager will be back again soon !\n\n" +
                    "Please, consider joining the discord (link on github) to get notified when it goes live again.\n\n" +
                    "Thanks for your patience !", "Mod Manager has been disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;

            this.token = System.IO.File.ReadAllText(this.appPath + "\\token.txt");

            this.checkNewVersion();

            this.config = new Config();
            this.config.load();
            //this.textureList = new TextureList(this.serverURL + "/textures", this.appPath + "\\textures.json", this);

            this.log("Config loaded : \n" + this.config.log()); 

            this.modlist = new ModList(this.serverURL, this.appPath + "\\modlist.json", this);
            this.modlist.currentMod = this.modlist.mods.First();
            this.pagelist = new PageList(this);
            this.modlist.show();
            //this.textureList.show();

            //this.serverList = new ServerList(this);
            //this.serverList.update();

            // Choose folder if needed
            if (this.config == null || this.config.amongUsPath == null)
            {
                this.pagelist.renderPage("PathSelection");
            }
            else
            {
                this.firstStart = false;
                this.pagelist.renderPage("ModSelection");
            }


        }

        public async void checkNewVersion()
        {
            this.log("Check new release");
            await this.checkNewVersionWorker();
        }

        public async Task checkNewVersionWorker()
        {
            await this.GetGithubVersion();

            if (this.lastVersion > curVersion)
            {
                if (MessageBox.Show("There is a new version of Mod Manager available, would you like to download it ?", "Mod Manager Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.log("New release found > install");
                    this.utils.FileDelete(this.appPath + "\\ModManagerInstaller.exe");
                    foreach (ReleaseAsset ra in this.latestRelease.Assets)
                    {
                        if (ra.Name == "ModManagerInstaller.exe")
                        {
                            try
                            {
                                using (WebClient client = new WebClient())
                                {
                                    client.DownloadFile(ra.BrowserDownloadUrl, this.appPath + "\\ModManagerInstaller.exe");
                                }
                            }
                            catch
                            {
                                this.log("Update Mod Manager > Server unreachable");
                                MessageBox.Show("Can't reach Mod Manager server.\nPlease verify your internet connection and try again !", "Mod Manager server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Environment.Exit(0);
                            }
                            Process.Start(this.appPath + "\\ModManagerInstaller.exe");
                            Environment.Exit(0);
                        }
                    }
                }
                else
                {
                    this.log("New release found > no install");
                }
            }
        }

        public async Task GetGithubVersion()
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(this.token);
            client.Credentials = tokenAuth;
            this.lastVersion = null;
            Release r = await client.Repository.Release.GetLatest("MatuxGG", "ModManager");
            this.latestRelease = r;
            this.lastVersion = Version.Parse(r.TagName);
        }

        public void chooseAmongUsDirectory(object sender, EventArgs e)
        {
            if (this.config != null && this.config.amongUsPath != null)
            {
                this.AmongUsSelectionPopup.SelectedPath = this.config.amongUsPath;
            }
            if (this.AmongUsSelectionPopup.ShowDialog() == DialogResult.OK)
            {
                FileInfo amongUsFile = new FileInfo(AmongUsSelectionPopup.SelectedPath + "\\Among Us.exe");
                if (amongUsFile.Exists)
                {
                    this.config = new Config(AmongUsSelectionPopup.SelectedPath, new List<InstalledMod>(), new List<string>(), "None");
                    this.config.update();

                    this.pagelist.renderPage("ModSelection");
                }
            }
        }

        // Utils
        public void debug(string s)
        {
            MessageBox.Show(s, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void log(string line)
        {
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\log.txt", line + Environment.NewLine);
        }

        public void updateStatus(string content)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Name == "Status")
                {
                    c.Text = content;
                }
            }
        }

    }
}
