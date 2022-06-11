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
                if (ServerConfig.get("gameVersion").value != config.currentGameVersion)
                {
                    Utils.log("New vanilla version", "ConfigManager");
                    duplicateVanillaAmongUs();
                }
            } else
            {
                Utils.log("Config does not exist", "ConfigManager");
                // Config doesn't exist
                duplicateVanillaAmongUs();
            }
            Utils.log("Load config END", "ConfigManager");
        }

        public static void duplicateVanillaAmongUs()
        {
            Utils.log("New backup for Vanilla START", "ConfigManager");
            string amongUsPath = null;

            // Search for Among Us path

            // Detection from Steam
            Utils.log("Steam detection START", "ConfigManager");
            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);

            if (myKey != null)
            {
                Utils.log("Steam detection YES", "ConfigManager");
                amongUsPath = (String)myKey.GetValue("InstallLocation");
                if (generateFolder(amongUsPath))
                {
                    Utils.log("Steam detection CONFIRM", "ConfigManager");
                    return;
                }
            }
            else
            {
                Utils.log("Steam detection NO", "ConfigManager");
            }
            Utils.log("Steam detection END", "ConfigManager");

            // Detection from Epic Games Store
            Utils.log("EGS detection START", "ConfigManager");
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                amongUsPath = d.Name + @"Program Files\Epic Games\AmongUs";
                if (generateFolder(amongUsPath))
                {
                    Utils.log("EGS detection YES", "ConfigManager");
                    Utils.log("EGS detection END", "ConfigManager");
                    return;
                }
            }
            Utils.log("EGS detection END", "ConfigManager");


            Utils.log("Config detection START", "ConfigManager");
            if (config.amongUsPath != null && config.amongUsPath != "")
            {
                Utils.log("Config detection YES", "ConfigManager");
                amongUsPath = config.amongUsPath;
                if (generateFolder(amongUsPath))
                {
                    Utils.log("Config detection CONFIRM", "ConfigManager");
                    return;
                }
            }
            Utils.log("Config detection END", "ConfigManager");
            // No Among Us found

            Utils.log("Manual selection START", "ConfigManager");
            amongUsPath = null;
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
            if (generateFolder(amongUsPath))
            {
                Utils.log("Manual selection CONFIRM", "ConfigManager");
                return;
            }
        }

        public static Boolean generateFolder(string path)
        {
            Utils.log("Vanilla creation START", "ConfigManager");
            if (File.Exists(path + @"\Among Us.exe"))
            {
                Utils.log("Vanilla creation YES", "ConfigManager");
                string latest = ServerConfig.get("gameVersion").value;
                string destPath = ModManager.appDataPath + @"\vanilla\" + latest;
                Directory.CreateDirectory(destPath);

                Utils.DirectoryCopy(path, destPath, true);
                config.installedVanilla.Add(new InstalledVanilla(latest));
                config.currentGameVersion = latest;
                config.amongUsPath = path;
                update();
                Utils.log("Vanilla creation CONFIRM", "ConfigManager");
                return true;
            }
            Utils.log("Vanilla creation NO", "ConfigManager");
            return false;
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

        public static InstalledMod getInstalledModById(string id)
        {
            return config.installedMods.Find(i => i.id == id);
        }

        public static Boolean containsGameVersion(string version)
        {
            return config.installedVanilla.Find(i => i.version == version) != null;
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
