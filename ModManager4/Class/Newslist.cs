using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Newslist
    {
        public List<News> newslist;
        public ModManager modManager;
        public int current;

        public Newslist(ModManager modManager)
        {
            this.modManager = modManager;
            this.current = 0;
        }

        public void load()
        {
            this.modManager.logs.log("Loading newslist");
            string newslistURL = this.modManager.apiURL + "/newslist";
            string newslist = "";
            try
            {
                using (var client = new WebClient())
                {
                    newslist = client.DownloadString(newslistURL);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected when loading newslist\n");
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
            this.newslist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<News>>(newslist);

        }

        public News getCurrent()
        {
            return this.newslist[this.current];
        }

        public int getMax()
        {
            return this.newslist.Count() - 1;
        }
    }
}
