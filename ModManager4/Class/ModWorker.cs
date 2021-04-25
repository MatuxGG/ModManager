using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    
    
    public class ModWorker
    {
        public ModManager modManager;
        public BackgroundWorker backgroundWorker;
        public BackgroundWorker backgroundWorkerCode;
        public string codeToInstall;
        public ModWorker(ModManager modManager)
        {
            this.modManager = modManager;
        }

        public void removeLocalMod(Mod m)
        {
            this.modManager.utils.FileDelete(m.github);
            if (this.modManager.config.containsMod(m.id))
            {
                this.uninstallMod(m);
            }
            this.modManager.modlist.mods.Remove(m);
            this.modManager.modlist.updateLocalMods();
        }

        public void installFromCode(string code)
        {
            this.modManager.logs.log("Install from code process");
            this.codeToInstall = code;
            this.backgroundWorkerCode = new BackgroundWorker();
            this.backgroundWorkerCode.WorkerReportsProgress = true;
            this.InitializeBackgroundWorkerCode();
            this.backgroundWorkerCode.RunWorkerAsync();
        }

        private void InitializeBackgroundWorkerCode()
        {
            this.backgroundWorkerCode.DoWork += new DoWorkEventHandler(this.backgroundWorkerCode_DoWork);
            this.backgroundWorkerCode.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorkerCode_RunWorkerCompleted);
            this.backgroundWorkerCode.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorkerCode_ProgressChanged);
        }

        public void backgroundWorkerCode_DoWork(object sender, DoWorkEventArgs e)
        {
            
            var backgroundWorkerCode = sender as BackgroundWorker;

            string binary = this.modManager.modlist.HexStringToBinary(this.codeToInstall);

            int supCount = this.modManager.modlist.getAvailableRemoteMods().Count;
            while (supCount % 5 != 0)
            {
                supCount++;
            }
            if (binary.Length != supCount)
            {
                MessageBox.Show("Invalid code !\nPlease enter a valid one !", "Invalid code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.uninstallMods();
            int i = 0;

            List<Mod> toInstall = new List<Mod>();

            foreach (Mod m in this.modManager.modlist.getAvailableRemoteMods())
            {
                if (binary[i] == '1')
                {
                    toInstall.Add(m);
                }
                i++;
            }

            i = 0;
            int max = toInstall.Count;
            foreach(Mod m in toInstall)
            {
                this.installMod(m);
                i++;
                backgroundWorkerCode.ReportProgress(i * 100 / max);
            }
        }

        private void backgroundWorkerCode_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Panel p = (Panel)this.modManager.componentlist.get("BeforeApplyCode").getControl("PagePanelApplyCode");
            ProgressBar prog = (ProgressBar)p.Controls["UpdateCodeBar"];
            prog.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Panel p = (Panel)this.modManager.componentlist.get("BeforeApplyCode").getControl("PagePanelApplyCode");
            ProgressBar prog = (ProgressBar)p.Controls["UpdateCodeBar"];
            prog.Value = 100;
            if (this.modManager.config.installedMods.Count == 0)
            {
                this.uninstallMods();
            }
            this.modManager.modlist.resetChanged();
            this.modManager.modlist.setCode();
            this.modManager.componentlist.refreshModSelection();
            this.modManager.logs.log("Install from code successful");
            this.modManager.pagelist.renderPage("ModSelection");
        }

        public void uninstallMods()
        {
            this.modManager.logs.log("Uninstall all mods process");
            if (this.modManager.config != null)
            {
                // Saving The Other Roles settings
                File.Delete(this.modManager.appDataPath + "\\me.eisbison.theotherroles.cfg");
                this.modManager.utils.FileCopy(this.modManager.config.amongUsPath + "\\BepInEx\\config\\me.eisbison.theotherroles.cfg", this.modManager.appDataPath+ "\\me.eisbison.theotherroles.cfg");
                this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\BepInEx");
                this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\Assets");
                this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\mono");
                this.modManager.utils.FileDelete(this.modManager.config.amongUsPath + "\\doorstop_config.ini");
                this.modManager.utils.FileDelete(this.modManager.config.amongUsPath + "\\winhttp.dll");
                if (this.modManager.config.installedDependencies != null)
                {
                    this.modManager.config.installedDependencies.Clear();
                }
                if (this.modManager.config.installedMods != null)
                {
                    this.modManager.config.installedMods.Clear();
                }
                this.modManager.config.update();
                
                this.modManager.logs.log("Uninstall successful");
            }
        }

        public void updateMods()
        {
            this.modManager.logs.log("Update mods process");
            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.WorkerReportsProgress = true;
            this.InitializeBackgroundWorker();
            this.backgroundWorker.RunWorkerAsync();
        }

        private void InitializeBackgroundWorker()
        {
            this.backgroundWorker.DoWork += new DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
        }

        public void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            int i = 0;
            int max = this.modManager.modlist.toInstall.Count + this.modManager.modlist.toUninstall.Count;
            this.modManager.logs.log("Mods to install = " + this.modManager.modlist.toInstall.Count);
            foreach (string modId in this.modManager.modlist.toInstall)
            {
                i++;
                backgroundWorker.ReportProgress(i * 100 / max);
                this.installMod(this.modManager.modlist.getModById(modId));
            }

            this.modManager.logs.log("Mods to uninstall = " + this.modManager.modlist.toUninstall.Count + "\n");
            foreach (string modId in this.modManager.modlist.toUninstall)
            {
                i++;
                backgroundWorker.ReportProgress(i * 100 / max);
                this.uninstallMod(this.modManager.modlist.getModById(modId));
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Panel p = (Panel)this.modManager.componentlist.get("BeforeUpdateMods").getControl("PagePaneBefUp");
            ProgressBar prog = (ProgressBar) p.Controls["UpdateBar"];
            prog.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Panel p = (Panel)this.modManager.componentlist.get("BeforeUpdateMods").getControl("PagePaneBefUp");
            ProgressBar prog = (ProgressBar) p.Controls["UpdateBar"];
            prog.Value = 100;
            if (this.modManager.config.installedMods.Count == 0)
            {
                this.uninstallMods();
            }
            this.modManager.modlist.resetChanged();
            this.modManager.modlist.setCode();
            this.modManager.logs.log("Update mods successful");
            this.modManager.pagelist.renderPage("ModSelection");
        }

        public void installDependencies(Mod m)
        {
            foreach (string dependencie in m.dependencies)
            {
                if (this.modManager.config.installedDependencies.Contains(dependencie) == false)
                {
                    this.modManager.logs.log("- - Install dependency " + dependencie);
                    string tempPath = this.modManager.tempPath;
                    this.modManager.utils.DirectoryDelete(tempPath);
                    Directory.CreateDirectory(tempPath);
                    this.modManager.utils.FileDelete(tempPath + "\\" + dependencie + ".zip");
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile(this.modManager.serverURL + "/dependencies/" + dependencie + ".zip", tempPath + "\\" + dependencie + ".zip");
                        }
                    }
                    catch
                    {
                        this.modManager.logs.log("Error : Disconnected during dependency install (" + dependencie + ")");
                        this.modManager.componentlist.events.exitMM();
                    }
                    ZipFile.ExtractToDirectory(tempPath + "\\" + dependencie + ".zip", this.modManager.config.amongUsPath);
                    this.modManager.config.installedDependencies.Add(dependencie);
                }
            }
            this.modManager.config.update();
        }

        public void installMod(Mod m)
        {
            if (this.modManager.config.containsMod(m.id) == false)
            {
                this.modManager.logs.log("- Install mod " + m.name);
                this.installDependencies(m);

                if (m.id == "TheOtherRoles")
                {
                    this.modManager.utils.FileCopy(this.modManager.appDataPath + "\\me.eisbison.theotherroles.cfg", this.modManager.config.amongUsPath + "\\BepInEx\\config\\me.eisbison.theotherroles.cfg");
                }

                string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";
                List<string> plugins = new List<string>();

                if (m.type == "mod") {
                    foreach (ReleaseAsset tab in m.release.Assets)
                    {
                        string fileName = tab.Name;
                        if (fileName.Contains(".zip"))
                        {
                            this.modManager.logs.log("- - Install ZIP mod " + fileName);
                            this.installZip(m, tab);
                            return;
                        }
                    }

                    foreach (ReleaseAsset tab in m.release.Assets)
                    {
                        string fileName = tab.Name;
                        if (fileName.Contains(".dll"))
                        {
                            this.modManager.logs.log("- - Install DLL mod " + fileName);
                            plugins.Add(fileName);
                            this.installDll(m, tab);
                        }
                    }

                    if (plugins.Count != 0)
                    {
                        InstalledMod newMod = new InstalledMod(m.id, m.release.TagName, m.gameVersion, new List<string>(), plugins);
                        this.modManager.config.installedMods.Add(newMod);
                        this.modManager.config.update();
                        return;
                    }
                } else
                {
                    string fileName = Path.GetFileName(m.github);
                    if (fileName.Contains(".zip"))
                    {
                        this.modManager.logs.log("- - Install ZIP for local mod " + fileName);
                        this.installLocalZip(m);
                        return;
                    }

                    if (fileName.Contains(".dll"))
                    {
                        this.modManager.logs.log("- - Install DLL for local mod " + fileName);
                        plugins.Add(fileName);
                        this.installLocalDll(m);
                    }

                    if (plugins.Count != 0)
                    {
                        InstalledMod newMod = new InstalledMod(m.id, "1.0", m.gameVersion, new List<string>(), plugins);
                        this.modManager.config.installedMods.Add(newMod);
                        this.modManager.config.update();
                        return;
                    }
                }

                

            }

            return;
        }

        public void installLocalZip(Mod m)
        {
            string fileName = Path.GetFileName(m.github);
            string tempPath = this.modManager.tempPath;
            this.modManager.utils.DirectoryDelete(tempPath);
            Directory.CreateDirectory(tempPath);
            
            string tempPathZip = tempPath + "\\ModZip";

            Directory.CreateDirectory(tempPathZip);
            ZipFile.ExtractToDirectory(m.github, tempPathZip);

            tempPathZip = this.getBepInExInsideRec(tempPathZip);

            DirectoryInfo dirPlugins = new DirectoryInfo(this.modManager.config.amongUsPath + "\\BepInEx\\plugins");

            // Install dll
            DirectoryInfo dirInfo = new DirectoryInfo(tempPathZip + "\\BepInEx\\plugins");

            List<string> plugins = new List<string>();
            if (dirInfo.Exists)
            {
                FileInfo[] files = dirInfo.GetFiles("*");

                foreach (FileInfo f in files)
                {
                    string target = this.modManager.config.amongUsPath + "\\BepInEx\\plugins\\" + f.Name;
                    string newName = f.Name;
                    if (File.Exists(target))
                    {
                        newName = m.id + "-" + f.Name.Remove(f.Name.Length - 4);
                        target = this.modManager.config.amongUsPath + "\\BepInEx\\plugins\\" + newName;
                    }
                    this.modManager.utils.FileCopy(f.FullName, target);
                    plugins.Add(newName);
                }
            }
            DirectoryInfo dirInfo2 = new DirectoryInfo(tempPathZip + "\\Assets");
            List<string> assets = new List<string>();
            if (dirInfo2.Exists)
            {
                FileInfo[] files = dirInfo2.GetFiles();
                foreach (FileInfo f in files)
                {
                    this.modManager.utils.FileCopy(f.FullName, this.modManager.config.amongUsPath + "\\Assets\\" + f.Name);
                    assets.Add(f.Name);
                }
            }
            InstalledMod newMod = new InstalledMod(m.id, "1.0", m.gameVersion, assets, plugins);
            this.modManager.config.installedMods.Add(newMod);
            this.modManager.config.update();
            return;
        }

        public void installLocalDll(Mod m)
        {
            string fileName = Path.GetFileName(m.github);
            string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";
            this.modManager.utils.FileDelete(pluginsPath + "\\" + fileName);
            this.modManager.utils.FileCopy(m.github, pluginsPath + "\\" + fileName);
        }

        public void installDll(Mod m, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";
            this.modManager.utils.FileDelete(pluginsPath + "\\" + fileName);
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(fileUrl, pluginsPath + "\\" + fileName);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected during DLL install (" + fileName + ")");
                this.modManager.componentlist.events.exitMM();
            }
            return;
        }

        public void installZip(Mod m, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string tempPath = this.modManager.tempPath;
            this.modManager.utils.DirectoryDelete(tempPath);
            Directory.CreateDirectory(tempPath);
            string zipPath = tempPath + "\\" + fileName;
            this.modManager.utils.FileDelete(zipPath);
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(fileUrl, zipPath);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected during ZIP install (" + fileName + ")");
                this.modManager.componentlist.events.exitMM();
            }
            string tempPathZip = tempPath + "\\ModZip";

            Directory.CreateDirectory(tempPathZip);
            ZipFile.ExtractToDirectory(zipPath, tempPathZip);

            tempPathZip = this.getBepInExInsideRec(tempPathZip);

            DirectoryInfo dirPlugins = new DirectoryInfo(this.modManager.config.amongUsPath + "\\BepInEx\\plugins");

            // Install dll
            DirectoryInfo dirInfo = new DirectoryInfo(tempPathZip + "\\BepInEx\\plugins");

            List<string> plugins = new List<string>();
            if (dirInfo.Exists)
            {
                FileInfo[] files = dirInfo.GetFiles("*");

                foreach (FileInfo f in files)
                {
                    string target = this.modManager.config.amongUsPath + "\\BepInEx\\plugins\\" + f.Name;
                    string newName = f.Name;
                    if (File.Exists(target))
                    {
                        newName = m.id + "-" + f.Name.Remove(f.Name.Length - 4);
                        target = this.modManager.config.amongUsPath + "\\BepInEx\\plugins\\" + newName;
                    } 
                    this.modManager.utils.FileCopy(f.FullName, target);
                    plugins.Add(newName);
                }
            }
            DirectoryInfo dirInfo2 = new DirectoryInfo(tempPathZip + "\\Assets");
            List<string> assets = new List<string>();
            if (dirInfo2.Exists)
            {
                FileInfo[] files = dirInfo2.GetFiles();
                foreach (FileInfo f in files)
                {
                    this.modManager.utils.FileCopy(f.FullName, this.modManager.config.amongUsPath + "\\Assets\\" + f.Name);
                    assets.Add(f.Name);
                }
            }
            InstalledMod newMod = new InstalledMod(m.id, fileTag, m.gameVersion, assets, plugins);
            this.modManager.config.installedMods.Add(newMod);
            this.modManager.config.update();
            return;
        }

        public string getBepInExInsideRec(string path)
        {
            if (Directory.Exists(path + "\\BepInEx"))
            {
                return path;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (this.getBepInExInsideRec(dir.FullName) != null)
                {
                    return dir.FullName;
                }
            }
            return null;
        }

        public void uninstallMod(Mod m)
        {
            this.modManager.logs.log("- Uninstall mod " + m.name);

            InstalledMod installedMod = this.modManager.config.getInstalledModById(m.id);

            string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";
            
            foreach (string plugin in installedMod.plugins)
            {
                Boolean canRemove = true;
                foreach (InstalledMod im in this.modManager.config.installedMods)
                {
                    if (im.id != m.id && im.plugins.Contains(plugin))
                    {
                        canRemove = false;
                    }
                }
                if (canRemove == true)
                {
                    this.modManager.utils.FileDelete(pluginsPath + "\\" + plugin);
                }
            }
            string assetsPath = this.modManager.config.amongUsPath + "\\Assets";
            foreach (string asset in installedMod.assets)
            {
                this.modManager.utils.FileDelete(assetsPath + "\\" + asset);
            }
            this.modManager.config.installedMods.Remove(installedMod);
            this.modManager.config.update();

            this.modManager.logs.log("- Uninstall mod " + m.name + " completed");
        }
    }
}
