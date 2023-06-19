using ExCSS;
using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class Mod
    {
        [JsonProperty(PropertyName = "sId")]
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string author { get; set; }
        public string github { get; set; }
        public string githubLink { get; set; }
        public string social { get; set; }
        public string countries { get; set; }
        public bool enabled { get; set; }
        public Release release { get; set; }
        public List<ModVersion> versions { get; set; }
        public List<ModDependency> dependencies { get; set; }
        public List<ModDependency> options { get; set; }

        //public string ignorePattern { get; set; }
        //public string needPattern { get; set; }
        //public string data { get; set; }

        public Mod(string id = "", string name = "", string category = "", string type = "",
            string author = "", string github = "", string githubLink = "", string social = "",
            string countries = "EN", bool enabled = true,
            List<ModVersion> versions = null, List<ModDependency> dependencies = null, List<ModDependency> options = null)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.type = type;
            this.author = author;
            this.github = github;
            this.githubLink = githubLink;
            this.social = social;
            this.countries = countries;
            this.enabled = enabled;
            this.versions = versions != null ? versions : new List<ModVersion>() { };
            this.dependencies = dependencies != null ? dependencies : new List<ModDependency>() { };
            this.options = options != null ? options : new List<ModDependency>() { };
        }
    }
}
