using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ModManager
{
    internal class Config
    {
        public string amongUsPath { get; set; }
        public List<string> installedMods { get; set; }
        public List<string> installedDependencies { get; set; }

        public Config(string amongUsPath, List<string> installedMods, List<string> installedDependencies)
        {
            this.amongUsPath = amongUsPath;
            this.installedMods = installedMods;
            this.installedDependencies = installedDependencies;
        }

        public void update()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager";
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(appDataPath + "\\config.conf", json);
        }

    }
}