using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class InstalledMod
    {
        public string id { get; set; }
        public string version { get; set; }
        public string gameVersion { get; set; }
        public List<string> assets { get; set; }
        public List<string> plugins { get; set; }

        public InstalledMod(string id, string version, string gameVersion, List<string> assets, List<string> plugins)
        {
            this.id = id;
            this.version = version;
            this.gameVersion = gameVersion;
            this.assets = assets;
            this.plugins = plugins;
        }
    }
}
