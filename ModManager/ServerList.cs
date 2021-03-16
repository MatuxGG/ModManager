using System;
using System.Collections.Generic;
using System.IO;

namespace ModManager
{
    public class ServerList
    {
        public List<List<string>> servers;

        public ModManager modManager;

        public ServerList(ModManager modManager)
        {
            this.modManager = modManager;
        }

        public void update()
        {
            string[] content = {"[Region 1]",
                "",
                "# Setting type: String",
                "# Default value: custom region",
                "Name = "+"matux.fr",
                "",
                "# Setting type: String",
                "# Default value:",
                "IP = "+ "152.228.160.91" };

            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\daemon.unify.reactor.cfg", content);

            if (this.modManager.config.containsMod("Unify"))
            {
                this.modManager.utils.FileDelete(this.modManager.config.amongUsPath + "\\BepInEx\\config\\daemon.unify.reactor.cfg");
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\daemon.unify.reactor.cfg", this.modManager.config.amongUsPath+ "\\BepInEx\\config\\daemon.unify.reactor.cfg");
            }

        }
    }
}