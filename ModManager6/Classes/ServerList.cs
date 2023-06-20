using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class ServerList
    {
        public int CurrentRegionIdx;
        public List<Server> Regions;

        public ServerList()
        {
            this.CurrentRegionIdx = 1;
            this.Regions = new List<Server>() { };
        }

        public ServerList(int CurrentRegionIdx, List<Server> Regions)
        {
            this.CurrentRegionIdx = CurrentRegionIdx;
            this.Regions = Regions;
        }
    }
}
