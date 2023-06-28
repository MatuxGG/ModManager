using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public static class ModWorker
    {
        public static bool finished;
        public static Mod modToInstall;
        public static ModVersion versionToInstall;
        public static List<string> optionsToInstall;
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

        /* Start Mod */

        public static void startMod(Mod m, ModVersion v, List<string> options)
        {
            if (!finished) return;

            if (m.type == "mod")
            {
                if (isGameOpen()) return;

                InstalledMod im = ConfigManager.getInstalledMod(m.id, v.version);

                if (im == null)
                {
                    Log.log("Mod " + m.id + " doesn't exist", "ModManager");
                    MessageBox.Show("The mod you're trying to run doesn't exist.\nPlease, try again.\nIf this happen again, please create a ticket on Mod Manager's support discord server.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                finished = false;
                modToInstall = m;
                versionToInstall = v;
                optionsToInstall = options;

                ModManagerUI.StatusLabel.Text = Translator.get("Starting MODNAME, please wait...").Replace("MODNAME", modToInstall.name);

                BackgroundWorker backgroundWorkerStart = new BackgroundWorker();
                backgroundWorkerStart.WorkerReportsProgress = true;
                backgroundWorkerStart.DoWork += new DoWorkEventHandler(backgroundWorkerStart_DoWork);
                backgroundWorkerStart.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerStart_RunWorkerCompleted);
                backgroundWorkerStart.RunWorkerAsync();
            }
        }

        public static void backgroundWorkerStart_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            enableVanilla(versionToInstall.gameVersion);

            List<Task> tasks = new List<Task>();

            enableMod(modToInstall, versionToInstall, true);

            foreach (string option in optionsToInstall)
            {
                ModOption opt = versionToInstall.options.Find(o => o.modOption == option);

                if (opt == null)
                {
                    Log.log("Option " + option + " doesn't exist for mod " + modToInstall.id + ", version " + versionToInstall.version + " (1)", "ModWorker");
                    continue;
                }

                Mod m = ModList.getModById(opt.modOption);

                if (m == null)
                {
                    Log.log("Option " + opt.modOption + ", version " + opt.version + " doesn't exist for mod " + modToInstall.id + ", version " + versionToInstall.version + " (2)", "ModWorker");
                    continue;
                }

                ModVersion v = m.versions.Find(version =>  version.version == opt.version);

                if (v == null)
                {
                    Log.log("Option " + opt.modOption + ", version " + opt.version + " doesn't exist for mod " + modToInstall.id + ", version " + versionToInstall.version + " (3)", "ModWorker");
                    continue;
                }

                enableMod(m, v);
            }
            
            finished = true;

            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (finished)
            {
                ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", modToInstall.name);
            }
            else
            {
                ModManagerUI.StatusLabel.Text = Translator.get("Error") + " : " + Translator.get("installation canceled.");
                finished = true;
            }
        }

        public static void enableVanilla(string version)
        {
            string modPath = ModManager.appDataPath + @"\mod";
            string toInstallPath = ModManager.appDataPath + @"\vanilla\" + version;

            FileSystem.DirectoryDelete(modPath);
            FileSystem.DirectoryCreate(modPath);

            try
            {
                FileSystem.DirectoryCopy(toInstallPath, modPath);
            } catch (Exception ex)
            {
                Log.logError("ModWoker", ex.Source, ex.Message);
            }
        }

        public static void enableMod(Mod m, ModVersion v, bool replacement = false)
        {
            string modPath = m.getPathForVersion(v);
            string toInstallPath = ModManager.appDataPath + @"\mod";

            Log.debug(modPath + " / " + toInstallPath);

            try
            {
                if (replacement)
                {
                    FileSystem.DirectoryCopy(modPath, toInstallPath);
                } else
                {
                    FileSystem.DirectoryCopyWithoutReplacement(modPath, toInstallPath);
                }
            } catch (Exception ex)
            {
                Log.logError("ModWoker", ex.Source, ex.Message);
            }
        }

        public static void startGame()
        {
            if (isGameOpen()) return;

            Process.Start("explorer", "steam://rungameid/945360");
            return;
        }

        public static void installAnyMod(Mod m, ModVersion v, List<string> options)
        {
            if (!finished) return;

            if (m.type == "mod")
            {
                finished = false;
                modToInstall = m;
                versionToInstall = v;
                optionsToInstall = options;

                ModManagerUI.StatusLabel.Text = Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", modToInstall.name);

                BackgroundWorker backgroundWorkerInstall = new BackgroundWorker();
                backgroundWorkerInstall.WorkerReportsProgress = true;
                backgroundWorkerInstall.DoWork += new DoWorkEventHandler(backgroundWorkerInstall_DoWork);
                backgroundWorkerInstall.RunWorkerAsync();
            }
        }

        public static void backgroundWorkerInstall_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            List<DownloadLine> lines = new List<DownloadLine>() { };
            List<DownloadLine> toExtract = new List<DownloadLine>() { };

            bool needVanilla = false;
            List<InstalledMod> installedMods = new List<InstalledMod>() { };

            // Add Download {vanilla} to Temp
            if (ConfigManager.config.installedVanilla.Find(iv => iv.version == versionToInstall.gameVersion) == null)
            {
                needVanilla = true;
                string vanillaPath = ModManager.appDataPath + @"\vanilla\" + versionToInstall.gameVersion;
                string vanillaUrl = ModManager.fileURL + "/client/" + versionToInstall.gameVersion + ".zip";
                string vanillaTempPath = ModManager.tempPath + @"\client.zip";
                FileSystem.DirectoryCreate(vanillaPath);
                FileSystem.FileDelete(vanillaTempPath);
                lines.Add(new DownloadLine(vanillaUrl, vanillaTempPath));
                toExtract.Add(new DownloadLine(vanillaTempPath, vanillaPath));
            }

            // Add Download {mod,version} to Temp
            if (ConfigManager.config.installedMods.Find(im => im.id == modToInstall.id && im.version == versionToInstall.version) == null)
            {
                installedMods.Add(new InstalledMod(modToInstall.id, versionToInstall.version));
                addModToInstall(lines, toExtract, modToInstall, versionToInstall);
            }

            foreach (string option in optionsToInstall)
            {
                ModOption modOption = versionToInstall.options.Find(o => o.modOption == option);
                Mod foundMod = ModList.getModById(option);
                ModVersion versionOption = foundMod.versions.Find(v => v.version == modOption.version);
                if (ConfigManager.config.installedMods.Find(im => im.id == option && im.version == versionOption.version) == null)
                {
                    installedMods.Add(new InstalledMod(foundMod.id, versionOption.version));
                    addModToInstall(lines, toExtract, foundMod, versionOption);
                }
            }

            FileDownloadManager.DownloadCompleted += () =>
            {
                // When finished

                ModManagerUI.StatusLabel.Invoke((MethodInvoker)delegate
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("Extracting files...");
                });

                string tempPath = ModManager.tempPath + @"\Modzip";
                foreach (DownloadLine te in toExtract)
                {
                    FileSystem.DirectoryDelete(tempPath);
                    FileSystem.DirectoryCreate(tempPath);
                    ZipFile.ExtractToDirectory(te.source, tempPath);
                    string newPath = getBepInExInsideRec(tempPath);
                    if (newPath == null)
                    {
                        newPath = tempPath;
                    }
                    FileSystem.DirectoryCopy(newPath, te.target);
                }

                if (needVanilla)
                {
                    if (ConfigManager.getInstalledVanilla(versionToInstall.gameVersion) == null)
                    {
                        ConfigManager.config.installedVanilla.Add(new InstalledVanilla(versionToInstall.gameVersion));
                    }
                }

                foreach(InstalledMod im in installedMods)
                {
                    if (ConfigManager.getInstalledMod(im.id, im.version) == null)
                    {
                        ConfigManager.config.installedMods.Add(im);
                    }
                }

                ConfigManager.update();

                ModManagerUI.StatusLabel.Invoke((MethodInvoker)delegate
                {
                    ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", modToInstall.name);
                    Form currentForm = ModManagerUI.getFormByCategoryId(modToInstall.category.id);
                    ModManagerUI.activeForm = currentForm;
                    ModManagerUI.reloadMods();
                    finished = true;
                });

                
            };

            ModManagerUI.StatusLabel.Invoke((MethodInvoker)delegate
            {
                FileDownloadManager.download(lines, ModManagerUI.StatusLabel);
            });


        }

        public static bool addModToInstall(List<DownloadLine> lines, List<DownloadLine> toExtract, Mod m, ModVersion v)
        {
            // Looking for .zip file
            foreach (ReleaseAsset ra in v.release.Assets)
            {
                if (ra.Name.Contains(".zip"))
                {
                    return addZipModToInstall(lines, toExtract, m, v, ra);
                }
            }

            foreach (ReleaseAsset ra in versionToInstall.release.Assets)
            {
                if (ra.Name.Contains(".dll"))
                {
                    return addDllModToInstall(lines, toExtract, m, v, ra);
                }
            }

            return false;
        }

        public static bool addZipModToInstall(List<DownloadLine> lines, List<DownloadLine> toExtract, Mod m, ModVersion v, ReleaseAsset ra)
        {
            string modPath = m.getPathForVersion(v);
            string modUrl = ra.BrowserDownloadUrl;
            string modTempPath = ModManager.tempPath + @"\" + ra.Name;

            FileSystem.DirectoryDelete(modPath);
            FileSystem.DirectoryCreate(modPath);
            FileSystem.DirectoryDelete(modTempPath);

            lines.Add(new DownloadLine(modUrl, modTempPath));
            toExtract.Add(new DownloadLine(modTempPath, modPath));
            return true;
        }

        public static bool addDllModToInstall(List<DownloadLine> lines, List<DownloadLine> toExtract, Mod m, ModVersion v, ReleaseAsset ra)
        {
            string modPath = m.getPathForVersion(v) + @"\BepInEx\plugins";
            string modUrl = ra.BrowserDownloadUrl;

            FileSystem.DirectoryDelete(modPath);
            FileSystem.DirectoryCreate(modPath);

            lines.Add(new DownloadLine(modUrl, modPath + @"\" + ra.Name));
            return true;
        }

        /* Unins Mod */

        public static void uninsMod(Mod m, ModVersion v)
        {
            if (!finished) return;

            if (m.type == "mod")
            {
                if (isGameOpen()) return;

                InstalledMod im = ConfigManager.getInstalledMod(m.id, v.version);

                if (im == null)
                {
                    Log.log("Mod " + m.id + " doesn't exist", "ModManager");
                    MessageBox.Show("The mod you're trying to uninstall doesn't exist.\nPlease, try again.\nIf this happen again, please create a ticket on Mod Manager's support discord server.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                finished = false;
                modToInstall = m;
                versionToInstall = v;

                ModManagerUI.StatusLabel.Text = Translator.get("Uninstalling MODNAME, please wait...").Replace("MODNAME", modToInstall.name);

                BackgroundWorker backgroundWorkerUnins = new BackgroundWorker();
                backgroundWorkerUnins.WorkerReportsProgress = true;
                backgroundWorkerUnins.DoWork += new DoWorkEventHandler(backgroundWorkerUnins_DoWork);
                backgroundWorkerUnins.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerUnins_RunWorkerCompleted);
                backgroundWorkerUnins.RunWorkerAsync();
            }
        }

        public static void backgroundWorkerUnins_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            string modPath = modToInstall.getPathForVersion(versionToInstall);
            FileSystem.DirectoryDelete(modPath);

            InstalledMod im = ConfigManager.getInstalledMod(modToInstall.id, versionToInstall.version);
            ConfigManager.config.installedMods.Remove(im);

            finished = true;

            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorkerUnins_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (finished)
            {
                ModManagerUI.StatusLabel.Text = Translator.get("MODNAME uninstalled successfully.").Replace("MODNAME", modToInstall.name);
                Form currentForm = ModManagerUI.getFormByCategoryId(modToInstall.category.id);
                ModManagerUI.activeForm = currentForm;
                ModManagerUI.reloadMods();
            }
            else
            {
                ModManagerUI.StatusLabel.Text = Translator.get("Error") + " : " + Translator.get("uninstallation canceled.");
                finished = true;
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
