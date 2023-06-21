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
        public Category category { get; set; }
        public string type { get; set; }
        public string author { get; set; }
        public string github { get; set; }
        public bool githubLink { get; set; }
        public string social { get; set; }
        public string countries { get; set; }
        public bool enabled { get; set; }
        public List<ModVersion> versions { get; set; }

        //public string ignorePattern { get; set; }
        //public string needPattern { get; set; }
        //public string data { get; set; }

        public Mod(string id = "", string name = "", Category category = null, string type = "",
            string author = "", string github = "", bool githubLink = true, string social = "",
            string countries = "EN", bool enabled = true,
            List<ModVersion> versions = null)
        {
            this.id = id;
            this.name = name;
            this.category = category != null ? category : new Category();
            this.type = type;
            this.author = author;
            this.github = github;
            this.githubLink = githubLink;
            this.social = social;
            this.countries = countries;
            this.enabled = enabled;
            this.versions = versions != null ? versions : new List<ModVersion>() { };
        }

        public string getPathForVersion(ModVersion v)
        {
            return ModManager.appDataPath + @"\mods\" + this.id + @"_" + v.version;
        }

        public string getLink()
        {
            if (this.githubLink)
            {
                return "https://github.com/" + this.author + "/" + this.github;
            }
            else
            {
                return this.github.Replace("SERVERURL", ModManager.serverURL).Replace("APIURL", ModManager.serverURL).Replace("FILEURL", ModManager.fileURL);
            }
        }

        public string getAuthorLink()
        {
            if (this.githubLink)
            {
                return "https://github.com/" + this.author;
            }
            else
            {
                return null;
            }
        }

        public string getReleaseLink(ModVersion v)
        {
            return v.release.HtmlUrl;
        }
    }
}
