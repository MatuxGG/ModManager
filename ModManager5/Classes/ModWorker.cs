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
            Utils.log("Start Steam START", "ModWorker");
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
            Utils.log("Start Steam END", "ModWorker");
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
            Utils.log("Start mod " + m.name + " START", "ModWorker");

            //startSteam();

            if (m.id == "Skeld")
            {
                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);
                Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Skeld.exe");
            }
            else if (m.id == "BetterCrewlink")
            {
                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);
                Process.Start("explorer", o.ToString() + @"\Better-CrewLink.exe");
            }
            else if (m.id == "Challenger" || m.id == "ChallengerBeta")
            {
                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);
                Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Among Us.exe");
            } else
            {
                Boolean modOpen = isGameOpen();
                if (modOpen)
                {
                    return;
                }

                

                string dirPath = (m.type != "local" ? ModManager.appDataPath + @"\mods\" + m.id : ModManager.appDataPath + @"\localMods\" + m.name);

                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("Starting MODNAME ... Please wait...").Replace("MODNAME", m.name);

                if (m.gameVersion == ServerConfig.get("gameVersion").value)
                {
                    Utils.log("Patching on official", "ModWorker");
                    string amongUsPath = ConfigManager.config.amongUsPath;
                    cleanGame(amongUsPath);
                    Utils.DirectoryCopy(dirPath, amongUsPath, true);
                    ConfigManager.config.lastMod = m.id;
                    ConfigManager.update();
                    if (!ModManager.silent)
                        ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);
                    startGame(false);
                } else
                {
                    Utils.log("Patching on vanilla", "ModWorker");
                    string amongUsPath = ModManager.appDataPath + @"\vanilla\" + m.gameVersion;
                    cleanGame(amongUsPath);
                    Utils.DirectoryCopy(dirPath, amongUsPath, true);
                    ConfigManager.config.lastMod = m.id;
                    ConfigManager.update();
                    if (!ModManager.silent)
                        ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);
                    Process.Start("explorer", amongUsPath + @"\Among Us.exe");
                }
                
            }

            Utils.log("Start mod " + m.name + " END", "ModWorker");
        }

        private static void cleanGame(string amongUsPath)
        {
            Utils.log("Clean game START", "ModWorker");
            saveData(amongUsPath);
            Utils.DirectoryDelete(amongUsPath + @"\BepInEx");
            Utils.DirectoryDelete(amongUsPath + @"\mono");
            Utils.FileDelete(amongUsPath + @"\doorstop_config.ini");
            Utils.FileDelete(amongUsPath + @"\winhttp.dll");
            Utils.log("Clean game END", "ModWorker");
        }

        public static void saveData(string amongUsPath)
        {
            Utils.log("Data save START", "ModWorker");
            if (ConfigManager.config.lastMod != null)
            {
                Mod mod = ModList.getModById(ConfigManager.config.lastMod);
                if (mod != null)
                {
                    List<string> tdata = new List<string>() { };
                    tdata.Add(mod.data);
                    tdata.Add("BepInEx/config");
                    foreach (string data in tdata)
                    {
                        Utils.log("Saving data in " + data, "ModWorker");
                        string path = amongUsPath + @"\" + data;
                        string destPath = ModManager.appDataPath + @"\mods\" + mod.id + @"\" + data;
                        if (Directory.Exists(path))
                        {
                            Utils.log("Data directory found", "ModWorker");
                            Utils.DirectoryCopy(path, destPath, true);
                        }
                        if (File.Exists(path))
                        {
                            Utils.log("Data file found", "ModWorker");
                            Utils.FileDelete(destPath);
                            File.Copy(path, destPath);
                        }
                    }
                }
            }
            Utils.log("Data save END", "ModWorker");
        }

        public static Boolean isGameOpen()
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length >= 1)
            {
                Utils.logE("Game already open", "ModWorker");
                MessageBox.Show("An instance of Among Us is already running", "Among Us already running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            return false;
        }

        public static void startGame(Boolean vanilla)
        {
            if (vanilla)
            {
                Utils.log("Start vanilla game START", "ModWorker");
                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", "Vanilla Among Us");
            } else
            {
                Utils.log("Start modded game START", "ModWorker");
            }

            Boolean vanillaOpen = (vanilla && isGameOpen());
            if (vanillaOpen)
            {
                return;
            }
            string amongUsPath;

            // Start from Steam

            Utils.log("Start game from Steam START", "ModWorker");
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
                    Utils.log("Start game from Steam YES", "ModWorker");
                    Process.Start("explorer", "steam://rungameid/945360");
                    return;
                }
            }
            Utils.log("Start game from Steam END", "ModWorker");

            // Start from EGS

            Utils.log("Start game from EGS START", "ModWorker");
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
                    Utils.log("Start game from EGS YES", "ModWorker");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {"com.epicgames.launcher://apps/33956bcb55d4452d8c47e16b94e294bd%3A729a86a5146640a2ace9e8c595414c56%3A963137e4c29d4c79a81323b8fab03a40?action=launch&silent=true"}") { CreateNoWindow = true });
                    return;
                }
            }
            Utils.log("Start game from EGS END", "ModWorker");

            // Else

            Utils.log("Start game from config START", "ModWorker");
            amongUsPath = ConfigManager.config.amongUsPath;
            if (vanilla)
            {
                cleanGame(amongUsPath);
                ConfigManager.config.lastMod = "";
                ConfigManager.update();
            }
            Utils.log("Start game from config YES", "ModWorker");
            Process.Start("explorer", amongUsPath + @"\Among Us.exe");
        }

        public static void installAnyMod(Mod m)
        {
            Utils.log("Install mod " + m.name + " START", "ModWorker");
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
            Utils.log("Install mod " + m.name + " END", "ModWorker");
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
                client.DownloadFile("https://github.com/OhMyGuus/BetterCrewLink/releases/download/v3.0.1/Better-CrewLink-Setup-3.0.1.exe", dlPath);
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
            DownloadWorker.download(ModManager.serverURL + "/skeld", path + @"\Skeld.exe", Translator.get("Downloading Skeld.net...") + "\n(PERCENT)", 0, 100);

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

            DownloadWorker.download(asset.BrowserDownloadUrl, path, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", ModToInstall.name) + "\n(PERCENT)", 0, 50);

            backgroundWorker.ReportProgress(20);

            string appPath = ModManager.appDataPath + @"\mods\" + ModToInstall.id;
            string configPath = appPath + @"\BepInEx\config";
            string configTempPath = ModManager.tempPath + @"\ChallengerConfig";
            Boolean configSaved = false;

            if (Directory.Exists(configPath))
            {
                Utils.DirectoryDelete(configTempPath);
                Utils.DirectoryCopy(configPath, configTempPath, true);
                configSaved = true;
            }

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

            DownloadWorker.download(asset.BrowserDownloadUrl, path, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", ModToInstall.name) + "\n(PERCENT)", 50, 50);

            backgroundWorker.ReportProgress(40);

            ZipFile.ExtractToDirectory(path, appPath);

            if (configSaved)
            {
                Utils.DirectoryCopy(configTempPath, configPath, true);
            }

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
                    ModManagerUI.StatusLabel.Text = Translator.get("Error") + " : " + Translator.get("installation canceled.");
                    finished = true;
                }
            } else
            {
                finished = true;
            }
        }

        public static void UninstallMod(Mod m)
        {
            Utils.log("Uninstall mod " + m.name + " START", "ModWorker");
            if (!finished)
            {
                return;
            }
            finished = false;

            ModManagerUI.StatusLabel.Text = Translator.get("Uninstalling MODNAME, please wait...").Replace("MODNAME", m.name);
            

            InstalledMod im = ConfigManager.getInstalledModById(m.id);
            Utils.DirectoryDelete(ModManager.appDataPath + @"\mods\" + m.id);
            ConfigManager.config.installedMods.Remove(im);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            finished = true;

            ModManagerUI.StatusLabel.Text = Translator.get("MODNAME uninstalled successfully.").Replace("MODNAME", m.name);
            Form currentForm = ModManagerUI.getFormByCategoryId(m.category);
            ModManagerUI.refreshModForm(currentForm);
            Utils.log("Uninstall mod " + m.name + " END", "ModWorker");

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

            int result = installDependencies(m);

            if (result == -1)
            {
                Utils.DirectoryDelete(destPath);
                backgroundWorker.ReportProgress(100);
                return;
            }

            backgroundWorker.ReportProgress(30);

            bool result2 = installFiles(m, result > 0);

            if (!result2)
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
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", ModToInstall.name);
                    Form currentForm = ModManagerUI.getFormByCategoryId(ModToInstall.category);
                    ModManagerUI.refreshModForm(currentForm);
                }
                else
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Error") + " : " + Translator.get("installation canceled.");
                    finished = true;
                }
            } else
            {
                finished = true;
            }
        }

        public static int installDependencies(Mod m)
        {
            Utils.log("Install dependencies for mod " + m.name + " START", "ModWorker");
            string destPath = ModManager.appDataPath + @"\mods\" + m.id;
            int countDep = 0;
            foreach (string dependencie in m.dependencies)
            {
                Utils.log("Install dependency " + dependencie, "ModWorker");
                string tempPath = ModManager.tempPath;
                string tempDestPath = tempPath + @"\" + dependencie + ".zip";
                Utils.FileDelete(tempDestPath);
                countDep++;
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
                Dependency d = DependencyList.getDependencyById(dependencie);
                Utils.log(ModManager.fileURL + "/dep/" + d.file + ".zip", "TEST");
                DownloadWorker.download(ModManager.fileURL + "/dep/" + d.file, tempDestPath, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name) + "\n(PERCENT)", 0, 50);

                try
                {
                    ZipFile.ExtractToDirectory(tempDestPath, destPath);
                }
                catch (Exception e)
                {
                    Utils.logE("Zip extraction FAIL", "ModWorker");
                    Utils.logEx(e, "ModWorker");
                    return -1;
                }
            }
            Utils.log("Install dependencies for mod " + m.name + " END", "ModWorker");
            return countDep;
        }

        public static Boolean installFiles(Mod m, bool hasDependencies)
        {
            Utils.log("Install files for mod " + m.name + " START", "ModWorker");
            if (m.type == "mod")
            {
                foreach (ReleaseAsset tab in m.release.Assets)
                {
                    string fileName = tab.Name;
                    if (fileName.Contains(".zip") && (m.needPattern == null || m.needPattern == "" || fileName.Contains(m.needPattern)) && (m.ignorePattern == null || m.ignorePattern == "" || !fileName.Contains(m.ignorePattern)))
                    {
                        return installZip(m, tab, hasDependencies);
                    }
                }

                foreach (ReleaseAsset tab in m.release.Assets)
                {
                    string fileName = tab.Name;
                    if (fileName.Contains(".dll") && (m.needPattern == "" || fileName.Contains(m.needPattern)) && (m.ignorePattern == "" || !fileName.Contains(m.ignorePattern)))
                    {
                        return installDll(m, tab, hasDependencies);
                    }
                }
            }

            Utils.log("Install files for mod " + m.name + " END", "ModWorker");
            return true;
        }

        

        public static Boolean installDll(Mod m, ReleaseAsset file, bool hasDependencies)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string pluginsPath = ModManager.appDataPath + @"\mods\" + m.id + @"\BepInEx\plugins";
            Directory.CreateDirectory(pluginsPath);
            Utils.log("Install dll file " + fileName + " START", "ModWorker");

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
            DownloadWorker.download(fileUrl, pluginsPath + @"\" + fileName, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name) + "\n(PERCENT)", (hasDependencies ? 50 : 0), (hasDependencies ? 50 : 100));
            Utils.log("Install dll file " + fileName + " END", "ModWorker");
            return true;
        }

        public static Boolean installZip(Mod m, ReleaseAsset file, bool hasDependencies)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string zipPath = ModManager.tempPath + @"\" + fileName;
            string modPath = ModManager.appDataPath + @"\mods\" + m.id;
            Utils.log("Install zip file " + fileName + " START", "ModWorker");

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

            DownloadWorker.download(fileUrl, zipPath, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name) + "\n(PERCENT)", (hasDependencies ? 50 : 0), (hasDependencies ? 50 : 100));

            string newPath = ModManager.tempPath + @"\ModZip";

            Utils.DirectoryDelete(newPath);
            Directory.CreateDirectory(newPath);
            ZipFile.ExtractToDirectory(zipPath, newPath);
            newPath = getBepInExInsideRec(newPath);
            Utils.DirectoryCopy(newPath, modPath, true);
            
            Utils.log("Install zip file " + fileName + " END", "ModWorker");

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
