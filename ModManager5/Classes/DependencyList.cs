using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public class DependencyList
    {
        public static List<Dependency> dependencies;
        public static void load()
        {
            Utils.log("Load START", "DependencyList");
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Loading Dependencies...";
            string dependenciesURL = ModManager.apiURL + "/dependency/list";
            string dependencylist = "";
            try
            {
                using (var client = new WebClient())
                {
                    dependencylist = client.DownloadString(dependenciesURL);
                }
            }
            catch
            {
                Utils.logE("Load connection FAIL", "DependencyList");
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
            dependencies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dependency>>(dependencylist);
            Utils.log("Load END", "DependencyList");
        }

        public static Dependency getDependencyById(string id)
        {
            return dependencies.Find(d => d.id == id);
        }
    }
}
