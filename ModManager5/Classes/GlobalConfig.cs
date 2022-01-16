using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class GlobalConfig
    {
        public string theme;
        public string lg;
        public string clientVersion;
        public int startTime;

        public GlobalConfig(string theme, string lg, string clientVersion, int startTime)
        {
            this.theme = theme;
            this.lg = lg;
            this.clientVersion = clientVersion;
            this.startTime = startTime;
        }

        public GlobalConfig()
        {
            this.theme = "Dark";
            this.lg = "";
            this.clientVersion = "Live";
            this.startTime = 0;
        }
    }
}
