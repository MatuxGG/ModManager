using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public class Language
    {
        public string code;
        public string name;
        public List<Translation> translations;

        public Language(string code, string name)
        {
            this.code = code;
            this.name = name;
            this.translations = new List<Translation>() { };
        }

        public Language()
        {
            this.code = "";
            this.name = "";
            this.translations = new List<Translation>() { };
        }

        public void load()
        {
            string translationsURL = ModManager.apiURL + "/translation/get/" + this.code;
            string tr = "";
            try
            {
                using (var client = new WebClient())
                {
                    tr = client.DownloadString(translationsURL);
                }
            }
            catch
            {
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
            translations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Translation>>(tr);
        }
    }
}
