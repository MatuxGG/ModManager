using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ModManager
{
    public class Config
    {
        public string amongUsPath { get; set; }
        public List<InstalledMod> installedMods { get; set; }
        public List<string> installedDependencies { get; set; }
        public string texture { get; set; }

        public Config(string amongUsPath, List<InstalledMod> installedMods, List<string> installedDependencies, string texture)
        {
            this.amongUsPath = amongUsPath;
            this.installedMods = installedMods;
            this.installedDependencies = installedDependencies;
            this.texture = texture;
        }

        public Config()
        {

        }

        public void load()
        {
            FileInfo f = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\config3.conf");

            if (f.Exists)
            {
                string json = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\config3.conf");
                Config temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                FileInfo f2 = new FileInfo(temp.amongUsPath + "\\Among Us.exe");
                if (f2.Exists)
                {
                    this.amongUsPath = temp.amongUsPath;
                    this.installedDependencies = temp.installedDependencies;
                    this.installedMods = temp.installedMods;
                    this.texture = temp.texture;
                    return;
                }
            }

            DirectoryInfo dirC = new DirectoryInfo("C:\\Program Files\\Steam\\steamapps\\common\\Among Us");
            DirectoryInfo dirC2 = new DirectoryInfo("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Among Us");

            this.installedMods = new List<InstalledMod>();
            this.installedDependencies = new List<string>();
            this.texture = "None";
            this.amongUsPath = null;
            if (dirC.Exists)
            {
                this.amongUsPath = "C:\\Program Files\\Steam\\steamapps\\common\\Among Us";
                return;
            }
            if (dirC2.Exists)
            {
                this.amongUsPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Among Us";
                return;
            }
            this.update();
            return;
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

        public bool exists()
        {
            FileInfo f = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\config3.conf");
            return f.Exists;
        }

    }
}