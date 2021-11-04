using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                System.Threading.Thread.Sleep(20 * 1000); // Each minute

                while (this.modManager.actionLock == true)
                {

                }

                this.modManager.actionLock = true;

                // Save current page
                string currentPage = this.modManager.pagelist.currentPage;

                // Refresh config
                this.modManager.refreshConfig();

                // Refresh categories
                this.modManager.refreshCategories();

                // Refresh modlist
                await this.modManager.refreshMods(true);

                // Refresh news
                this.modManager.refreshNews();

                // Refresh faq
                this.modManager.refreshFaq();

                // Refresh serverlist
                this.modManager.refreshServers();

                this.modManager.Invoke(new Action(() => {

                    this.modManager.componentlist = new Componentlist(this.modManager);
                    this.modManager.refreshPages();

                    if (this.modManager.serverConfig.get("enabled").value == "false")
                    {
                        this.modManager.pagelist.renderPage("Disabled");
                    }

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
