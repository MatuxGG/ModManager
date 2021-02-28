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
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Octokit;
using System.Web.Security;

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
        private List<Page> pages;
        private List<Language> languages;
        private Mod currentMod;
        private Boolean isNewMods;
        private Release currentRelease;
        public ModManager()
        {
            InitializeComponent();

            if (System.Diagnostics.Process.GetProcessesByName("ModManager").Length > 1)
            {
                Environment.Exit(0);
            }

            this.serverURL = "https://mm.matux.fr";
            this.curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.appPath = System.AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager");
            this.appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager";

            if (!new DirectoryInfo(this.appPath+"\\files").Exists
                || !new FileInfo(this.appPath+"\\files\\modlist.json").Exists
                || !new FileInfo(this.appPath + "\\files\\lglist.json").Exists
                || !new DirectoryInfo(this.appPath + "\\files\\translations").Exists
                || !new DirectoryInfo(this.appPath + "\\files\\servers").Exists
                || !new DirectoryInfo(this.appPath + "\\files\\dependencies").Exists
                )
            {
                this.updateFilesWorker();
                System.Windows.Forms.Application.Restart();
                Environment.Exit(0);
            }

            this.loadLanguages();

            using (WebClient client = new WebClient())
            {
                string version = client.DownloadString(this.serverURL+"/version.txt");
                if (Version.Parse(version) > curVersion)
                {
                    if (MessageBox.Show(lg(0), lg(1), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.deleteMods();
                        FileInfo installer = new FileInfo(this.appPath + "\\ModManagerInstaller.exe");
                        if (installer.Exists)
                        {
                            this.FileDelete(this.appPath + "\\ModManagerInstaller.exe");
                        }
                        client.DownloadFile(this.serverURL + "/ModManagerInstaller.exe", this.appPath + "\\ModManagerInstaller.exe");
                        Process.Start(this.appPath + "\\ModManagerInstaller.exe");
                        Environment.Exit(0);
                    }
                }
            }


            this.getAmongUsPath();


            // Clean old directories
            if (new DirectoryInfo(this.appPath+"\\mods").Exists)
            {
                this.DirectoryDelete(this.appPath + "\\mods");
            }

            this.createPages();

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

        private string lg(int id)
        {
            if (this.config == null || this.config.lg == null)
            {
                this.config = new Config(null, new List<InstalledMod>(), new List<string>(), "US", false);
            }
            Language currentLanguage = this.getLanguageFromId(this.config.lg);
            if (currentLanguage.get(id) != null)
            {
                return currentLanguage.get(id);
            }
            else
            {
                return this.getLanguageFromId("US").get(id);
            }
            return "";
        }

        private Language getLanguageFromId(string id)
        {
            foreach (Language l in this.languages)
            {
                if (l.id == id)
                {
                    return l;
                }
            }
            return null;
        }
        private void createPages()
        {

            // Header

            this.VersionField.Text = lg(26) + " " + this.curVersion;

            // Pages init
            this.pages = new List<Page>();

            // Path Selection
            Page p = new Page("PathSelection");

            System.Windows.Forms.Label AmongUsDirectoryLabel = new System.Windows.Forms.Label();
            AmongUsDirectoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            AmongUsDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectoryLabel.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsDirectoryLabel.Location = new System.Drawing.Point(20, 100);
            AmongUsDirectoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AmongUsDirectoryLabel.Name = "AmongUsDirectoryLabel";
            AmongUsDirectoryLabel.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectoryLabel.TabIndex = 5;
            AmongUsDirectoryLabel.Text = lg(2);
            this.Controls.Add(AmongUsDirectoryLabel);
            p.addControl(AmongUsDirectoryLabel);

            Button AmongUsDirectorySelection = new System.Windows.Forms.Button();
            AmongUsDirectorySelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectorySelection.Location = new System.Drawing.Point(20, 150);
            AmongUsDirectorySelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirectorySelection.Name = "AmongUsDirectorySelection";
            AmongUsDirectorySelection.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectorySelection.TabIndex = 6;
            AmongUsDirectorySelection.Text = lg(3);
            AmongUsDirectorySelection.Click += new EventHandler(this.chooseAmongUsDirectory);
            AmongUsDirectorySelection.UseVisualStyleBackColor = true;
            this.Controls.Add(AmongUsDirectorySelection);
            p.addControl(AmongUsDirectorySelection);

            System.Windows.Forms.Label AmongUsPathLabel = new System.Windows.Forms.Label();
            AmongUsPathLabel.TextAlign = ContentAlignment.MiddleCenter;
            AmongUsPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsPathLabel.Location = new System.Drawing.Point(20, 250);
            AmongUsPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AmongUsPathLabel.Name = "AmongUsPathLabel";
            AmongUsPathLabel.Size = new System.Drawing.Size(400, 50);
            AmongUsPathLabel.TabIndex = 8;
            AmongUsPathLabel.Text = lg(4);
            this.Controls.Add(AmongUsPathLabel);
            p.addControl(AmongUsPathLabel);

            TextBox AmongUsPathSelection = new System.Windows.Forms.TextBox();
            AmongUsPathSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsPathSelection.Location = new System.Drawing.Point(20, 310);
            AmongUsPathSelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsPathSelection.Name = "AmongUsPathSelection";
            AmongUsPathSelection.Multiline = true;
            AmongUsPathSelection.Size = new System.Drawing.Size(400, 50);
            AmongUsPathSelection.TabIndex = 7;
            this.Controls.Add(AmongUsPathSelection);
            p.addControl(AmongUsPathSelection);

            Button AmongUsDirectoryConfirm = new System.Windows.Forms.Button();
            AmongUsDirectoryConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectoryConfirm.Location = new System.Drawing.Point(20, 380);
            AmongUsDirectoryConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirectoryConfirm.Name = "AmongUsDirectoryConfirm";
            AmongUsDirectoryConfirm.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectoryConfirm.TabIndex = 19;
            AmongUsDirectoryConfirm.Text = lg(5);
            AmongUsDirectoryConfirm.Click += new EventHandler(this.textChangedAmongUsPath);
            AmongUsDirectoryConfirm.UseVisualStyleBackColor = true;
            this.Controls.Add(AmongUsDirectoryConfirm);
            p.addControl(AmongUsDirectoryConfirm);

            System.Windows.Forms.Label Step1Label = new System.Windows.Forms.Label();
            Step1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Step1Label.ForeColor = System.Drawing.SystemColors.Control;
            Step1Label.Location = new System.Drawing.Point(450, 70);
            Step1Label.Name = "Step1Label";
            Step1Label.Size = new System.Drawing.Size(450, 25);
            Step1Label.TabIndex = 28;
            Step1Label.Text = lg(6);
            this.Controls.Add(Step1Label);
            p.addControl(Step1Label);

            PictureBox Step1Pic = new System.Windows.Forms.PictureBox();
            Step1Pic.Image = Properties.Resources.step1;
            Step1Pic.Location = new System.Drawing.Point(450, 80);
            Step1Pic.Name = "Step1Pic";
            Step1Pic.Size = new System.Drawing.Size(230, 160);
            Step1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Step1Pic.TabIndex = 26;
            Step1Pic.TabStop = false;
            this.Controls.Add(Step1Pic);
            p.addControl(Step1Pic);

            System.Windows.Forms.Label Step2Label = new System.Windows.Forms.Label();
            Step2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Step2Label.ForeColor = System.Drawing.SystemColors.Control;
            Step2Label.Location = new System.Drawing.Point(450, 250);
            Step2Label.Name = "Step2Label";
            Step2Label.Size = new System.Drawing.Size(450, 50);
            Step2Label.TabIndex = 29;
            Step2Label.Text = lg(7);
            this.Controls.Add(Step2Label);
            p.addControl(Step2Label);

            PictureBox Step2Pic = new System.Windows.Forms.PictureBox();
            Step2Pic.Image = Properties.Resources.step2;
            Step2Pic.Location = new System.Drawing.Point(430, 300);
            Step2Pic.Name = "Step2Pic";
            Step2Pic.Size = new System.Drawing.Size(450, 160);
            Step2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Step2Pic.TabIndex = 27;
            Step2Pic.TabStop = false;
            Controls.Add(Step2Pic);
            p.addControl(Step2Pic);

            this.pages.Add(p);

            // Mod Selection
            p = new Page("ModSelection");


            PictureBox SettingsPic = new System.Windows.Forms.PictureBox();
            SettingsPic.Image = global::ModManager.Properties.Resources.settings;
            SettingsPic.Location = new System.Drawing.Point(850, 15);
            SettingsPic.Name = "SettingsPic";
            SettingsPic.Size = new System.Drawing.Size(30, 30);
            SettingsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            SettingsPic.TabStop = false;
            SettingsPic.Cursor = Cursors.Hand;
            SettingsPic.Click += new EventHandler(this.openSettings);
            SettingsPic.BringToFront();
            Controls.Add(SettingsPic);
            p.addControl(SettingsPic);

            PictureBox ThanksPic = new System.Windows.Forms.PictureBox();
            ThanksPic.Image = global::ModManager.Properties.Resources.thanks;
            ThanksPic.Location = new System.Drawing.Point(900, 15);
            ThanksPic.Name = "ThanksPic";
            ThanksPic.Size = new System.Drawing.Size(30, 30);
            ThanksPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ThanksPic.TabStop = false;
            ThanksPic.Cursor = Cursors.Hand;
            ThanksPic.Click += new EventHandler(this.openCredits);
            ThanksPic.BringToFront();
            Controls.Add(ThanksPic);
            p.addControl(ThanksPic);

            Button RemoveModsButton = new System.Windows.Forms.Button();
            RemoveModsButton.BackColor = System.Drawing.Color.Red;
            RemoveModsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RemoveModsButton.Location = new System.Drawing.Point(20, 485);
            RemoveModsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            RemoveModsButton.Name = "RemoveModsButton";
            RemoveModsButton.Size = new System.Drawing.Size(197, 32);
            RemoveModsButton.TabIndex = 16;
            RemoveModsButton.Text = lg(8);
            RemoveModsButton.Click += new EventHandler(this.removeMods);
            this.Controls.Add(RemoveModsButton);
            p.addControl(RemoveModsButton);

            Button PlayGameButton = new System.Windows.Forms.Button();
            PlayGameButton.BackColor = System.Drawing.Color.Lime;
            PlayGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PlayGameButton.Location = new System.Drawing.Point(250, 485);
            PlayGameButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PlayGameButton.Name = "PlayGameButton";
            PlayGameButton.Size = new System.Drawing.Size(105, 32);
            PlayGameButton.Text = lg(9);
            PlayGameButton.Click += new EventHandler(this.launchGame);
            this.Controls.Add(PlayGameButton);
            p.addControl(PlayGameButton);

            System.Windows.Forms.Label ModListLabel = new System.Windows.Forms.Label();
            ModListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModListLabel.ForeColor = System.Drawing.SystemColors.Control;
            ModListLabel.Location = new System.Drawing.Point(20, 85);
            ModListLabel.Name = "ModListLabel";
            ModListLabel.Size = new System.Drawing.Size(150, 50);
            ModListLabel.Text = lg(10);
            this.Controls.Add(ModListLabel);
            p.addControl(ModListLabel);

            ComboBox ModListCombo = new System.Windows.Forms.ComboBox();
            ModListCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModListCombo.Location = new System.Drawing.Point(200, 80);
            ModListCombo.Name = "ModListCombo";
            ModListCombo.Size = new System.Drawing.Size(300, 50);
            ModListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ModListCombo.SelectedIndexChanged += new EventHandler(this.changeMod);
            this.Controls.Add(ModListCombo);
            p.addControl(ModListCombo);

            System.Windows.Forms.Label AuthorTitle = new System.Windows.Forms.Label();
            AuthorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AuthorTitle.ForeColor = System.Drawing.SystemColors.Control;
            AuthorTitle.Location = new System.Drawing.Point(20, 130);
            AuthorTitle.Name = "AuthorTitle";
            AuthorTitle.Size = new System.Drawing.Size(150, 25);
            AuthorTitle.Text = lg(11);
            this.Controls.Add(AuthorTitle);
            p.addControl(AuthorTitle);

            System.Windows.Forms.Label AuthorLabel = new System.Windows.Forms.Label();
            AuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AuthorLabel.ForeColor = System.Drawing.SystemColors.Control;
            AuthorLabel.Location = new System.Drawing.Point(200, 130);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new System.Drawing.Size(500, 25);
            AuthorLabel.Text = "Author";
            this.Controls.Add(AuthorLabel);
            p.addControl(AuthorLabel);

            System.Windows.Forms.Label VersionTitle = new System.Windows.Forms.Label();
            VersionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionTitle.ForeColor = System.Drawing.SystemColors.Control;
            VersionTitle.Location = new System.Drawing.Point(20, 160);
            VersionTitle.Name = "VersionTitle";
            VersionTitle.Size = new System.Drawing.Size(150, 25);
            VersionTitle.Text = lg(12);
            this.Controls.Add(VersionTitle);
            p.addControl(VersionTitle);

            System.Windows.Forms.Label VersionLabel = new System.Windows.Forms.Label();
            VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionLabel.ForeColor = System.Drawing.SystemColors.Control;
            VersionLabel.Location = new System.Drawing.Point(200, 160);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new System.Drawing.Size(500, 25);
            VersionLabel.Text = "vX.X.X";
            this.Controls.Add(VersionLabel);
            p.addControl(VersionLabel);

            System.Windows.Forms.Label GithubTitle = new System.Windows.Forms.Label();
            GithubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GithubTitle.ForeColor = System.Drawing.SystemColors.Control;
            GithubTitle.Location = new System.Drawing.Point(20, 190);
            GithubTitle.Name = "GithubTitle";
            GithubTitle.Size = new System.Drawing.Size(150, 25);
            GithubTitle.Text = lg(13);
            this.Controls.Add(GithubTitle);
            p.addControl(GithubTitle);

            LinkLabel GithubLabel = new System.Windows.Forms.LinkLabel();
            GithubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GithubLabel.ForeColor = System.Drawing.SystemColors.Control;
            GithubLabel.LinkColor = System.Drawing.SystemColors.Control;
            GithubLabel.Location = new System.Drawing.Point(200, 190);
            GithubLabel.Name = "GithubLabel";
            GithubLabel.Size = new System.Drawing.Size(500, 25);
            GithubLabel.Text = "";
            this.Controls.Add(GithubLabel);
            p.addControl(GithubLabel);

            System.Windows.Forms.Label DescriptionTitle = new System.Windows.Forms.Label();
            DescriptionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DescriptionTitle.ForeColor = System.Drawing.SystemColors.Control;
            DescriptionTitle.Location = new System.Drawing.Point(20, 220);
            DescriptionTitle.Name = "DescriptionTitle";
            DescriptionTitle.Size = new System.Drawing.Size(150, 25);
            DescriptionTitle.Text = lg(14);
            this.Controls.Add(DescriptionTitle);
            p.addControl(DescriptionTitle);

            TextBox DescriptionLabel = new System.Windows.Forms.TextBox();
            DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DescriptionLabel.ForeColor = System.Drawing.SystemColors.Control;
            DescriptionLabel.BackColor = System.Drawing.SystemColors.WindowText;
            DescriptionLabel.BorderStyle = BorderStyle.FixedSingle;
            DescriptionLabel.Location = new System.Drawing.Point(20, 250);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new System.Drawing.Size(920, 160);
            DescriptionLabel.ScrollBars = ScrollBars.Vertical;
            DescriptionLabel.Multiline = true;
            DescriptionLabel.WordWrap = true;
            DescriptionLabel.ReadOnly = true;
            DescriptionLabel.Cursor = Cursors.Arrow;
            DescriptionLabel.Text = "";
            this.Controls.Add(DescriptionLabel);
            p.addControl(DescriptionLabel);

            Button InstallModButton = new System.Windows.Forms.Button();
            InstallModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InstallModButton.ForeColor = System.Drawing.SystemColors.Control;
            InstallModButton.Location = new System.Drawing.Point(20, 425);
            InstallModButton.Name = "InstallModButton";
            InstallModButton.Size = new System.Drawing.Size(150, 32);
            InstallModButton.Text = lg(15);
            InstallModButton.BackColor = Color.Blue;
            InstallModButton.Click += new EventHandler(this.installMod);
            this.Controls.Add(InstallModButton);
            p.addControl(InstallModButton);

            Button UninstallModButton = new System.Windows.Forms.Button();
            UninstallModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModButton.ForeColor = System.Drawing.SystemColors.ControlText;
            UninstallModButton.Location = new System.Drawing.Point(20, 425);
            UninstallModButton.Name = "UninstallModButton";
            UninstallModButton.Size = new System.Drawing.Size(150, 32);
            UninstallModButton.Text = lg(16);
            UninstallModButton.BackColor = Color.Red;
            UninstallModButton.Click += new EventHandler(this.uninstallMod);
            this.Controls.Add(UninstallModButton);
            p.addControl(UninstallModButton);

            Button UpdateModButton = new System.Windows.Forms.Button();
            UpdateModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateModButton.ForeColor = System.Drawing.SystemColors.Control;
            UpdateModButton.Location = new System.Drawing.Point(220, 425);
            UpdateModButton.Name = "UpdateModButton";
            UpdateModButton.Size = new System.Drawing.Size(150, 32);
            UpdateModButton.Text = lg(43);
            UpdateModButton.BackColor = Color.Purple;
            UpdateModButton.Click += new EventHandler(this.updateMod);
            this.Controls.Add(UpdateModButton);
            p.addControl(UpdateModButton);

            using (WebClient client = new WebClient())
            {
                string remoteVersion = client.DownloadString(this.serverURL + "/modsVersion.txt");
                string modsVersionPath = this.appDataPath + "\\modsVersion.txt";
                string curVersion = File.ReadLines(modsVersionPath).First();

                if (Version.Parse(remoteVersion) > Version.Parse(curVersion))
                {
                    this.isNewMods = true;
                }
                else
                {
                    this.isNewMods = false;
                }
            }

            System.Windows.Forms.Label UpdateFilesLabel = new System.Windows.Forms.Label();
            UpdateFilesLabel.TextAlign = ContentAlignment.MiddleRight;
            UpdateFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateFilesLabel.ForeColor = System.Drawing.Color.Purple;
            UpdateFilesLabel.Location = new System.Drawing.Point(380, 490);
            UpdateFilesLabel.Name = "UpdateFilesLabel";
            UpdateFilesLabel.Size = new System.Drawing.Size(250, 25);
            UpdateFilesLabel.Text = lg(21);
            this.Controls.Add(UpdateFilesLabel);
            p.addControl(UpdateFilesLabel);

            Button UpdateFilesButton = new System.Windows.Forms.Button();
            UpdateFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateFilesButton.Location = new System.Drawing.Point(650, 485);
            UpdateFilesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            UpdateFilesButton.BackColor = System.Drawing.Color.Purple;
            UpdateFilesButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            UpdateFilesButton.Name = "UpdateFilesButton";
            UpdateFilesButton.Size = new System.Drawing.Size(150, 33);
            UpdateFilesButton.Text = lg(22);
            UpdateFilesButton.Click += new EventHandler(this.updateFiles);

            this.Controls.Add(UpdateFilesButton);
            p.addControl(UpdateFilesButton);

            this.pages.Add(p);

            // Settings
            p = new Page("Settings");

            PictureBox BackPic = new System.Windows.Forms.PictureBox();
            BackPic.Image = Properties.Resources.back;
            BackPic.Location = new System.Drawing.Point(30, 20);
            BackPic.Name = "BackPic";
            BackPic.Size = new System.Drawing.Size(25, 25);
            BackPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            BackPic.TabIndex = 27;
            BackPic.TabStop = false;
            BackPic.Cursor = Cursors.Hand;
            BackPic.Click += new EventHandler(this.backToMods);
            Controls.Add(BackPic);
            p.addControl(BackPic);

            System.Windows.Forms.Label SettingsTitle = new System.Windows.Forms.Label();
            SettingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            SettingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SettingsTitle.ForeColor = System.Drawing.SystemColors.Control;
            SettingsTitle.Location = new System.Drawing.Point(20, 80);
            SettingsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            SettingsTitle.Name = "SettingsTitle";
            SettingsTitle.Size = new System.Drawing.Size(920, 40);
            SettingsTitle.Text = lg(34);
            this.Controls.Add(SettingsTitle);
            p.addControl(SettingsTitle);

            System.Windows.Forms.Label AmongUsDirSwitchLabel = new System.Windows.Forms.Label();
            AmongUsDirSwitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsDirSwitchLabel.Location = new System.Drawing.Point(20, 130);
            AmongUsDirSwitchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AmongUsDirSwitchLabel.Name = "AmongUsDirSwitchLabel";
            AmongUsDirSwitchLabel.Size = new System.Drawing.Size(200, 20);
            AmongUsDirSwitchLabel.TabIndex = 12;
            AmongUsDirSwitchLabel.Text = lg(17);
            this.Controls.Add(AmongUsDirSwitchLabel);
            p.addControl(AmongUsDirSwitchLabel);
            
            Button AmongUsDirSwitchButton = new System.Windows.Forms.Button();
            AmongUsDirSwitchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchButton.Location = new System.Drawing.Point(250, 130);
            AmongUsDirSwitchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirSwitchButton.Name = "AmongUsDirSwitchButton";
            AmongUsDirSwitchButton.Size = new System.Drawing.Size(150, 30);
            AmongUsDirSwitchButton.TabIndex = 11;
            AmongUsDirSwitchButton.Text = lg(18);
            AmongUsDirSwitchButton.UseVisualStyleBackColor = true;
            AmongUsDirSwitchButton.Click += new EventHandler(this.backToDirectorySelection);
            this.Controls.Add(AmongUsDirSwitchButton);
            p.addControl(AmongUsDirSwitchButton);
            
            Button OpenAmongUs = new System.Windows.Forms.Button();
            OpenAmongUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenAmongUs.Location = new System.Drawing.Point(450, 130);
            OpenAmongUs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            OpenAmongUs.Name = "OpenAmongUs";
            OpenAmongUs.Size = new System.Drawing.Size(150, 30);
            OpenAmongUs.TabIndex = 13;
            OpenAmongUs.Text = lg(19);
            OpenAmongUs.UseVisualStyleBackColor = true;
            OpenAmongUs.Click += new EventHandler(this.openAmongUsDirectory);
            this.Controls.Add(OpenAmongUs);
            p.addControl(OpenAmongUs);

            System.Windows.Forms.Label LanguageLabel = new System.Windows.Forms.Label();
            LanguageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LanguageLabel.ForeColor = System.Drawing.SystemColors.Control;
            LanguageLabel.Location = new System.Drawing.Point(20, 180);
            LanguageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            LanguageLabel.Name = "LanguageLabel";
            LanguageLabel.Size = new System.Drawing.Size(150, 20);
            LanguageLabel.Text = lg(20);
            this.Controls.Add(LanguageLabel);
            p.addControl(LanguageLabel);

            ComboBox LanguageCombobox = new System.Windows.Forms.ComboBox();
            LanguageCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LanguageCombobox.Location = new System.Drawing.Point(250, 180);
            LanguageCombobox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            LanguageCombobox.Name = "LanguageCombobox";
            LanguageCombobox.Size = new System.Drawing.Size(350, 30);
            LanguageCombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (Language lg in this.languages)
            {
                LanguageCombobox.Items.Add(lg.name);
            }

            LanguageCombobox.SelectedItem = this.getLanguageNameFromId(this.config.lg);

            LanguageCombobox.SelectedIndexChanged += new EventHandler(this.changeLg);

            this.Controls.Add(LanguageCombobox);
            p.addControl(LanguageCombobox);

            System.Windows.Forms.Label TenPlayersLabel = new System.Windows.Forms.Label();
            TenPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TenPlayersLabel.ForeColor = System.Drawing.SystemColors.Control;
            TenPlayersLabel.Location = new System.Drawing.Point(20, 230);
            TenPlayersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            TenPlayersLabel.Name = "TenPlayersLabel";
            TenPlayersLabel.Size = new System.Drawing.Size(500, 20);
            TenPlayersLabel.Text = lg(35);
            this.Controls.Add(TenPlayersLabel);
            p.addControl(TenPlayersLabel);

            CheckBox TenPlayersCheckbox = new System.Windows.Forms.CheckBox();
            TenPlayersCheckbox.ForeColor = System.Drawing.SystemColors.Control;
            TenPlayersCheckbox.Location = new System.Drawing.Point(550, 230);
            TenPlayersCheckbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            TenPlayersCheckbox.Name = "TenPlayersCheckbox";
            TenPlayersCheckbox.Size = new System.Drawing.Size(300, 20);
            TenPlayersCheckbox.Cursor = Cursors.Hand;
            TenPlayersCheckbox.Click += new EventHandler(this.enableTenPlayers);

            if (this.config.tenPlayers)
            {
                TenPlayersCheckbox.Checked = true;
            } else
            {
                TenPlayersCheckbox.Checked = false;
            }

            this.Controls.Add(TenPlayersCheckbox);
            p.addControl(TenPlayersCheckbox);

            System.Windows.Forms.Label OpenSkeldLabel = new System.Windows.Forms.Label();
            OpenSkeldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenSkeldLabel.ForeColor = System.Drawing.SystemColors.Control;
            OpenSkeldLabel.Location = new System.Drawing.Point(20, 280);
            OpenSkeldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            OpenSkeldLabel.Name = "OpenSkeldLabel";
            OpenSkeldLabel.Size = new System.Drawing.Size(300, 20);
            OpenSkeldLabel.Text = lg(48);
            this.Controls.Add(OpenSkeldLabel);
            p.addControl(OpenSkeldLabel);

            Button OpenSkeldButton = new System.Windows.Forms.Button();
            OpenSkeldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenSkeldButton.Location = new System.Drawing.Point(450, 280);
            OpenSkeldButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            OpenSkeldButton.Name = "OpenAmongUs";
            OpenSkeldButton.Size = new System.Drawing.Size(150, 30);
            OpenSkeldButton.TabIndex = 13;
            OpenSkeldButton.Text = lg(19);
            OpenSkeldButton.UseVisualStyleBackColor = true;
            OpenSkeldButton.Click += new EventHandler(this.openSkeldNet);
            this.Controls.Add(OpenSkeldButton);
            p.addControl(OpenSkeldButton);

            this.pages.Add(p);

            // Credits
            p = new Page("Credits");

            PictureBox BackPic2 = new System.Windows.Forms.PictureBox();
            BackPic2.Image = Properties.Resources.back;
            BackPic2.Location = new System.Drawing.Point(30, 20);
            BackPic2.Name = "BackPic2";
            BackPic2.Size = new System.Drawing.Size(25, 25);
            BackPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            BackPic2.TabStop = false;
            BackPic2.Cursor = Cursors.Hand;
            BackPic2.Click += new EventHandler(this.backToMods);
            Controls.Add(BackPic);
            p.addControl(BackPic);

            System.Windows.Forms.Label CreditsTitle = new System.Windows.Forms.Label();
            CreditsTitle.TextAlign = ContentAlignment.MiddleCenter;
            CreditsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CreditsTitle.ForeColor = System.Drawing.SystemColors.Control;
            CreditsTitle.Location = new System.Drawing.Point(20, 80);
            CreditsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            CreditsTitle.Name = "CreditsTitle";
            CreditsTitle.Size = new System.Drawing.Size(920, 30);
            CreditsTitle.BackColor = System.Drawing.SystemColors.ControlText;
            CreditsTitle.Text = lg(36);
            this.Controls.Add(CreditsTitle);
            p.addControl(CreditsTitle);

            System.Windows.Forms.Label Line1Label = new System.Windows.Forms.Label();
            Line1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line1Label.ForeColor = System.Drawing.SystemColors.Control;
            Line1Label.Location = new System.Drawing.Point(20, 130);
            Line1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line1Label.Name = "Line1Label";
            Line1Label.Size = new System.Drawing.Size(920, 30);
            Line1Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line1Label.Text = lg(23);
            this.Controls.Add(Line1Label);
            p.addControl(Line1Label);

            System.Windows.Forms.Label Line2Label = new System.Windows.Forms.Label();
            Line2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line2Label.ForeColor = System.Drawing.SystemColors.Control;
            Line2Label.Location = new System.Drawing.Point(20, 180);
            Line2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line2Label.Name = "Line2Label";
            Line2Label.Size = new System.Drawing.Size(920, 30);
            Line2Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line2Label.Text = lg(24);
            this.Controls.Add(Line2Label);
            p.addControl(Line2Label);

            System.Windows.Forms.Label Line3Label = new System.Windows.Forms.Label();
            Line3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line3Label.ForeColor = System.Drawing.SystemColors.Control;
            Line3Label.Location = new System.Drawing.Point(20, 210);
            Line3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line3Label.Name = "Line3Label";
            Line3Label.Size = new System.Drawing.Size(920, 30);
            Line3Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line3Label.Text = lg(25);
            this.Controls.Add(Line3Label);
            p.addControl(Line3Label);

            System.Windows.Forms.Label Line4Label = new System.Windows.Forms.Label();
            Line4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line4Label.ForeColor = System.Drawing.SystemColors.Control;
            Line4Label.Location = new System.Drawing.Point(20, 240);
            Line4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line4Label.Name = "Line4Label";
            Line4Label.Size = new System.Drawing.Size(920, 30);
            Line4Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line4Label.Text = lg(33);
            this.Controls.Add(Line4Label);
            p.addControl(Line4Label);

            PictureBox MatuxGithubLabel = new System.Windows.Forms.PictureBox();
            MatuxGithubLabel.Image = Properties.Resources.github;
            MatuxGithubLabel.Location = new System.Drawing.Point(20, 490);
            MatuxGithubLabel.Name = "MatuxGithubLabel";
            MatuxGithubLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MatuxGithubLabel.TabStop = false;
            MatuxGithubLabel.Cursor = Cursors.Hand;
            MatuxGithubLabel.Size = new System.Drawing.Size(25, 25);
            MatuxGithubLabel.Click += new EventHandler(this.openMatuxGithub);
            this.Controls.Add(MatuxGithubLabel);
            p.addControl(MatuxGithubLabel);

            PictureBox MMDiscordLabel = new System.Windows.Forms.PictureBox();
            MMDiscordLabel.Image = Properties.Resources.discord;
            MMDiscordLabel.Location = new System.Drawing.Point(70, 490);
            MMDiscordLabel.Name = "MMDiscordLabel";
            MMDiscordLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MMDiscordLabel.TabStop = false;
            MMDiscordLabel.Cursor = Cursors.Hand;
            MMDiscordLabel.Size = new System.Drawing.Size(25, 25);
            MMDiscordLabel.Click += new EventHandler(this.openMMDiscord);
            this.Controls.Add(MMDiscordLabel);
            p.addControl(MMDiscordLabel);

            this.pages.Add(p);

        }
        
        public string getLanguageNameFromId(string id)
        {
            foreach (Language l in this.languages)
            {
                if (l.id == id)
                {
                    return l.name;
                }
            }
            return "English";
        }

        public string getLanguageIdFromName(string name)
        {
            foreach (Language l in this.languages)
            {
                if (l.name == name)
                {
                    return l.id;
                }
            }
            return "English";
        }

        private void renderPage(string page)
        {
            foreach (Page p in this.pages)
            {
                p.hide();
            }

            this.getPage(page).show(this.isNewMods);
            if (page == "PathSelection")
            {

                if (this.config != null && this.config.amongUsPath != null)
                {
                    this.getPage("PathSelection").getControl("AmongUsPathSelection").Text = this.config.amongUsPath;
                }
            } else if (page == "ModSelection")
            {
                this.loadMods();
                this.changeModWorker();
            }
        }

        private Page getPage(string name)
        {
            foreach (Page p in this.pages)
            {
                if (p.name == name)
                {
                    return p;
                }
            }
            return null;
        }

        private void loadLanguages()
        {
            string languagesPath = this.appPath + "\\files\\lglist.json";
            FileInfo lglist = new FileInfo(languagesPath);
            string json = System.IO.File.ReadAllText(languagesPath);
            this.languages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Language>>(json);
        }

        private void loadMods()
        {
            string modlistPath = this.appPath+"\\files\\modlist.json";

            FileInfo modlist = new FileInfo(modlistPath);

            string json = System.IO.File.ReadAllText(modlistPath);
            this.mods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Mod>>(json);
            ComboBox comboMods = (ComboBox) this.getPage("ModSelection").getControl("ModListCombo");
            comboMods.Items.Clear();
            int i = 0;
            foreach (Mod item in this.mods)
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

            return;
        }

        private Mod getModFromName(string name)
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

        private void changeLg(object sender, EventArgs e)
        {
            ComboBox changedLg = ((ComboBox)sender);
            this.config.lg = this.getLanguageIdFromName(changedLg.SelectedItem.ToString());
            this.config.update();
            foreach (Page p in this.pages)
            {
                foreach (Control c in p.controls)
                {
                    this.Controls.Remove(c);
                }
            }
            this.pages.Clear();
            this.createPages();
            this.renderPage("Settings");
        }

        private void changeMod(object sender, EventArgs e)
        {
            ComboBox changedBox = ((ComboBox)sender);
            this.currentMod = this.getModFromName(changedBox.SelectedItem.ToString());

            this.changeModWorker();
        }

        private async Task GetGithubInfos(string author, string repository)
        {
            var client = new GitHubClient(new ProductHeaderValue("ModManager"));
            var tokenAuth = new Credentials("9225e430ab0b8fbb69060f168aa7875c1f29add3");
            client.Credentials = tokenAuth;
            this.currentRelease = null;
            this.currentRelease =  await client.Repository.Release.GetLatest(author, repository);


        }
        private async void changeModWorker()
        {
            Page modSelectionPage = (Page)this.getPage("ModSelection");

            modSelectionPage.getControl("AuthorLabel").Text = this.currentMod.author;

            await this.GetGithubInfos(this.currentMod.author, this.currentMod.github);

            using (WebClient wc = new WebClient())
            {
                string version = this.currentRelease.TagName;
                modSelectionPage.getControl("VersionLabel").Text = version;

                modSelectionPage.getControl("GithubLabel").Text = "https://github.com/" + this.currentMod.author + "/" + this.currentMod.github;
                modSelectionPage.getControl("GithubLabel").Click += new EventHandler(this.openGithub);
                modSelectionPage.getControl("DescriptionLabel").Text = this.currentMod.getDescriptionById("EN").description;
                Button installButton = (Button)modSelectionPage.getControl("InstallModButton");
                Button uninstallButton = (Button)modSelectionPage.getControl("UninstallModButton");
                Button updateButton = (Button)modSelectionPage.getControl("UpdateModButton");
                if (this.config.containsMod(this.currentMod.id))
                {

                    installButton.Visible = false;
                    uninstallButton.Visible = true;
                    if (this.config.isUpTodate(this.currentMod.id, version))
                    {
                        updateButton.Visible = false;
                    }
                    else
                    {
                        updateButton.Visible = true;
                    }
                }
                else
                {
                    installButton.Visible = true;
                    uninstallButton.Visible = false;
                    updateButton.Visible = false;
                }
            }
        }

        private void openGithub(object sender, EventArgs e)
        {
            LinkLabel clickedLink = ((LinkLabel)sender);
            string link = clickedLink.Text;
            System.Diagnostics.Process.Start(link);
        }

        private void openMatuxGithub(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MatuxGG/ModManager");
        }

        private void openMMDiscord(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/yBNgKuGjNw");
        }

        private void enableTenPlayers(object sender, EventArgs e) {

            CheckBox clickedBox = ((CheckBox)sender);

            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                if (clickedBox.Checked)
                {
                    clickedBox.Checked = false;
                } else
                {
                    clickedBox.Checked = true;
                }
                MessageBox.Show(lg(41), lg(42), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string pluginsPath = this.config.amongUsPath + "\\BepInEx\\plugins";

            if (clickedBox.Checked)
            {
                this.installDependencies();

                if (Directory.Exists(pluginsPath) == false)
                {
                    Directory.CreateDirectory(pluginsPath);
                }

                this.FileDelete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\LocalLow\\Innersloth\\Among Us\\regionInfo.dat");
                File.Copy(this.appPath + "\\files\\servers\\matux.dat", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\LocalLow\\Innersloth\\Among Us\\regionInfo.dat");
                this.FileDelete(pluginsPath + "\\CrowdedMod.dll");
                File.Copy(this.appPath + "\\files\\CrowdedMod.dll", pluginsPath+"\\CrowdedMod.dll");

                this.config.tenPlayers = true;
                this.config.update();
            } else
            {
                this.FileDelete(pluginsPath + "\\CrowdedMod.dll");
                this.FileDelete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\LocalLow\\Innersloth\\Among Us\\regionInfo.dat");

                this.config.tenPlayers = false;
                this.config.update();
            }

        }

        private void installDependencies() {
            string dependenciesPath = this.appPath + "\\files\\dependencies";
            List<string> dependencies = new List<string>();
            dependencies.Add("BepInEx");
            dependencies.Add("Reactor");
            dependencies.Add("Essentials");
            foreach (string dependencie in dependencies)
            {
                if (this.config.installedDependencies.Contains(dependencie) == false)
                {
                    this.DirectoryCopy(dependenciesPath + "\\" + dependencie, this.config.amongUsPath, true);
                    this.config.installedDependencies.Add(dependencie);
                }
            }
        }

        private void uninstallMod(object sender, EventArgs e)
        {
            this.uninstallModWorker();
            this.getPage("ModSelection").getControl("InstallModButton").Visible = true;
            this.getPage("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Blue;
            this.getPage("ModSelection").getControl("UninstallModButton").Visible = false;
            MessageBox.Show(lg(44), lg(45), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void uninstallModWorker()
        {
            InstalledMod installedMod = this.config.getInstalledModById(this.currentMod.id);
            string pluginsPath = this.config.amongUsPath + "\\BepInEx\\plugins";
            foreach (string plugin in installedMod.plugins)
            {
                this.FileDelete(pluginsPath + "\\" + plugin);
            }
            string assetsPath = this.config.amongUsPath + "\\Assets";
            foreach (string asset in installedMod.assets)
            {
                this.FileDelete(assetsPath + "\\" + asset);
            }
            this.config.installedMods.Remove(installedMod);
            this.config.update();
        }

        private void updateMod(object sender, EventArgs e)
        {
            this.uninstallModWorker();
            this.installModWorker();
            this.getPage("ModSelection").getControl("UpdateModButton").Visible = false;
            this.getPage("ModSelection").getControl("InstallModButton").Visible = false;
            this.getPage("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Blue;
            this.getPage("ModSelection").getControl("UninstallModButton").Visible = true;
            MessageBox.Show(lg(46), lg(47), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void installMod(object sender, EventArgs e)
        {
            this.installModWorker();
            this.getPage("ModSelection").getControl("InstallModButton").Visible = false;
            this.getPage("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Blue;
            this.getPage("ModSelection").getControl("UninstallModButton").Visible = true;
            MessageBox.Show(lg(31), lg(32), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private async void installModWorker()
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show(lg(37), lg(38), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.config.containsMod(this.currentMod.id) == false)
            {
                this.getPage("ModSelection").getControl("InstallModButton").BackColor = System.Drawing.Color.Orange;

                this.installDependencies();

                string pluginsPath = this.config.amongUsPath + "\\BepInEx\\plugins";

                if (Directory.Exists(pluginsPath) == false)
                {
                    Directory.CreateDirectory(pluginsPath);
                }

                await this.GetGithubInfos(this.currentMod.author, this.currentMod.github);

                using (WebClient wc = new WebClient())
                {
                    foreach (ReleaseAsset tab in this.currentRelease.Assets)
                    {
                        string fileName = tab.Name;
                        if (fileName.Contains(".dll"))
                        {
                            this.installDll(this.currentRelease, tab);
                            return;
                        }
                    }
                    foreach (ReleaseAsset tab in this.currentRelease.Assets)
                    {
                        string fileName = tab.Name;
                        if (fileName.Contains(".zip"))
                        {
                            this.installZip(this.currentRelease, tab);
                            return;
                        }
                    }
                }
                return;
            }
        }

        private void installDll(Release jObject, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = jObject.TagName;
            string pluginsPath = this.config.amongUsPath + "\\BepInEx\\plugins";
            using (var client = new WebClient())
            {
                client.DownloadFile(fileUrl, pluginsPath + "\\" + fileName);
            }

            List<string> plugins = new List<string>();
            plugins.Add(fileName);
            InstalledMod newMod = new InstalledMod(this.currentMod.id, fileTag, new List<string>(), plugins);
            this.config.installedMods.Add(newMod);
            this.config.update();
            return;
        }

        private void installZip(Release jObject, ReleaseAsset file)
        {
            string fileName = file.Name;
            string fileUrl = file.BrowserDownloadUrl;
            string fileTag = jObject.TagName;
            string tempPath = Path.GetTempPath()+"\\ModManager";
            this.DirectoryDelete(tempPath);
            Directory.CreateDirectory(tempPath);
            string zipPath = tempPath + "\\" + fileName;
            using (var client = new WebClient())
            {
                client.DownloadFile(fileUrl, zipPath);
            }
            this.DirectoryDelete(tempPath + "\\BepInEx");
            this.DirectoryDelete(tempPath + "\\Assets");
            this.DirectoryDelete(tempPath + "\\mono");
            this.FileDelete(tempPath + "\\doorstop_config.ini");
            this.FileDelete(tempPath + "\\winhttp.dll");
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
                        File.Copy(f.FullName, this.config.amongUsPath+"\\BepInEx\\plugins\\"+f.Name);
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
                     File.Copy(f.FullName, this.config.amongUsPath + "\\Assets\\" + f.Name);
                    assets.Add(f.Name);
                }
            }
            InstalledMod newMod = new InstalledMod(this.currentMod.id, fileTag, assets, plugins);
            this.config.installedMods.Add(newMod);
            this.config.update();
            return;
        }

        private void removeMods(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                MessageBox.Show(lg(39), lg(40), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.deleteMods();

            Control installButton = this.getPage("ModSelection").getControl("InstallModButton");

            if (installButton != null)
            {
                installButton.Visible = true;
            }

            Control uninstallButton = this.getPage("ModSelection").getControl("UninstallModButton");

            if (uninstallButton != null)
            {
                uninstallButton.Visible = false;
            }

            MessageBox.Show(lg(27), lg(28), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteMods()
        {
            if (this.config != null)
            {
                if (this.config.amongUsPath != null)
                {

                    this.DirectoryDelete(this.config.amongUsPath + "\\BepInEx");
                    this.DirectoryDelete(this.config.amongUsPath + "\\Assets");
                    this.DirectoryDelete(this.config.amongUsPath + "\\mono");
                    this.FileDelete(this.config.amongUsPath + "\\doorstop_config.ini");
                    this.FileDelete(this.config.amongUsPath + "\\winhttp.dll");
                }
                if (this.config.installedDependencies != null) {
                    this.config.installedDependencies.Clear();
                }
                if (this.config.installedMods != null)
                {
                    this.config.installedMods.Clear();
                }
                this.config.update();

            }
        }

        private void updateFiles(object sender, EventArgs e)
        {
            if (this.pages != null)
            {
                this.getPage("ModSelection").getControl("UpdateFilesButton").BackColor = System.Drawing.Color.Orange;
            }

            this.updateFilesWorker();
            this.loadMods();

            if (this.pages != null)
            {
                this.getPage("ModSelection").getControl("UpdateFilesButton").BackColor = System.Drawing.Color.Purple;
                this.getPage("ModSelection").getControl("UpdateFilesButton").Visible = false;
                this.getPage("ModSelection").getControl("UpdateFilesLabel").Visible = false;
            }

            MessageBox.Show(lg(29), lg(30), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateFilesWorker()
        {
            
            string url = this.serverURL + "/files3.zip";
            string filesPath = this.appPath + "\\files";
            // Disable mods and clicks
            this.deleteMods();
            this.Update();

            DirectoryInfo fileMain = new DirectoryInfo(filesPath);
            if (fileMain.Exists == false)
            {
                Directory.CreateDirectory(filesPath);
            }

            // Download remote files.zip
            using (var client = new WebClient())
            {
                client.DownloadFile(url, filesPath + "\\files3.zip");
            }

            // Delete files
            DirectoryInfo directoryInfo = new DirectoryInfo(filesPath);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (file.Name != "files3.zip")
                {
                    file.Delete();
                }
            }
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                Directory.Delete(directory.FullName, recursive: true);
            }

            // Extract files.zip

            ZipFile.ExtractToDirectory(filesPath + "\\files3.zip", filesPath);
            this.FileDelete(filesPath + "\\files3.zip");

            //this.loadLanguages();


            //this.createPages();
            //this.renderPage("ModSelection");

            using (WebClient client = new WebClient())
            {
                string remoteVersion = client.DownloadString(this.serverURL + "/modsVersion.txt");
                string modsVersionPath = this.appDataPath + "\\modsVersion.txt";
                File.WriteAllText(modsVersionPath, remoteVersion);

            }

        }

        private void openSettings(object sender, EventArgs e)
        {
            this.renderPage("Settings");
        }

        private void backToMods(object sender, EventArgs e)
        {
            this.renderPage("ModSelection");
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
            FileInfo f = new FileInfo(this.appDataPath + "\\config3.conf");

            if (f.Exists)
            {
                string json = System.IO.File.ReadAllText(this.appDataPath + "\\config3.conf");
                Config temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(json);
                if (temp.lg == null)
                {
                    temp.lg = "US";
                }
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
            if (this.config != null && this.config.amongUsPath != null)
            {
                this.AmongUsSelectionPopup.SelectedPath = this.config.amongUsPath;
            }
            if (this.AmongUsSelectionPopup.ShowDialog() == DialogResult.OK)
            {
                FileInfo amongUsFile = new FileInfo(AmongUsSelectionPopup.SelectedPath + "\\Among Us.exe");
                if (amongUsFile.Exists)
                {
                    string lg = "EN";
                    if (this.config != null && this.config.lg != null)
                    {
                        lg = this.config.lg;
                    }
                    this.config = new Config(AmongUsSelectionPopup.SelectedPath, new List<InstalledMod>(), new List<string>(), lg, false);
                    this.config.update();

                    this.renderPage("ModSelection");
                }
            }
        }

        public void textChangedAmongUsPath(object sender, EventArgs e)
        {
            Control pathSelect = this.getPage("PathSelection").getControl("AmongUsPathSelection");
            FileInfo f = new FileInfo(pathSelect.Text+"\\Among Us.exe");
            if (f.Exists)
            {
                string lg = "EN";
                if (this.config != null && this.config.lg != null)
                {
                    lg = this.config.lg;
                } 
                this.config = new Config(pathSelect.Text, new List<InstalledMod>(), new List<string>(), lg, false);
                string json = JsonConvert.SerializeObject(this.config);
                File.WriteAllText(this.appDataPath + "\\config3.conf", json);

                this.renderPage("ModSelection");
            }
        }



        private void openAmongUsDirectory(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", this.config.amongUsPath);
        }

        private void openSkeldNet(object sender, EventArgs e)
        {
            this.deleteMods();
            string SkeldPath = this.appPath + "\\files\\servers\\SkeldLaunch.exe";
            System.Diagnostics.Process.Start(SkeldPath);
        }

        private void openCredits(object sender, EventArgs e)
        {
            this.renderPage("Credits");
        }

        private void backToDirectorySelection(object sender, EventArgs e)
        {
            this.renderPage("PathSelection");
        }

        private void launchGame(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                return;
            }

            string batpath = this.appPath + "\\openGame.bat";
            this.FileDelete(batpath);
            File.WriteAllText(batpath, "explorer.exe \""+this.config.amongUsPath+"\\Among Us.exe"+"\"");
            Process.Start(batpath);

            /*ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.LoadUserProfile = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = this.config.amongUsPath + "\\Among Us.exe";
            Process.Start(startInfo);*/
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
                if (!new FileInfo(tempPath).Exists)
                {
                    file.CopyTo(tempPath, false);
                }
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

        private void debug(string s)
        {
            MessageBox.Show(s, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
