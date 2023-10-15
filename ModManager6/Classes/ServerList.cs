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

        public ServerList(int CurrentRegionIdx = 1, List<Server> Regions = null)
        {
            try
            {
                this.CurrentRegionIdx = CurrentRegionIdx;
                this.Regions = Regions == null ? new List<Server>() { } : Regions;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}
