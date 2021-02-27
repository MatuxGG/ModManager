using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ModManager
{
    internal class Config
    {
        public string amongUsPath { get; set; }
        public List<InstalledMod> installedMods { get; set; }
        public List<string> installedDependencies { get; set; }

        public bool tenPlayers { get; set; }

        public string lg { get; set; }

        public Config(string amongUsPath, List<InstalledMod> installedMods, List<string> installedDependencies, string lg, bool tenPlayers)
        {
            this.amongUsPath = amongUsPath;
            this.installedMods = installedMods;
            this.installedDependencies = installedDependencies;
            this.lg = lg;
            this.tenPlayers = tenPlayers;
        }

        public void update()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager";
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(appDataPath + "\\config3.conf", json);
        }

        public Boolean containsMod(string id)
        {
            foreach (InstalledMod m in this.installedMods)
            {
                if (m.id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean isUpTodate(string id, string version) {
            foreach (InstalledMod m in this.installedMods)
            {
                
                if (m.id == id && m.version == version)
                {
                    return true;
                }
            }
            return false;
        }

        public InstalledMod getInstalledModById(string id)
        {
            foreach (InstalledMod m in this.installedMods)
            {
                if (m.id == id)
                {
                    return m;
                }
            }
            return null;
        }

    }
}