using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class ModWorker
    {
        private static Mod ModToInstall;
        public static Boolean finished;

        public static void load()
        {
            finished = true;
        }

        public static void startTransaction()
        {
            while (ModWorker.finished == false)
            {

            }
            ModWorker.finished = false;
        }

        public static void endTransaction()
        {
            ModWorker.finished = true;
        }

        public static void startSteam()
        {
            if (!finished)
            {
                return;
            }
            finished = false;
            BackgroundWorker backgroundWorkerSteam = new BackgroundWorker();
            backgroundWorkerSteam.WorkerReportsProgress = true;
            backgroundWorkerSteam.DoWork += new DoWorkEventHandler(backgroundWorkerSteam_DoWork);
            backgroundWorkerSteam.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerSteam_RunWorkerCompleted);
            backgroundWorkerSteam.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerSteam_ProgressChanged);
            backgroundWorkerSteam.RunWorkerAsync();

        }

        private static void backgroundWorkerSteam_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            if (System.Diagnostics.Process.GetProcessesByName("Steam").Length < 1)
            {
                Process.Start("explorer", "steam://");
                backgroundWorker.ReportProgress(10);
            }

            while (System.Diagnostics.Process.GetProcessesByName("Steam").Length < 1)
            {

            }

            finished = true;
            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerSteam_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!ModManager.silent)
            {
                switch (e.ProgressPercentage)
                {
                    case 10:
                        ModManagerUI.StatusLabel.Text = Translator.get("Starting Steam...");
                        break;
                }
            }

            
        }

        private static void backgroundWorkerSteam_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ModManager.silent)
            {
                if (finished)
                {
                    ModManagerUI.StatusLabel.Text =  Translator.get("Steam started.");
                }
            }
            else
            {
                finished = true;
            }
        }

        public static void startMod(Mod m)
        {
            Utils.log("[ModWorker] Starting mod " + m.name);

            //startSteam();

            if (m.id == "Skeld")
            {
                Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Skeld.exe");
            }
            else if (m.id == "BetterCrewlink")
            {
                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                Process.Start("explorer", o.ToString() + @"\Better-CrewLink.exe");
            }
            else if (m.id == "Challenger" || m.id == "ChallengerBeta")
            {
                Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Among Us.exe");
            } else
            {
                Boolean modOpen = isGameOpen();
                if (modOpen)
                {
                    return;
                }

                string dirPath = (m.type != "local" ? ModManager.appDataPath + @"\mods\" + m.id : ModManager.appDataPath + @"\localMods\" + m.name);

                if (m.gameVersion == ServerConfig.get("gameVersion").value)
                {
                    string amongUsPath = ConfigManager.config.amongUsPath;
                    cleanGame(amongUsPath);
                    Utils.DirectoryCopy(dirPath, amongUsPath, true);
                    ConfigManager.config.lastMod = m.id;
                    ConfigManager.update();
                    startGame(false);
                } else
                {
                    string amongUsPath = ModManager.appDataPath + @"\vanilla\" + m.gameVersion;
                    cleanGame(amongUsPath);
                    Utils.DirectoryCopy(dirPath, amongUsPath, true);
                    ConfigManager.config.lastMod = m.id;
                    ConfigManager.update();
                    Process.Start("explorer", amongUsPath + @"\Among Us.exe");
                }
                
            }
        }

        

        private static void cleanGame(string amongUsPath)
        {
            Utils.log("[ModWorker] Cleaning game");
            saveData(amongUsPath);
            Utils.DirectoryDelete(amongUsPath + @"\BepInEx");
            Utils.DirectoryDelete(amongUsPath + @"\mono");
            Utils.FileDelete(amongUsPath + @"\doorstop_config.ini");
            Utils.FileDelete(amongUsPath + @"\winhttp.dll");
        }

        public static void saveData(string amongUsPath)
        {
            Utils.log("[ModWorker] Saving data");
            if (ConfigManager.config.lastMod != null)
            {
                Mod mod = ModList.getModById(ConfigManager.config.lastMod);
                if (mod != null)
                {
                    foreach (string data in mod.data)
                    {
                        string path = amongUsPath + @"\" + data;
                        string destPath = ModManager.appDataPath + @"\mods\" + mod.id + @"\" + data;
                        if (Directory.Exists(path))
                        {
                            Utils.DirectoryCopy(path, destPath, true);
                            
                        }
                        if (File.Exists(path))
                        {
                            Utils.FileDelete(destPath);
                            File.Copy(path, destPath);
                        }
                    }
                }
            }
        }

        public static Boolean isGameOpen()
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length >= 1)
            {
                    MessageBox.Show("An instance of Among Us is already running", "Among Us already running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            return false;
        }

        public static void startGame(Boolean vanilla)
        {
            if (vanilla)
                Utils.log("[ModWorker] Starting game");
            Boolean vanillaOpen = (vanilla && isGameOpen());
            if (vanillaOpen)
            {
                return;
            }
            string amongUsPath;

            // Start from Steam

            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);
            
            if (myKey != null)
            {
                amongUsPath = (String)myKey.GetValue("InstallLocation");
                if (amongUsPath == ConfigManager.config.amongUsPath && File.Exists(amongUsPath + @"\Among Us.exe"))
                {
                    if (vanilla)
                    {
                        cleanGame(amongUsPath);
                        ConfigManager.config.lastMod = "";
                        ConfigManager.update();
                    }
                    Process.Start("explorer", "steam://rungameid/945360");
                    return;
                }
            }

            // Start from EGS

            amongUsPath = null;
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                amongUsPath = d.Name + @"Program Files\Epic Games\AmongUs";
                if (amongUsPath == ConfigManager.config.amongUsPath && File.Exists(amongUsPath + @"\Among Us.exe"))
                {
                    if (vanilla)
                    {
                        cleanGame(amongUsPath);
                        ConfigManager.config.lastMod = "";
                        ConfigManager.update();
                    }
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {"com.epicgames.launcher://apps/33956bcb55d4452d8c47e16b94e294bd%3A729a86a5146640a2ace9e8c595414c56%3A963137e4c29d4c79a81323b8fab03a40?action=launch&silent=true"}") { CreateNoWindow = true });
                    return;
                }
            }

            // Else

            amongUsPath = ConfigManager.config.amongUsPath;
            if (vanilla)
            {
                cleanGame(amongUsPath);
                ConfigManager.config.lastMod = "";
                ConfigManager.update();
            }
            Process.Start("explorer", amongUsPath + @"\Among Us.exe");
        }

        public static void installAnyMod(Mod m)
        {
            Utils.log("[ModWorker] Installing mod " + m.name);
            if (m.id == "Challenger")
            {
                ModWorker.installChallenger(true);
            }
            else if(m.id == "ChallengerBeta")
            {
                ModWorker.installChallenger(false);
            }
            else if (m.id == "Skeld")
            {
                ModWorker.installSkeld(m);
            }
            else if (m.id == "BetterCrewlink")
            {
                ModWorker.installBetterCrewlink(m);
            }
            else
            {
                ModWorker.installMod(m);
            }
        }

        public static void installBetterCrewlink(Mod m)
        {
            if (!finished)
            {
                return;
            }

            finished = false;
            
            string dlPath = ModManager.tempPath + @"\Better-CrewLink-Setup.exe";

            using (var client = new WebClient())
            {
                client.DownloadFile(ModManager.serverURL + @"\bcl", dlPath);
            }
            Process.Start("explorer", dlPath);

            Boolean installed = false;
            while (!installed)
            {
                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                if (o != null && System.IO.File.Exists(o.ToString() + "\\Better-CrewLink.exe"))
                {
                    installed = true;
                }
            }

            if (!ModManager.silent)
            {
                ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", "Better Crewlink");

                Form currentForm = ModManagerUI.getFormByCategoryId(m.category);
                ModManagerUI.refreshModForm(currentForm);
            }

            finished = true;

        }

        public static void installSkeld(Mod m)
        {
            if (!finished)
            {
                return;
            }

            finished = false;
            //if (!ModManager.silent)
            //    ModManagerUI.StatusLabel.Text = "Downloading Skeld.net...";

            string path = ModManager.appDataPath + @"\mods\Skeld";

            Directory.CreateDirectory(path);

            /*
            using (var client = new WebClient())
            {
                client.DownloadFile(ModManager.serverURL + "/skeld",  path + @"\Skeld.exe");
            }
            */
            DownloadWorker.download(ModManager.serverURL + "/skeld", path + @"\Skeld.exe", "Downloading Skeld.net... (PERCENT%)");

            InstalledMod newMod = new InstalledMod("Skeld", "", "");
            ConfigManager.config.installedMods.Add(newMod);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            if (!ModManager.silent)
            {
                ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", "Skeld.net");

                Form currentForm = ModManagerUI.getFormByCategoryId(m.category);
                ModManagerUI.refreshModForm(currentForm);
            }

            finished = true;
        }

        public static void installChallenger(Boolean live)
        {
            if (!finished)
            {
                return;
            }
            finished = false;
            if (live)
            {
                ModToInstall = ModList.getModById("Challenger");
            } else
            {
                ModToInstall = ModList.getModById("ChallengerBeta");
            }
            BackgroundWorker backgroundWorkerChallenger = new BackgroundWorker();
            backgroundWorkerChallenger.WorkerReportsProgress = true;
            backgroundWorkerChallenger.DoWork += new DoWorkEventHandler(backgroundWorkerChallenger_DoWork);
            backgroundWorkerChallenger.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerChallenger_RunWorkerCompleted);
            backgroundWorkerChallenger.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerChallenger_ProgressChanged);
            backgroundWorkerChallenger.RunWorkerAsync();
        }

        private static void backgroundWorkerChallenger_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;


            backgroundWorker.ReportProgress(10);

            ReleaseAsset asset = new ReleaseAsset();

            foreach (ReleaseAsset ra in ModList.challengerClient.Assets)
            {
                if (ra.Name.Contains("zip"))
                {
                    asset = ra;
                    break;
                }
            }

            string path = ModManager.tempPath + @"\" + asset.Name;
            Utils.FileDelete(path);

            /*
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(new Uri(asset.BrowserDownloadUrl), path);
                }
            }
            catch
            {
                backgroundWorker.ReportProgress(100);
                return;
            }
            */

            DownloadWorker.download(asset.BrowserDownloadUrl, path, "Installing " + ModToInstall.name + ", please wait...\nInstalling client... (PERCENT%)");

            backgroundWorker.ReportProgress(20);

            string appPath = ModManager.appDataPath + @"\mods\" + ModToInstall.id;

            Utils.DirectoryDelete(appPath);
            Directory.CreateDirectory(appPath);

            ZipFile.ExtractToDirectory(path, appPath);

            backgroundWorker.ReportProgress(30);

            foreach (ReleaseAsset ra in ModToInstall.release.Assets)
            {
                if (ra.Name.Contains("zip"))
                {
                    asset = ra;
                    break;
                }
            }

            path = ModManager.tempPath + @"\" + asset.Name;

            /*
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(new Uri(asset.BrowserDownloadUrl), path);
                }
            }
            catch
            {
                backgroundWorker.ReportProgress(100);
                return;
            }
            */
            DownloadWorker.download(asset.BrowserDownloadUrl, path, "Installing " + ModToInstall.name + ", please wait...\nInstalling mod... (PERCENT%)");

            backgroundWorker.ReportProgress(40);

            ZipFile.ExtractToDirectory(path, appPath);

            InstalledMod existingMod = ConfigManager.getInstalledModById(ModToInstall.id);
            if (existingMod != null)
            {
                ConfigManager.config.installedMods.Remove(existingMod);
            }
            InstalledMod newMod = new InstalledMod(ModToInstall.id, ModToInstall.release.TagName, ModToInstall.gameVersion);
            ConfigManager.config.installedMods.Add(newMod);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            finished = true;
            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerChallenger_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private static void backgroundWorkerChallenger_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ModManager.silent)
            {
                if (finished)
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", ModToInstall.name);
                    Form currentForm = ModManagerUI.getFormByCategoryId(ModToInstall.category);
                    ModManagerUI.refreshModForm(currentForm);
                }
                else
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Error : installation canceled.");
                    finished = true;
                }
            } else
            {
                finished = true;
            }
        }

        public static void UninstallMod(Mod m)
        {
            Utils.log("[ModWorker] Uninstalling mod " + m.name);
            if (!finished)
            {
                return;
            }
            finished = false;

            ModManagerUI.StatusLabel.Text = Translator.get("Uninstalling Mod, please wait...");
            

            InstalledMod im = ConfigManager.getInstalledModById(m.id);
            Utils.DirectoryDelete(ModManager.appDataPath + @"\mods\" + m.id);
            ConfigManager.config.installedMods.Remove(im);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            finished = true;

            ModManagerUI.StatusLabel.Text = Translator.get("Mod uninstalled successfully.");
            Form currentForm = ModManagerUI.getFormByCategoryId(m.category);
            ModManagerUI.refreshModForm(currentForm);

        }

        public static void installMod(Mod m)
        {
            if (!finished)
            {
                return;
            }
            finished = false;

            ModToInstall = m;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerAsync();
        }

        private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            Mod m = ModToInstall;

            backgroundWorker.ReportProgress(10);

            InstalledMod im = ConfigManager.getInstalledModById(m.id);
            if (im != null)
            {
                ConfigManager.config.installedMods.Remove(im);
                ConfigManager.update();
            }

            if (!ConfigManager.containsGameVersion(m.gameVersion))
            {
                backgroundWorker.ReportProgress(100);
                return;
            }

            string destPath = ModManager.appDataPath + @"\mods\" + m.id;
            
            Utils.DirectoryDelete(destPath);
            Directory.CreateDirectory(destPath);
            //Utils.DirectoryCopy(ModManager.appDataPath + @"\vanilla\" + m.gameVersion, destPath, true);

            backgroundWorker.ReportProgress(20);

            
            Boolean result = installDependencies(m);

            if (!result)
            {
                Utils.DirectoryDelete(destPath);
                backgroundWorker.ReportProgress(100);
                return;
            }

            backgroundWorker.ReportProgress(30);

            result = installFiles(m);

            if (!result)
            {
                Utils.DirectoryDelete(destPath);
                backgroundWorker.ReportProgress(100);
                return;
            }

            InstalledMod existingMod = ConfigManager.getInstalledModById(ModToInstall.id);
            if (existingMod != null)
            {
                ConfigManager.config.installedMods.Remove(existingMod);
            }
            InstalledMod newMod = new InstalledMod(m.id, m.release.TagName, m.gameVersion);
            ConfigManager.config.installedMods.Add(newMod);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            finished = true;
            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ModManager.silent)
            {
                if (finished)
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Mod installed successfully.");
                    Form currentForm = ModManagerUI.getFormByCategoryId(ModToInstall.category);
                    ModManagerUI.refreshModForm(currentForm);
                }
                else
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Error : installation canceled.");
                    finished = true;
                }
            } else
            {
                finished = true;
            }
        }

        public static Boolean installDependencies(Mod m)
        {
            Utils.log("[ModWorker] Installing dependencies for mod " + m.name);
            string destPath = ModManager.appDataPath + @"\mods\" + m.id;
            foreach (string dependencie in m.dependencies)
            {
                Utils.log("[ModWorker] Installing dependency " + dependencie);
                string tempPath = ModManager.tempPath;
                string tempDestPath = tempPath + @"\" + dependencie + ".zip";
                Utils.FileDelete(tempDestPath);
                /*try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(ModManager.apiURL + "/files/dependencies/" + dependencie + ".zip", tempDestPath);
                    }
                }
                catch
                {
                    return false;
                }
                */
                DownloadWorker.download(ModManager.apiURL + "/files/dependencies/" + dependencie + ".zip", tempDestPath, "Installing mod, please wait...\nInstalling dependencies... (PERCENT%)");

                try
                {
                    ZipFile.ExtractToDirectory(tempDestPath, destPath);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean installFiles(Mod m)
        {
            Utils.log("[ModWorker] Installing files for mod " + m.name);
            if (m.type == "mod")
            {
                foreach (ReleaseAsset tab in m.release.Assets)
                {
                    string fileName = tab.Name;
                    if (fileName.Contains(".zip"))
                    {
                        return installZip(m, tab);
                    }
                }

                foreach (ReleaseAsset tab in m.release.Assets)
                {
                    string fileName = tab.Name;
                    if (fileName.Contains(".dll"))
                    {
                        return installDll(m, tab);
                    }
                }
            }

            return true;
        }

        

        public static Boolean installDll(Mod m, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string pluginsPath = ModManager.appDataPath + @"\mods\" + m.id + @"\BepInEx\plugins";
            Directory.CreateDirectory(pluginsPath);
            Utils.log("[ModWorker] Installing dll file " + fileName);

            /*try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(fileUrl, pluginsPath + @"\" + fileName);
                }
            }
            catch
            {
                return false;
            }
            */
            DownloadWorker.download(fileUrl, pluginsPath + @"\" + fileName, "Installing mod, please wait...\nInstalling mod... (PERCENT%)");
            return true;
        }

        public static Boolean installZip(Mod m, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string zipPath = ModManager.tempPath + @"\" + fileName;
            string modPath = ModManager.appDataPath + @"\mods\" + m.id;
            Utils.log("[ModWorker] Installing zip file " + fileName);

            Utils.FileDelete(zipPath);

            /*
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(fileUrl, zipPath);
                }
            }
            catch
            {
                return false;
            }
            */

            DownloadWorker.download(fileUrl, zipPath, "Installing mod, please wait...\nInstalling mod... (PERCENT%)");

            string newPath = ModManager.tempPath + @"\ModZip";

            Utils.DirectoryDelete(newPath);
            Directory.CreateDirectory(newPath);
            ZipFile.ExtractToDirectory(zipPath, newPath);
            newPath = getBepInExInsideRec(newPath);
            Utils.DirectoryCopy(newPath, modPath, true);

            return true;
        }

        public static string getBepInExInsideRec(string path)
        {
            if (Directory.Exists(path + @"\BepInEx"))
            {
                return path;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (getBepInExInsideRec(dir.FullName) != null)
                {
                    return dir.FullName;
                }
            }
            return null;
        }
    }
}
