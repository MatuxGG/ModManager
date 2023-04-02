using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class Mod
    {
        [JsonProperty(PropertyName = "sId")]
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string gameVersion { get; set; }

        [JsonProperty(PropertyName = "dependencies2")]
        public List<string> dependencies { get; set; }

        [JsonProperty(PropertyName = "options")]
        public List<string> options { get; set; }

        public string author { get; set; }
        public string github { get; set; }
        public string githubLink { get; set; }
        public string githubTag { get; set; }
        public string social { get; set; }
        public string ignorePattern { get; set; }
        public string needPattern { get; set; }
        public string data { get; set; }
        public string countries { get; set; }
        public bool hasUpdater { get; set; }
        public bool enabled { get; set; }

        public Release release { get; set; }

        public Mod(string id, string name, string category, string type, string gameVersion, List<string> dependencies,
            string author = "", string github = "", string githubLink = "", string githubTag = "", string social = "",
            string ignorePattern = "", string needPattern = "", string data = "",
            List<string> options = null, string countries = "en", bool enabled = true, bool hasUpdater = false)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.gameVersion = gameVersion;
            this.dependencies = dependencies;
            this.options = options;
            this.author = author;
            this.github = github;
            this.githubLink = githubLink;
            this.githubTag = githubTag;
            this.social = social;
            this.ignorePattern = ignorePattern;
            this.needPattern = needPattern;
            this.type = type;
            this.release = null;
            this.data = data;

            if (this.dependencies == null)
            {
                this.dependencies = new List<string>() { };
            }

            if (this.data == null)
            {
                this.data = "";
            }

            if (this.options == null)
            {
                this.options = new List<string>() { };
            }
            this.countries = countries;
            this.enabled = enabled;
            this.hasUpdater = hasUpdater;
        }

        public string getLink()
        {
            if (this.githubLink == "1")
            {
                return "https://github.com/" + this.author + "/" + this.github;
            } else
            {
                return this.github.Replace("SERVERURL", ModManager.serverURL).Replace("APIURL", ModManager.serverURL).Replace("FILEURL", ModManager.fileURL);
            }
        }

        public string getAuthorLink()
        {
            if (this.githubLink == "1")
            {
                return "https://github.com/" + this.author;
            } else
            {
                return null;
            }
        }

        public async Task getGithubRelease()
        {
            try
            {
                if (this.githubTag == null || this.githubTag == "")
                {
                    var releases = await ModManager.githubClient.Repository.Release.GetAll(this.author, this.github);
                    this.release = releases.First();
                } else
                {
                    this.release = await ModManager.githubClient.Repository.Release.Get(this.author, this.github, this.githubTag);
                }
            }
            catch
            {
                this.release = null;
            }
        }


        public List<string> getCountries()
        {
            string[] myArray = this.countries.Split(';');
            return myArray.ToList();
        }
    }
}
