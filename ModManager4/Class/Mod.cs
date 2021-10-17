using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Mod
    {
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string gameVersion { get; set; }
        public List<string> dependencies { get; set; }
        public string type { get; set; }
        public string author { get; set; }
        public string github { get; set; }
        public string githubLink { get; set; }
        public List<string> folders { get; set; }
        public List<string> data { get; set; }

        public List<string> excludeFiles { get; set; }

        public Release release { get; set; }

        public Mod(string id, string name, string category, string type, string gameVersion, List<string> dependencies, string author, string github, string githubLink, List<string> folders, List<string> data, List<string> excludeFiles)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.gameVersion = gameVersion;
            this.dependencies = dependencies;
            this.author = author;
            this.github = github;
            this.githubLink = githubLink;
            this.type = type;
            this.release = null;
            this.folders = folders;
            this.data = data;
            this.excludeFiles = excludeFiles;

            if (this.dependencies == null)
            {
                this.dependencies = new List<string>() { };
            }

            if (this.folders == null)
            {
                this.folders = new List<string>() { };
            }

            if (this.data == null)
            {
                this.data = new List<string>() { };
            }

            if (this.excludeFiles == null)
            {
                this.excludeFiles = new List<string>() { };
            }
        }

        public async Task getGithubRelease(string token)
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(token);
            client.Credentials = tokenAuth;
            try
            {
                this.release = await client.Repository.Release.GetLatest(this.author, this.github);
            } catch
            {
                this.release = null;
            }
        }
    }
}
