using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class Refresher
    {
        private static ModManager thisModManager;

        public static void load(ModManager modManager)
        {
            thisModManager = modManager;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerAsync();
        }

        public static async void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            while (true)
            {
                System.Threading.Thread.Sleep(5 * 60 * 1000); // Each 10 minute

                while (ModWorker.finished == false)
                {

                }

                ModWorker.finished = false;

                thisModManager.Invoke(new Action(async () => {
                    ModManagerUI.StatusLabel.Text = "Updating data, please wait...";
                    ModManager.silent = true;
                    ServerConfig.load();
                    //ConfigManager.load();
                    ModList.load();
                    await ModList.loadReleases();
                    DependencyList.load();
                    CategoryManager.load();

                    // News
                    int current = NewsList.current;
                    News currentNews = NewsList.getCurrent();
                    NewsList.load();
                    NewsList.current = current;
                    if (currentNews.id != NewsList.getCurrent().id)
                    {
                        NewsList.current = 0;
                    }

                    // Faq
                    current = FaqList.current;
                    Faq currentFaq = FaqList.getCurrent();
                    FaqList.load();
                    FaqList.current = current;
                    if (currentFaq.id != FaqList.getCurrent().id)
                    {
                        FaqList.current = 0;
                    }

                    ServerManager.load();
                    //ModWorker.load();
                    ContextMenu.load();
                    ModManagerUI.InitUI();
                    ModManagerUI.openForm(ModManagerUI.activeForm);
                    ModManager.silent = false;
                    ModManagerUI.StatusLabel.Text = "";
                }));

                ModWorker.finished = true;

            }
        }

        private static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Nothing
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Nothing
        }
    }
}
