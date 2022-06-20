using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class CategoryManager
    {
        public static List<Category> categories;

        public static void load()
        {
            Utils.log("Load START", "CategoryManager");
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = Translator.get("Loading categories...");
            string catlistURL = ModManager.apiURL + "/cat";
            string cat = "";
            try
            {
                using (var client = new WebClient())
                {
                    cat = client.DownloadString(catlistURL);
                }
            }
            catch (Exception e)
            {
                Utils.logE("Load connection FAIL", "CategoryManager");
                Utils.logEx(e, "CategoryManager");
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
            categories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Category>>(cat);
            Utils.log("Load END", "CategoryManager");
        }

        public static Category getCategoryById(string id)
        {
            if (id == "Favorites")
                return new Category("Favorites", "Favorites");
            return categories.Find(c => c.id == id);
        }
    }
}
