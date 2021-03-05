using System.Collections.Generic;

namespace ModManager
{
    public class Mod
    {
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }

        public string description { get; set; }
        public string author { get; set; }
        public string github { get; set; }

        public Mod(string id, string name, string category, string description, string author, string github)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.description = description;
            this.author = author;
            this.github = github;
        }

    }
}