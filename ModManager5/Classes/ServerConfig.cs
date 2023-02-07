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
            Utils.log("Load START", "ServerConfig");
            if (!ModManager.silent)
               ModManagerUI.StatusLabel.Text = Translator.get("Loading Server Config...");
            string configURL = ModManager.apiURL + "/config";
            string config = "";
            try
            {
                using (var client = Utils.getClient())
                {
                    config = client.DownloadString(configURL);
                }
            }
            catch
            {
                Utils.logE("Load connection FAIL", "ServerConfig");
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
            Utils.log("Load END", "ServerConfig");
        }

        public static ServerConfigLine get(string id)
        {
            return configlines.Find(c => c.id == id);
        }
    }
}
