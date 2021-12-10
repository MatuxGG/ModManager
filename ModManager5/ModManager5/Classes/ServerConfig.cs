using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class ServerConfig
    {
        public static List<ServerConfigLine> configlines;

        public static void load()
        {
            if (!ModManager.silent)
               ModManagerUI.StatusLabel.Text = "Loading Server Config...";
            string configURL = ModManager.apiURL + "/config";
            string config = "";
            try
            {
                using (var client = new WebClient())
                {
                    config = client.DownloadString(configURL);
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
            configlines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerConfigLine>>(config);
        }

        public static ServerConfigLine get(string id)
        {
            return configlines.Find(c => c.id == id);
        }
    }
}
