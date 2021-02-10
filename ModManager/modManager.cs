using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AutoUpdaterDotNET;

namespace ModManager
{


    public partial class ModManager : Form
    {

        private string amongUsPath;
        private string modsPath;
        private Mod[] mods;
        private Mod curMod;
        public ModManager()
        {
            InitializeComponent();

            AutoUpdater.Start("https://au.matux.fr/modManager/latest.xml");

            this.loading.Text = "";

            this.mods = new Mod[13];
            this.mods[0] = new Mod("Among Us Classic", "Among Us Classic");
            this.mods[1] = new Mod("CustomKeyBinds", "Custom Keybinds");
            this.mods[2] = new Mod("ExtraRoles", "Extra Roles");
            this.mods[3] = new Mod("CustomRoles", "Custom Roles");
            this.mods[4] = new Mod("Tryhard", "Tryhard");
            this.mods[5] = new Mod("Sheriff", "Sheriff");
            this.mods[6] = new Mod("Lovers", "Lovers");
            this.mods[7] = new Mod("Mayor", "Mayor");
            this.mods[8] = new Mod("Torch", "Torch");
            this.mods[9] = new Mod("Sweeper", "Sweeper");
            this.mods[10] = new Mod("AnonymousImpostors", "Anonymous impostors");
            this.mods[11] = new Mod("Chameleon", "Chameleon");
            this.mods[12] = new Mod("Smol", "Smol");

            foreach (Mod installedMod in this.mods)
            {
                this.mod.Items.Add(installedMod.getName());
            }

            this.amongUsPath = getPath();
            if (this.amongUsPath != null)
            {
                this.directoryPath.Text = this.amongUsPath;
            } else
            {
                this.directoryPath.Text = "/!\\ Among Us directory not found, please select a location /!\\";
            }

            this.modsPath = getModsPath();

            this.curMod = getCurrentMod();

            if (this.curMod != null)
            {
                this.currentMod.Text = this.curMod.getName();
                this.mod.SelectedItem = this.curMod.getName();
                this.modTitle.Text = this.curMod.getName();
            } else
            {
                this.currentMod.Text = "Unknown";
                this.modTitle.Text = "";
            }

            

            this.valid.Click += new EventHandler(this.valid_Click);
            this.directorySelect.Click += new EventHandler(this.ChooseFolder);
            this.credits.Click += new EventHandler(this.goToMatux);
            this.Play.Click += new EventHandler(this.play);
        }

        private string getModsPath()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }

        private string getPath()
        {
            DirectoryInfo temp = new DirectoryInfo("C:\\Program Files\\Steam\\steamapps\\common\\Among Us");
            DirectoryInfo temp2 = new DirectoryInfo("D:\\Program Files\\Steam\\steamapps\\common\\Among Us");
            string path = System.AppDomain.CurrentDomain.BaseDirectory+"settings.conf";
            FileInfo settings = new FileInfo(path);

            if (settings.Exists)
            {
                return File.ReadAllLines(path).First();
            }
            else if (temp.Exists)
            {
                return "C:\\Program Files\\Steam\\steamapps\\common\\Among Us";
            }
            else if (temp2.Exists)
            {
                return "D:\\Program Files\\Steam\\steamapps\\common\\Among Us";
            } else
            {
                return null;
            }
        }

        private Mod getModFromName(string name)
        {
            foreach (Mod m in this.mods)
            {
                if (name == m.getName())
                {
                    return m;
                }
            }
            return null;
        }

        private Mod getCurrentMod()
        {
            DirectoryInfo bepInEx = new DirectoryInfo(this.amongUsPath+"\\BepInEx");
            DirectoryInfo assets = new DirectoryInfo(this.amongUsPath + "\\Assets");
            DirectoryInfo mono = new DirectoryInfo(this.amongUsPath + "\\mono");
            FileInfo doorstop = new FileInfo(this.amongUsPath + "\\doorstop_config.ini");
            FileInfo winhttp = new FileInfo(this.amongUsPath + "\\winhttp.dll");

            if (bepInEx.Exists && mono.Exists && doorstop.Exists && winhttp.Exists)
            {
                string modInfo = File.ReadLines(this.amongUsPath + "\\modInfo.txt").First();
                return this.getModFromName(modInfo);
            }

            if (!bepInEx.Exists && !assets.Exists && !mono.Exists && !doorstop.Exists && !winhttp.Exists)
            {
                return this.getModFromName("Among Us Classic");
            }

            return null;
        } 

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private static void DirectoryDelete(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                Directory.Delete(dirName, true);
            }
        }
        private static void FileDelete(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private void valid_Click(object sender, EventArgs e)
        {
            loading.Text = "Please wait ...";
            loading.Refresh();
            Mod choosenMod = getModFromName(mod.SelectedItem.ToString());

            DirectoryDelete(amongUsPath + "\\BepInEx");
            DirectoryDelete(amongUsPath + "\\mono");
            DirectoryDelete(amongUsPath + "\\Assets");
            FileDelete(amongUsPath + "\\doorstop_config.ini");
            FileDelete(amongUsPath + "\\winhttp.dll");
            FileDelete(amongUsPath + "\\modInfo.txt");

            if (choosenMod.getName() != "Among Us Classic")
            {
                DirectoryCopy(modsPath + "\\" + choosenMod.getId(), amongUsPath, true);
                string[] lines = { choosenMod.getName(), "" };
                File.WriteAllLines(amongUsPath + "\\modInfo.txt", lines);
            }
            this.currentMod.Text = choosenMod.getName();
            this.modTitle.Text = choosenMod.getName();
            this.modDescripiton.Text = ""; // TODO
            loading.Text = "Successfully installed !";
            loading.Refresh();
        }

        public void ChooseFolder(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.amongUsPath = folderBrowser.SelectedPath;
                this.directoryPath.Text = this.amongUsPath;
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "settings.conf";
                FileInfo settings = new FileInfo(path);
                string[] lines = { this.amongUsPath, "" };
                File.WriteAllLines(path, lines);
            }
        }

        private void goToMatux(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://matux.fr");
        }

        private void play(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.amongUsPath+ "\\Among Us.exe");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ModManager_Load(object sender, EventArgs e)
        {

        }

        private void separator2_Click(object sender, EventArgs e)
        {

        }

        private void loading_Click(object sender, EventArgs e)
        {

        }

        private void choose_Click(object sender, EventArgs e)
        {

        }

        private void separator_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void directoryPath_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
