using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Faqlist
    {
        public List<Faq> faqlist;
        public ModManager modManager;
        public int current;

        public Faqlist(ModManager modManager)
        {
            this.modManager = modManager;
            this.current = 0;
        }

        public void load()
        {
            this.modManager.logs.log("Loading faqlist");
            string faqlistURL = this.modManager.apiURL + "/faq";
            string faqlist = "";
            try
            {
                using (var client = new WebClient())
                {
                    faqlist = client.DownloadString(faqlistURL);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected when loading faqlist\n");
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
            this.faqlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Faq>>(faqlist);

        }

        public Faq getCurrent()
        {
            return this.faqlist[this.current];
        }

        public int getMax()
        {
            return this.faqlist.Count() - 1;
        }
    }
}
