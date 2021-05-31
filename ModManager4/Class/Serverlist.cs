using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Serverlist
    {
        public int CurrentRegionIdx;

        public List<Server> Regions;
        
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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\LocalLow\\Innersloth\\Among Us\\regionInfo.json";
            if (File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                Serverlist s = Newtonsoft.Json.JsonConvert.DeserializeObject<Serverlist>(json);
                this.Regions = s.Regions;
                this.CurrentRegionIdx = s.CurrentRegionIdx;
            }
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
            Server matux = new Server("DnsRegionInfo, Assembly-CSharp", "152.228.160.91", "152.228.160.91", 22023, "matux.fr", 1003);
            temp.Add(matux);
            this.Regions = temp;
            //this.CurrentRegionIdx = 1;
            this.update(modManager);
        }
        public void add(ModManager modManager)
        {
            Server newServ = new Server("DnsRegionInfo, Assembly-CSharp", "127.0.0.1", "127.0.0.1", 22023, "New Server", 1003);
            this.Regions.Add(newServ);
            //this.CurrentRegionIdx = CurrentRegionIdx + 1;
            this.update(modManager);
        }


        /*
        public void updateUnify(ModManager modManager)
        {
            if (modManager.config.containsMod("Unify") == false || Directory.Exists(modManager.config.amongUsPath + "\\BepInEx") == false || Directory.Exists(modManager.config.amongUsPath + "\\BepInEx\\config") == false)
            {
                return;
            }
            string str = "[Preferences]\n" +
                "\n" +
                "## If the official regions should be shown when displaying the regions menu\n" +
                "# Setting type: Boolean\n" +
                "# Default value: true\n" +
                "Show Official Regions = " + this.showOfficialRegions + "\n" +
                "\n" +
                "## If the extra regions added by default in Unify should be shown when displaying the regions menu\n" +
                "# Setting type: Boolean\n" +
                "# Default value: true\n" +
                "Show Extra Regions = " + this.showExtraRegions + "\n" +
                "\n";
            int i = 0;
            foreach (Server s in this.servers)
            {
                i++;
                string serverStr = "[Region " + i + "]\n" +
                    "\n" +
                    "# Setting type: String\n" +
                    "# Default value: custom region\n" +
                    "Name = " + s.name + "\n" +
                    "\n" +
                    "# Setting type: String\n" +
                    "# Default value: \n" +
                    "IP = " + s.ip + "\n" +
                    "\n" +
                    "# Setting type: UInt16\n" +
                    "# Default value: 22023\n" +
                    "Port = " + s.port + "\n" +
                    "\n";
                str = str + serverStr;
            }
            File.WriteAllText(modManager.config.amongUsPath + "\\BepInEx\\config\\daemon.unify.cfg", str);
        }
        */

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
