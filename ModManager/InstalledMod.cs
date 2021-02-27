using System.Collections.Generic;

namespace ModManager
{

    public class InstalledMod
    {
        public string id { get; set; }
        public string version { get; set; }
        public List<string> assets { get; set; }
        public List<string> plugins { get; set; }

        public InstalledMod(string id, string version, List<string> assets, List<string> plugins)
        {
            this.id = id;
            this.version = version;
            this.assets = assets;
            this.plugins = plugins;
        }

    }
}