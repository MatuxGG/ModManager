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

namespace ModManager4.Class
{
    public class Modlist
    {
        public List<Mod> mods;
        public List<Dependency> availableDependencies;
        public ModManager modManager;
        public string code;
        public List<string> toInstall;
        public List<string> toUninstall;
        public Release challengerClient;
        public Release challengerMod;

        public Modlist(ModManager modManager)
        {
            this.modManager = modManager;
            this.resetChanged();
        }

        public void load()
        {
            this.modManager.logs.log("Loading modlist");
            string modlistURL = this.modManager.apiURL + "/mods";
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
                this.modManager.logs.log("Error : Disconnected when loading modlist\n");
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
            this.mods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(modlist);

            string dependenciesURL = this.modManager.apiURL + "/dependencies";
            string dependencies = "";
            try
            {
                using (var client = new WebClient())
                {
                    dependencies = client.DownloadString(dependenciesURL);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected when loading dependencies\n");
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
            this.availableDependencies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dependency>>(dependencies);

            this.modManager.logs.log("- Modlist loaded successfully");
        }

        public async Task loadReleases()
        {
            ProgressBar progress = (ProgressBar)this.modManager.Controls["InitProgressBar"];
            int max = this.mods.Count();
            int i = 0;
            List<Mod> releasesToRemove = new List<Mod>() { };

            List<Task> tasks = new List<Task>() { };
            foreach (Mod m in this.mods)
            {
                Task t = this.loadRelease(m);
                i++;
                tasks.Add(t);
            }
            progress.Value = 50;
            await Task.WhenAll(tasks);
            progress.Value = 100;

            
            foreach(Mod m in this.mods)
            {
                if (m.type != "allInOne" && m.name != "Challenger" && m.release == null)
                {
                    releasesToRemove.Add(m);
                }
            }

            foreach (Mod toRemove in releasesToRemove)
            {
                this.mods.Remove(toRemove);
            
            }
            
            string localModsPath = this.modManager.appDataPath + "\\localMods.json";
            if (File.Exists(localModsPath))
            {
                string json = File.ReadAllText(localModsPath);
                List<Mod> localMods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);

                // Code to remove old local mods
                //
                List<Mod> oldMods = new List<Mod>() { };
                foreach (Mod lm in localMods)
                {
                    if (lm.category == "Local mods")
                    {
                        oldMods.Add(lm);
                    }
                }
                if (oldMods.Count > 0)
                {
                    foreach (Mod toRemove in oldMods)
                    {
                        localMods.Remove(toRemove);
                    }
                    json = JsonConvert.SerializeObject(localMods);
                    File.WriteAllText(this.modManager.appDataPath + "\\localMods.json", json);
                }
                //

                this.mods.AddRange(localMods);
            }

            progress.Visible = false;
        }

        public async Task loadRelease(Mod m)
        {
            if (m.type != "allInOne" || m.id == "BetterCrewlink")
            {
                await m.getGithubRelease(this.modManager.token);
            }
            else if (m.id == "Challenger")
            {
                await this.getChallengerReleases(m, this.modManager.token);
            }
        }

        public async Task getChallengerReleases(Mod m, string token)
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(token);
            client.Credentials = tokenAuth;
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll(m.author, m.github);
            m.release = releases.First();
            // There is no management of Challenger down because we assume that it will be always up
            this.challengerClient = null;
            this.challengerMod = null;
            foreach (Release r in releases)
            {
                if (r.TagName.Contains("C") && this.challengerClient == null)
                {
                    this.challengerClient = r;
                }
                if (r.TagName.Contains("C") == false && r.TagName.Contains("B") == false && r.TagName.Contains("L") == false && r.TagName.Contains("A") == false && this.challengerMod == null)
                {
                    this.challengerMod = r;
                }
                if (this.challengerMod != null && this.challengerClient != null)
                {
                    break;
                }
            }
        }

        public void updateLocalMods()
        {
            List<Mod> localMods = this.getLocalMods();
            string json = JsonConvert.SerializeObject(localMods);
            File.WriteAllText(this.modManager.appDataPath + "\\localMods.json", json);
        }

        public List<Mod> getLocalMods()
        {
            return this.mods.FindAll(m => m.type == "localMod");
        }

        public void resetChanged()
        {
            this.toInstall = new List<string>();
            this.toUninstall = new List<string>();
        }

        private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
            { 'A', "00000" },
            { 'B', "00001" },
            { 'C', "00010" },
            { 'D', "00011" },
            { 'E', "00100" },
            { 'F', "00101" },
            { 'G', "00110" },
            { 'H', "00111" },
            { 'I', "01000" },
            { 'J', "01001" },
            { 'K', "01010" },
            { 'L', "01011" },
            { 'M', "01100" },
            { 'N', "01101" },
            { 'O', "01110" },
            { 'P', "01111" },
            { 'Q', "10000" },
            { 'R', "10001" },
            { 'S', "10010" },
            { 'T', "10011" },
            { 'U', "10100" },
            { 'V', "10101" },
            { 'W', "10110" },
            { 'X', "10111" },
            { 'Y', "11000" },
            { 'Z', "11001" },
            { '1', "11010" },
            { '2', "11011" },
            { '3', "11100" },
            { '4', "11101" },
            { '5', "11110" },
            { '6', "11111" }
        };

        private static readonly Dictionary<string, char> BinaryToHexCharacter = new Dictionary<string, char> {
            { "00000", 'A' },
            { "00001", 'B' },
            { "00010", 'C' },
            { "00011", 'D' },
            { "00100", 'E' },
            { "00101", 'F' },
            { "00110", 'G' },
            { "00111", 'H' },
            { "01000", 'I' },
            { "01001", 'J' },
            { "01010", 'K' },
            { "01011", 'L' },
            { "01100", 'M' },
            { "01101", 'N' },
            { "01110", 'O' },
            { "01111", 'P' },
            { "10000", 'Q' },
            { "10001", 'R' },
            { "10010", 'S' },
            { "10011", 'T' },
            { "10100", 'U' },
            { "10101", 'V' },
            { "10110", 'W' },
            { "10111", 'X' },
            { "11000", 'Y' },
            { "11001", 'Z' },
            { "11010", '1' },
            { "11011", '2' },
            { "11100", '3' },
            { "11101", '4' },
            { "11110", '5' },
            { "11111", '6' }
        };

        public string getCode()
        {
            string code = "";
            foreach (Mod m in this.getAvailableRemoteMods())
            {
                if (this.modManager.config.containsMod(m.id))
                {
                    code = code + "1";
                }
                else
                {
                    code = code + "0";
                }
            }
            string ret = this.BinaryStringToHex(code);
            return ret;
        }

        public string getCodeFromList(List<string> modsToInstall)
        {
            string code = "";
            foreach (Mod m in this.getAvailableRemoteMods())
            {
                if (modsToInstall.Contains(m.id))
                {
                    code = code + "1";
                }
                else
                {
                    code = code + "0";
                }
            }
            string ret = this.BinaryStringToHex(code);
            return ret;
        }

        public void setCode()
        {
            this.code = this.getCode();
            TextBox t = (TextBox)this.modManager.componentlist.get("Footer").getControl("CodeTextbox");
            t.Text = this.code;
        }

        public string BinaryStringToHex(string binary)
        {
            StringBuilder result = new StringBuilder();
            while (binary.Length % 5 != 0)
            {
                binary = binary + "0";
            }
            while (binary.Length >= 5)
            {
                string sub = binary.Substring(0, 5);
                result.Append(BinaryToHexCharacter[sub]);
                binary = binary.Substring(5);
            }
            return result.ToString();
        }
        public string HexStringToBinary(string hex)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in hex)
            {
                result.Append(hexCharacterToBinary[c]);
            }
            return result.ToString();
        }

        public Mod getModById(string id)
        {
            return this.mods.Find(m => m.id == id);
        }

        public Mod getAvailableModById(string id)
        {
            return this.mods.Find(m => m.id == id && m.gameVersion == this.modManager.serverConfig.get("gameVersion").value);
        }

        public List<Category> getAvailableCategories(ModManager modManager)
        {
            return this.modManager.categorylist.categories.FindAll(c => this.mods.Find(m => c.id == m.category) != null);
        }

        public List<Mod> getModsByCategory(Category category)
        {
            return this.mods.FindAll(m => m.category == category.id);
        }

        public List<Mod> getAvailableModsByCategory(Category category)
        {
            return sort(this.mods.FindAll(m => m.category == category.id && m.gameVersion == this.modManager.serverConfig.get("gameVersion").value));
        }

        public List<Mod> getAvailableMods()
        {
            return this.mods.FindAll(m => m.gameVersion == this.modManager.serverConfig.get("gameVersion").value);
        }

        public List<Mod> getAvailableRemoteMods()
        {
            return this.mods.FindAll(m => m.gameVersion == this.modManager.serverConfig.get("gameVersion").value && m.type == "mod");
        }

        public List<Mod> sort(List<Mod> mods)
        {
            Mod[] res = mods.ToArray();
            QuickSort(res, 0, res.Length - 1);
            return new List<Mod>(res);
        }

        private void QuickSort(Mod[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        private int Partition(Mod[] arr, int start, int end)
        {
            Mod temp;
            Mod p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (this.inferior(arr[j],p))
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }

        private Boolean inferior(Mod a, Mod b)
        {
            int i;
            switch (this.modManager.config.sortType)
            {
                case "Author":
                    i = String.Compare(a.author, b.author);
                    break;
                case "Version":
                    if (a.type == "localMod" || a.type == "allInOne")
                    {
                        i = String.Compare(a.name, b.name);
                    } else
                    {
                        i = String.Compare(a.release.TagName, b.release.TagName);
                    }
                    break;
                case "Checked":
                    Boolean installedA = this.modManager.config.containsMod(a.id);
                    Boolean installedB = this.modManager.config.containsMod(b.id);
                    if (installedA == true && installedB == false)
                    {
                        i = -1;
                    } else if (installedA == false && installedB == true)
                    {
                        i = 1;
                    } else
                    {
                        i = String.Compare(a.name, b.name);
                    }
                    break;
                default:
                    i = String.Compare(a.name, b.name);
                    break;
            }
            if (this.modManager.config.sortOrder == "A")
            {
                return i < 0;
            } else
            {
                return i > 0;
            }
        }

        public string toString()
        {
            string ret = "ModList :\n";
            foreach (Mod m in this.mods)
            {
                ret = ret + "- Mod " + m.id + ": Name = " + m.name + " / Author = " + m.author + " / Category = " + m.category + " / Game version = " + m.gameVersion + " /  Github = "+ m.github + " / Type = " + m.type + " / Dependencies = [";
                int i = 0;
                foreach (string d in m.dependencies) 
                {
                    if (i != 0)
                    {
                        ret = ret + ", ";
                    }
                    ret = ret + d.ToString();
                    i++;
                }
                ret = ret + "]\n";
            }
            return ret;
        }

    }
}
