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
using System.Net;
using System.IO.Compression;
using Newtonsoft.Json;
using AutoUpdaterDotNET;

namespace ModManager
{


    public partial class ModManager : Form
    {
        private string serverURL;
        private Version curVersion;
        private string appDataPath;
        private string appPath;
        private List<Mod> mods;
        private Config config;
        private string lg;
        public ModManager()
        {
            InitializeComponent();

            AutoUpdater.Start("https://au.matux.fr/modManager/latest.xml");

            this.serverURL = "https://au.matux.fr/modManager";
            this.curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager");
            this.appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager";
            this.getAmongUsPath();
            this.VersionField.Text = "Version " + this.curVersion;
            this.lg = "en_US";
            this.WaitLabel.Hide();

            this.AmongUsDirectorySelection.Click += new EventHandler(this.chooseAmongUsDirectory);
            this.AmongUsDirectoryConfirm.Click += new EventHandler(this.textChangedAmongUsPath);
            this.AmongUsDirSwitchButton.Click += new EventHandler(this.backToDirectorySelection);
            this.OpenAmongUs.Click += new EventHandler(this.openAmongUsDirectory);
            this.PlayGameButton.Click += new EventHandler(this.launchGame);
            this.RemoveModsButton.Click += new EventHandler(this.removeMods);
            this.UpdateModsButton.Click += new EventHandler(this.updateMods);
            this.credits.Click += new EventHandler(this.goToMatux);
            this.enFlag.Click += new EventHandler(this.changeLg);
            this.frFlag.Click += new EventHandler(this.changeLg);

            // Choose folder if needed
            if (this.config == null || this.config.amongUsPath == null)
            {
                this.renderPage("PathSelection");
            }
            else
            {
                this.renderPage("ModSelection");
            }

        }

        private void renderPage(string page)
        {
            if (page == "PathSelection")
            {
                this.ModsPanel.Hide();
                this.AmongUsDirSwitchLabel.Hide();
                this.AmongUsDirSwitchButton.Hide();
                this.OpenAmongUs.Hide();
                this.RemoveModsButton.Hide();
                this.PlayGameButton.Hide();
                this.AmongUsDirSwitchButton.Hide();
                this.OpenAmongUs.Hide();
                this.AmongUsDirectoryLabel.Show();
                this.AmongUsDirectorySelection.Show();
                this.AmongUsPathLabel.Show();
                this.AmongUsPathSelection.Show();
                this.AmongUsDirectoryConfirm.Show();
                if (this.config != null && this.config.amongUsPath != null)
                {
                    this.AmongUsPathSelection.Text = this.config.amongUsPath;
                }
            } else if (page == "ModSelection")
            {
                this.AmongUsDirectoryLabel.Hide();
                this.AmongUsDirectorySelection.Hide();
                this.AmongUsPathLabel.Hide();
                this.AmongUsPathSelection.Hide();
                this.AmongUsDirSwitchLabel.Show();
                this.AmongUsDirSwitchButton.Show();
                this.OpenAmongUs.Show();
                this.RemoveModsButton.Show();
                this.PlayGameButton.Show();
                this.AmongUsDirSwitchButton.Show();
                this.OpenAmongUs.Show();
                this.ModsPanel.Show();
                this.AmongUsDirectoryConfirm.Hide();
                this.loadMods();
            }
        }

        private void loadMods()
        {
            string modlistPath = this.appPath+"\\files\\modlist.json";

            FileInfo modlist = new FileInfo(modlistPath);
            if (!modlist.Exists)
            {
                this.updateModsWorker();
            }

            string json = System.IO.File.ReadAllText(modlistPath);
            this.mods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
            int i = 0;
            int max = this.mods.Count/3;
            if (this.mods.Count%3 != 0) { max++;}
            foreach (Mod item in this.mods)
            {
                // Affichage Mod

                Button buton = new Button();
                buton.Size = new Size(200, 30);
                buton.Font = new Font(buton.Font.FontFamily, 12);
                int x = i % max;
                int y = i / max;
                buton.Location = new Point(210*y, 40 * x);
                buton.Text = item.name;
                buton.Name = item.id;
                if (item.id != "Skeld.net")
                {
                    buton.Click += new EventHandler(this.enableMod);
                } else
                {
                    buton.BackColor = Color.Blue;
                    buton.Click += new EventHandler(this.openSkeldNet);
                }

                ToolTip tt = new ToolTip();
                
                tt.SetToolTip(buton, item.descriptionEN);

                // Verification

                if (this.config.installedMods.Contains(item.id))
                {
                    buton.Enabled = false;
                    buton.BackColor = Color.Lime;
                }

                this.ModsPanel.Controls.Add(buton);
                i++;
            }

            return;
        }

        private void enableMod(object sender, EventArgs e)
        {
            Button pressedButton = ((Button)sender);
            string modId = pressedButton.Name;

            if (this.config.installedMods.Contains(modId) == false) // && !File.Exists(pluginsPath + "\\" + file
            {

                string dependenciesPath = this.appPath + "\\files\\dependencies";
                string modPath = this.appPath + "\\files\\mods";
                Mod m = this.getModById(modId);
                foreach (string dependencie in m.dependencies)
                {
                    if (this.config.installedDependencies.Contains(dependencie) == false)
                    {
                        this.DirectoryCopy(dependenciesPath+ "\\"+dependencie, this.config.amongUsPath, true);
                        this.config.installedDependencies.Add(dependencie);
                    }
                }

                string pluginsPath = this.config.amongUsPath + "\\BepInEx\\plugins";

                if (Directory.Exists(pluginsPath) == false)
                {
                    Directory.CreateDirectory(pluginsPath);
                }


                foreach (string file in m.plugins)
                {
                    File.Copy(modPath + "\\"+modId+"\\"+file, pluginsPath+"\\"+file);
                    
                }

                this.config.installedMods.Add(modId);
                this.config.update();
                pressedButton.Enabled = false;
                pressedButton.BackColor = Color.Lime;

            }
            return;
        }

        private void removeMods(object sender, EventArgs e)
        {
            this.deleteMods();
        }

        private void deleteMods()
        {
            this.DirectoryDelete(this.config.amongUsPath + "\\BepInEx");
            this.DirectoryDelete(this.config.amongUsPath + "\\Assets");
            this.DirectoryDelete(this.config.amongUsPath + "\\mono");
            this.FileDelete(this.config.amongUsPath + "\\doorstop_config.ini");
            this.FileDelete(this.config.amongUsPath + "\\winhttp.dll");
            this.config.installedDependencies.Clear();
            this.config.installedMods.Clear();
            this.config.update();
            foreach (Button b in this.ModsPanel.Controls)
            {
                if (b.Enabled == false)
                {
                    b.Enabled = true;
                    b.BackColor = SystemColors.ControlText;
                }
            }
        }

        private void updateMods(object sender, EventArgs e)
        {
            this.updateModsWorker();
        }

        private void updateModsWorker()
        {
            string url = this.serverURL + "/files.zip";
            string filesPath = this.appPath + "\\files";
            // Disable mods and clicks
            this.deleteMods();
            this.ModsPanel.Controls.Clear();
            this.AmongUsDirSwitchButton.Hide();
            this.OpenAmongUs.Hide();
            this.RemoveModsButton.Hide();
            this.PlayGameButton.Hide();
            this.AmongUsDirSwitchButton.Hide();
            this.OpenAmongUs.Hide();
            this.WaitLabel.Show();
            this.Update();

            DirectoryInfo fileMain = new DirectoryInfo(filesPath);
            if (fileMain.Exists == false)
            {
                Directory.CreateDirectory(filesPath);
            }

            // Download remote files.zip
            using (var client = new WebClient())
            {
                client.DownloadFile(url, filesPath + "\\files.zip");
            }

            // Delete files
            DirectoryInfo directoryInfo = new DirectoryInfo(filesPath);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (file.Name != "files.zip")
                {
                    file.Delete();
                }
            }
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                Directory.Delete(directory.FullName, recursive: true);
            }

            // Extract files.zip

            ZipFile.ExtractToDirectory(filesPath + "\\files.zip", filesPath);
            this.FileDelete(filesPath + "\\files.zip");

            this.loadMods();

            this.AmongUsDirSwitchButton.Show();
            this.OpenAmongUs.Show();
            this.RemoveModsButton.Show();
            this.PlayGameButton.Show();
            this.AmongUsDirSwitchButton.Show();
            this.OpenAmongUs.Show();
            this.WaitLabel.Hide();
        }

        private Mod getModById(string id)
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

        private void getAmongUsPath()
        {
            FileInfo f = new FileInfo(this.appDataPath + "\\config.conf");

            if (f.Exists)
            {
                string json = System.IO.File.ReadAllText(this.appDataPath + "\\config.conf");
                Config temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                FileInfo f2 = new FileInfo(temp.amongUsPath + "\\Among Us.exe");
                if (f2.Exists)
                {
                    this.config = temp;
                    this.config.update();
                    return;
                }
            }

            DirectoryInfo dirC = new DirectoryInfo("C:\\Program Files\\Steam\\steamapps\\common\\Among Us");
            DirectoryInfo dirC2 = new DirectoryInfo("C:\\Program Files(x86)\\Steam\\steamapps\\common\\Among Us");

            if (dirC.Exists)
            {
                this.config.amongUsPath = "C:\\Program Files\\Steam\\steamapps\\common\\Among Us";
                this.config.update();
                return;
            }
            if (dirC2.Exists)
            {
                this.config.amongUsPath = "C:\\Program Files(x86)\\Steam\\steamapps\\common\\Among Us";
                this.config.update();
                return;
            }
            return;
        }

        public void chooseAmongUsDirectory(object sender, EventArgs e)
        {
            if (this.AmongUsSelectionPopup.ShowDialog() == DialogResult.OK)
            {
                FileInfo amongUsFile = new FileInfo(AmongUsSelectionPopup.SelectedPath + "\\Among Us.exe");
                if (amongUsFile.Exists)
                {
                    this.config = new Config(AmongUsSelectionPopup.SelectedPath, new List<string>(), new List<string>());
                    this.config.update();

                    this.renderPage("ModSelection");
                }
            }
        }

        public void textChangedAmongUsPath(object sender, EventArgs e)
        {
            FileInfo f = new FileInfo(this.AmongUsPathSelection.Text+"\\Among Us.exe");
            if (f.Exists)
            {

                this.config = new Config(this.AmongUsPathSelection.Text, new List<string>(), new List<string>());
                string json = JsonConvert.SerializeObject(this.config);
                File.WriteAllText(this.appDataPath + "\\config.conf", json);

                this.renderPage("ModSelection");
            }
        }

        private void backToDirectorySelection(object sender, EventArgs e)
        {
            this.renderPage("PathSelection");
        }

        private void openAmongUsDirectory(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", this.config.amongUsPath);
        }

        private void openSkeldNet(object sender, EventArgs e)
        {
            this.deleteMods();
            string SkeldPath = this.appPath + "\\files\\mods\\Skeld.net\\SkeldLaunch.exe";
            System.Diagnostics.Process.Start(SkeldPath);
        }

        private void changeLg(object sender, EventArgs e)
        {
            PictureBox lgBox = ((PictureBox)sender);
            if (lgBox.Name == "frFlag")
            {
                this.lg = "fr_FR";
                this.AmongUsDirSwitchLabel.Text = "Dossier Among Us :";
                this.ModsGroupbox.Text = "Choisis les mods souhaités :";
                this.AmongUsDirSwitchButton.Text = "Changer";
                this.OpenAmongUs.Text = "Ouvrir";
                this.AmongUsDirectorySelection.Text = "Sélectionner un dossier";
                this.AmongUsDirectoryConfirm.Text = "Confirmer le dossier";
                this.RemoveModsButton.Text = "Supprimer les mods";
                this.PlayGameButton.Text = "Jouer";
                this.credits.Text = "Créé par Matux";
                this.AmongUsDirectoryLabel.Text = "Sélectionnez votre dossier Among Us";
                this.AmongUsPathLabel.Text = "Ou entrez le chemin du dossier Among Us ici";
                this.WaitLabel.Text = "Patientez SVP ...";
                this.UpdateModsButton.Text = "Mods MAJ";
            } else
            {
                this.lg = "en_US";
                this.AmongUsDirSwitchLabel.Text = "Among Us directory :";
                this.ModsGroupbox.Text = "Choose wanted mods :";
                this.AmongUsDirSwitchButton.Text = "Change";
                this.OpenAmongUs.Text = "Open";
                this.AmongUsDirectorySelection.Text = "Select directory";
                this.AmongUsDirectoryConfirm.Text = "Confirm directory";
                this.RemoveModsButton.Text = "Remove mods";
                this.PlayGameButton.Text = "Play";
                this.credits.Text = "Made by Matux";
                this.AmongUsDirectoryLabel.Text = "Please select your Among Us directory";
                this.AmongUsPathLabel.Text = "Or enter Among Us directory path here";
                this.WaitLabel.Text = "Please wait ...";
                this.UpdateModsButton.Text = "Update mods";
            }
        }

        private void openCredits(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://matux.fr");
        }

        private void launchGame(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                return;
            }
            System.Diagnostics.Process.Start(this.config.amongUsPath + "\\Among Us.exe");
        }

        private void goToMatux(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://matux.fr");
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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

        private void DirectoryDelete(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                Directory.Delete(dirName, true);
            }
        }

        private void FileDelete(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

    }
}
