using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Drawing;
using System.Drawing.Imaging;

namespace ModManager5.Classes
{
    public static class ModList
    {
        public static List<Mod> mods;
        public static List<Mod> localMods;
        public static Release challengerClient;
        public static Release challengerClientBeta;

        public static void load()
        {
            Utils.log("Load START", "ModList");
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = Translator.get("Loading Mods...");
            string modlistURL = ModManager.apiURL + "/mod";
            string modlist = "";
            try
            {
                using (var client = new WebClient())
                {
                    modlist = client.DownloadString(modlistURL);
                }
            }
            catch (Exception e)
            {
                Utils.logE("Load connection FAIL", "ModList");
                Utils.logEx(e, "ModList");
                MessageBox.Show("Mod Manager's server is unreacheable.\n" +
                                    "\n" +
                                    "There are many possible reasons for this :\n" +
                                    "- You are disconnected from internet\n" +
                                    "- Your antivirus blocks Mod Manager\n" +
                                    "- Mod Manager server is down. Check its status on matux.fr\n" +
                                    "\n" +
                                    "If this problem persists, please send a ticket on Mod Manager's discord.", "Server unreacheable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            mods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(modlist);

            Utils.log("Load END", "ModList");
        }

        public static void loadLocalMods()
        {
            Utils.log("Load local mods START", "ModList");
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = Translator.get("Loading local mods...");

            string path = ModManager.appDataPath + @"\localMods.conf";
            if (System.IO.File.Exists(path))
            {
                Utils.log("Local mods exists", "ModList");
                string json = System.IO.File.ReadAllText(path);
                localMods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
            } else
            {
                Utils.log("Local mods does not exist", "ModList");
                localMods = new List<Mod>() { };
            }
            Utils.log("Load local mods END", "ModList");
        }

        public static void updateLocalMods()
        {
            Utils.log("Update local mods START", "ModList");
            string json = JsonConvert.SerializeObject(localMods);
            System.IO.File.WriteAllText(ModManager.appDataPath + @"\localMods.conf", json);
            Utils.log("Update local mods END", "ModList");
        }

        public static Mod getLocalModById(string id)
        {
            return localMods.Find(m => m.id == id);
        }

        public static async Task loadReleases()
        {
            Utils.log("Load Releases START", "ModList");
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = Translator.get("Loading Releases...");
            int max = mods.Count();
            int i = 0;
            List<Mod> releasesToRemove = new List<Mod>() { };

            List<Task> tasks = new List<Task>() { };

            Utils.log("Loading " + mods.Count() + " mods", "ModList");
            foreach (Mod m in mods)
            {
                Task t = loadRelease(m);
                i++;
                tasks.Add(t);
            }
            await Task.WhenAll(tasks);

            foreach (Mod m in mods)
            {
                if (m.type != "allInOne" && ((m.release == null && m.githubLink == "1") || m.id == "Challenger" || m.id == "ChallengerBeta"))
                {
                    releasesToRemove.Add(m);
                }
            }

            foreach (Mod toRemove in releasesToRemove)
            {
                mods.Remove(toRemove);
            }
            Utils.log("Loaded " + mods.Count() + " mods", "ModList");

            string localModsPath = ModManager.appDataPath + @"\localMods.json";
            if (System.IO.File.Exists(localModsPath))
            {
                Utils.log("Loading local mods START", "ModList");
                string json = System.IO.File.ReadAllText(localModsPath);
                List<Mod> localMods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
                mods.AddRange(localMods);
                Utils.log("Loading local mods END", "ModList");
            }

            Utils.log("Load Releases END", "ModList");
        }

        public static async Task loadRelease(Mod m)
        {
            Utils.log("Load release for mod " + m.id + " START", "ModList");
            if (m.type != "allInOne" || m.id == "BetterCrewlink")
            {
                await m.getGithubRelease();
            }
            else if (m.id == "Challenger")
            {
                await getChallengerReleases(m, true);
            } else if (m.id == "ChallengerBeta")
            {
                await getChallengerReleases(m, false);
            }
            Utils.log("Load release for mod " + m.id + " END", "ModList");
        }

        public static async Task getChallengerReleases(Mod m, Boolean live)
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(ModManager.token);
            client.Credentials = tokenAuth;
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll(m.author, m.github);
            m.release = releases.First();
            // There is no management of Challenger down because we assume that it will be always up
            challengerClient = null;
            challengerClientBeta = null;
            Release challengerMod = null;
            foreach (Release r in releases)
            {
                if (r.TagName.Contains("C") && challengerClient == null)
                {
                    challengerClient = r;
                }
                if (r.TagName.Contains("D") && challengerClientBeta == null) {
                    challengerClientBeta = r;
                }
                if (live) {
                    if (r.TagName.Contains("C") == false && r.TagName.Contains("D") == false && r.TagName.Contains("B") == false && r.TagName.Contains("L") == false && r.TagName.Contains("A") == false && challengerMod == null)
                    {
                        challengerMod = r;
                    }
                } else
                {
                    if (r.TagName.Contains("B") == true && challengerMod == null)
                    {
                        challengerMod = r;
                    }
                }
                if (challengerMod != null && ((live && challengerClient != null) || (!live && challengerClientBeta != null)))
                {
                    m.release = challengerMod;
                    break;
                }
            }
        }

        public static void createShortcut(Mod m)
        {
            Utils.log("Create shortcut START", "ModList");
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string title = m.name + " (Mod Manager)";
            string arguments = m.id;
            
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + title + ".lnk";
            
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Mod Manager Mod";
            shortcut.TargetPath = ModManager.appPath + @"\ModManager5.exe";
            shortcut.Arguments = arguments;
            
            string localPath = ModManager.appDataPath + @"\icons\" + m.id + ".ico";
            Utils.FileDelete(localPath);
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(ModManager.serverURL + @"/file/icons/" + m.id + ".ico", localPath);
                }
                shortcut.IconLocation = localPath;
            } catch (Exception e)
            {
                Utils.logEx(e, "ModList");
            }

            shortcut.Save();
            ModManagerUI.StatusLabel.Text = Translator.get("A shortcut has been created on your desktop !");

            Utils.log("Create shortcut END", "ModList");
        }

        public static Mod getModById(string id)
        {
            return mods.Find(m => m.id == id);
        }

        public static List<Mod> getModsByCategory(string category)
        {
            if (ConfigManager.config.launcher == "Steam")
                return mods.FindAll(m => m.category == category && m.type != "dependency");
            else
                return mods.FindAll(m => m.category == category && m.type != "dependency" && (m.type == "allInOne" || m.type == "local" || m.gameVersion == ServerConfig.get("gameVersion").value));
        }

        public static List<Mod> getMyMods(List<string> listOfMods)
        {
            return mods.FindAll(m => listOfMods.Contains(m.id));
        }
    }
}
