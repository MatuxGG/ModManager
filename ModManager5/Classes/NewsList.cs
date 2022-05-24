using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class NewsList
    {
        public static List<News> newslist;
        public static int current;

        public static void load()
        {
            Utils.log("Load START", "NewsList");
            ModManagerUI.StatusLabel.Text = "Loading News...";
            current = 0;
            string newslistURL = ModManager.apiURL + "/news/list";
            string newslistS = "";
            try
            {
                using (var client = new WebClient())
                {
                    newslistS = client.DownloadString(newslistURL);
                }
            }
            catch
            {
                Utils.logE("Load connection FAIL", "NewsList");
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
            newslist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<News>>(newslistS);

            Utils.log("Load END", "NewsList");
        }

        public static News getCurrent()
        {
            return newslist[current];
        }

        public static int getMax()
        {
            return newslist.Count() - 1;
        }
    }
}
