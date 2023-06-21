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
        public List<ModDependency> dependencies { get; set; }
        public List<ModOption> options { get; set; }
        public Release release { get; set; }

        public ModVersion(string version = "", string gameVersion = "", List<ModDependency> dependencies = null, List<ModOption> options = null) {
            this.version = version;
            this.gameVersion = gameVersion;
            this.dependencies = dependencies != null ? dependencies : new List<ModDependency>() { };
            this.options = options != null ? options : new List<ModOption>() { };
        }

        public string getGithubVersion()
        {
            return this.release.TagName;
        }
    }
}
