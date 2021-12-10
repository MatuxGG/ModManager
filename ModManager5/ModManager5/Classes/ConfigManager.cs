using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public static string path = ModManager.appDataPath + @"\config5.conf";

        public static void load()
        {
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Loading Local Config...";
            config = new Config();
            if (File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                if (ServerConfig.get("gameVersion").value != config.currentGameVersion)
                {
                    duplicateVanillaAmongUs();
                }
                return;
            } else
            {
                // Config doesn't exist
                duplicateVanillaAmongUs();
            }
        }

        public static void duplicateVanillaAmongUs()
        {
            string amongUsPath = null;
            
            // Search for Among Us path

            // Detection from Steam
            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);

            if (myKey != null)
            {
                amongUsPath = (String)myKey.GetValue("InstallLocation");
                generateFolder(amongUsPath);
                return;
            }
            else
            {

            }

            // Detection from Epic Games Store

            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                amongUsPath = d.Name + @"Program Files\Epic Games\AmongUs";
                generateFolder(amongUsPath);
                return;
            }

            if (config.amongUsPathHistory != null && config.amongUsPathHistory != "")
            {
                amongUsPath = config.amongUsPathHistory;
                generateFolder(amongUsPath);
                return;
            }
            // No Among Us found

            amongUsPath = null;
            while (amongUsPath == null || File.Exists(amongUsPath + @"\Among Us.exe") == false)
            {
                if (MessageBox.Show("Among Us not found ! Please, select the Among Us executable", "Among Us not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
                amongUsPath = selectFolderWorker();
            }
            generateFolder(amongUsPath);
            return;
        }

        public static void generateFolder(string path)
        {
            if (File.Exists(path + @"\Among Us.exe"))
            {
                string latest = ServerConfig.get("gameVersion").value;
                string destPath = ModManager.appDataPath + @"\vanilla\" + latest;
                Directory.CreateDirectory(destPath);

                Utils.DirectoryCopy(path, destPath, true);
                config.installedVanilla.Add(latest);
                config.currentGameVersion = latest;
                config.amongUsPathHistory = path;
                update();
            }
            return;
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

        public static InstalledMod getInstalledModById(string id)
        {
            return config.installedMods.Find(i => i.id == id);
        }

        public static Boolean containsGameVersion(string version)
        {
            return config.installedVanilla.Find(i => i == version) != null;
        }

    }

}
