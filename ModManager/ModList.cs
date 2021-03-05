using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
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

        public ModList(string url, string path, ModManager modManager)
        {
            this.url = url;
            this.path = path;
            this.modManager = modManager;
            this.load();
        }

        public void load()
        {
            // Download remote files.zip
            using (var client = new WebClient())
            {
                client.DownloadFile(this.url, this.path);
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

            //this.changeCatWorker();
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
            var tokenAuth = new Credentials("TOKEN");
            client.Credentials = tokenAuth;
            this.modManager.currentRelease = null;
            this.modManager.currentRelease = await client.Repository.Release.GetLatest(author, repository);

        }


        public void installDependencies()
        {
            string dependenciesPath = this.modManager.appPath + "\\files\\dependencies";
            List<string> dependencies = new List<string>();
            dependencies.Add("BepInEx");
            dependencies.Add("Reactor");
            dependencies.Add("Essentials");
            foreach (string dependencie in dependencies)
            {
                if (this.modManager.config.installedDependencies.Contains(dependencie) == false)
                {
                    this.modManager.utils.DirectoryCopy(dependenciesPath + "\\" + dependencie, this.modManager.config.amongUsPath, true);
                    this.modManager.config.installedDependencies.Add(dependencie);
                }
            }
        }

        public void uninstallMod(object sender, EventArgs e)
        {
            this.uninstallModWorker();
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").Visible = true;
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Blue;
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
            this.installModWorker();
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").Visible = false;
            this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Blue;
            this.modManager.pagelist.get("ModSelection").getControl("UninstallModButton").Visible = true;
            MessageBox.Show("The mod have been installed !", "Mod installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public async void installModWorker()
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show("Close Among Us to install this mod", "Can't install mod", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.modManager.config.containsMod(this.currentMod.id) == false)
            {
                this.modManager.pagelist.get("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Orange;

                this.installDependencies();

                string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";

                if (Directory.Exists(pluginsPath) == false)
                {
                    Directory.CreateDirectory(pluginsPath);
                }

                await this.GetGithubInfos(this.currentMod.author, this.currentMod.github);

                using (WebClient wc = new WebClient())
                {
                    foreach (ReleaseAsset tab in this.modManager.currentRelease.Assets)
                    {
                        string fileName = tab.Name;
                        if (fileName.Contains(".dll"))
                        {
                            this.installDll(this.modManager.currentRelease, tab);
                            return;
                        }
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
    }
}