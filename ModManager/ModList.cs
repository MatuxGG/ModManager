using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager
{
    public class ModList
    {
        public List<Mod> mods;

        public string url;

        public string path;

        public Mod currentMod;

        public string currentCat;

        public ModManager modManager;

        public string token;

        public ModList(string url, string path, ModManager modManager)
        {
            this.url = url;
            this.path = path;
            this.modManager = modManager;
            this.load();
        }

        public void load()
        {
            this.token = System.IO.File.ReadAllText(this.modManager.appPath+"\\token.txt");
            using (var client = new WebClient())
            {
                client.DownloadFile(this.url+"/modlist.json", this.path);
            }
            string json = System.IO.File.ReadAllText(this.path);
            this.mods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
            File.Delete(this.path);
        }

        public void show()
        {
            ComboBox comboCats = (ComboBox)this.modManager.pagelist.get("ModSelection").getControl("CatListCombo");
            comboCats.Items.Clear();
            int i = 0;
            foreach (string item in this.getCategories())
            {
                // Affichage Mod

                comboCats.Items.Add(item);

                if (i == 0)
                {
                    comboCats.SelectedItem = item;
                    this.currentCat = item;
                }
                i++;
            }

            this.changeModsForCategory();
            
        }

        public void changeModsForCategory()
        {
            ComboBox comboMods = (ComboBox)this.modManager.pagelist.get("ModSelection").getControl("ModListCombo");
            comboMods.Items.Clear();
            int i = 0;
            foreach (Mod item in this.getByCategory(this.currentCat))
            {
                // Affichage Mod

                comboMods.Items.Add(item.name);

                if (i == 0)
                {
                    comboMods.SelectedItem = item.name;
                    this.currentMod = item;
                }

                i++;

            }
        }

        public Mod get(string id)
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

        public List<Mod> getByCategory(string category)
        {
            List<Mod> retour = new List<Mod>();
            foreach(Mod m in this.mods)
            {
                if (m.category == category)
                {
                    retour.Add(m);
                }
            }
            return retour;
        }

        public Mod getModFromName(string name)
        {
            foreach (Mod m in this.mods)
            {
                if (m.name == name)
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

        public void changeCat(object sender, EventArgs e)
        {
            ComboBox changedBox = ((ComboBox)sender);
            this.currentCat = changedBox.SelectedItem.ToString();

            this.currentMod = this.getByCategory(this.currentCat)[0];

            this.changeModsForCategory();

            this.changeModWorker();
        }

        public void changeMod(object sender, EventArgs e)
        {
            ComboBox changedBox = ((ComboBox)sender);
            this.currentMod = this.getModFromName(changedBox.SelectedItem.ToString());
            this.changeModWorker();
        }

        public async void changeModWorker()
        {
            Page modSelectionPage = (Page)this.modManager.pagelist.get("ModSelection");

            modSelectionPage.getControl("AuthorLabel").Text = this.modManager.modlist.currentMod.author;

            await this.GetGithubInfos(this.modManager.modlist.currentMod.author, this.modManager.modlist.currentMod.github);

            using (WebClient wc = new WebClient())
            {
                string version = this.modManager.currentRelease.TagName;
                modSelectionPage.getControl("VersionLabel").Text = version;
                modSelectionPage.getControl("GameVersionLabel").Text = this.currentMod.gameVersion;
                modSelectionPage.getControl("GithubLabel").Text = "https://github.com/" + this.currentMod.author + "/" + this.currentMod.github;
                modSelectionPage.getControl("DescriptionLabel").Text = this.currentMod.description;
                Button installButton = (Button)modSelectionPage.getControl("InstallModButton");
                Button uninstallButton = (Button)modSelectionPage.getControl("UninstallModButton");
                Button updateButton = (Button)modSelectionPage.getControl("UpdateModButton");
                updateButton.Visible = false;
                installButton.Visible = false;
                uninstallButton.Visible = false;
                if (this.modManager.config.containsMod(this.currentMod.id))
                {
                    uninstallButton.Visible = true;
                    if (!this.modManager.config.isUpTodate(this.currentMod.id, version))
                    {
                        updateButton.Visible = true;
                    }
                }
                else if (this.modManager.config.amongUsPath != null)
                {
                    installButton.Visible = true;
                }
            }
        }

        public async Task GetGithubInfos(string author, string repository)
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials(this.token);
            client.Credentials = tokenAuth;
            this.modManager.currentRelease = null;
            this.modManager.currentRelease = await client.Repository.Release.GetLatest(author, repository);
        }

        public void installDependencies()
        {
            List<string> dependencies = new List<string>();
            dependencies.Add("BepInEx");
            foreach (string dependencie in dependencies)
            {
                if (this.modManager.config.installedDependencies.Contains(dependencie) == false)
                {
                    string tempPath = Path.GetTempPath() + "\\ModManager";
                    this.modManager.utils.FileDelete(tempPath + "\\" + dependencie + ".zip");
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(this.url + "/" + dependencie + ".zip", tempPath + "\\" + dependencie + ".zip");
                    }
                    ZipFile.ExtractToDirectory(tempPath + "\\" + dependencie + ".zip", this.modManager.config.amongUsPath);
                    this.modManager.config.installedDependencies.Add(dependencie);
                }
            }
            this.modManager.config.update();
        }

        public void uninstallMod(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show("Close Among Us to uninstall this mod", "Can't uninstall mod", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton").BackColor = System.Drawing.Color.Orange;
            if (this.modManager.config.installedMods.Count == 1)
            {
                this.uninstallModsWorker();
            } else
            {
                this.uninstallModWorker();
            }
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").Visible = true;
            this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton").BackColor = System.Drawing.Color.Blue;
            this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton").Visible = false;
            MessageBox.Show("The mod have been uninstalled !", "Mod uninstalled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void uninstallModWorker()
        {
            InstalledMod installedMod = this.modManager.config.getInstalledModById(this.currentMod.id);
            string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";
            foreach (string plugin in installedMod.plugins)
            {
                this.modManager.utils.FileDelete(pluginsPath + "\\" + plugin);
            }
            string assetsPath = this.modManager.config.amongUsPath + "\\Assets";
            foreach (string asset in installedMod.assets)
            {
                this.modManager.utils.FileDelete(assetsPath + "\\" + asset);
            }
            this.modManager.config.installedMods.Remove(installedMod);
            this.modManager.config.update();
        }

        public void updateMod(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show("Close Among Us to update this mod", "Can't update mod", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.uninstallModWorker();
            this.installModWorker();
            this.modManager.pagelist.get("ModSelection").getControl("UpdateModButton").Visible = false;
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").Visible = false;
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Blue;
            this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton").Visible = true;
            MessageBox.Show("The mod have been updated !", "Mod updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void installMod(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show("Close Among Us to install this mod", "Can't install mod", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Orange;
            this.installModWorker();
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").Visible = false;
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Blue;
            this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton").Visible = true;
            this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton").BackColor = System.Drawing.Color.Red;
            MessageBox.Show("The mod have been installed !", "Mod installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public void installModWorker()
        {
            if (this.modManager.config.containsMod(this.currentMod.id) == false)
            {

                this.installDependencies();

                string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";

                bool foundDll = false;
                foreach (ReleaseAsset tab in this.modManager.currentRelease.Assets)
                    {
                        string fileName = tab.Name;
                        if (fileName.Contains(".dll"))
                        {
                            foundDll = true;
                            this.installDll(this.modManager.currentRelease, tab);
                        }
                    }
                if (foundDll)
                {
                    return;
                }
                foreach (ReleaseAsset tab in this.modManager.currentRelease.Assets)
                    {
                        string fileName = tab.Name;
                        if (fileName.Contains(".zip"))
                        {
                            this.installZip(this.modManager.currentRelease, tab);
                        return;
                        }
                    }
                return;
            }
        }

        public void installDll(Release jObject, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = jObject.TagName;
            string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";
            using (var client = new WebClient())
            {
                client.DownloadFile(fileUrl, pluginsPath + "\\" + fileName);
            }

            List<string> plugins = new List<string>();
            plugins.Add(fileName);
            InstalledMod newMod = new InstalledMod(this.currentMod.id, fileTag, new List<string>(), plugins);
            this.modManager.config.installedMods.Add(newMod);
            this.modManager.config.update();
            return;
        }

        public void installZip(Release jObject, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = jObject.TagName;
            string tempPath = Path.GetTempPath() + "\\ModManager";
            this.modManager.utils.DirectoryDelete(tempPath);
            Directory.CreateDirectory(tempPath);
            string zipPath = tempPath + "\\" + fileName;
            using (var client = new WebClient())
            {
                client.DownloadFile(fileUrl, zipPath);
            }
            this.modManager.utils.DirectoryDelete(tempPath + "\\BepInEx");
            this.modManager.utils.DirectoryDelete(tempPath + "\\Assets");
            this.modManager.utils.DirectoryDelete(tempPath + "\\mono");
            this.modManager.utils.FileDelete(tempPath + "\\doorstop_config.ini");
            this.modManager.utils.FileDelete(tempPath + "\\winhttp.dll");
            ZipFile.ExtractToDirectory(zipPath, tempPath);
            // Install dll
            DirectoryInfo dirInfo = new DirectoryInfo(tempPath + "\\BepInEx\\plugins");
            List<string> plugins = new List<string>();
            if (dirInfo.Exists)
            {
                FileInfo[] files = dirInfo.GetFiles("*.dll");
                foreach (FileInfo f in files)
                {
                    if (!(f.Name.Contains("Essentials-") || f.Name.Contains("Reactor-")))
                    {
                        File.Copy(f.FullName, this.modManager.config.amongUsPath + "\\BepInEx\\plugins\\" + f.Name);
                        plugins.Add(f.Name);
                    }
                }
            }
            DirectoryInfo dirInfo2 = new DirectoryInfo(tempPath + "\\Assets");
            List<string> assets = new List<string>();
            if (dirInfo2.Exists)
            {
                FileInfo[] files = dirInfo2.GetFiles();
                foreach (FileInfo f in files)
                {
                    File.Copy(f.FullName, this.modManager.config.amongUsPath + "\\Assets\\" + f.Name);
                    assets.Add(f.Name);
                }
            }
            InstalledMod newMod = new InstalledMod(this.currentMod.id, fileTag, assets, plugins);
            this.modManager.config.installedMods.Add(newMod);
            this.modManager.config.update();
            return;
        }

        public void uninstallMods(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show("Close Among Us to uninstall mods", "Can't uninstall mods", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.uninstallModsWorker();

            Control installButton = this.modManager.pagelist.get("ModSelection").getControl("InstallModButton");

            if (installButton != null)
            {
                installButton.Visible = true;
            }

            Control uninstallButton = this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton");

            if (uninstallButton != null)
            {
                uninstallButton.Visible = false;
            }

            MessageBox.Show("All Mods have been uninstalled !", "Mods uninstalled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void uninstallModsWorker()
        {
            if (this.modManager.config != null)
            {
                if (this.modManager.config.amongUsPath != null)
                {

                    this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\BepInEx");
                    this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\Assets");
                    this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\mono");
                    this.modManager.utils.FileDelete(this.modManager.config.amongUsPath + "\\doorstop_config.ini");
                    this.modManager.utils.FileDelete(this.modManager.config.amongUsPath + "\\winhttp.dll");
                }
                if (this.modManager.config.installedDependencies != null)
                {
                    this.modManager.config.installedDependencies.Clear();
                }
                if (this.modManager.config.installedMods != null)
                {
                    this.modManager.config.installedMods.Clear();
                }
                this.modManager.config.update();

            }
        }

        public string getCode()
        {
            string code = "";
            foreach (Mod m in this.mods)
            {
                if (this.modManager.config.containsMod(m.id))
                {
                    code = code + "1";
                } else
                {
                    code = code + "0";
                }
            }
            return this.BinaryStringToHex(code);
        }

        public void enterCode(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show("Close Among Us to use a code", "Can't enter code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string code = this.modManager.pagelist.get("Installed").getControl("UploadCodeTextbox").Text;
            this.installFromCode(code);
            MessageBox.Show("Mods from code have been installed", "Mods installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void installFromCode(string code)
        {
            string binary = HexStringToBinary(code);
            this.uninstallModsWorker();
            int i = 0;
            foreach(Mod m in this.mods)
            {
                if (binary[i] == '1')
                {
                    this.currentMod = m;
                    this.installModWorker();
                }
                i++;
            }
            
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
    }
}