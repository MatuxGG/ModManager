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
    public class Serverlist
    {
        public int CurrentRegionIdx;

        public List<Server> Regions;

        public List<Server> remoteServers;
        
        public Serverlist()
        {
            this.CurrentRegionIdx = 1;
            this.Regions = new List<Server>() { };
        }

        public Serverlist(int CurrentRegionIdx, List<Server> Regions)
        {
            this.CurrentRegionIdx = CurrentRegionIdx;
            this.Regions = Regions;
        }

        public void load(ModManager modManager)
        {
            modManager.logs.log("Loading serverlist");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\LocalLow\\Innersloth\\Among Us\\regionInfo.json";
            if (File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                Serverlist s = Newtonsoft.Json.JsonConvert.DeserializeObject<Serverlist>(json);
                this.Regions = s.Regions;
                this.CurrentRegionIdx = s.CurrentRegionIdx;
            }

            string serverlistURL = modManager.apiURL + "/servers";
            string serverlist = "";
            try
            {
                using (var client = new WebClient())
                {
                    serverlist = client.DownloadString(serverlistURL);
                }
            }
            catch
            {
                modManager.logs.log("Error : Disconnected when loading serverlist\n");
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
            this.remoteServers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Server>>(serverlist);
        }

        public void update(ModManager modManager)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\LocalLow\\Innersloth\\Among Us\\regionInfo.json", json);
        }

        public void removeRegion(int regionId)
        {
            this.Regions.RemoveAt(regionId);
            this.CurrentRegionIdx--;
        }

        public void reset(ModManager modManager)
        {
            List<Server> temp = new List<Server>();
            temp.Add(this.Regions[0]);
            temp.Add(this.Regions[1]);
            temp.Add(this.Regions[2]);
            temp.AddRange(this.remoteServers);
            this.Regions = temp;
            this.update(modManager);
        }
        public void add(ModManager modManager)
        {
            Server newServ = new Server("DnsRegionInfo, Assembly-CSharp", "127.0.0.1", "127.0.0.1", 22023, "New Server", 1003);
            this.Regions.Add(newServ);
            this.update(modManager);
        }

        public string toString()
        {
            string ret = "Server list :\n";

            foreach (Server s in this.Regions)
            {
                ret = ret + "- Server " + s.name + "\n";
            }
            return ret;
        }
    }
}
