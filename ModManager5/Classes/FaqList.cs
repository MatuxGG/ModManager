using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class FaqList
    {
        public static List<Faq> faqlist;
        public static int current;

        public static void load()
        {
            Utils.log("Load START", "FaqList");
            ModManagerUI.StatusLabel.Text = "Loading FAQ...";
            current = 0;
            string faqlistURL = ModManager.apiURL + "/faq/list";
            string faqlistS = "";
            try
            {
                using (var client = new WebClient())
                {
                    faqlistS = client.DownloadString(faqlistURL);
                }
            }
            catch
            {
                Utils.logE("Load connection FAIL", "FaqList");
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
            faqlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Faq>>(faqlistS);

            Utils.log("Load END", "FaqList");
        }

        public static Faq getCurrent()
        {
            return faqlist[current];
        }

        public static int getMax()
        {
            return faqlist.Count() - 1;
        }
    }
}
