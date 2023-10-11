using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using ModManager6.Classes;
using ModManager6;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace ModManager6.Classes
{
    public static class ConfigManager
    {
        public static Config config;
        public static string path = ModManager.appDataPath + @"\config6.json";

        public static void load()
        {
            config = new Config();
            if (File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
            }
        }

        public static void updateAmongUs()
        {
            updateAmongUsPathIfNeeded();
            updateAvailablePathsIfNeeded();
        }

        public static void update()
        {
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(path, json);
        }

        public static void updateAvailablePathsIfNeeded()
        {
            if (ConfigManager.config.availableAmongUsPaths == null)
            {
                ConfigManager.config.availableAmongUsPaths = new List<string>() { };
            }
            List<string> toRemove = new List<string>() { };
            foreach (string path in ConfigManager.config.availableAmongUsPaths)
            {
                try
                {
                    if (!File.Exists(path + @"\Among Us.exe"))
                    {
                        toRemove.Add(path);
                    }
                }
                catch (Exception ex)
                {
                    toRemove.Add(path);
                    Log.logError("ConfigManager", ex.Source, ex.Message);
                    // Access denied
                }

            }
            if (toRemove.Count > 0)
                ConfigManager.config.availableAmongUsPaths.RemoveAll(path => toRemove.Contains(path));

            addAvailableAmongUsPath(ConfigManager.config.amongUsPath);
            addAvailableAmongUsPath(getSteamAmongUsPath());
            ConfigManager.update();
        }

        public static void addAvailableAmongUsPath(string path)
        {
            try
            {
                if (path != null && !ConfigManager.config.availableAmongUsPaths.Contains(path))
                {
                    ConfigManager.config.availableAmongUsPaths.Add(path);
                }
            }
            catch (Exception ex)
            {
                Log.logError("ConfigManager", ex.Source, ex.Message);
                // Access denied
            }
        }

        public static void updateAmongUsPathIfNeeded()
        {
            if (ConfigManager.config.amongUsPath == null || ConfigManager.config.amongUsPath == "" || !File.Exists(ConfigManager.config.amongUsPath + @"\Among Us.exe"))
            {
                string amongUsPath = getSteamAmongUsPath();

                if (amongUsPath != null)
                {
                    config.amongUsPath = amongUsPath;
                    return;
                }

                // Else

                while (amongUsPath == null || File.Exists(amongUsPath + @"\Among Us.exe") == false)
                {
                    if (MessageBox.Show(Translator.get("Among Us not found ! Please, select the Among Us executable"), Translator.get("Among Us not found"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        Environment.Exit(0);
                    }
                    amongUsPath = selectFolderWorker();
                }

                config.amongUsPath = amongUsPath;
            }
        }


        public static string getSteamAmongUsPath()
        {
            string amongUsPath = null;

            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);

            if (myKey != null)
            {
                amongUsPath = (String)myKey.GetValue("InstallLocation");
                if (amongUsPath != null && File.Exists(amongUsPath + @"\Among Us.exe"))
                {
                    return amongUsPath;
                }
            }
            return null;
        }

        public static bool isBetterCrewlinkInstalled()
        {
            object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
            return o != null && System.IO.File.Exists(o.ToString() + @"\Better-CrewLink.exe");
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

        public static InstalledMod getInstalledMod(string modId, string gameVersion)
        {
            return config.installedMods.Find(im => im.id == modId && im.gameVersion == gameVersion);
        }

        public static bool isInstalled(Mod m, ModVersion v, List<ModOption> options = null)
        {
            if (getInstalledMod(m.id, v.gameVersion) == null) return false;

            if (options == null || options.Count() == 0) return true;

            foreach (ModOption option in options)
            {
                if (getInstalledMod(option.modOption, option.gameVersion) == null) return false;
            }

            return true;
        }

        public static InstalledVanilla getInstalledVanilla(string version)
        {
            return config.installedVanilla.Find(v => v.version == version);
        }

        public static List<ModOption> getActiveOptions(string modId, string gameVersion)
        {
            foreach (ModState ms in config.modStates)
            {
                if (ms.modId == modId && ms.gameVersion == gameVersion)
                {
                    return ms.options;
                }
            }
            return null;
        }

        public static bool isActiveOption(string modId, string gameVersion, ModOption option)
        {
            foreach (ModState ms in config.modStates)
            {
                if (ms.modId == modId && ms.gameVersion == gameVersion)
                {
                    foreach (ModOption mo in ms.options)
                    {
                        if (mo.modOption == option.modOption && mo.gameVersion == option.gameVersion)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static void addActiveOption(string modId, string modGameVersion, ModOption option)
        {
            if (!isActiveOption(modId, modGameVersion, option))
            {
                if (ConfigManager.config.modStates.Find(s => s.modId == modId) == null)
                {
                    ConfigManager.config.modStates.Add(new ModState(modId, modGameVersion, new List<ModOption>() { }));
                }
                ConfigManager.config.modStates.Find(s => s.modId == modId && s.gameVersion == modGameVersion).options.Add(option);
            }
            ConfigManager.update();
        }

        public static void removeActiveOption(string modId, string modGameVersion, ModOption option)
        {
            if (isActiveOption(modId, modGameVersion, option))
            {
                List<ModOption> mos = ConfigManager.config.modStates.Find(s => s.modId == modId && s.gameVersion == modGameVersion).options;
                foreach (ModOption mo in mos)
                {
                    if (mo.gameVersion == option.gameVersion && mo.modOption == option.modOption)
                    {
                        mos.Remove(mo);
                        break;
                    }
                }
            }
            ConfigManager.update();
        }

        public static string getActiveGameVersion(string modId)
        {
            ModState ms = ConfigManager.config.modStates.Find(s => s.modId == modId);
            if (ms == null) return null;
            return ms.gameVersion;
        }

        public static string getActiveVersion(string modId)
        {
            string gameVersion = getActiveGameVersion(modId);
            if (gameVersion == null) return null;
            InstalledMod m = ConfigManager.getInstalledMod(modId, gameVersion);
            if (m == null) return null;
            return m.version;
        }

        public static void setActiveGameVersion(string modId, string modGameVersion)
        {
            ConfigManager.config.modStates.FindAll(s => s.modId == modId).ForEach(s => ConfigManager.config.modStates.Remove(s));
            ConfigManager.config.modStates.Add(new ModState(modId, modGameVersion, new List<ModOption>() { }));
            ConfigManager.config.modStates.Find(s => s.modId == modId).gameVersion = modGameVersion;
            ConfigManager.update();
        }

        public static bool isAllInOneInstalled(Mod m)
        {
            if (m.id == "Challenger")
            {
                return isChallengerInstalled();
            } else if (m.id == "BetterCrewlink")
            {
                return isBetterCrewlinkInstalled();
            } else
            {
                return false;
            }
        }

        public static bool isChallengerInstalled()
        {
            RegistryKey challKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 2160150", false);
            return challKey != null;
        }

        public static bool isBclInstalled()
        {
            object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
            return o != null && System.IO.File.Exists(o.ToString() + @"\Better-CrewLink.exe");
        }

        public static bool needUpdate(Mod m, string gameVersion, string version)
        {
            InstalledMod im = ConfigManager.getInstalledMod(m.id, gameVersion);
            if (im == null) return false;
            if (im.version != version) return true;
            ModVersion versionObj = m.versions.FindAll(ver => ver.gameVersion == gameVersion).First();
            List<ModOption> options = ConfigManager.getActiveOptions(m.id, versionObj.gameVersion);
            if (options == null) return false;
            foreach (ModOption option in options)
            {
                InstalledMod imOption = ConfigManager.getInstalledMod(option.modOption, option.gameVersion);
                if (imOption == null) continue;
                if (imOption.version != versionObj.version)
                {
                    return true;
                }
            }
            return false;
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
    }

}