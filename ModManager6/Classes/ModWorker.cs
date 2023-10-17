using Microsoft.Win32;
using ModManager6.Forms;
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

        public static async Task startMod(Mod m, ModVersion v, List<string> options)
        {
            try
            {
                if (!finished) return;

                string statusText = "";

                if (m.type == "mod")
                {
                    if (isGameOpen()) return;

                    InstalledMod im = ConfigManager.getInstalledMod(m.id, v.gameVersion);

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

                    statusText = Translator.get("Starting MODNAME, please wait...").Replace("MODNAME", modToInstall.name);
                    ModManagerUI.StatusLabel.Text = statusText;
                    ModManagerUI.Alert(statusText);

                    await Task.Run(() => enableVanilla(versionToInstall.gameVersion));

                    await Task.Run(() => enableMod(modToInstall, versionToInstall, true));

                    List<Task> tasks = new List<Task>() { };

                    foreach (string option in optionsToInstall)
                    {
                        ModOption opt = ModList.getModOptions(modToInstall, versionToInstall).Find(o => o.modOption == option);

                        if (opt == null)
                        {
                            Log.log("Option " + option + " doesn't exist for mod " + modToInstall.id + ", version " + versionToInstall.version + " (1)", "ModWorker");
                            continue;
                        }

                        Mod mOpt = ModList.getModById(opt.modOption);

                        if (mOpt == null)
                        {
                            Log.log("Option " + opt.modOption + ", version " + opt.gameVersion + " doesn't exist for mod " + modToInstall.id + ", version " + versionToInstall.version + " (2)", "ModWorker");
                            continue;
                        }

                        ModVersion vOpt = mOpt.versions.Find(version => version.gameVersion == opt.gameVersion);

                        if (vOpt == null)
                        {
                            Log.log("Option " + opt.modOption + ", version " + opt.gameVersion + " doesn't exist for mod " + modToInstall.id + ", version " + versionToInstall.version + " (3)", "ModWorker");
                            continue;
                        }

                        tasks.Add(enableMod(mOpt, vOpt));
                    }

                    await Task.WhenAll(tasks);

                    Process.Start("explorer", ConfigManager.config.dataPath + @"\mod\Among Us.exe");
                    statusText = Translator.get("MODNAME started.").Replace("MODNAME", modToInstall.name);

                    finished = true;

                }
                else if (m.type == "allInOne")
                {
                    statusText = Translator.get("Starting MODNAME, please wait...").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = statusText;
                    ModManagerUI.Alert(statusText);
                    if (m.id == "Challenger")
                    {
                        await installOrUpdateChall();
                    }
                    else if (m.id == "BetterCrewlink")
                    {
                        await installOrUpdateBcl();
                    }
                    statusText = Translator.get("MODNAME started.").Replace("MODNAME", m.name);
                    ModManagerUI.reloadMods();
                }

                await Task.Run(() =>
                {
                    while (System.Diagnostics.Process.GetProcessesByName("Among Us").Length < 1)
                    {

                    }
                    ModManagerUI.StatusLabel.Invoke((MethodInvoker)delegate
                    {
                        ModManagerUI.StatusLabel.Text = statusText;
                        ModManagerUI.Alert(statusText);
                    });
                    while (System.Diagnostics.Process.GetProcessesByName("Among Us").Length >= 1)
                    {

                    }
                    ModManagerUI.FeedbackForm.Invoke((MethodInvoker)delegate
                    {
                        ModManagerUI.FeedbackForm.showFeedback(Translator.get("How was your experience with MODNAME?").Replace("MODNAME", m.name), "for mod " + m.name);
                    });
                });
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

        }

        public static async Task enableVanilla(string version)
        {
            string modPath = ConfigManager.config.dataPath + @"\mod";
            string toInstallPath = ConfigManager.config.dataPath + @"\vanilla\" + version;
            try
            {
                FileSystem.DirectoryDelete(modPath);
                FileSystem.DirectoryCreate(modPath);
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

            try
            {
                FileSystem.DirectoryCopy(toInstallPath, modPath);
            } catch (Exception ex)
            {
                Log.logError("ModWoker", ex.Source, ex.Message);
            }
        }

        public static async Task enableMod(Mod m, ModVersion v, bool replacement = false)
        {
            string modPath = m.getPathForVersion(v);
            string toInstallPath = ConfigManager.config.dataPath + @"\mod";

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
                Log.logExceptionToServ(ex);
            }
        }

        public static void startGame()
        {
            try
            {
                if (isGameOpen()) return;

                Process.Start("explorer", "steam://rungameid/945360");
                return;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static async Task installAnyMod(Mod m, ModVersion v, List<string> options)
        {
            try
            {
                if (!finished) return;

                if (m.type == "mod")
                {
                    finished = false;
                    modToInstall = m;
                    versionToInstall = v;
                    optionsToInstall = options;

                    string statusText = Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = statusText;
                    ModManagerUI.Alert(statusText);

                    await installModWorker();
                }
                else if (m.type == "allInOne")
                {
                    string statusText = Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = statusText;
                    ModManagerUI.Alert(statusText);
                    if (m.id == "Challenger")
                    {
                        await installOrUpdateChall();
                    }
                    else if (m.id == "BetterCrewlink")
                    {
                        await installOrUpdateBcl();
                    }
                    statusText = Translator.get("MODNAME installed successfully.").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = statusText;
                    ModManagerUI.Alert(statusText);
                    ModManagerUI.reloadMods();
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

        }

        public static async Task installModWorker()
        {
            try
            {
                List<DownloadLine> lines = new List<DownloadLine>() { };
                List<DownloadLine> toExtract = new List<DownloadLine>() { };

                bool needVanilla = false;
                List<InstalledMod> installedMods = new List<InstalledMod>() { };

                // Add Download {vanilla} to Temp
                if (ConfigManager.config.installedVanilla.Find(iv => iv.version == versionToInstall.gameVersion) == null)
                {
                    needVanilla = true;
                    string vanillaPath = ConfigManager.config.dataPath + @"\vanilla\" + versionToInstall.gameVersion;
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
                    installedMods.Add(new InstalledMod(modToInstall.id, versionToInstall.version, versionToInstall.gameVersion));
                    addModToInstall(lines, toExtract, modToInstall, versionToInstall);
                }

                // Add list of Download {option,version} to Temp
                foreach (string option in optionsToInstall)
                {
                    ModOption modOption = ModList.getModOptions(modToInstall, versionToInstall).Find(o => o.modOption == option);
                    Mod foundMod = ModList.getModById(option);

                    ModVersion versionOption = foundMod.versions.Find(v => v.gameVersion == modOption.gameVersion);
                    if (ConfigManager.config.installedMods.Find(im => im.id == option && im.version == versionOption.version) == null)
                    {
                        installedMods.Add(new InstalledMod(foundMod.id, versionOption.version, versionOption.gameVersion));
                        addModToInstall(lines, toExtract, foundMod, versionOption);
                    }
                }

                // Download content
                await Downloader.DownloadFiles(Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", modToInstall.name), lines);

                // When finished

                ModManagerUI.StatusLabel.Invoke((MethodInvoker)delegate
                {
                    string statusText = Translator.get("Extracting files...");
                    ModManagerUI.StatusLabel.Text = statusText;
                    ModManagerUI.Alert(statusText);
                });

                await Task.Run(() =>
                {
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

                    foreach (InstalledMod im in installedMods)
                    {
                        InstalledMod alreadyIm = ConfigManager.getInstalledMod(im.id, im.gameVersion);
                        if (alreadyIm != null)
                        {
                            ModVersion alreadyVersion = new ModVersion(alreadyIm.version, alreadyIm.gameVersion);
                            string modPath = modToInstall.getPathForVersion(alreadyVersion);
                            FileSystem.DirectoryDelete(modPath);

                            ConfigManager.config.installedMods.Remove(alreadyIm);
                        }
                        if (ConfigManager.getInstalledMod(im.id, im.gameVersion) == null)
                        {
                            ConfigManager.config.installedMods.Add(im);
                        }
                    }

                    ConfigManager.update();

                    ModManagerUI.StatusLabel.Invoke((MethodInvoker)delegate
                    {
                        string statusText = Translator.get("MODNAME installed successfully.").Replace("MODNAME", modToInstall.name);
                        ModManagerUI.StatusLabel.Text = statusText;
                        ModManagerUI.Alert(statusText);
                        GenericPanel currentForm = ModManagerUI.getFormByCategoryId(modToInstall.category.id);
                        ModManagerUI.activeForm = currentForm;
                        ModManagerUI.reloadMods();
                        finished = true;
                    });
                });
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

        }

        public static bool addModToInstall(List<DownloadLine> lines, List<DownloadLine> toExtract, Mod m, ModVersion v)
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static bool addZipModToInstall(List<DownloadLine> lines, List<DownloadLine> toExtract, Mod m, ModVersion v, ReleaseAsset ra)
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }

        }

        public static bool addDllModToInstall(List<DownloadLine> lines, List<DownloadLine> toExtract, Mod m, ModVersion v, ReleaseAsset ra)
        {
            try
            {
                string modPath = m.getPathForVersion(v) + @"\BepInEx\plugins";
                string modUrl = ra.BrowserDownloadUrl;

                FileSystem.DirectoryDelete(modPath);
                FileSystem.DirectoryCreate(modPath);

                lines.Add(new DownloadLine(modUrl, modPath + @"\" + ra.Name));
                return true;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }

        }

        /* Unins Mod */

        public static async void uninsMod(Mod m, ModVersion v)
        {
            try
            {
                if (!finished) return;

                if (m.type == "mod")
                {
                    if (isGameOpen()) return;

                    InstalledMod im = ConfigManager.getInstalledMod(m.id, v.gameVersion);

                    if (im == null)
                    {
                        Log.log("Mod " + m.id + " doesn't exist", "ModManager");
                        MessageBox.Show("The mod you're trying to uninstall doesn't exist.\nPlease, try again.\nIf this happen again, please create a ticket on Mod Manager's support discord server.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    finished = false;

                    string labelText = Translator.get("Uninstalling MODNAME, please wait...").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = labelText;
                    ModManagerUI.Alert(labelText);

                    string modPath = modToInstall.getPathForVersion(v);
                    FileSystem.DirectoryDelete(modPath);

                    ConfigManager.config.installedMods.Remove(im);

                    labelText = Translator.get("MODNAME uninstalled successfully.").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = labelText;
                    ModManagerUI.Alert(labelText);
                    ModManagerUI.reloadMods();

                    finished = true;
                }
                else if (m.type == "allInOne")
                {
                    finished = false;

                    string labelText = Translator.get("Uninstalling MODNAME, please wait...").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = labelText;
                    ModManagerUI.Alert(labelText);
                    if (m.id == "Challenger")
                    {
                        await uninsChall();
                    }
                    else if (m.id == "BetterCrewlink")
                    {
                        await uninsBcl();
                    }
                    ModManagerUI.reloadMods();
                    labelText = Translator.get("MODNAME uninstalled successfully.").Replace("MODNAME", m.name);
                    ModManagerUI.StatusLabel.Text = labelText;
                    ModManagerUI.Alert(labelText);
                    finished = true;

                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

        }

        // All In One Start / Install

        public static async Task installOrUpdateChall()
        {
            try
            {
                finished = false;
                await Task.Run(() =>
                {
                    if (ConfigManager.isChallengerInstalled())
                    {
                        Process.Start("explorer", "steam://rungameid/2160150");
                    }
                    else
                    {
                        Process.Start("explorer", "steam://run/2160150");
                        while (!ConfigManager.isChallengerInstalled())
                        {

                        }
                    }
                });
                finished = true;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static async Task installOrUpdateBcl()
        {
            try
            {
                finished = false;
                if (ConfigManager.isBetterCrewlinkInstalled())
                {
                    object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                }
                else
                {
                    string dlPath = ModManager.tempPath + @"\Better-CrewLink-Setup.exe";
                    FileSystem.FileDelete(dlPath);

                    List<DownloadLine> lines = new List<DownloadLine>() { new DownloadLine(ModManager.serverURL + @"/bcl", dlPath) };

                    await Downloader.DownloadFiles(Translator.get("Installing MODNAME, please wait...").Replace("MODNAME", "BetterCrewlink"), lines);

                    Process.Start("explorer", dlPath);

                    await Task.Run(() =>
                    {
                        while (!ConfigManager.isBetterCrewlinkInstalled())
                        {

                        }
                    });
                }
                finished = true;

            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

        }

        public static async Task uninsChall()
        {
            try
            {
                finished = false;
                await Task.Run(() =>
                {
                    object uninsPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 2160150", "UninstallString", null);
                    if (uninsPath != null)
                    {
                        Process.Start(new ProcessStartInfo("cmd", $"/c" + uninsPath.ToString()) { CreateNoWindow = true });

                        while (ConfigManager.isChallengerInstalled())
                        {

                        }
                    }
                });
                finished = true;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }


        public static async Task uninsBcl()
        {
            try
            {

                finished = false;
                await Task.Run(() =>
                {
                    object uninsPath = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\03ceac78-9166-585d-b33a-90982f435933", "QuietUninstallString", null);
                    if (uninsPath != null)
                    {
                        Process.Start(new ProcessStartInfo("cmd", $"/c" + uninsPath.ToString()) { CreateNoWindow = true });

                        while (ConfigManager.isBetterCrewlinkInstalled())
                        {

                        }
                    }
                });
                finished = true;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static async Task<bool> StartShortcut(string[] parameters)
        {

            Mod m = ModList.getModById(parameters[1]);
            if (m == null) return false; // If mod doesn't exist

            ModVersion mv = m.versions.FindAll(ver => ver.version == parameters[2]).First();

            if (mv == null) // If doesn't exist, take latest
            {
                mv = m.versions.First();
            }

            List<ModOption> modOptions = new List<ModOption>() { };
            List<string> modOptionsStr = new List<string>() { };
            int i = 3;
            while (parameters.Count() > i)
            {
                ModOption mo = ModList.getModOptions(m, mv).FindAll(o => o.modOption == parameters[i]).First();
                if (mo != null)
                {
                    modOptions.Add(mo);
                    modOptionsStr.Add(mo.modOption);
                }
                i++;
            }

            if (!ConfigManager.isInstalled(m, mv, modOptions))
            {
                await ModWorker.installAnyMod(m, mv, modOptionsStr);
            }
            await ModWorker.startMod(m, mv, modOptionsStr);
            System.Windows.Forms.Application.Exit();
            return true;
        }

        public static async void installAndStartLocalMod(string modId, string modName, string githubAuthor, string githubRepo, string version, string gameVersion)
        {
            Mod m = ModList.getLocalMod(modId);
            if (m == null)
            {
                await installLocalMod(modId, modName, githubAuthor, githubRepo, version, gameVersion);
                return;
            }

            ModVersion mv = m.versions.FindAll(ver => ver.version == version).First();

            if (mv == null) // If doesn't exist
            {
                await installLocalMod(modId, modName, githubAuthor, githubRepo, version, gameVersion);
                return;
            }

            // When exist

            await startMod(m, mv, new List<string>() { });
        }

        public static async Task installLocalMod(string modId, string modName, string githubAuthor, string githubRepo, string version, string gameVersion)
        {
            Mod resutMod = await ModList.addLocalMod(modId, modName, githubAuthor, githubRepo, gameVersion, version);
            ModVersion resultVersion = resutMod.versions.FindAll(v => v.version == version).First();
            await installAnyMod(resutMod, resultVersion, new List<string>() { });
            installAndStartLocalMod(modId, modName, githubAuthor, githubRepo, version, gameVersion);
        }


        // Various

        public static bool isGameOpen(bool silent = false)
        {
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length >= 1)
                {
                    if (!silent)
                    {
                        MessageBox.Show("An instance of Among Us is already running", "Among Us already running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return false;
            }
        }

        public static string getBepInExInsideRec(string path)
        {
            try
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
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }
    }

    
}
