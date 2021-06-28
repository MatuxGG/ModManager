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
        public BackgroundWorker backgroundWorkerChallenger;
        public string codeToInstall;
        public Boolean startAfterUpdate;
        public Boolean changeUI;

        public ModWorker(ModManager modManager)
        {
            this.modManager = modManager;
            this.changeUI = true;
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
            if (this.changeUI)
            {
                Panel p = (Panel)this.modManager.componentlist.get("BeforeApplyCode").getControl("PagePanelApplyCode");
                ProgressBar prog = (ProgressBar)p.Controls["UpdateCodeBar"];
                prog.Value = e.ProgressPercentage;
            }
        }

        private void backgroundWorkerCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.changeUI)
            {
                Panel p = (Panel)this.modManager.componentlist.get("BeforeApplyCode").getControl("PagePanelApplyCode");
                ProgressBar prog = (ProgressBar)p.Controls["UpdateCodeBar"];
                prog.Value = 100;
            }
            if (this.modManager.config.installedMods.Count == 0)
            {
                this.uninstallMods();
            }
            this.modManager.modlist.resetChanged();
            if (this.changeUI)
            {
                this.modManager.modlist.setCode();
                this.modManager.componentlist.refreshModSelection();
                this.modManager.logs.log("Install from code successful");
                this.modManager.pagelist.renderPage("ModSelection");
            }
            if (this.startAfterUpdate == true)
            {
                this.modManager.componentlist.events.startGame();
                Environment.Exit(0);
            }
        }

        public void uninstallMods()
        {
            this.modManager.logs.log("Uninstall all mods process");
            if (this.modManager.config != null)
            {
                foreach (InstalledMod im in this.modManager.config.installedMods)
                {
                    Mod m = this.modManager.modlist.getModById(im.id);
                    this.saveData(m);
                }

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
                    List<InstalledMod> allInOneTemp = new List<InstalledMod>() { };
                    foreach (InstalledMod im in this.modManager.config.installedMods)
                    {
                        if (this.modManager.modlist.getModById(im.id).type == "allInOne")
                        {
                            allInOneTemp.Add(im);
                        }
                    }
                    this.modManager.config.installedMods.Clear();
                    this.modManager.config.installedMods = allInOneTemp;
                }
                this.modManager.config.update(this.modManager);
                
                this.modManager.logs.log("Uninstall successful");
            }
        }

        public void installChallenger()
        {
            this.modManager.logs.log("Install Challenger process");
            this.backgroundWorkerChallenger = new BackgroundWorker();
            this.backgroundWorkerChallenger.WorkerReportsProgress = true;
            this.InitializeBackgroundWorkerChallenger();
            this.backgroundWorkerChallenger.RunWorkerAsync();
        }

        private void InitializeBackgroundWorkerChallenger()
        {
            this.backgroundWorkerChallenger.DoWork += new DoWorkEventHandler(this.backgroundWorkerChallenger_DoWork);
            this.backgroundWorkerChallenger.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorkerChallenger_RunWorkerCompleted);
            this.backgroundWorkerChallenger.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorkerChallenger_ProgressChanged);
        }

        public void backgroundWorkerChallenger_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            this.modManager.logs.log("Downloading Challenger Client");

            backgroundWorker.ReportProgress(0);

            ReleaseAsset asset = new ReleaseAsset();

            foreach (ReleaseAsset ra in this.modManager.modlist.challengerClient.Assets)
            {
                if (ra.Name.Contains("zip"))
                {
                    asset = ra;
                    break;
                }
            }

            string path = this.modManager.tempPath + "\\" + asset.Name;
            this.modManager.utils.FileDelete(path);

            backgroundWorker.ReportProgress(5);

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(new Uri(asset.BrowserDownloadUrl), path);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Error when downloading client\n");
                this.modManager.componentlist.events.exitMM();
            }

            backgroundWorker.ReportProgress(25);
            this.modManager.logs.log("Challenger Client downloaded");
            this.modManager.logs.log("Extracting Challenger Client");

            string appPath = this.modManager.appDataPath + "\\allInOneMods\\Challenger";

            this.modManager.utils.DirectoryDelete(appPath);
            Directory.CreateDirectory(appPath);

            ZipFile.ExtractToDirectory(path, appPath);

            backgroundWorker.ReportProgress(50);
            this.modManager.logs.log("Challenger Client extracted");

            foreach (ReleaseAsset ra in this.modManager.modlist.challengerMod.Assets)
            {
                if (ra.Name.Contains("zip"))
                {
                    asset = ra;
                    break;
                }
            }

            path = this.modManager.tempPath + "\\" + asset.Name;

            this.modManager.logs.log("Downloading Challenger Mod");

            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(new Uri(asset.BrowserDownloadUrl), path);
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Error when downloading mod\n");
                this.modManager.componentlist.events.exitMM();
            }

            backgroundWorker.ReportProgress(75);

            this.modManager.logs.log("Challenger Mod downloaded");
            this.modManager.logs.log("Extracting Challenger Mod");

            ZipFile.ExtractToDirectory(path, appPath);

            this.modManager.logs.log("Challenger Mod extracted");

            backgroundWorker.ReportProgress(100);
            this.modManager.logs.log("Challenger Mod installed successfully");
        }

        private void backgroundWorkerChallenger_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Panel p = (Panel)this.modManager.componentlist.get("BeforeUpdateMods").getControl("PagePaneBefUp");
            ProgressBar prog = (ProgressBar)p.Controls["UpdateBar"];
            prog.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerChallenger_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Panel p = (Panel)this.modManager.componentlist.get("BeforeUpdateMods").getControl("PagePaneBefUp");
            ProgressBar prog = (ProgressBar)p.Controls["UpdateBar"];
            prog.Value = 100;

            this.modManager.logs.log("Install of Challenger Mod successful");

            if (this.modManager.config.containsMod("Challenger"))
            {
                this.modManager.config.getInstalledModById("Challenger").version = this.modManager.modlist.challengerMod.TagName;
            } else
            {
                InstalledMod newMod = new InstalledMod("Challenger", this.modManager.modlist.challengerMod.TagName, this.modManager.serverConfig.gameVersion, new List<string>() { });
                this.modManager.config.installedMods.Add(newMod);
            }

            this.modManager.config.update(this.modManager);

            this.modManager.componentlist.events.clearWithBlink();
            this.modManager.pagelist.renderPage("ModSelection");
        }

        public void updateMods(Boolean startAfterUpdate)
        {
            this.modManager.logs.log("Update mods process");
            this.startAfterUpdate = startAfterUpdate;
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
            if (this.startAfterUpdate == true)
            {
                this.modManager.componentlist.events.startGame();
            }
            this.modManager.componentlist.events.clearWithBlink();
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
                    //this.modManager.utils.DirectoryDelete(tempPath);
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
            this.modManager.config.update(this.modManager);
        }

        public void installMod(Mod m)
        {
            if (this.modManager.config.containsMod(m.id) == false)
            {
                this.modManager.logs.log("- Install mod " + m.name);
                this.installDependencies(m);

                this.restoreData(m);

                string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";
                List<string> files = new List<string>();

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
                            files.Add("BepInEx\\plugins\\" + fileName);
                            this.installDll(m, tab);
                        }
                    }

                    if (files.Count != 0)
                    {
                        this.checkInstalledFiles(files);

                        InstalledMod newMod = new InstalledMod(m.id, m.release.TagName, m.gameVersion, files);
                        this.modManager.config.installedMods.Add(newMod);
                        this.modManager.config.update(this.modManager);
                        return;
                    } else
                    {
                        this.modManager.logs.log("Error : Mod release incorrect for mod " + m.name);
                        MessageBox.Show("Mod release inccorect for mod " + m.name + "\n" +
                        "\n" +
                        "If this problem persists, please send a ticket on Mod Manager's discord.", "Mod release inccorect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(0);
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
                        files.Add("BepInEx\\plugins\\" + fileName);
                        this.installLocalDll(m);
                    }

                    if (files.Count != 0)
                    {
                        InstalledMod newMod = new InstalledMod(m.id, "1.0", m.gameVersion, files);
                        this.modManager.config.installedMods.Add(newMod);
                        this.modManager.config.update(this.modManager);
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

            string dirPlugins = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";

            // Install dll
            DirectoryInfo dirInfo = new DirectoryInfo(tempPathZip + "\\BepInEx\\plugins");

            if (Directory.Exists(dirPlugins) == false)
            {
                Directory.CreateDirectory(dirPlugins);
            }

            List<string> plugins = new List<string>();
            if (dirInfo.Exists)
            {
                FileInfo[] files = dirInfo.GetFiles("*");

                foreach (FileInfo f in files)
                {
                    string target = dirPlugins + "\\" + f.Name;
                    string newName = f.Name;
                    if (File.Exists(target))
                    {
                        newName = m.id + "-" + f.Name.Remove(f.Name.Length - 4);
                        target = dirPlugins + "\\" + newName;
                    }
                    this.modManager.utils.FileCopy(f.FullName, target);
                    plugins.Add(newName);
                }

                DirectoryInfo[] dirs = dirInfo.GetDirectories("*");

                foreach (DirectoryInfo d in dirs)
                {
                    string target = dirPlugins + "\\" + d.Name;
                    string newName = d.Name;
                    if (Directory.Exists(target))
                    {
                        newName = m.id + "-" + d.Name.Remove(d.Name.Length);
                        target = dirPlugins + "\\" + newName;
                    }
                    this.modManager.utils.DirectoryCopy(d.FullName, target, true);
                    plugins.Add(newName);
                }
            }

            string dirAssets = this.modManager.config.amongUsPath + "\\Assets";

            if (Directory.Exists(dirAssets) == false)
            {
                Directory.CreateDirectory(dirAssets);
            }

            DirectoryInfo dirInfo2 = new DirectoryInfo(tempPathZip + "\\Assets");

            if (dirInfo2.Exists)
            {
                FileInfo[] files = dirInfo2.GetFiles();
                foreach (FileInfo f in files)
                {
                    this.modManager.utils.FileCopy(f.FullName, dirAssets + "\\" + f.Name);
                    plugins.Add(f.FullName);
                }
            }
            InstalledMod newMod = new InstalledMod(m.id, "1.0", m.gameVersion, plugins);
            this.modManager.config.installedMods.Add(newMod);
            this.modManager.config.update(this.modManager);
            return;
        }

        public void installLocalDll(Mod m)
        {
            string fileName = Path.GetFileName(m.github);
            string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";

            if (Directory.Exists(pluginsPath) == false)
            {
                Directory.CreateDirectory(pluginsPath);
            }

            this.modManager.utils.FileDelete(pluginsPath + "\\" + fileName);
            this.modManager.utils.FileCopy(m.github, pluginsPath + "\\" + fileName);
        }

        public void installDll(Mod m, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string pluginsPath = this.modManager.config.amongUsPath + "\\BepInEx\\plugins";

            if (Directory.Exists(pluginsPath) == false)
            {
                Directory.CreateDirectory(pluginsPath);
            }

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

        public void checkInstalledFiles(List<string> files)
        {
            foreach (string f in files)
            {
                if (File.Exists(this.modManager.config.amongUsPath + "\\" + f) == false)
                {
                    this.modManager.logs.log("Check process after install : File not installed (" + f + ")");
                    MessageBox.Show("Mod Manager was not able to install this mod\n" +
                    "\n" +
                    "There are many possible reasons for this :\n" +
                    "- Your antivirus blocks access to the Among Us folder\n" +
                    "- Another process is using the Among Us folder\n" +
                    "- The Among Us folder is read only for other softwares\n" +
                    "\n" +
                    "If this problem persists, please send a ticket on Mod Manager's discord.", "Mod not installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }
        }

        public void installZip(Mod m, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = m.release.TagName;
            string tempPath = this.modManager.tempPath;
            //this.modManager.utils.DirectoryDelete(tempPath);
            Directory.CreateDirectory(tempPath);
            string zipPath = tempPath + "\\" + fileName;
            
            if (this.modManager.config.enableCache == true)
            {
                this.modManager.logs.log("- Cache enabled");
                if (File.Exists(zipPath) && File.Exists(tempPath+"\\"+fileName + "-" + fileTag + ".cache"))
                {
                    this.modManager.logs.log("- Mod found in cache");
                } else
                {
                    this.modManager.logs.log("- Mod not found in cache");
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
                    File.Create(tempPath + "\\" + fileName +"-"+fileTag+ ".cache");
                }
            } else
            {
                this.modManager.logs.log("- Cache disabled");
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
            }
                        
            string tempPathZip = tempPath + "\\ModZip";

            this.modManager.utils.DirectoryDelete(tempPathZip);
            Directory.CreateDirectory(tempPathZip);
            ZipFile.ExtractToDirectory(zipPath, tempPathZip);

            tempPathZip = this.getBepInExInsideRec(tempPathZip);

            List<string> installedFiles = new List<string>();
            foreach (string folder in m.folders)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(tempPathZip + "\\" + folder);
                if (dirInfo.Exists)
                {
                    if (Directory.Exists(this.modManager.config.amongUsPath + "\\" + folder) == false)
                    {
                        Directory.CreateDirectory(this.modManager.config.amongUsPath + "\\" + folder);
                    }

                    FileInfo[] files = dirInfo.GetFiles("*");
                    foreach (FileInfo f in files)
                    { 
                        if (m.excludeFiles.Contains(folder + "\\" + f.Name) == false)
                        {
                            string target = this.modManager.config.amongUsPath + "\\" + folder + "\\" + f.Name;
                            string newName = f.Name;
                            if (File.Exists(target))
                            {
                                newName = m.id + "-" + f.Name.Remove(f.Name.Length - 4);
                                target = this.modManager.config.amongUsPath + "\\" + folder + "\\" + newName;
                            }
                            this.modManager.utils.FileCopy(f.FullName, target);
                            installedFiles.Add(folder + "\\" + newName);
                        }
                    }
                }
            }

            this.checkInstalledFiles(installedFiles);

            InstalledMod newMod = new InstalledMod(m.id, fileTag, m.gameVersion, installedFiles);
            this.modManager.config.installedMods.Add(newMod);
            this.modManager.config.update(this.modManager);
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

            this.saveData(m);

            foreach (string file in installedMod.files)
            {
                Boolean canRemove = true;
                foreach (InstalledMod im in this.modManager.config.installedMods)
                {
                    if (im.id != m.id && im.files.Contains(file))
                    {
                        canRemove = false;
                    }
                }
                if (canRemove == true)
                {
                    if (File.Exists(this.modManager.config.amongUsPath + "\\" + file))
                    {
                        this.modManager.utils.FileDelete(this.modManager.config.amongUsPath + "\\" + file);
                    }
                    if (Directory.Exists(this.modManager.config.amongUsPath + "\\" + file))
                    {
                        this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\" + file);
                    }
                }
            }

            

            this.modManager.config.installedMods.Remove(installedMod);
            this.modManager.config.update(this.modManager);

            this.modManager.logs.log("- Uninstall mod " + m.name + " completed");
        }

        public void saveData(Mod m)
        {
            if (m.data != null)
            {
                foreach (string dataFile in m.data)
                {
                    string dataPath = this.modManager.appDataPath + "\\modsData\\" + m.id + "\\";

                    if (Directory.Exists(this.modManager.appDataPath + "\\modsData\\" + m.id) == false)
                    {
                        Directory.CreateDirectory(this.modManager.appDataPath + "\\modsData\\" + m.id);
                    }

                    if (Directory.Exists(this.modManager.config.amongUsPath + "\\" + dataFile))
                    {
                        this.modManager.utils.DirectoryCopy(this.modManager.config.amongUsPath + "\\" + dataFile, dataPath + Path.GetDirectoryName(dataFile), true);
                    }
                    if (File.Exists(this.modManager.config.amongUsPath + "\\" + dataFile))
                    {
                        this.modManager.utils.FileCopy(this.modManager.config.amongUsPath + "\\" + dataFile, dataPath + Path.GetFileName(dataFile));
                    }
                }
            }
            
        }

        public void restoreData(Mod m)
        {
            if (m.data != null)
            {
                foreach (string dataFile in m.data)
                {
                    string dataPath = this.modManager.appDataPath + "\\modsData\\" + m.id + "\\";
                    if (Directory.Exists(dataPath + Path.GetDirectoryName(dataFile)))
                    {
                        this.modManager.utils.DirectoryCopy(dataPath + Path.GetDirectoryName(dataFile), this.modManager.config.amongUsPath + "\\" + dataFile, true);
                    }
                    if (File.Exists(dataPath + Path.GetFileName(dataFile)))
                    {
                        this.modManager.utils.FileCopy(dataPath + Path.GetFileName(dataFile), this.modManager.config.amongUsPath + "\\" + dataFile);
                    }
                }
            }
        }
    }
}
