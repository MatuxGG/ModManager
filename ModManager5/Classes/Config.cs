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
        public string amongUsPath;
        public string launcher;
        public List<string> favoriteMods;
        public bool miniEnabled;
        public List<string> availableAmongUsPaths;

        public Config(string modManagerVersion, List<InstalledMod> installedMods, List<InstalledVanilla> installedVanilla, string amongUsPath, string launcher, List<string> faroriteMods, bool miniEnabled)
        {
            this.ModManagerVersion = modManagerVersion;
            this.installedMods = installedMods;
            this.installedVanilla = installedVanilla;
            this.amongUsPath = amongUsPath;
            this.launcher = launcher;
            this.favoriteMods = faroriteMods;
            this.miniEnabled = miniEnabled;
            this.availableAmongUsPaths = new List<string>() { };
        }

        public Config(string modManagerVersion, List<InstalledMod> installedMods, List<InstalledVanilla> installedVanilla, string amongUsPath, string launcher, List<string> faroriteMods, bool miniEnabled, List<string> availableAmongUsPaths)
        {
            this.ModManagerVersion = modManagerVersion;
            this.installedMods = installedMods;
            this.installedVanilla = installedVanilla;
            this.amongUsPath = amongUsPath;
            this.launcher = launcher;
            this.favoriteMods = faroriteMods;
            this.miniEnabled = miniEnabled;
            this.availableAmongUsPaths = availableAmongUsPaths;
        }

        public Config()
        {
            this.ModManagerVersion = ModManager.visibleVersion;
            string version = ServerConfig.get("gameVersion").value;
            this.installedMods = new List<InstalledMod>() { };
            this.installedVanilla = new List<InstalledVanilla>() { };
            this.amongUsPath = "";
            this.launcher = "Steam";
            this.favoriteMods = new List<string>() { };
            this.miniEnabled = true;
            this.availableAmongUsPaths = new List<string>() { };
        }

    }
}
