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
            globalConfig = new GlobalConfig();
            if (File.Exists(globalPath))
            {
                string json = System.IO.File.ReadAllText(globalPath);
                globalConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<GlobalConfig>(json);
                
                if (globalConfig.lg == "English")
                {
                    globalConfig.lg = "EN";
                    updateGlobalConfig();
                }

                return;
            }
            else
            {
                updateGlobalConfig();
            }
        }

        public static void load()
        {
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Loading Local Config...";
            config = new Config();
            Utils.log("[ConfigManager] Starting config detection");
            if (File.Exists(path))
            {
                Utils.log("[ConfigManager] Config detected");
                string json = System.IO.File.ReadAllText(path);
                config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                if (ServerConfig.get("gameVersion").value != config.currentGameVersion)
                {
                    duplicateVanillaAmongUs();
                }
                return;
            } else
            {
                Utils.log("[ConfigManager] Config not detected");
                // Config doesn't exist
                duplicateVanillaAmongUs();
            }
        }

        public static void duplicateVanillaAmongUs()
        {
            Utils.log("[ConfigManager] Creating new backup for vanilla Among Us");
            string amongUsPath = null;

            // Search for Among Us path

            // Detection from Steam
            Utils.log("[ConfigManager] Starting detection from Steam");
            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);

            if (myKey != null)
            {
                amongUsPath = (String)myKey.GetValue("InstallLocation");
                if (generateFolder(amongUsPath))
                {
                    return;
                }
            }
            else
            {

            }

            // Detection from Epic Games Store
            Utils.log("[ConfigManager] Starting detection from EGS");
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                amongUsPath = d.Name + @"Program Files\Epic Games\AmongUs";
                if (generateFolder(amongUsPath))
                {
                    return;
                }
            }

            
            if (config.amongUsPath != null && config.amongUsPath != "")
            {
                Utils.log("[ConfigManager] Among Us path detected in Config");
                amongUsPath = config.amongUsPath;
                if (generateFolder(amongUsPath))
                {
                    return;
                }
            }
            // No Among Us found

            Utils.log("[ConfigManager] Among Us path not detected, manual selection starts");
            amongUsPath = null;
            while (amongUsPath == null || File.Exists(amongUsPath + @"\Among Us.exe") == false)
            {
                if (MessageBox.Show("Among Us not found ! Please, select the Among Us executable", "Among Us not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
                amongUsPath = selectFolderWorker();
            }
            if (generateFolder(amongUsPath))
            {
                return;
            }
        }

        public static Boolean generateFolder(string path)
        {
            if (File.Exists(path + @"\Among Us.exe"))
            {
                Utils.log("[ConfigManager] Among Us path validated");
                string latest = ServerConfig.get("gameVersion").value;
                string destPath = ModManager.appDataPath + @"\vanilla\" + latest;
                Directory.CreateDirectory(destPath);

                Utils.DirectoryCopy(path, destPath, true);
                config.installedVanilla.Add(new InstalledVanilla(latest));
                config.currentGameVersion = latest;
                config.amongUsPath = path;
                update();
                return true;
            }
            return false;
        }
        
        public static string selectFolderWorker()
        {
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
                return folderPath;
            }
            return null;
        }

        public static void update()
        {
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(path, json);
        }

        public static void updateGlobalConfig()
        {
            string json = JsonConvert.SerializeObject(globalConfig);
            File.WriteAllText(globalPath, json);
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
            string ret = "[ConfigManager] OS Version : " + System.Environment.OSVersion.ToString();
            Utils.log(ret);
        }
    }

}
