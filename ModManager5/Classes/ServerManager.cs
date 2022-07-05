using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class ServerManager
    {
        public static ServerList serverList;
        public static List<Server> remoteServers;

        public static void load()
        {
            Utils.log("Load START", "ServerManager");
            ModManagerUI.StatusLabel.Text = Translator.get("Loading Among Us Servers...");
            string prePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us";
            string path = prePath + @"\regionInfo.json";
            if (File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                serverList = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerList>(json);
            } else
            {
                Directory.CreateDirectory(prePath);
                init();
            }
            /*
            string serverlistURL = ModManager.apiURL + "/server/list";
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
                Utils.logE("Load connection FAIL", "ServerManager");
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
            remoteServers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Server>>(serverlist);
            */
            remoteServers = new List<Server>() { };
            Utils.log("Load END", "ServerManager");
        }

        public static void update()
        {
            Utils.log("Update START", "ServerManager");
            string json = JsonConvert.SerializeObject(serverList);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us\regionInfo.json", json);
            Utils.log("Update END", "ServerManager");
        }

        public static void removeRegion(int regionId)
        {
            Utils.log("Remove region " + regionId.ToString(), "ServerManager");
            serverList.Regions.RemoveAt(regionId);
            serverList.CurrentRegionIdx--;
        }

        public static void init()
        {
            Server na = new Server("DnsRegionInfo, Assembly-CSharp", "na.mm.among.us", "50.116.1.42", 22023, "North America", 289);
            Server eu = new Server("DnsRegionInfo, Assembly-CSharp", "eu.mm.among.us", "172.105.251.170", 22023, "Europe", 290);
            Server asia = new Server("DnsRegionInfo, Assembly-CSharp", "as.mm.among.us", "139.162.111.196", 22023, "Asia", 291);
            List<Server> sList = new List<Server>() { na, eu, asia };
            serverList = new ServerList(1, sList);
            update();
        }

        public static void reset()
        {
            Utils.log("Reset", "ServerManager");
            ServerList temp = serverList;
            serverList = new ServerList();
            serverList.Regions.Add(temp.Regions[0]);
            serverList.Regions.Add(temp.Regions[1]);
            serverList.Regions.Add(temp.Regions[2]);
            serverList.Regions.AddRange(remoteServers);
            serverList.CurrentRegionIdx = temp.CurrentRegionIdx;
            update();
        }
        public static void add()
        {
            Utils.log("Add", "ServerManager");
            Server newServ = new Server("DnsRegionInfo, Assembly-CSharp", "127.0.0.1", "127.0.0.1", 22023, "New Server", 1003);
            serverList.Regions.Add(newServ);
            update();
        }

    }
}
