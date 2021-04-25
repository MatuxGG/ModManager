using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class ServerConfig
    {
        public bool enabled;
        public string gameVersion;


        public ServerConfig(bool enabled, string gameVersion)
        {
            this.enabled = enabled;
            this.gameVersion = gameVersion;
        }
    }
}
