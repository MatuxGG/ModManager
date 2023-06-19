using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class ModVersion
    {
        public string version { get; set; }
        public string githubTag { get; set; }
        public string gameVersion { get; set; }

        public ModVersion(string version = "", string githubTag = "", string gameVersion = "") {
            this.version = version;
            this.githubTag = githubTag;
            this.gameVersion = gameVersion;
        }
    }
}
