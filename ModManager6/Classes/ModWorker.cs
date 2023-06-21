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

                string modPath = ModManager.appDataPath + @"\mod";
                FileSystem.DirectoryDelete(modPath);
                FileSystem.DirectoryCreate(modPath);

                BackgroundWorker backgroundWorkerStart = new BackgroundWorker();
                backgroundWorkerStart.WorkerReportsProgress = true;

                backgroundWorkerStart.DoWork += new DoWorkEventHandler(backgroundWorkerStart_DoWork);
                backgroundWorkerStart.RunWorkerAsync();
            }
        }

        public static async void backgroundWorkerStart_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            await enableVanilla(versionToInstall.gameVersion);

            List<Task> tasks = new List<Task>();

            tasks.Add(enableMod(modToInstall, versionToInstall));

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

                tasks.Add(enableMod(m, v));
            }

            await Task.WhenAll(tasks);
            
            finished = true;

            backgroundWorker.ReportProgress(100);
        }

        public static async Task enableVanilla(string version)
        {
            string modPath = ModManager.appDataPath + @"\mod";
            string toInstallPath = ModManager.appDataPath + @"\vanilla\" + version;

            try
            {
                FileSystem.DirectoryCopy(toInstallPath, modPath);
            } catch (Exception ex)
            {
                Log.logError("ModWoker", ex.Source, ex.Message);
            }
        }

        public static async Task enableMod(Mod m, ModVersion v)
        {
            string modPath = ModManager.appDataPath + @"\mod";
            string toInstallPath = m.getPathForVersion(v);

            try
            {
                FileSystem.DirectoryCopy(modPath, toInstallPath);
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

        public static void installMod(Mod m, ModVersion v, List<string> options)
        {
            if (!finished) return;

            if (m.type == "mod")
            {
                finished = false;
                modToInstall = m;
                versionToInstall = v;
                optionsToInstall = options;

                ModManagerUI.StatusLabel.Text = Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", modToInstall.name);

                BackgroundWorker backgroundWorkerStart = new BackgroundWorker();
                backgroundWorkerStart.WorkerReportsProgress = true;
                backgroundWorkerStart.DoWork += new DoWorkEventHandler(backgroundWorkerInstall_DoWork);
                backgroundWorkerStart.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorkerStart.RunWorkerAsync();
            }
        }

        public static void backgroundWorkerInstall_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            List<Task> tasks = new List<Task>() { };

            int offset = 0;
            int percent = 0;

            if (ConfigManager.config.installedVanilla.Find(iv => iv.version == versionToInstall.gameVersion) == null)
            {
                percent = 50;
                bool result = installVanilla(versionToInstall.gameVersion, offset, percent);
                if (!result) backgroundWorker.ReportProgress(100); // Error
                
                offset += percent;
            }

            if (ConfigManager.config.installedMods.Find(im => im.id == modToInstall.id && im.version == versionToInstall.version) == null)
            {
                percent = (100 - offset) / 2;
                bool result = installMod(modToInstall, versionToInstall, offset, percent);
                offset += percent;
            }

            finished = true;

            backgroundWorker.ReportProgress(100);
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (finished)
            {
                ModManagerUI.StatusLabel.Text = Translator.get("MODNAME installed successfully.").Replace("MODNAME", modToInstall.name);
                Form currentForm = ModManagerUI.getFormByCategoryId(modToInstall.category.id);
                ModManagerUI.activeForm = currentForm;
                ModManagerUI.reloadMods();
            }
            else
            {
                ModManagerUI.StatusLabel.Text = Translator.get("Error") + " : " + Translator.get("installation canceled.");
                finished = true;
            }
        }


        public static bool installVanilla(string version, int offset, int percent)
        {
            string vanillaPath = ModManager.appDataPath + @"\vanilla\" + version;
            string vanillaUrl = ModManager.fileURL + "/client/" + version + ".zip";
            string tempPath = ModManager.tempPath + @"\" + version + ".zip";

            try
            {
                Download.download(vanillaUrl, tempPath, Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", modToInstall.name) + "\n(PERCENT)", offset, percent);
            } catch (Exception ex)
            {
                Log.showError("ModWorker", ex.Source, ex.Message);
                return false;
            }

            try
            {
                FileSystem.DirectoryDelete(vanillaPath);
                FileSystem.DirectoryCreate(vanillaPath);
                ZipFile.ExtractToDirectory(tempPath, vanillaPath);
            } catch (Exception ex)
            {
                Log.showError("ModWorker", ex.Source, ex.Message);
                return false;
            }

            ConfigManager.config.installedVanilla.Add(new InstalledVanilla(version));
            ConfigManager.update();
            return true;
        }

        public static bool installMod(Mod m, ModVersion v, int offset, int percent)
        {
            return true; // TODO
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
