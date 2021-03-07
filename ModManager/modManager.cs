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
        public string appPath;
        public ModList modlist;
        public Config config;
        public PageList pagelist;
        public Utils utils;
        public TextureList textureList;

        public Release currentRelease;
        public Boolean isNewMods;
        public ModManager()
        {
            InitializeComponent();

            this.Size = new Size(980, 570);

            // Exit if Mod Manager already running
            if (System.Diagnostics.Process.GetProcessesByName("ModManager").Length > 1)
            {
                Environment.Exit(0);
            }

            this.serverURL = "https://mm.matux.fr";
            this.curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.utils = new Utils();

            // Create AppData if doesn't exist already
            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager");

            using (WebClient client = new WebClient())
            {
                string version = client.DownloadString(this.serverURL+"/version.txt");
                if (Version.Parse(version) > curVersion)
                {
                    if (MessageBox.Show("There is a new version of Mod Manager available, would you like to download it ?", "Mod Manager Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FileInfo installer = new FileInfo(this.appPath + "\\ModManagerInstaller.exe");
                        if (installer.Exists)
                        {
                            this.utils.FileDelete(this.appPath + "\\ModManagerInstaller.exe");
                        }
                        client.DownloadFile(this.serverURL + "/ModManagerInstaller.exe", this.appPath + "\\ModManagerInstaller.exe");
                        Process.Start(this.appPath + "\\ModManagerInstaller.exe");
                        Environment.Exit(0);
                    }
                }
            }

            this.config = new Config();
            this.config.load();
            this.textureList = new TextureList(this.serverURL + "/textures", this.appPath + "\\textures.json", this);
            

            this.modlist = new ModList(this.serverURL, this.appPath + "\\modlist.json", this);
            this.modlist.currentMod = this.modlist.mods.First();
            this.pagelist = new PageList(this);
            this.modlist.show();
            this.textureList.show();

            // Choose folder if needed
            if (this.config == null || this.config.amongUsPath == null)
            {
                this.pagelist.renderPage("PathSelection");
            }
            else
            {
                this.pagelist.renderPage("ModSelection");
            }

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

    }
}
