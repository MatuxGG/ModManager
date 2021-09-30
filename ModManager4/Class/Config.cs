using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Config
    {
        public string amongUsPath { get; set; }
        public List<InstalledMod> installedMods { get; set; }
        public List<string> installedDependencies { get; set; }

        public Boolean enableCache { get; set; }

        public int resolutionX { get; set; }
        public int resolutionY { get; set; }

        public string startMethod { get; set; }

        public List<string> hiddenCategories { get; set; }

        public string sortType { get; set; }
        public string sortOrder { get; set; }

        public Config(string amongUsPath, List<InstalledMod> installedMods, List<string> installedDependencies, Boolean enableCache, int resolutionX, int resolutionY, string startMethod, List<string> hiddenCategories, string sortType, string sortOrder)
        {
            this.amongUsPath = amongUsPath;
            this.installedMods = installedMods;
            this.installedDependencies = installedDependencies;
            this.enableCache = enableCache;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.startMethod = startMethod;
            this.hiddenCategories = hiddenCategories;
            this.sortType = sortType;
            this.sortOrder = sortOrder;
        }

        public Config()
        {
            this.amongUsPath = "";
            this.installedMods = new List<InstalledMod>() { };
            this.installedDependencies = new List<string>() { };
            this.enableCache = true;
            this.resolutionX = 1300;
            this.resolutionY = 810;
            this.startMethod = "Direct Link";
            this.hiddenCategories = new List<string>() { };
            this.sortType = "Checked";
            this.sortOrder = "A";
        }

        public List<int[]> getResolutions()
        {
            List<int[]> temp = new List<int[]>() { };
            int x = 2560;
            int y = 1600;
            while (y >= 450)
            {
                temp.Add(new int[] { x, y });
                x = (x * (y - 50)) / y;
                y = y - 50;
            }

            List<int[]> res = new List<int[]>() { };
            foreach (int[] r in temp)
            {
                if (r[0] + 100 < Screen.PrimaryScreen.Bounds.Width && r[1] + 100 < Screen.PrimaryScreen.Bounds.Height)
                {
                    res.Add(r);
                }
            }
            return res;
        }

        
        public void check(ModManager modManager)
        {
            modManager.logs.log("Check mods integrity");

            while (this.checkWorker(modManager) == true)
            {

            }

            modManager.logs.log("- Mods integrity checked");
        }

        public Boolean checkWorker(ModManager modManager)
        {
            foreach (InstalledMod mod in this.installedMods)
            {
                Mod m = modManager.modlist.getModById(mod.id);

                if (m.type != "allInOne")
                {
                    if (mod.gameVersion != modManager.serverConfig.get("gameVersion").value || (m.type == "mod" && mod.version != m.release.TagName))
                    {
                        modManager.logs.log("- Uninstall mod " + m.name + " (wrong version or game version)");
                        modManager.modWorker.uninstallMod(m);
                        return true;
                    }
                }


                foreach (string file in mod.files)
                {
                    if (File.Exists(this.amongUsPath + "\\" + file) == false && Directory.Exists(this.amongUsPath + "\\" + file) == false)
                    {
                        modManager.logs.log("- Uninstall mod " + m.name + " (missing file " + file + ")");
                        modManager.modWorker.uninstallMod(m);
                        return true;
                    }
                }
            }

            return false;
        }

        public void load(ModManager modManager)
        {
            modManager.logs.log(this.toString());
            modManager.logs.log("- start");

            string path = modManager.appDataPath + "\\config4.conf";
            modManager.logs.log("- Path = " + path);

            if (File.Exists(path))
            {
                modManager.logs.log("- config exists");
                string json = System.IO.File.ReadAllText(path);
                Config temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                modManager.logs.log("- Among Us Path = " + temp.amongUsPath + "\\Among Us.exe");
                if (File.Exists(temp.amongUsPath + "\\Among Us.exe")) // Exists in config
                {
                    modManager.logs.log("- Among Us exists");
                    this.amongUsPath = temp.amongUsPath;
                    this.installedDependencies = temp.installedDependencies;
                    this.installedMods = temp.installedMods;
                    this.enableCache = temp.enableCache;
                    this.resolutionX = temp.resolutionX;
                    this.resolutionY = temp.resolutionY;
                    int[] size = this.getResolutions().First();
                    if (this.resolutionX > size[0] || this.resolutionY > size[1])
                    {
                        this.resolutionX = size[0];
                        this.resolutionY = size[1];
                    }
                    this.startMethod = temp.startMethod;
                    this.hiddenCategories = temp.hiddenCategories;
                    this.sortType = temp.sortType;
                    this.sortOrder = temp.sortOrder;
                    this.update(modManager);
                    return;
                } else
                {
                    modManager.logs.log("- Among Us doesn't exists in stored config");
                }
            } else
            {
                modManager.logs.log("- Config doesn't exists");

                int[] size = this.getResolutions().First();
                this.resolutionX = size[0];
                this.resolutionY = size[1];
            }
            this.installedMods = new List<InstalledMod>() { };
            this.installedDependencies = new List<string>() { };
            this.amongUsPath = null;
            this.startMethod = "Direct Link";
            this.hiddenCategories = new List<string>() { };
            this.sortType = "Checked";
            this.sortOrder = "A";

            // Detection from Steam
            modManager.logs.log("- Getting Among Us path from Steam");
            RegistryKey myKey  = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", false);
            
            if (myKey != null)
            {
                modManager.logs.log("- Among Us detected on Steam");
                this.amongUsPath = (String)myKey.GetValue("InstallLocation");
                this.startMethod = "Steam";

                modManager.logs.log("- Saving Among Us path : " + this.amongUsPath);

                this.update(modManager);
                modManager.logs.log("- Config updated");
                return;
            } else
            {
                modManager.logs.log("- Among Us not detected on Steam");
            }

            
            // Detection from Epic Games Store

            modManager.logs.log("- Getting Among Us path from Epic Games Store");

            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                string egsPath = d.Name + "Program Files\\Epic Games\\AmongUs";
                if (File.Exists(egsPath + "\\Among Us.exe"))
                {
                    modManager.logs.log("- Among Us detected on Epic Games Store");
                    this.amongUsPath = egsPath;
                    //this.startMethod = "Epic Games Store";

                    modManager.logs.log("- Saving Among Us path : " + this.amongUsPath);
                    this.update(modManager);
                    modManager.logs.log("- Config updated");
                    return;
                }
            }
            modManager.logs.log("- Among Us not detected on Epic Games Store");
            

            // No Among Us found

            while (this.amongUsPath == null || File.Exists(this.amongUsPath + "\\Among Us.exe") == false)
            {
                if (MessageBox.Show("Among Us not found ! Please, select the Among Us executable", "Among Us not found", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Cancel) {
                    Environment.Exit(0);
                }
                this.selectFolderWorker(modManager);
            }
            return;
        }

        public void selectFolderWorker(ModManager modManager)
        {
            modManager.logs.log("Event : Open popup to select Among Us folder on startup\n");
            OpenFileDialog folderBrowser = new OpenFileDialog();
            if (modManager.config != null && modManager.config.amongUsPath != null)
            {
                folderBrowser.InitialDirectory = modManager.config.amongUsPath;
            }
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Filter = "Among Us file|Among Us.exe";
            // Always default to Folder Selection.
            folderBrowser.FileName = "Among Us.exe";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                modManager.logs.log("- Folder selected : " + folderPath + "\n");
                if (modManager.config == null)
                {
                    modManager.config = new Config();
                }
                modManager.config.amongUsPath = folderPath;
                modManager.config.update(modManager);
            }
        }

        public void update(ModManager modManager)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(modManager.appDataPath + "\\config4.conf", json);
        }

        public Boolean containsMod(string id)
        {
            return this.installedMods.Find(m => m.id == id) != null;
        }

        public Boolean isUpTodate(string id, string version)
        {
            return this.installedMods.Find(m => m.id == id && m.version == version) != null;
        }

        public InstalledMod getInstalledModById(string id)
        {
            return this.installedMods.Find(im => im.id == id);
        }

        public List<InstalledMod> getInstalledModsForCategory(ModManager modManager, Category cat)
        {
            return this.installedMods.FindAll(im => modManager.modlist.getAvailableModById(im.id).category == cat.id);
        }

        public List<InstalledMod> getInstalledModsWithoutAllInOne(ModManager modManager)
        {
            return this.installedMods.FindAll(im => modManager.modlist.getModById(im.id).type != "allInOne");
        }

        public bool exists(ModManager modManager)
        {
            FileInfo f = new FileInfo(modManager.appDataPath + "\\config4.conf");
            return f.Exists;
        }

        public string toString()
        {
            
            string ret = "Config :\n- OS Version : " + System.Environment.OSVersion.ToString() + "\n- Among Us path : " + this.amongUsPath + "\n- Cache enabled : " + this.enableCache + "\n- Resolution : " + this.resolutionX + "x" + this.resolutionY + "\n- Installed dependencies :\n";
            foreach (string d in this.installedDependencies)
            {
                ret = ret + "- - Installed dependency " + d;
            }
            ret = ret + "\n- Installed mods :\n";
            foreach (InstalledMod m in this.installedMods)
            {
                ret = ret + "- - Installed mod " + m.id + " : Version = " + m.version + " / Game version = " + m.gameVersion + " / Assets = [";
                int i = 0;
                foreach (string p in m.files)
                {
                    if (i != 0)
                    {
                        ret = ret + ", ";
                    }
                    ret = ret + p;
                    i++;
                }
                ret = ret + "]\n";
            }
            return ret;
        }
    }
}
