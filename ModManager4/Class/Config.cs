using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Config
    {
        public string amongUsPath { get; set; }
        public List<InstalledMod> installedMods { get; set; }
        public List<string> installedDependencies { get; set; }

        public Boolean enableCache { get; set; }

        public int resolutionX { get; set; }
        public int resolutionY { get; set; }

        public Config(string amongUsPath, List<InstalledMod> installedMods, List<string> installedDependencies, Boolean enableCache, int resolutionX, int resolutionY)
        {
            this.amongUsPath = amongUsPath;
            this.installedMods = installedMods;
            this.installedDependencies = installedDependencies;
            this.enableCache = enableCache;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
        }

        public Config()
        {
            this.amongUsPath = "";
            this.installedMods = new List<InstalledMod>();
            this.installedDependencies = new List<string>();
            this.enableCache = true;
            this.resolutionX = 1300;
            this.resolutionY = 810;
        }

        public List<int[]> getResolutions()
        {
            List<int[]> res = new List<int[]>();
            res.Add(new int[] { 1300, 810 });
            res.Add(new int[] { 1920, 1200 });
            return res;
        }

        
        public void check(ModManager modManager)
        {
            modManager.logs.log("Check mods integrity");


            while (this.checkWorker(modManager) == true)
            {

            }

            modManager.logs.log("- Mods integrity checked");
        }

        public Boolean checkWorker(ModManager modManager)
        {
            string pluginPath = this.amongUsPath + "\\BepInEx\\plugins";
            foreach (InstalledMod mod in this.installedMods)
            {
                Mod m = modManager.modlist.getModById(mod.id);

                if (mod.gameVersion != modManager.serverConfig.gameVersion || (m.type == "mod" && mod.version != m.release.TagName))
                {
                    modManager.logs.log("- Uninstall mod " + m.name + " (wrong version or game version)");
                    modManager.modWorker.uninstallMod(m);
                    return true;
                }
                foreach (string asset in mod.assets)
                {
                    if (File.Exists(this.amongUsPath + "\\" + asset) == false)
                    {
                        modManager.logs.log("- Uninstall mod " + m.name + " (missing asset " + asset + ")");
                        modManager.modWorker.uninstallMod(m);
                        return true;
                    }
                }
                foreach (string plugin in mod.plugins)
                {
                    if (File.Exists(pluginPath + "\\" + plugin) == false && Directory.Exists(pluginPath + "\\" + plugin) == false)
                    {
                        modManager.logs.log("- Uninstall mod " + m.name + " (missing plugin " + plugin + ")");
                        modManager.modWorker.uninstallMod(m);
                        return true;
                    }
                }
            }
            return false;
        }

        public void load(ModManager modManager)
        {
            modManager.logs.log(this.toString());
            modManager.logs.log("- start");

            string path = modManager.appDataPath + "\\config4.conf";
            modManager.logs.log("- Path = " + path);

            if (File.Exists(path))
            {
                modManager.logs.log("- config exists");
                string json = System.IO.File.ReadAllText(path);
                Config temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                modManager.logs.log("- Among Us Path = " + temp.amongUsPath + "\\Among Us.exe");
                if (File.Exists(temp.amongUsPath + "\\Among Us.exe"))
                {
                    modManager.logs.log("- Among Us exists");
                    this.amongUsPath = temp.amongUsPath;
                    this.installedDependencies = temp.installedDependencies;
                    this.installedMods = temp.installedMods;
                    this.enableCache = temp.enableCache;

                    if (this.getResolutions().Contains(new int[] {temp.resolutionX, temp.resolutionY}) == false)
                    {
                        temp.resolutionX = 1300;
                        temp.resolutionY = 810;
                    }

                    this.resolutionX = temp.resolutionX;
                    this.resolutionY = temp.resolutionY;
                    this.update(modManager);
                    return;
                } else
                {
                    modManager.logs.log("- Among Us doesn't exists in stored config");
                }
            } else
            {
                modManager.logs.log("- Config doesn't exists");
            }
            this.installedMods = new List<InstalledMod>();
            this.installedDependencies = new List<string>();
            modManager.logs.log("- Getting path");
            this.amongUsPath = null;
            RegistryKey myKey  = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);
            this.amongUsPath = (String)myKey.GetValue("InstallLocation");
            
            modManager.logs.log("- Among Us path detection : " + this.amongUsPath);

            this.update(modManager);
            modManager.logs.log("- Config updated");

            return;
        }

        public void update(ModManager modManager)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(modManager.appDataPath + "\\config4.conf", json);
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

        public Boolean isUpTodate(string id, string version)
        {
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

        public bool exists(ModManager modManager)
        {
            FileInfo f = new FileInfo(modManager.appDataPath + "\\config4.conf");
            return f.Exists;
        }

        public string toString()
        {
            
            string ret = "Config :\n- OS Version : " + System.Environment.OSVersion.ToString() + "\n- Among Us path : " + this.amongUsPath + "\n- Cache enabled : " + this.enableCache + "\n- Resolution : " + this.resolutionX + "x" + this.resolutionY + "\n- Installed dependencies :\n";
            foreach (string d in this.installedDependencies)
            {
                ret = ret + "- - Installed dependency " + d;
            }
            ret = ret + "\n- Installed mods :\n";
            foreach (InstalledMod m in this.installedMods)
            {
                ret = ret + "- - Installed mod " + m.id + " : Version = " + m.version + " / Game version = " + m.gameVersion + " / Assets = [";
                int i = 0;
                foreach (string a in m.assets)
                {
                    if (i != 0)
                    {
                        ret = ret + ", ";
                    }
                    ret = ret + a;
                    i++;
                }
                ret = ret + "] / Plugins = [";
                i = 0;
                foreach (string p in m.plugins)
                {
                    if (i != 0)
                    {
                        ret = ret + ", ";
                    }
                    ret = ret + p;
                    i++;
                }
                ret = ret + "]\n";
            }
            return ret;
        }
    }
}
