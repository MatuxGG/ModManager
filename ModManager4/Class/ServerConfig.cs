using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class ServerConfig
    {
        public List<ConfigLine> configlines;
        public ModManager modManager;

        public ServerConfig(ModManager modManager)
        {
            this.modManager = modManager;
        }

        public void load()
        {
            this.modManager.logs.log("Loading server config");
            string configURL = this.modManager.apiURL + "/config";
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
                this.modManager.logs.log("Error : Disconnected when loading Server config\n");
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
            this.configlines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ConfigLine>>(config);
        }

        public ConfigLine get(string id)
        {
            return this.configlines.Find(c => c.id == id);
        }

    }
}
