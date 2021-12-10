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

        public static void startMod(Mod m)
        {
            if (m.id == "Skeld")
            {
                Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Skeld.exe");
            }
            else if (m.id == "BetterCrewlink")
            {
                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                Process.Start("explorer", o.ToString() + @"\Better-CrewLink.exe");
            }
            else
            {
                Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Among Us.exe");
            }
        }

        public static void startVanilla()
        {
            string amongUsPath;

            // Start from Steam

            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);
            
            if (myKey != null)
            {
                amongUsPath = (String)myKey.GetValue("InstallLocation");
                if (amongUsPath == ConfigManager.config.amongUsPathHistory && File.Exists(amongUsPath + @"\Among Us.exe"))
                {
                    Process.Start("explorer", "steam://rungameid/945360");
                    return;
                }
            }

            // Start from EGS

            amongUsPath = null;
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                amongUsPath = d.Name + @"Program Files\Epic Games\AmongUs";
                if (amongUsPath == ConfigManager.config.amongUsPathHistory && File.Exists(amongUsPath + @"\Among Us.exe"))
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {"com.epicgames.launcher://apps/33956bcb55d4452d8c47e16b94e294bd%3A729a86a5146640a2ace9e8c595414c56%3A963137e4c29d4c79a81323b8fab03a40?action=launch&silent=true"}") { CreateNoWindow = true });
                    return;
                }
            }

            // Else

            Process.Start("explorer", ConfigManager.config.amongUsPathHistory + @"\Among Us.exe");
        }

        public static void installAnyMod(Mod m)
        {
            if (m.id == "Challenger")
            {
                ModWorker.installChallenger();
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
            
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Downloading Better Crewlink...";

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
                ModManagerUI.StatusLabel.Text = "Better Crewlink installed successfully !";

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
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Downloading Skeld.net...";

            string path = ModManager.appDataPath + @"\mods\Skeld";

            Directory.CreateDirectory(path);

            using (var client = new WebClient())
            {
                client.DownloadFile(ModManager.serverURL + "/skeld",  path + @"\Skeld.exe");
            }

            InstalledMod newMod = new InstalledMod("Skeld", "", "");
            ConfigManager.config.installedMods.Add(newMod);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            if (!ModManager.silent)
            {
                ModManagerUI.StatusLabel.Text = "Skeld.net successfully installed !";

                Form currentForm = ModManagerUI.getFormByCategoryId(m.category);
                ModManagerUI.refreshModForm(currentForm);
            }

            finished = true;
        }

        public static void installChallenger()
        {
            if (!finished)
            {
                return;
            }
            finished = false;
            ModToInstall = ModList.getModById("Challenger");
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
            }
            backgroundWorker.ReportProgress(20);

            string appPath = ModManager.appDataPath + @"\mods\Challenger";

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
            }

            backgroundWorker.ReportProgress(40);

            ZipFile.ExtractToDirectory(path, appPath);

            InstalledMod newMod = new InstalledMod("Challenger", ModToInstall.release.TagName, ModToInstall.gameVersion);
            ConfigManager.config.installedMods.Add(newMod);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            finished = true;
            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerChallenger_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!ModManager.silent)
            {
                switch (e.ProgressPercentage)
                {
                    case 10:
                        ModManagerUI.StatusLabel.Text = "Installing Challenger, please wait... Downloading client...";
                        break;
                    case 20:
                        ModManagerUI.StatusLabel.Text = "Installing Challenger, please wait... Installating client...";
                        break;
                    case 30:
                        ModManagerUI.StatusLabel.Text = "Installing Challenger, please wait... Downloading mod...";
                        break;
                    case 40:
                        ModManagerUI.StatusLabel.Text = "Installing Challenger, please wait... Installing mod...";
                        break;
                }
            }
        }

        private static void backgroundWorkerChallenger_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ModManager.silent)
            {
                if (finished)
                {
                    ModManagerUI.StatusLabel.Text = "Challenger successfully installed !";
                    Form currentForm = ModManagerUI.getFormByCategoryId(ModToInstall.category);
                    ModManagerUI.refreshModForm(currentForm);
                }
                else
                {
                    ModManagerUI.StatusLabel.Text = "Error : installation cancelled.";
                    finished = true;
                }
            } else
            {
                finished = true;
            }
        }

        public static void UninstallMod(Mod m)
        {
            if (!finished)
            {
                return;
            }
            finished = false;

            ModManagerUI.StatusLabel.Text = "Uninstalling Mod, please wait...";
            

            InstalledMod im = ConfigManager.getInstalledModById(m.id);
            Utils.DirectoryDelete(ModManager.appDataPath + @"\mods\" + m.id);
            ConfigManager.config.installedMods.Remove(im);
            ConfigManager.update();
            if (!ModManager.silent)
                ContextMenu.load();

            finished = true;

            ModManagerUI.StatusLabel.Text = "Mod successfully uninstalled !";
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
                backgroundWorker.ReportProgress(100);

            string destPath = ModManager.appDataPath + @"\mods\" + m.id;
            Utils.DirectoryDelete(destPath);
            Directory.CreateDirectory(destPath);
            Utils.DirectoryCopy(ModManager.appDataPath + @"\vanilla\" + m.gameVersion, destPath, true);

            backgroundWorker.ReportProgress(20);

            Boolean result = installDependencies(m);

            if (!result)
            {
                Utils.DirectoryDelete(destPath);
                backgroundWorker.ReportProgress(100);
            }

            backgroundWorker.ReportProgress(30);

            result = installFiles(m);

            if (!result)
            {
                Utils.DirectoryDelete(destPath);
                backgroundWorker.ReportProgress(100);
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
            if (!ModManager.silent)
            {
                switch (e.ProgressPercentage)
                {
                    case 10:
                        ModManagerUI.StatusLabel.Text = "Installing Mod, please wait... Initializing...";
                        break;
                    case 20:
                        ModManagerUI.StatusLabel.Text = "Installing Mod, please wait... Installing dependencies...";
                        break;
                    case 30:
                        ModManagerUI.StatusLabel.Text = "Installing Mod, please wait... Installing mod...";
                        break;
                }
            }
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ModManager.silent)
            {
                if (finished)
                {
                    ModManagerUI.StatusLabel.Text = "Mod successfully installed !";
                    Form currentForm = ModManagerUI.getFormByCategoryId(ModToInstall.category);
                    ModManagerUI.refreshModForm(currentForm);
                }
                else
                {
                    ModManagerUI.StatusLabel.Text = "Error : installation cancelled.";
                    finished = true;
                }
            } else
            {
                finished = true;
            }
        }

        public static Boolean installDependencies(Mod m)
        {
            string destPath = ModManager.appDataPath + @"\mods\" + m.id;
            foreach (string dependencie in m.dependencies)
            {
                string tempPath = ModManager.tempPath;
                string tempDestPath = tempPath + @"\" + dependencie + ".zip";
                Utils.FileDelete(tempDestPath);
                try
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

            try
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
            return true;
        }

        public static Boolean installZip(Mod m, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string zipPath = ModManager.tempPath + @"\" + fileName;
            string modPath = ModManager.appDataPath + @"\mods\" + m.id;

            Utils.FileDelete(zipPath);

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

            string newPath = ModManager.tempPath + @"\ModZip";

            Utils.DirectoryDelete(newPath);
            Directory.CreateDirectory(newPath);
            ZipFile.ExtractToDirectory(zipPath, newPath);

            List<string> installedFiles = new List<string>();

            foreach (string folder in m.folders)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(newPath + @"\" + folder);
                if (dirInfo.Exists)
                {
                    Directory.CreateDirectory(modPath + @"\" + folder);

                    FileInfo[] files = dirInfo.GetFiles("*");
                    foreach (FileInfo f in files)
                    {
                        if (m.excludeFiles.Contains(folder + @"\" + f.Name) == false)
                        {
                            string target = modPath + @"\" + folder + "\\" + f.Name;
                            string newName = f.Name;
                            // Should never be triggered but it's still here just in case
                            if (File.Exists(target))
                            {
                                newName = m.id + "-" + f.Name.Remove(f.Name.Length - 4);
                                target = modPath + @"\" + folder + @"\" + newName;
                            }
                            Utils.FileCopy(f.FullName, target);
                        }
                    }
                }
            }
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
