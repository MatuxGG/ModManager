using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Refresher
    {
        public ModManager modManager;

        public BackgroundWorker backgroundWorker;

        public Refresher(ModManager modManager)
        {
            this.modManager = modManager;
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

            while (true)
            {
                System.Threading.Thread.Sleep(60 * 60 * 1000); // Each 60 minute

                while (this.modManager.actionLock == true)
                {

                }

                this.modManager.actionLock = true;

                this.modManager.Invoke(new Action(async () => {

                    // Save current page
                    string currentPage = this.modManager.pagelist.currentPage;

                    // Save current toInstall & toUninstall
                    List<string> toInstall = this.modManager.modlist.toInstall;
                    List<string> toUninstall = this.modManager.modlist.toUninstall;

                    // Save current remote version
                    string version = this.modManager.serverConfig.get("gameVersion").value;

                    // Refresh config
                    this.modManager.refreshConfig();

                    // Check if server got disabled
                    if (this.modManager.serverConfig.get("enabled").value == "false")
                    {
                        string path = this.modManager.appPath + "ModManager4.exe";
                        Process.Start(path, "force");
                        Environment.Exit(0);
                    }

                    // Check if version is different
                    if (version != this.modManager.serverConfig.get("gameVersion").value)
                    {
                        string path = this.modManager.appPath + "ModManager4.exe";
                        Process.Start(path, "force");
                        Environment.Exit(0);
                    }

                    // Refresh categories
                    this.modManager.refreshCategories();

                    // Refresh modlist
                    await this.modManager.refreshMods(true);

                    //Restore toInstall & toUninstall
                    this.modManager.modlist.toInstall = toInstall;
                    this.modManager.modlist.toUninstall = toUninstall;

                    // Refresh news
                    this.modManager.refreshNews();

                    // Refresh faq
                    this.modManager.refreshFaq();

                    // Refresh serverlist
                    this.modManager.refreshServers();

                    this.modManager.componentlist = new Componentlist(this.modManager);
                    this.modManager.refreshPages();

                    if (this.modManager.config.amongUsPath != null)
                    {
                        this.modManager.pagelist.renderPage(currentPage);
                    }
                    else
                    {
                        this.modManager.pagelist.renderPage("FirstPathSelection");
                    }

                }));

                this.modManager.actionLock = false;

            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Nothing
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Nothing
        }
    }
}
