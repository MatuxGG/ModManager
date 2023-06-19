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

namespace ModManager6.Classes
{
    public static class ConfigManager
    {
        public static Config config;
        public static string path = ModManager.appDataPath + @"\config6.conf";

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

    }

}