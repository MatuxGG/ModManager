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
            Server challenger = new Server("DnsRegionInfo, Assembly-CSharp", "51.210.123.16", "51.210.123.16", 22023, "challenger", 1003);
            Server skeld = new Server("DnsRegionInfo, Assembly-CSharp", "192.241.154.115", "192.241.154.115", 22023, "skeld.net", 1003);
            temp.Add(matux);
            temp.Add(challenger);
            temp.Add(skeld);
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
