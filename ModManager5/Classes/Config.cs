using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class Config
    {
        public string ModManagerVersion;
        public List<InstalledMod> installedMods;
        public List<InstalledVanilla> installedVanilla;
        public string currentGameVersion;
        public string amongUsPath;
        public string lastMod;
        public List<string> favoriteMods;

        public Config(string modManagerVersion, List<InstalledMod> installedMods, List<InstalledVanilla> installedVanilla, string currentGameVersion, string amongUsPath, string lastMod, List<string> faroriteMods)
        {
            this.ModManagerVersion = modManagerVersion;
            this.installedMods = installedMods;
            this.installedVanilla = installedVanilla;
            this.currentGameVersion = currentGameVersion;
            this.amongUsPath = amongUsPath;
            this.lastMod = lastMod;
            this.favoriteMods = faroriteMods;
        }

        public Config()
        {
            this.ModManagerVersion = ModManager.visibleVersion;
            string version = ServerConfig.get("gameVersion").value;
            this.installedMods = new List<InstalledMod>() { };
            this.installedVanilla = new List<InstalledVanilla>() { };
            this.currentGameVersion = "";
            this.amongUsPath = "";
            this.lastMod = "";
            this.favoriteMods = new List<string>() { };
        }

    }
}
