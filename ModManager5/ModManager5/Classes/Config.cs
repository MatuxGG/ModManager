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
        public List<InstalledMod> installedMods;
        public List<string> installedVanilla;
        public string currentGameVersion;
        public string amongUsPathHistory;
        public string theme;

        public Config(List<InstalledMod> installedMods, List<string> installedVanilla, string currentGameVersion, string amongUsPathHistory, string theme)
        {
            this.installedMods = installedMods;
            this.installedVanilla = installedVanilla;
            this.currentGameVersion = currentGameVersion;
            this.amongUsPathHistory = amongUsPathHistory;
            this.theme = theme;
        }

        public Config()
        {
            string version = ServerConfig.get("gameVersion").value;
            this.installedMods = new List<InstalledMod>() { };
            this.installedVanilla = new List<string>() { };
            this.currentGameVersion = "";
            this.amongUsPathHistory = "";
            this.theme = "dark";
        }

    }
}
