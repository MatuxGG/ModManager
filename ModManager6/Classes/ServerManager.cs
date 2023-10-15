using ModManager6.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public static class ServerManager
    {
        public static ServerList serverList;
        public static List<Server> remoteServers;

        public static void load()
        {
            try
            {
                string prePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us";
                string path = prePath + @"\regionInfo.json";
                if (File.Exists(path))
                {
                    string json = System.IO.File.ReadAllText(path);
                    serverList = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerList>(json);
                }
                else
                {
                    Directory.CreateDirectory(prePath);
                    init();
                }
                remoteServers = new List<Server>() { };
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void update()
        {
            try
            {
                string json = JsonConvert.SerializeObject(serverList);
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us\regionInfo.json", json);
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void removeRegion(int regionId)
        {
            try
            {
                serverList.Regions.RemoveAt(regionId);
                serverList.CurrentRegionIdx--;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void init()
        {
            try
            {
                Server na = new Server("DnsRegionInfo, Assembly-CSharp", "na.mm.among.us", "50.116.1.42", 22023, "North America", 289);
                Server eu = new Server("DnsRegionInfo, Assembly-CSharp", "eu.mm.among.us", "172.105.251.170", 22023, "Europe", 290);
                Server asia = new Server("DnsRegionInfo, Assembly-CSharp", "as.mm.among.us", "139.162.111.196", 22023, "Asia", 291);
                List<Server> sList = new List<Server>() { na, eu, asia };
                serverList = new ServerList(1, sList);
                update();
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void reset()
        {
            try
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
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
        public static void add()
        {
            try
            {
                Server newServ = new Server("DnsRegionInfo, Assembly-CSharp", "127.0.0.1", "127.0.0.1", 22023, "New Server", 1003);
                serverList.Regions.Add(newServ);
                update();
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

    }
}