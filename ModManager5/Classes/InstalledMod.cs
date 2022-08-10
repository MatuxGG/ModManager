using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class InstalledMod
    {
        public string id;
        public string version;
        public string gameVersion;
        public List<string> options;

        public InstalledMod(string id, string version, string gameVersion, List<string> options)
        {
            this.id = id;
            this.version = version;
            this.gameVersion = gameVersion;
            this.options = options;
        }

        public InstalledMod()
        {
            this.id = "";
            this.version = "";
            this.gameVersion = "";
            this.options = new List<string>() { };
        }
    }
}
