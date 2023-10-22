using IWshRuntimeLibrary;
using ModManager6.Properties;
using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public static class ModList
    {
        public static List<ModSource> modSources;

        public static async Task load()
        {
            try
            {
                modSources = new List<ModSource>() { };

                // Load local mods
                string localSourcePath = ModManager.appDataPath + @"\localMods.json";
                string json;

                if (!System.IO.File.Exists(localSourcePath))
                {
                    ModSource localSource = new ModSource("Local");
                    json = JsonConvert.SerializeObject(localSource);
                    System.IO.File.WriteAllText(localSourcePath, json);
                }
                json = System.IO.File.ReadAllText(localSourcePath);
                ModSource modSource = Newtonsoft.Json.JsonConvert.DeserializeObject<ModSource>(json);
                modSources.Add(modSource);

                // Load external sources
                List<Task> tasks = new List<Task>() { };
                foreach (string source in ConfigManager.config.sources)
                {
                    tasks.Add(FetchSource(source));
                }
                await Task.WhenAll(tasks);

            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static async Task<Mod> addLocalMod(string modId, string modName, string githubAuthor, string githubRepo, string gameVersion, string version)
        {
            ModSource localSource = modSources.FindAll(s => s.name == "Local").FirstOrDefault();
            ModVersion newVersion = new ModVersion(version, gameVersion);
            Mod newLocal = ModList.getLocalMod(modId);
            bool isNew = false;
            if (newLocal.versions.FindAll(v => v.gameVersion == gameVersion).FirstOrDefault() != null)
            {
                Log.showError("ModList", "AddLocalMod", "A version of this mod already exist for this game version");
            }
            if (newLocal == null)
            {
                isNew = true;
                newLocal = new Mod(modId, modName, new Category("Local", "Local", 1000), "mod", githubAuthor, githubRepo);
                newLocal.versions = new List<ModVersion>() {};
            }
            newLocal.versions.Add(newVersion);
            if (isNew)
            {
                localSource.mods.Add(newLocal);
            }
            ModList.updateLocalMods();
            await loadRelease(newLocal);
            foreach (ModVersion v in newLocal.versions)
            {
                if (v.release == null)
                {
                    localSource.mods.Remove(newLocal);
                    ModList.updateLocalMods();
                    Log.showError("ModList", "AddLocalMod", "This mod doesn't exist");
                }
            }
            return newLocal;
        }

        public static Mod getLocalMod(string modId)
        {
            ModSource localSource = modSources.FindAll(s => s.name == "Local").FirstOrDefault();
            return localSource.mods.FindAll(m => m.id == modId).FirstOrDefault();
        }

        public static void updateLocalMods()
        {
            try
            {
                string json = JsonConvert.SerializeObject(modSources.FindAll(s => s.name == "Local").FirstOrDefault());
                if (json == null) return;
                System.IO.File.WriteAllText(ModManager.appDataPath + @"\localMods.json", json);
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static async Task FetchSource(string source)
        {
            try
            {
                string result = await Downloader.downloadString(source);
                ModSource modSource = Newtonsoft.Json.JsonConvert.DeserializeObject<ModSource>(result);
                modSources.Add(modSource);
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static async Task loadReleases()
        {
            try
            {

                List<Task> tasks = new List<Task>() { };
                foreach (ModSource source in modSources)
                {
                    foreach (Mod m in source.mods)
                    {
                        tasks.Add(loadRelease(m));
                    }
                }
                await Task.WhenAll(tasks);

                // Remove mods without releases / versions
                foreach (ModSource source in modSources)
                {
                    List<Mod> modsToRemove = new List<Mod>() { };
                    foreach (Mod m in source.mods)
                    {
                        if (m.type == "mod")
                        {
                            List<ModVersion> versionsToRemove = new List<ModVersion>() { };

                            // Find versions without release
                            foreach (ModVersion v in m.versions)
                            {
                                if (v.release == null)
                                {
                                    versionsToRemove.Add(v);
                                }
                            }

                            // Remove versions without release
                            foreach (ModVersion v in versionsToRemove)
                            {
                                m.versions.Remove(v);
                            }

                            // Find mods without version
                            if (m.versions.Count() == 0)
                            {
                                modsToRemove.Add(m);
                            }
                        }
                    }
                    // Remove mods without version
                    foreach (Mod mo in modsToRemove)
                    {
                        source.mods.Remove(mo);
                    }
                }

                foreach (ModSource modSource1 in modSources)
                {
                    foreach (Mod m in modSource1.mods)
                    {
                        foreach (ModVersion mv in m.versions)
                        {
                            if (mv.version == "latest")
                            {
                                mv.version = mv.release.TagName;
                            }
                        }
                    }
                }

                // Sort mods by gameVersion
                foreach (ModSource modSource in modSources)
                {
                    foreach (Mod m in modSource.mods)
                    {
                        m.versions.Sort((a, b) => b.gameVersion.CompareTo(a.gameVersion));
                    }
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static async Task loadRelease(Mod m)
        {
            if (m.id == "Tuxmongus")
            {
                Log.debug("BepInEx23");
            }
            try
            {
                if (m.type == "mod")
                {
                    IReadOnlyCollection<Release> releases = await ModManager.githubClient.Repository.Release.GetAll(m.author, m.github);

                    int i = 0;

                    foreach (Release release in releases)
                    {
                        foreach (ModVersion v in m.versions)
                        {
                            if (i == 0 && v.version == "latest")
                            {
                                v.release = release;
                            }
                            else if (release.TagName == v.version)
                            {
                                v.release = release;
                                break;
                            }
                        }
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Log.logError("ModList loadRelease", e.Source, e.Message);
            }
        }

        public static async void createShortcut(Mod m, ModVersion mv, List<string> mos)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string title = m.name + " " + mv.version;
            string arguments = "startmod " + m.id + " " + mv.version;
            foreach (string mo in mos)
            {
                title = title + " & " + mo;
                arguments = arguments + " " + mo;
            }
            title = title + " (Mod Manager)";

            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + title + ".lnk";

            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Mod Manager Mod";
            shortcut.TargetPath = ModManager.appPath + @"\ModManager6.exe";
            shortcut.Arguments = arguments;

            string localPath = ModManager.appDataPath + @"\icons\" + m.id + ".ico";
            FileSystem.FileDelete(localPath);
            try
            {
                DownloadLine dl = new DownloadLine(ModManager.serverURL + @"/file/icons/" + m.id + ".ico", localPath);
                await Downloader.DownloadFile(dl);
            }
            catch (Exception e)
            {
                Log.logError("ModList createShortcut", e.Source, e.Message);
            }

            if (System.IO.File.Exists(localPath))
            {
                shortcut.IconLocation = localPath;
            }

            shortcut.Save();
            string statusText = Translator.get("A shortcut has been created on your desktop !");
            ModManagerUI.StatusLabel.Text = statusText;
            ModManagerUI.Alert(statusText);
        }

        public static List<Mod> getAllMods()
        {
            try
            {
                List<Mod> mods = new List<Mod>();

                modSources.ForEach(s =>
                {
                    List<Mod> modsFromSource = s.mods.FindAll(m => m.type == "mod");
                    mods.AddRange(modsFromSource);
                });

                return mods;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static Mod getModById(string modId)
        {
            try
            {
                foreach (ModSource source in modSources)
                {
                    Mod m = source.mods.Find(m => m.id == modId);
                    if (m != null) return m;
                }
                return null;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static List<Category> getAllCategories()
        {
            try
            {
                List<Category> categories = new List<Category>() { };
                foreach (ModSource source in modSources)
                {
                    foreach (Mod mod in source.mods)
                    {
                        if (mod.type == "mod" && categories.Find(c => c.id == mod.category.id) == null)
                        {
                            categories.Add(mod.category);
                        }
                    }
                }
                categories.Sort((x, y) => x.weight.CompareTo(y.weight));
                return categories;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static List<Mod> getModsByCategoryId(string categoryId)
        {
            try
            {
                List<Mod> mods = new List<Mod>() { };
                modSources.ForEach(s => s.mods.FindAll(m => (m.type == "mod" || m.type == "allInOne") && m.category.id == categoryId).ForEach(m => mods.Add(m)));
                mods.Sort((x, y) => y.name.CompareTo(x.name));
                return mods;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static Category getCategoryById(string categoryId)
        {
            try
            {
                if (categoryId == "Favorites")
                    return new Category("Favorites", "Favorites");
                foreach (ModSource source in modSources)
                {
                    foreach (Mod mod in source.mods)
                    {
                        if (mod.category.id == categoryId)
                        {
                            return mod.category;
                        }
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

        public static List<ModOption> getModOptions(Mod m, ModVersion mv)
        {
            try
            {
                List<ModOption> modOptions = new List<ModOption>() { };
                foreach (ModSource ms in modSources)
                {
                    foreach (Mod mod in ms.mods)
                    {
                        if (mod.id != m.id)
                        {
                            foreach (ModVersion v in mod.versions)
                            {
                                if (v.canBeCombined == true && mv.gameVersion == v.gameVersion)
                                {
                                    modOptions.Add(new ModOption(mod.id, v.gameVersion));
                                }
                            }
                        }
                    }
                }

                return modOptions;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

    }
}
