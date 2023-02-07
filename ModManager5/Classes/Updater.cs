using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace ModManager5.Classes
{
    public static class Updater
    {
        public static Version latestVersion = null;
        public static Release latestRelease = null;
        public static BackgroundWorker backgroundWorker;
        public static async Task CheckRunUpdateOnStart()
        {
            await GetGithubVersion();

            if (latestVersion > ModManager.version)
            {
                await updateMM();
            }
        }
        public static void StartUpdateChecker()
        {
            backgroundWorker = new BackgroundWorker();
            InitializeBackgroundWorker();
            backgroundWorker.RunWorkerAsync();
        }

        private static void InitializeBackgroundWorker()
        {
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
        }

        public static async void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            var backgroundWorker = sender as BackgroundWorker;

            while (latestVersion <= ModManager.version)
            {
                System.Threading.Thread.Sleep(60 * 60 * 1000); // Each 60 minute
                await GetGithubVersion();
            }

            string path = ModManager.appPath + "ModManager5.exe";
            Process.Start(path, "force");
            Environment.Exit(0);

        }

        private static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Nothing
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Nothing
        }

        public static async Task updateMM()
        {
            Utils.log("Update START", "Updater");
            string installerPath = ModManager.tempPath + @"\ModManagerInstaller.exe";
            DialogResult userAction = MessageBox.Show("There is a new version of Mod Manager available. Mod Manager will auto update.\n\n" +
                "Press OK to continue.", "Mod Manager Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (userAction == DialogResult.OK)
            {
                Utils.log("Update accepted", "Updater");
                Utils.FileDelete(installerPath);
                foreach (ReleaseAsset ra in latestRelease.Assets)
                {
                    if (ra.Name == "ModManagerInstaller.exe")
                    {
                        try
                        {
                            using (WebClient client = Utils.getClient())
                            {
                                client.DownloadFile(ra.BrowserDownloadUrl, installerPath);
                            }
                        }
                        catch (Exception e)
                        {
                            Utils.logE("Update connection FAIL", "Updater");
                            Utils.logEx(e, "Updater");
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
                        Process.Start("explorer", installerPath);
                        Utils.log("Update DONE", "Updater");
                        Environment.Exit(0);
                    }
                }
            }
            Environment.Exit(0);
        }

        public static async Task GetGithubVersion()
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(ModManager.token);
            client.Credentials = tokenAuth;
            Release r = new Release() { };
            try
            {
                r = await client.Repository.Release.GetLatest("MatuxGG", "ModManager");
            }
            catch (Exception e)
            {
                Utils.logE("Github connection FAIL", "Updater");
                Utils.logEx(e, "Updater");
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

            latestRelease = r;
            latestVersion = Version.Parse(r.TagName);
        }
    }
}
