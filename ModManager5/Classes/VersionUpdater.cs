using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public static class VersionUpdater
    {
        public static void applyUpdates(string oldVersion, string newVersion)
        {
            if (Version.Parse(oldVersion) < Version.Parse("5.3.2"))
            {
                ModList.localMods = new List<Mod>() { };
                string localPath = ModManager.appDataPath + @"\localMods\";
                Utils.DirectoryDelete(localPath);
                Utils.DirectoryCreate(localPath);
                ModList.updateLocalMods();
            }

            if (Version.Parse(oldVersion) < Version.Parse("5.3.5"))
            {
                InstalledMod im = ConfigManager.getInstalledModById("TownOfHost");
                if (im != null)
                {
                    Mod m = ModList.getModById("TownOfUs");
                    if (m != null)
                    {
                        string modPath = ModManager.appDataPath + @"\mods\" + m.id;
                        Utils.DirectoryDelete(modPath);
                        Utils.DirectoryDelete(modPath + "-options");
                        ConfigManager.config.installedMods.Remove(im);
                        ConfigManager.update();
                    }
                }
                ConfigManager.update();
            }

            if (oldVersion != newVersion)
            {
                ConfigManager.config.ModManagerVersion = newVersion;
                ConfigManager.update();
            }
        }
    }
}
