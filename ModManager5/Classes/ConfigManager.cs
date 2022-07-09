using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class ConfigManager
    {
        public static Config config;
        public static GlobalConfig globalConfig;
        public static string globalPath = ModManager.appDataPath + @"\globalConfig5.conf";
        public static string path = ModManager.appDataPath + @"\config5.conf";

        public static void loadGlobalConfig()
        {
            Utils.log("Load global START", "ConfigManager");
            globalConfig = new GlobalConfig();
            if (File.Exists(globalPath))
            {
                Utils.log("Global config exists", "ConfigManager");
                string json = System.IO.File.ReadAllText(globalPath);
                globalConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<GlobalConfig>(json);
                
                if (globalConfig.lg == "English")
                {
                    Utils.log("Global config update to EN", "ConfigManager");
                    globalConfig.lg = "EN";
                    updateGlobalConfig();
                }
            }
            else
            {
                updateGlobalConfig();
            }
            Utils.log("Load global END", "ConfigManager");
        }

        public static void load()
        {
            Utils.log("Load config START", "ConfigManager");
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = Translator.get("Loading Local Config...");
            config = new Config();
            if (File.Exists(path))
            {
                Utils.log("Config exists", "ConfigManager");
                string json = System.IO.File.ReadAllText(path);
                config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
            }

            updateAmongUsPathIfNeeded();

            Utils.log("Load config END", "ConfigManager");
        }

        public static void update()
        {
            Utils.log("Config update START", "ConfigManager");
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(path, json);
            Utils.log("Config update END", "ConfigManager");
        }

        public static void updateGlobalConfig()
        {
            Utils.log("Global config update START", "ConfigManager");
            string json = JsonConvert.SerializeObject(globalConfig);
            File.WriteAllText(globalPath, json);
            Utils.log("Global config update END", "ConfigManager");
        }

        public static void updateAmongUsPathIfNeeded()
        {
            if (ConfigManager.config.amongUsPath == null || ConfigManager.config.amongUsPath == "" || !File.Exists(ConfigManager.config.amongUsPath + @"\Among Us.exe"))
            {
                string amongUsPath = null;

                RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);

                if (myKey != null)
                {
                    amongUsPath = (String)myKey.GetValue("InstallLocation");
                    if (amongUsPath != null && File.Exists(amongUsPath + @"\Among Us.exe"))
                    {
                        config.launcher = "Steam";
                        config.amongUsPath = amongUsPath;
                        return;
                    }
                }

                // Found from EGS

                amongUsPath = null;
                foreach (DriveInfo d in DriveInfo.GetDrives())
                {
                    amongUsPath = d.Name + @"Program Files\Epic Games\AmongUs";
                    if (amongUsPath != null && File.Exists(amongUsPath + @"\Among Us.exe"))
                    {
                        config.launcher = "EGS";
                        config.amongUsPath = amongUsPath;
                        return;
                    }
                }

                // Else

                while (amongUsPath == null || File.Exists(amongUsPath + @"\Among Us.exe") == false)
                {
                    if (MessageBox.Show("Among Us not found ! Please, select the Among Us executable", "Among Us not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        Utils.log("Manual selection LEFT", "ConfigManager");
                        Environment.Exit(0);
                    }
                    amongUsPath = selectFolderWorker();
                }
                Utils.log("Manual selection YES", "ConfigManager");

                config.launcher = "EGS";
                config.amongUsPath = amongUsPath;
            }
        }

        public static string selectFolderWorker()
        {
            Utils.log("Select folder START", "ConfigManager");
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Filter = "Among Us file|Among Us.exe";
            // Always default to Folder Selection.
            folderBrowser.FileName = "Among Us.exe";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                Utils.log("Select folder YES", "ConfigManager");
                return folderPath;
            }
            Utils.log("Select folder NO", "ConfigManager");
            return null;
        }

        public static InstalledMod getInstalledModById(string id)
        {
            return config.installedMods.Find(i => i.id == id);
        }

        public static Boolean containsGameVersion(string version)
        {
            return config.installedVanilla.Find(i => i.version == version) != null;
        }

        public static List<Mod> getFavoriteMods()
        {
            if (config.favoriteMods.Count() == 0)
                return null;

            List<Mod> mods = new List<Mod>();
            foreach (string modId in config.favoriteMods)
            {
                Mod m = ModList.getModById(modId);
                if (m != null)
                {
                    mods.Add(m);
                }
            }
            return mods;
        }

        public static Boolean isFavoriteMod(string modId)
        {
            return config.favoriteMods.Contains(modId);
        }

        public static void removeFavoriteMod(string modId)
        {
            config.favoriteMods.Remove(modId);
        }

        public static void addFavoriteMod(string modId)
        {
            config.favoriteMods.Add(modId);
            config.favoriteMods.Sort();
        }

        public static void logConfig()
        {
            Utils.log("Computer information", "ConfigManager");
            try
            {
                ComputerInfo c = new ComputerInfo();
                decimal ram = c.TotalPhysicalMemory;
                ram = Math.Round(ram / (1024 * 1024 * 1024), 1);
                Utils.log("- OS Version: " + c.OSFullName, "ConfigManager");
                Utils.log("- OS Language: " + c.InstalledUICulture.Name, "ConfigManager");
                Utils.log("- Processor: " + System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"), "ConfigManager");
                Utils.log("- RAM: " + ram.ToString() + "Go", "ConfigManager");
                Utils.log("- Drives:", "ConfigManager");
                foreach (DriveInfo d in DriveInfo.GetDrives())
                {
                    decimal free = d.AvailableFreeSpace;
                    decimal total = d.TotalSize;
                    free = Math.Round(free / (1024 * 1024 * 1024), 1);
                    total = Math.Round(total / (1024 * 1024 * 1024), 1);

                    Utils.log(" - Drive " + d.Name + ":" + free + "/" + total, "ConfigManager");
                }
            } catch (Exception e)
            {
                Utils.logE("Loading computer info FAIL", "ConfigManager");
                Utils.logEx(e, "ConfigManager");
            }
            
        }
    }

}
