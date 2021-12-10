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
            ModManagerUI.StatusLabel.Text = "Loading Servers...";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us\regionInfo.json";
            if (File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                serverList = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerList>(json);
            }

            string serverlistURL = ModManager.apiURL + "/servers";
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
        }

        public static void update()
        {
            string json = JsonConvert.SerializeObject(serverList);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us\regionInfo.json", json);
        }

        public static void removeRegion(int regionId)
        {
            serverList.Regions.RemoveAt(regionId);
            serverList.CurrentRegionIdx--;
        }

        public static void reset()
        {
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
            Server newServ = new Server("DnsRegionInfo, Assembly-CSharp", "127.0.0.1", "127.0.0.1", 22023, "New Server", 1003);
            serverList.Regions.Add(newServ);
            update();
        }

    }
}
