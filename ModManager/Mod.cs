using System.Collections.Generic;

namespace ModManager
{
    internal class Mod
    {
        public string id { get; set; }
        public string name { get; set; }

        public List<Description> descriptions { get; set; }
        public string author { get; set; }
        public string github { get; set; }

        public Mod(string id, string name, List<Description> descriptions, string author, string github)
        {
            this.id = id;
            this.name = name;
            this.descriptions = descriptions;
            this.author = author;
            this.github = github;
        }

        public Description getDescriptionById(string id)
        {
            foreach (Description d in this.descriptions)
            {
                if (d.id == id)
                {
                    return d;
                }
            }
            return null;
        }

    }
}