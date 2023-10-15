using ModManager6.Classes;
using ModManager6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public static class VersionUpdater
    {
        public static void applyUpdates(string oldVersion, string newVersion)
        {
            try
            {
                //if (Version.Parse(oldVersion) < Version.Parse("6.0.0"))
                //{
                //    FileSystem.DirectoryDelete(ModManager.appDataPath + @"\mods\");
                //    FileSystem.DirectoryDelete(ModManager.appDataPath + @"\vanilla\");
                //    FileSystem.FileDelete(ModManager.appDataPath + @"\config5.json");
                //    FileSystem.FileDelete(ModManager.appDataPath + @"\globalConfig5.json");
                //}

                //if (oldVersion != newVersion)
                //{
                //    ConfigManager.config.ModManagerVersion = newVersion;
                //    ConfigManager.update();
                //}
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}