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
            try
            {
                config = new Config();
                if (File.Exists(path))
                {
                    string json = System.IO.File.ReadAllText(path);
                    config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

            FileSystem.DirectoryCreate(config.dataPath + @"\vanilla");
            FileSystem.DirectoryCreate(config.dataPath + @"\mods");
        }

        public static void updateAmongUs()
        {
            updateAmongUsPathIfNeeded();
            updateAvailablePathsIfNeeded();
        }

        public static void update()
        {
            try
            {
                string json = JsonConvert.SerializeObject(config);
                File.WriteAllText(path, json);
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void updateAvailablePathsIfNeeded()
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
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
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }


        public static string getSteamAmongUsPath()
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static bool isBetterCrewlinkInstalled()
        {
            try
            {

                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                return o != null && System.IO.File.Exists(o.ToString() + @"\Better-CrewLink.exe");
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static string selectFolderWorker()
        {
            try
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

            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static InstalledMod getInstalledMod(string modId, string gameVersion)
        {
            try
            {
                return config.installedMods.Find(im => im.id == modId && im.gameVersion == gameVersion);
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            } 
        }

        public static bool isInstalled(Mod m, ModVersion v, List<ModOption> options = null)
        {
            try
            {

                if (getInstalledMod(m.id, v.gameVersion) == null) return false;

                if (options == null || options.Count() == 0) return true;

                foreach (ModOption option in options)
                {
                    if (getInstalledMod(option.modOption, option.gameVersion) == null) return false;
                }

                return true;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static InstalledVanilla getInstalledVanilla(string version)
        {
            try
            {
                return config.installedVanilla.Find(v => v.version == version);
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static List<ModOption> getActiveOptions(string modId, string gameVersion)
        {
            try
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
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static bool isActiveOption(string modId, string gameVersion, ModOption option)
        {
            try
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
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static void addActiveOption(string modId, string modGameVersion, ModOption option)
        {
            try
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
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void removeActiveOption(string modId, string modGameVersion, ModOption option)
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static string getActiveGameVersion(string modId)
        {
            try
            {

                ModState ms = ConfigManager.config.modStates.Find(s => s.modId == modId);
                if (ms == null) return null;
                return ms.gameVersion;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static string getActiveVersion(string modId)
        {
            try
            {

                string gameVersion = getActiveGameVersion(modId);
                if (gameVersion == null) return null;
                InstalledMod m = ConfigManager.getInstalledMod(modId, gameVersion);
                if (m == null) return null;
                return m.version;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static void setActiveGameVersion(string modId, string modGameVersion)
        {
            try
            {
                ConfigManager.config.modStates.FindAll(s => s.modId == modId).ForEach(s => ConfigManager.config.modStates.Remove(s));
                ConfigManager.config.modStates.Add(new ModState(modId, modGameVersion, new List<ModOption>() { }));
                ConfigManager.config.modStates.Find(s => s.modId == modId).gameVersion = modGameVersion;
                ConfigManager.update();
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static bool isAllInOneInstalled(Mod m)
        {
            try
            {
                if (m.id == "Challenger")
                {
                    return isChallengerInstalled();
                }
                else if (m.id == "BetterCrewlink")
                {
                    return isBetterCrewlinkInstalled();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static bool isChallengerInstalled()
        {
            try
            {
                RegistryKey challKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 2160150", false);
                return challKey != null;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static bool isBclInstalled()
        {
            try
            {
                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                return o != null && System.IO.File.Exists(o.ToString() + @"\Better-CrewLink.exe");
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static bool needUpdate(Mod m, string gameVersion, string version)
        {
            try
            {
                if (ModList.getLocalMod(m.id) != null) return false;
                InstalledMod im = ConfigManager.getInstalledMod(m.id, gameVersion);
                if (im == null) return false;
                if (im.version != version) return true;
                ModVersion versionObj = m.versions.FindAll(ver => ver.gameVersion == gameVersion).FirstOrDefault();
                List<ModOption> options = ConfigManager.getActiveOptions(m.id, versionObj.gameVersion);
                if (options == null) return false;
                foreach (ModOption option in options)
                {
                    InstalledMod imOption = ConfigManager.getInstalledMod(option.modOption, option.gameVersion);
                    if (imOption == null) continue;
                    Mod mOption = ModList.getModById(option.modOption);
                    if (mOption == null) continue;
                    ModVersion oVersion = mOption.versions.FindAll(ver => ver.gameVersion == option.gameVersion).FirstOrDefault();
                    if (oVersion == null) continue;
                    if (imOption.version != oVersion.version)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static List<Mod> getFavoriteMods()
        {
            try
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
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }
        public static Boolean isFavoriteMod(string modId)
        {
            try
            {
                return config.favoriteMods.Contains(modId);
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static void removeFavoriteMod(string modId)
        {
            try
            {
                config.favoriteMods.Remove(modId);
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void addFavoriteMod(string modId)
        {
            try
            {
                config.favoriteMods.Add(modId);
                config.favoriteMods.Sort();
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }

}