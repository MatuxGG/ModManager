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
                System.Threading.Thread.Sleep(10 * 60 * 1000); // Each 10 minutes

                ModWorker.startTransaction();

                Utils.log("[Refresher] Starting data refresh");

                Action a = new Action(async () =>
                {
                    ModManagerUI.StatusLabel.Text = "Updating data, please wait...";
                    Utils.log("[Refresher] Loading global config");
                    ConfigManager.loadGlobalConfig();
                    ModManager.silent = true;
                    Utils.log("[Refresher] Loading server config");
                    ServerConfig.load();
                    //ConfigManager.load();

                    Utils.log("[Refresher] Loading translations");
                    Translator.load();
                    Utils.log("[Refresher] Loading mods");
                    ModList.load();
                    Utils.log("[Refresher] Loading local mods");
                    ModList.loadLocalMods();
                    Utils.log("[Refresher] Loading releases");
                    await ModList.loadReleases();
                    Utils.log("[Refresher] Loading dependencies");
                    DependencyList.load();
                    Utils.log("[Refresher] Loading categories");
                    CategoryManager.load();

                    // News
                    Utils.log("[Refresher] Loading news");
                    int current = NewsList.current;
                    News currentNews = NewsList.getCurrent();
                    NewsList.load();
                    NewsList.current = current;
                    if (currentNews.id != NewsList.getCurrent().id)
                    {
                        NewsList.current = 0;
                    }
                    // Faq
                    Utils.log("[Refresher] Loading faq");
                    current = FaqList.current;
                    Faq currentFaq = FaqList.getCurrent();
                    FaqList.load();
                    FaqList.current = current;
                    if (currentFaq.id != FaqList.getCurrent().id)
                    {
                        FaqList.current = 0;
                    }

                    Utils.log("[Refresher] Loading servers");
                    ServerManager.load();
                    //ModWorker.load();
                    Utils.log("[Refresher] Loading context menu");

                    ContextMenu.load();
                    Utils.log("[Refresher] Loading Mod Manager UI");
                    ModManagerUI.InitUI();
                    ModManagerUI.openForm(ModManagerUI.activeForm);
                    ModManager.silent = false;
                    ModManagerUI.StatusLabel.Text = "";
                });

                thisModManager.Invoke(a);

                ModWorker.endTransaction();

            }
        }

        private static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Nothing
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Nothing
            Utils.debug("test");
        }
    }
}
