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
        private static int installOffset;
        private static int installMax;
        private static int installStep;

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
            if (m.type == "local")
            {
                string dirPath = ModManager.appDataPath + @"\localMods\" + m.name + ".zip";

                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("Starting MODNAME ... Please wait...").Replace("MODNAME", m.name);

                if (!ConfigManager.config.multipleGames && isGameOpen()) return;

                if (ConfigManager.config.launcher != "Steam")
                {
                    cleanGame();

                    string newPath = ModManager.tempPath + @"\ModZip";
                    Utils.DirectoryDelete(newPath);
                    Directory.CreateDirectory(newPath);
                    try
                    {
                        ZipFile.ExtractToDirectory(dirPath, newPath);
                    }
                    catch (Exception ex)
                    {
                        Utils.logE("Local mod zip extraction FAIL", "ModWorker");
                        Utils.logEx(ex, "ModWorker");
                        Utils.logToServ(ex, "ModWorker");
                        return;
                    }
                    newPath = getBepInExInsideRec(newPath);

                    Utils.DirectoryCopy(newPath, ConfigManager.config.amongUsPath, true);
                    Process.Start("explorer", ConfigManager.config.amongUsPath + @"\Among Us.exe");
                }
                else
                {
                    string vanillaPath = ModManager.appDataPath + @"\vanilla\" + m.gameVersion;
                    string playPath = ModManager.appDataPath + @"\epicplay";
                    Utils.DirectoryDelete(playPath);
                    Utils.DirectoryCreate(playPath);

                    string newPath = ModManager.tempPath + @"\ModZip";
                    Utils.DirectoryDelete(newPath);
                    Directory.CreateDirectory(newPath);
                    try
                    {
                        ZipFile.ExtractToDirectory(dirPath, newPath);
                    }
                    catch (Exception ex)
                    {
                        Utils.logE("Local mod zip extraction FAIL", "ModWorker");
                        Utils.logEx(ex, "ModWorker");
                        Utils.logToServ(ex, "ModWorker");
                        return;
                    }
                    newPath = getBepInExInsideRec(newPath);

                    Utils.DirectoryCopy(vanillaPath, playPath, true);
                    Utils.DirectoryCopy(newPath, playPath, true);

                    Process.Start("explorer", playPath + @"\Among Us.exe");
                }

                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);

            }
            else if (m.id == "Skeld")
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
            else if (m.id == "ChallengerBeta")
            {
                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);
                Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Among Us.exe");
            }
            else if (m.id == "Challenger")
            {
                ModWorker.openOrInstallChall();
                return;
            }
            else
            {
                if (!ConfigManager.config.multipleGames && isGameOpen()) return;

                InstalledMod im = ConfigManager.getInstalledModById(m.id);

                string dirPath = ModManager.appDataPath + @"\mods\" + m.id;
                string optionsPath = dirPath + "-options";


                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("Starting MODNAME ... Please wait...").Replace("MODNAME", m.name);

                if (ConfigManager.config.launcher != "Steam")
                {
                    cleanGame();
                    Utils.DirectoryCopy(dirPath, ConfigManager.config.amongUsPath, true);
                    foreach(string optionName in m.options)
                    {
                        Utils.DirectoryCopy(ModManager.appDataPath + @"\mods\" + optionName, ConfigManager.config.amongUsPath, true);
                    }
                    Process.Start("explorer", ConfigManager.config.amongUsPath + @"\Among Us.exe");
                } else
                {
                    if (im.options.Count() <= 0)
                    {
                        Process.Start("explorer", dirPath + @"\Among Us.exe");
                    } else
                    {
                        Utils.DirectoryCopy(dirPath, optionsPath, true);
                        foreach (string optionName in m.options)
                        {
                            Utils.DirectoryCopyWithoutReplacement(ModManager.appDataPath + @"\mods\" + optionName, optionsPath);
                        }
                        Process.Start("explorer", optionsPath + @"\Among Us.exe");
                    }
                }


                if (!ModManager.silent)
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", m.name);

            }

            Utils.log("Start mod " + m.name + " END", "ModWorker");
        }

        public static void openOrInstallChall()
        {
            if (ModList.isChallengerInstalled())
            {
                Process.Start("explorer", "steam://rungameid/2160150");
            }
            else
            {
                Process.Start("explorer", "steam://run/2160150");
                BackgroundWorker backgroundWorkerChall = new BackgroundWorker();
                backgroundWorkerChall.WorkerReportsProgress = true;

                backgroundWorkerChall.DoWork += new DoWorkEventHandler(ModWorker.backgroundWorkerChall_DoWork);
                backgroundWorkerChall.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ModWorker.backgroundWorkerChall_RunWorkerCompleted);
                backgroundWorkerChall.ProgressChanged += new ProgressChangedEventHandler(ModWorker.backgroundWorkerChall_ProgressChanged);
                backgroundWorkerChall.RunWorkerAsync();
            }
        }

        public static void backgroundWorkerChall_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            Boolean installed = false;
            while (!installed)
            {
                if (ModList.isChallengerInstalled())
                {
                    installed = true;
                }
            }
            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerChall_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private static void backgroundWorkerChall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ModManagerUI.reloadMods();
        }


        public static void dataSave(Mod mod)
        {
            List<string> tdata = new List<string>() { };
            tdata.Add(mod.data);
            tdata.Add("BepInEx/config");
            string modSavePath = ModManager.tempPath + @"\" + mod.id;
            Utils.DirectoryDelete(modSavePath);
            foreach (string data in tdata)
            {
                Utils.log("Saving data in " + data, "ModWorker");
                string origPath = ModManager.appDataPath + @"\mods\" + mod.id + @"\" + data;
                string savePath = modSavePath + @"\" + data;
                if (Directory.Exists(origPath))
                {
                    Utils.log("Data directory found", "ModWorker");
                    Utils.DirectoryDelete(savePath);
                    Utils.DirectoryCopy(origPath, savePath, true);
                }
                if (File.Exists(origPath))
                {
                    Utils.log("Data file found", "ModWorker");
                    Utils.FileDelete(savePath);
                    File.Copy(origPath, savePath);
                }
            }
        }

        public static void dataLoad(Mod mod)
        {
            List<string> tdata = new List<string>() { };
            tdata.Add(mod.data);
            tdata.Add("BepInEx/config");
            string modSavePath = ModManager.tempPath + @"\" + mod.id;
            foreach (string data in tdata)
            {
                Utils.log("Loading data in " + data, "ModWorker");
                string origPath = ModManager.appDataPath + @"\mods\" + mod.id + @"\" + data;
                string savePath = modSavePath + @"\" + data;
                if (Directory.Exists(savePath))
                {
                    Utils.log("Data directory found", "ModWorker");
                    Utils.DirectoryCopy(savePath, origPath, true);
                }
                if (File.Exists(savePath))
                {
                    Utils.log("Data file found", "ModWorker");
                    File.Copy(savePath, origPath);
                }
            }
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

        public static void cleanGame()
        {
            Utils.DirectoryDelete(ConfigManager.config.amongUsPath + @"\BepInEx");
            Utils.DirectoryDelete(ConfigManager.config.amongUsPath + @"\mono");
            Utils.FileDelete(ConfigManager.config.amongUsPath + @"\doorstop_config.ini");
            Utils.FileDelete(ConfigManager.config.amongUsPath + @"\winhttp.dll");
        }

        public static void startGame()
        {
            if (!ConfigManager.config.multipleGames && isGameOpen())
                return;

            Utils.log("Start vanilla game START", "ModWorker");
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = Translator.get("MODNAME started.").Replace("MODNAME", "Vanilla Among Us");

            ConfigManager.updateAmongUsPathIfNeeded();

            cleanGame();

            if (ConfigManager.config.launcher == "Steam")
            {
                Process.Start("explorer", "steam://rungameid/945360");
                return;
            } else if (ConfigManager.config.launcher == "EGS")
            {
                Process.Start(new ProcessStartInfo("com.epicgames.launcher://apps/963137e4c29d4c79a81323b8fab03a40?action=launch&silent=true") { UseShellExecute = true });
                return;
            } else
            {
                Process.Start("explorer", ConfigManager.config.amongUsPath + @"\Among Us.exe");
                return;
            }
        }

        public static void installAnyMod(Mod m)
        {
            Utils.log("Install mod " + m.name + " START", "ModWorker");
            if (m.id == "Challenger")
            {
                ModWorker.openOrInstallChall();
                //ModWorker.installChallenger(true);
            }
            else if(m.id == "ChallengerBeta")
            {
                ModWorker.installChallenger(false);
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
            ModToInstall = m;

            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", ModToInstall.name);

            BackgroundWorker backgroundWorkerBcl = new BackgroundWorker();
            backgroundWorkerBcl.WorkerReportsProgress = true;
            backgroundWorkerBcl.DoWork += new DoWorkEventHandler(backgroundWorkerBcl_DoWork);
            backgroundWorkerBcl.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerBcl_RunWorkerCompleted);
            backgroundWorkerBcl.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerBcl_ProgressChanged);
            backgroundWorkerBcl.RunWorkerAsync();
        }

        private static void backgroundWorkerBcl_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            string dlPath = ModManager.tempPath + @"\Better-CrewLink-Setup.exe";
            Utils.FileDelete(dlPath);

            DownloadWorker.download(ModManager.serverURL + @"/bcl", dlPath, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", ModToInstall.name) + "\n(PERCENT)", 0, 80);

            Process.Start("explorer", dlPath);

            Boolean installed = false;
            while (!installed)
            {
                if (ConfigManager.isBetterCrewlinkInstalled())
                {
                    installed = true;
                }
            }
            finished = true;
            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerBcl_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private static void backgroundWorkerBcl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ModManager.silent)
            {
                if (finished)
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", ModToInstall.name) + "\n(100%)";
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", ModToInstall.name);
                    Form currentForm = ModManagerUI.getFormByCategoryId(ModToInstall.category);
                    ModManagerUI.activeForm = currentForm;
                    ModManagerUI.reloadMods();
                }
                else
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Error") + " : " + Translator.get("installation canceled.");
                    finished = true;
                }
            }
            else
            {
                finished = true;
            }
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

            if (ModToInstall.id == "Challenger")
            {
                foreach (ReleaseAsset ra in ModList.challengerClient.Assets)
                {
                    if (ra.Name.Contains("zip"))
                    {
                        asset = ra;
                        break;
                    }
                }
            } else
            {
                foreach (ReleaseAsset ra in ModList.challengerClientBeta.Assets)
                {
                    if (ra.Name.Contains("zip"))
                    {
                        asset = ra;
                        break;
                    }
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
            InstalledMod newMod = new InstalledMod(ModToInstall.id, ModToInstall.release.TagName, ModToInstall.gameVersion, new List<string>() { });
            ConfigManager.config.installedMods.Add(newMod);
            ConfigManager.update();

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
                    ModManagerUI.activeForm = currentForm;
                    ModManagerUI.reloadMods();
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

            if (m.id == "BetterCrewlink")
            {
                ModToInstall = m;

                BackgroundWorker backgroundWorkerUnBcl = new BackgroundWorker();
                backgroundWorkerUnBcl.WorkerReportsProgress = true;
                backgroundWorkerUnBcl.DoWork += new DoWorkEventHandler(backgroundWorkerUnBcl_DoWork);
                backgroundWorkerUnBcl.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerUnBcl_RunWorkerCompleted);
                backgroundWorkerUnBcl.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerUnBcl_ProgressChanged);
                backgroundWorkerUnBcl.RunWorkerAsync();
                return;
            } else if (m.id == "Challenger") {
                BackgroundWorker backgroundWorkerUnChall = new BackgroundWorker();
                backgroundWorkerUnChall.WorkerReportsProgress = true;
                backgroundWorkerUnChall.DoWork += new DoWorkEventHandler(backgroundWorkerUnChall_DoWork);
                backgroundWorkerUnChall.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerUnChall_RunWorkerCompleted);
                backgroundWorkerUnChall.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerUnChall_ProgressChanged);
                backgroundWorkerUnChall.RunWorkerAsync();
            } else
            {
                string modPath = ModManager.appDataPath + @"\mods\" + m.id;
                Utils.DirectoryDelete(modPath);
                Utils.DirectoryDelete(modPath + "-options");
            }

            ConfigManager.config.installedMods.Remove(im);
            ConfigManager.update();

            finished = true;

            ModManagerUI.StatusLabel.Text = Translator.get("MODNAME uninstalled successfully.").Replace("MODNAME", m.name);
            Form currentForm = ModManagerUI.getFormByCategoryId(m.category);
            ModManagerUI.activeForm = currentForm;
            ModManagerUI.reloadMods();
            Utils.log("Uninstall mod " + m.name + " END", "ModWorker");
        }

        private static void backgroundWorkerUnChall_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            object uninsPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 2160150", "UninstallString", null);
            if (uninsPath != null)
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c" + uninsPath.ToString()) { CreateNoWindow = true });

                Boolean installed = true;
                while (installed)
                {
                    installed = false;
                    if (ModList.isChallengerInstalled())
                    {
                        installed = true;
                    }
                }
                finished = true;
            }

            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerUnChall_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private static void backgroundWorkerUnChall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ModManagerUI.reloadMods();
        }

        private static void backgroundWorkerUnBcl_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            object uninsPath = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\03ceac78-9166-585d-b33a-90982f435933", "QuietUninstallString", null);
            if (uninsPath != null)
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c" + uninsPath.ToString()) { CreateNoWindow = true });

                Boolean installed = true;
                while (installed)
                {
                    installed = false;
                    if (ConfigManager.isBetterCrewlinkInstalled())
                    {
                        installed = true;
                    }
                }
                finished = true;
            }

            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerUnBcl_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private static void backgroundWorkerUnBcl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!ModManager.silent)
            {
                if (finished)
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME uninstalled successfully.").Replace("MODNAME", ModToInstall.name);
                    Form currentForm = ModManagerUI.getFormByCategoryId(ModToInstall.category);
                    ModManagerUI.activeForm = currentForm;
                    ModManagerUI.reloadMods();
                }
                else
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Error") + " : " + Translator.get("canceled.");
                    finished = true;
                }
            }
            else
            {
                finished = true;
            }
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

            // Check if update
            InstalledMod existingMod = ConfigManager.getInstalledModById(ModToInstall.id);
            Boolean isUpdate = false;
            if (existingMod != null)
                isUpdate = true;
            
            // Remove mod
            if (isUpdate)
            {
                ConfigManager.config.installedMods.Remove(existingMod);
            }

            // Add mods to queue
            List<Mod> queue = new List<Mod>() { };
            queue.Add(m);
            foreach (string modName in m.dependencies)
            {
                Mod toInstallMod = ModList.getModById(modName);
                if (!queue.Contains(toInstallMod))
                {
                    if (toInstallMod.id != "GLMod" ||
                        (toInstallMod.id == "GLMod" && ConfigManager.config.launcher == "Steam"))
                    {
                        queue.Add(toInstallMod);
                    }
                }
            }

            string destPath = ModManager.appDataPath + @"\mods\" + m.id;
            string vanillaDestPath = ModManager.appDataPath + @"\vanilla\" + m.gameVersion;

            // Clean destination path
            dataSave(m);

            Utils.DirectoryDelete(destPath);
            Directory.CreateDirectory(destPath);

            installMax = queue.Count() * 2;
            installStep = (100 / installMax);
            installOffset = 0;

            // Install client if needed
            if (!ConfigManager.containsGameVersion(m.gameVersion) && ConfigManager.config.launcher == "Steam")
            {
                installMax = installMax + 2;
                installStep = (100 / installMax);

                string tempPath = ModManager.tempPath + @"\" + m.gameVersion + ".zip";
                Utils.FileDelete(tempPath);
                
                DownloadWorker.download(ModManager.fileURL + @"/client/" + m.gameVersion + @".zip", tempPath, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name) + "\n(PERCENT)", installOffset, installStep);
                installOffset += installStep;

                Utils.DirectoryDelete(vanillaDestPath);
                Directory.CreateDirectory(vanillaDestPath);
                try
                {
                    ZipFile.ExtractToDirectory(tempPath, vanillaDestPath);
                }
                catch (Exception ex)
                {
                    Utils.logE("Client zip extraction FAIL", "ModWorker");
                    Utils.logEx(ex, "ModWorker");
                    Utils.logToServ(ex, "ModWorker");
                    backgroundWorker.ReportProgress(100);
                }
                ConfigManager.config.installedVanilla.Add(new InstalledVanilla(m.gameVersion));
                ConfigManager.update();

                installOffset += installStep;
                backgroundWorker.ReportProgress(installOffset);
            }

            if (ConfigManager.config.launcher == "Steam")
                Utils.DirectoryCopy(vanillaDestPath, destPath, true);

            // Treat queue
            foreach (Mod toInstallMod in queue)
            {
                bool result2 = installFiles(toInstallMod, destPath);
                if (!result2)
                {
                    Utils.DirectoryDelete(destPath);
                    backgroundWorker.ReportProgress(100);
                    return;
                }
                if (toInstallMod.id == "GLMod")
                {
                    File.Create(destPath + @"\BepInEx\config\" + m.id + ".mm");
                }
                backgroundWorker.ReportProgress(installOffset);
            }

            dataLoad(m);


            InstalledMod newMod = new InstalledMod(m.id, m.release.TagName, m.gameVersion, existingMod == null ? new List<string>() { } : existingMod.options);
            ConfigManager.config.installedMods.Add(newMod);
            ConfigManager.update();
            
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
                    ModManagerUI.activeForm = currentForm;
                    ModManagerUI.reloadMods();
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

        public static Boolean installFiles(Mod m, string destPath)
        {

            Utils.log("Install files for mod " + m.name + " START", "ModWorker");
            if (m.type != "allInOne")
            {
                foreach (ReleaseAsset tab in m.release.Assets)
                {
                    string fileName = tab.Name;
                    if (fileName.Contains(".zip") && (m.needPattern == null || m.needPattern == "" || fileName.Contains(m.needPattern)) && (m.ignorePattern == null || m.ignorePattern == "" || !fileName.Contains(m.ignorePattern)))
                    {
                        return installZip(m, tab, destPath);
                    }
                }

                foreach (ReleaseAsset tab in m.release.Assets)
                {
                    string fileName = tab.Name;
                    if (fileName.Contains(".dll") && (m.needPattern == "" || fileName.Contains(m.needPattern)) && (m.ignorePattern == "" || !fileName.Contains(m.ignorePattern)))
                    {
                        return installDll(m, tab, destPath);
                    }
                }
            }

            Utils.log("Install files for mod " + m.name + " END", "ModWorker");
            return true;
        }

        public static Boolean installDll(Mod m, ReleaseAsset file, string destPath)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string pluginsPath = destPath + @"\BepInEx\plugins";
            Directory.CreateDirectory(pluginsPath);
            Utils.log("Install dll file " + fileName + " START", "ModWorker");

            DownloadWorker.download(fileUrl, pluginsPath + @"\" + fileName, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name) + "\n(PERCENT)", installOffset, installStep);
            installOffset += installStep * 2;
            Utils.log("Install dll file " + fileName + " END", "ModWorker");
            return true;
        }

        public static Boolean installZip(Mod m, ReleaseAsset file, string destPath)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string zipPath = ModManager.tempPath + @"\" + fileName;
            Utils.log("Install zip file " + fileName + " START", "ModWorker");

            Utils.FileDelete(zipPath);

            DownloadWorker.download(fileUrl, zipPath, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name) + "\n(PERCENT)", installOffset, installStep);
            installOffset += installStep;

            string newPath = ModManager.tempPath + @"\ModZip";

            Utils.DirectoryDelete(newPath);
            Directory.CreateDirectory(newPath);
            ZipFile.ExtractToDirectory(zipPath, newPath);
            newPath = getBepInExInsideRec(newPath);
            Utils.DirectoryCopy(newPath, destPath, true);

            installOffset += installStep;

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

            ModManagerUI.reloadMods();
            return null;
        }

        public static void removeAllMods()
        {
            string modsPath = ModManager.appDataPath + @"\mods";
            Utils.DirectoryDelete(modsPath);
            Directory.CreateDirectory(modsPath);
            string localPath = ModManager.appDataPath + @"\localMods";
            Utils.DirectoryDelete(localPath);
            Directory.CreateDirectory(localPath);
            string vanillaPath = ModManager.appDataPath + @"\vanilla";
            Utils.DirectoryDelete(vanillaPath);
            Directory.CreateDirectory(vanillaPath);
            ConfigManager.config.installedMods = new List<InstalledMod>() { };
            ConfigManager.config.installedVanilla = new List<InstalledVanilla>() { };
            ConfigManager.config.favoriteMods = new List<string>() { };
        }
    }
}
