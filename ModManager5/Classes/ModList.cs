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

        public static void load()
        {
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Loading Mods...";
            string modlistURL = ModManager.apiURL + "/mod/list";
            string modlist = "";
            try
            {
                using (var client = new WebClient())
                {
                    modlist = client.DownloadString(modlistURL);
                }
            }
            catch
            {
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

            
        }

        public static void loadLocalMods()
        {
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Loading local mods...";

            string path = ModManager.appDataPath + @"\localMods.conf";
            if (System.IO.File.Exists(path))
            {
                string json = System.IO.File.ReadAllText(path);
                localMods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
            } else
            {
                localMods = new List<Mod>() { };
            }
        }

        public static void updateLocalMods()
        {
            string json = JsonConvert.SerializeObject(localMods);
            System.IO.File.WriteAllText(ModManager.appDataPath + @"\localMods.conf", json);
        }

        public static Mod getLocalModById(string id)
        {
            return localMods.Find(m => m.id == id);
        }

        public static async Task loadReleases()
        {
            if (!ModManager.silent)
                ModManagerUI.StatusLabel.Text = "Loading Releases...";
            int max = mods.Count();
            int i = 0;
            List<Mod> releasesToRemove = new List<Mod>() { };

            List<Task> tasks = new List<Task>() { };
            foreach (Mod m in mods)
            {
                Task t = loadRelease(m);
                i++;
                tasks.Add(t);
            }
            await Task.WhenAll(tasks);

            foreach (Mod m in mods)
            {
                if (m.type != "allInOne" && (m.release == null || m.id == "Challenger" || m.id == "ChallengerBeta" || ConfigManager.containsGameVersion(m.gameVersion) == false))
                {
                    releasesToRemove.Add(m);
                }
            }

            foreach (Mod toRemove in releasesToRemove)
            {
                mods.Remove(toRemove);
            }

            string localModsPath = ModManager.appDataPath + @"\localMods.json";
            if (System.IO.File.Exists(localModsPath))
            {
                string json = System.IO.File.ReadAllText(localModsPath);
                List<Mod> localMods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
                mods.AddRange(localMods);
            }

        }

        public static async Task loadRelease(Mod m)
        {
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
            Release challengerMod = null;
            foreach (Release r in releases)
            {
                if (r.TagName.Contains("C") && challengerClient == null)
                {
                    challengerClient = r;
                }
                if (live) {
                    if (r.TagName.Contains("C") == false && r.TagName.Contains("B") == false && r.TagName.Contains("L") == false && r.TagName.Contains("A") == false && challengerMod == null)
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
                if (challengerMod != null && challengerClient != null)
                {
                    m.release = challengerMod;
                    break;
                }
            }
        }

        public static void createShortcut(Mod m)
        {
            ModManagerUI.StatusLabel.Text = "A shortcut is under creation, please wait...";
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
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(ModManager.apiURL + @"/files/icons/" + m.id + ".ico", localPath);
                }
                shortcut.IconLocation = localPath;
            } catch
            {

            }

            shortcut.Save();
            ModManagerUI.StatusLabel.Text = "A shortcut has been created on your desktop !";
        }

        public static Mod getModById(string id)
        {
            return mods.Find(m => m.id == id);
        }

        public static List<Mod> getModsByCategory(string category)
        {
            return mods.FindAll(m => m.category == category);
        }

        public static List<Mod> getMyMods(List<string> listOfMods)
        {
            return mods.FindAll(m => listOfMods.Contains(m.id));
        }
    }
}
