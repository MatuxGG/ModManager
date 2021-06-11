using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Toollist
    {
        public ModManager modManager;
        public List<Tool> tools;
        public Toollist(ModManager modManager)
        {
            this.modManager = modManager;
        }

        public void load()
        {
            this.modManager.logs.log("Loading toollist");
            string localToollistPath = this.modManager.appDataPath + "\\toollist.json";
            this.tools = new List<Tool> { };
            if (File.Exists(localToollistPath))
            {
                string json = File.ReadAllText(localToollistPath);
                this.tools = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tool>>(json);
            }

            string toollistURL = this.modManager.serverURL + "/toollist.json";
            string toollist = "";
            try
            {
                using (var client = new WebClient())
                {
                    toollist = client.DownloadString(toollistURL);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected when loading toollist\n");
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
            this.tools = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tool>>(toollist);
            /*
            if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null) != null)
            {
                foreach (Tool t in this.tools)
                {
                    if (t.name == "Better Crewlink" && t.path == "")
                    {
                        t.path = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null).ToString() + "\\Better-CrewLink.exe";
                    }
                }
            }
            this.update();
            */
            this.modManager.logs.log("- Toolist loaded successfully");
        }

        public void update()
        {
            string json = JsonConvert.SerializeObject(this.tools);
            File.WriteAllText(this.modManager.appDataPath + "\\toollist.json", json);
        }

        public Tool getToolByName(string name)
        {
            foreach (Tool t in this.tools)
            {
                if (t.name == name)
                {
                    return t;
                }
            }
            return null;
        }

        public string toString()
        {
            string ret = "Toollist :\n";
            foreach (Tool t in this.tools)
            {
                ret = ret + "- Tool " + t.name + "\n";
            }
            return ret;
        }
    }
}
