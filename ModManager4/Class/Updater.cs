using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Updater
    {
        public ModManager modManager { get; set; }
        public Version latestVersion { get; set; }
        public Release latestRelease { get; set; }

        public BackgroundWorker backgroundWorker;
        public Updater(ModManager modManager)
        {
            this.modManager = modManager;
            this.latestVersion = null;
            this.latestRelease = null;
        }

        public async Task CheckRunUpdateOnStart()
        {
            this.modManager.logs.log("Updater : Started");
            await this.GetGithubVersion();

            if (this.latestVersion > this.modManager.version)
            {
                await this.updateMM();
            }
            this.modManager.logs.log("Updater : No update found");
        }

        public void StartUpdateChecker()
        {
            this.backgroundWorker = new BackgroundWorker();
            this.InitializeBackgroundWorker();
            this.backgroundWorker.RunWorkerAsync();
        }

        private void InitializeBackgroundWorker()
        {
            this.backgroundWorker.DoWork += new DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
        }

        public async void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            var backgroundWorker = sender as BackgroundWorker;

            while (this.latestVersion <= this.modManager.version)
            {
                System.Threading.Thread.Sleep(60 * 1000); // Each minute
                await this.GetGithubVersion();
            }

            string path = this.modManager.appPath + "ModManager4.exe";
            Process.Start(path, "force");
            Environment.Exit(0);

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Nothing
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Nothing
        }

        public async Task updateMM()
        {
            string installerPath = this.modManager.tempPath + "\\ModManagerInstaller.exe";
            this.modManager.logs.log("Updater : Update available");
            DialogResult userAction = MessageBox.Show("There is a new version of Mod Manager available. Mod Manager will auto update.\n\n" +
                "Press OK to continue.", "Mod Manager Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (userAction == DialogResult.OK)
            {
                this.modManager.utils.FileDelete(installerPath);
                foreach (ReleaseAsset ra in this.latestRelease.Assets)
                {
                    if (ra.Name == "ModManagerInstaller.exe")
                    {
                        try
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(ra.BrowserDownloadUrl, installerPath);
                            }
                        }
                        catch
                        {
                            this.modManager.logs.log("Error : Disconnected when checking update\n");
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
                        this.modManager.logs.log("- Launching installer");
                        Process.Start("explorer", installerPath);
                        Environment.Exit(0);
                    }
                }
            }
            Environment.Exit(0);
        }

        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        public async Task GetGithubVersion()
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(this.modManager.token);
            client.Credentials = tokenAuth;
            Release r = new Release() { };
            try
            {
                r = await client.Repository.Release.GetLatest("MatuxGG", "ModManager");
            }
            catch
            {
                this.modManager.logs.log("Error : Can't get Mod Manager release\n");
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
            
            this.latestRelease = r;
            this.latestVersion = Version.Parse(r.TagName);
        }
    }
}
