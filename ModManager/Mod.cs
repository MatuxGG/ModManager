namespace ModManager
{
    internal class Mod
    {
        public string id { get; set; }
        public string name { get; set; }
        public string descriptionEN { get; set; }
        public string descriptionFR { get; set; }
        public string[] dependencies { get; set; }
        public string[] plugins { get; set; }

        /*public Mod(string id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }*/
        public Mod(string id, string name, string descriptionEN, string descriptionFR, string[] dependencies, string[] plugins)
        {
            this.id = id;
            this.name = name;
            this.descriptionEN = descriptionEN;
            this.descriptionFR = descriptionFR;
            this.dependencies = dependencies;
            this.plugins = plugins;
        }

    }
}