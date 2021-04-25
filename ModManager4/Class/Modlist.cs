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

        public Modlist(ModManager modManager)
        {
            this.modManager = modManager;
            this.resetChanged();
        }

        public async Task load()
        {
            string modlistURL = this.modManager.serverURL + "/modlist.json";
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

            string dependenciesURL = this.modManager.serverURL + "/dependencies.json";
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

            ProgressBar progress = (ProgressBar)this.modManager.Controls["InitProgressBar"];
            int max = this.mods.Count();
            int i = 0;
            foreach (Mod m in this.mods)
            {
                i++;
                progress.Value = (100 * i) / max;
                await m.getGithubRelease(this.modManager.token);
            }
            string localModsPath = this.modManager.appDataPath + "\\localMods.json";
            if (File.Exists(localModsPath))
            {
                string json = File.ReadAllText(localModsPath);
                List<Mod> localMods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
                this.mods.AddRange(localMods);
            }

            progress.Visible = false;
        }

        public void updateLocalMods()
        {
            List<Mod> localMods = this.getLocalMods();
            string json = JsonConvert.SerializeObject(localMods);
            File.WriteAllText(this.modManager.appDataPath + "\\localMods.json", json);
        }

        public List<Mod> getLocalMods()
        {
            List<Mod> localMods = new List<Mod>();
            foreach (Mod m in this.mods)
            {
                if (m.type == "localMod")
                {
                    localMods.Add(m);
                }
            }
            return localMods;
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
            foreach (Mod m in this.mods)
            {
                if (m.id == id)
                {
                    return m;
                }
            }
            return null;
        }

        public List<string> getCategories()
        {
            List<string> categories = new List<string>();
            foreach (Mod m in this.mods)
            {
                if (!categories.Contains(m.category))
                {
                    categories.Add(m.category);
                }
            }
            return categories;
        }

        public List<string> getAvailableCategories()
        {
            List<string> categories = new List<string>();
            foreach (Mod m in this.mods)
            {
                if (!categories.Contains(m.category) && m.gameVersion == this.modManager.serverConfig.gameVersion)
                {
                    categories.Add(m.category);
                }
            }
            return categories;
        }

        public List<Mod> getModsByCategory(string category)
        {
            List<Mod> retour = new List<Mod>();
            foreach (Mod m in this.mods)
            {
                if (m.category == category)
                {
                    retour.Add(m);
                }
            }
            return retour;
        }

        public List<Mod> getAvailableModsByCategory(string category)
        {
            List<Mod> retour = new List<Mod>();
            foreach (Mod m in this.mods)
            {
                if (m.category == category && m.gameVersion == this.modManager.serverConfig.gameVersion)
                {
                    retour.Add(m);
                }
            }
            return retour;
        }

        public List<Mod> getAvailableMods()
        {
            List<Mod> retour = new List<Mod>();
            foreach (Mod m in this.mods)
            {
                if (m.gameVersion == this.modManager.serverConfig.gameVersion)
                {
                    retour.Add(m);
                }
            }
            return retour;
        }

        public List<Mod> getAvailableRemoteMods()
        {
            List<Mod> retour = new List<Mod>();
            foreach (Mod m in this.mods)
            {
                if (m.gameVersion == this.modManager.serverConfig.gameVersion && m.type == "mod")
                {
                    retour.Add(m);
                }
            }
            return retour;
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
