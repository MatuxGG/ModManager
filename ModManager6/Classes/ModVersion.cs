using Newtonsoft.Json;
using Octokit;
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
        public string gameVersion { get; set; }
        [JsonProperty(PropertyName = "modDependencies")]
        public List<ModDependency> dependencies { get; set; }
        [JsonProperty(PropertyName = "modOptions")]
        public Release release { get; set; }
        public Boolean canBeCombined { get; set; }

        public ModVersion(string version = "", string gameVersion = "", List<ModDependency> dependencies = null, Boolean canBeCombined = false) {
            this.version = version;
            this.gameVersion = gameVersion;
            this.dependencies = dependencies != null ? dependencies : new List<ModDependency>() { };
            this.canBeCombined = canBeCombined;
        }

        public string getGithubVersion()
        {
            return this.release.TagName;
        }
    }
}
