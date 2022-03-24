﻿using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class Mod
    {
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string gameVersion { get; set; }
        public List<string> dependencies { get; set; }
        public string author { get; set; }
        public string github { get; set; }
        public string githubLink { get; set; }
        public string ignoredPattern { get; set; }
        public List<string> data { get; set; }
        public Release release { get; set; }

        public Mod(string id, string name, string category, string type, string gameVersion, List<string> dependencies, string author, string github, string githubLink, string ignoredPattern, List<string> data)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.gameVersion = gameVersion;
            this.dependencies = dependencies;
            this.author = author;
            this.github = github;
            this.githubLink = githubLink;
            this.ignoredPattern = ignoredPattern;
            this.type = type;
            this.release = null;
            this.data = data;

            if (this.dependencies == null)
            {
                this.dependencies = new List<string>() { };
            }

            if (this.data == null)
            {
                this.data = new List<string>() { };
            }

        }

        public async Task getGithubRelease()
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(ModManager.token);
            client.Credentials = tokenAuth;
            try
            {
                this.release = await client.Repository.Release.GetLatest(this.author, this.github);
            }
            catch
            {
                this.release = null;
            }
        }

    }
}