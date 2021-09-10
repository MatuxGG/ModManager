using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Categorylist
    {
        public ModManager modManager;

        public List<Category> categories;
        public Categorylist(ModManager modManager)
        {
            this.modManager = modManager;
            this.categories = new List<Category>();
        }
        public void load()
        {
            this.modManager.logs.log("Loading categories");
            string catlistURL = this.modManager.serverURL + "/categorylist.json";
            string cat = "";
            try
            {
                using (var client = new WebClient())
                {
                    cat = client.DownloadString(catlistURL);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected when loading categories\n");
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
            this.categories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(cat);

            this.modManager.logs.log("- Categories loaded successfully");
        }

        public Category getCategoryById(string id)
        {
            foreach (Category cat in this.categories)
            {
                if (cat.id == id)
                {
                    return cat;
                }
            }
            return null;
        }
    }
}
