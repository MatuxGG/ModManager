using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ModManager
{
    public class PageList
    {
        public List<Page> pages;

        public ModManager modManager;

        public PageList(ModManager modManager)
        {
            this.modManager = modManager;
            this.load();
        }

        public void load()
        {
            // Header

            this.modManager.VersionField.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

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
            AmongUsDirectoryLabel.Text = "Please select your Among Us directory";
            this.modManager.Controls.Add(AmongUsDirectoryLabel);
            p.addControl(AmongUsDirectoryLabel);

            Button AmongUsDirectorySelection = new System.Windows.Forms.Button();
            AmongUsDirectorySelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectorySelection.Location = new System.Drawing.Point(20, 150);
            AmongUsDirectorySelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirectorySelection.Name = "AmongUsDirectorySelection";
            AmongUsDirectorySelection.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectorySelection.TabIndex = 6;
            AmongUsDirectorySelection.Text = "Select directory";
            AmongUsDirectorySelection.Click += new EventHandler(this.modManager.chooseAmongUsDirectory);
            AmongUsDirectorySelection.UseVisualStyleBackColor = true;
            this.modManager.Controls.Add(AmongUsDirectorySelection);
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
            AmongUsPathLabel.Text = "Or enter Among Us directory path here (see steps on screenshots on the side)";
            this.modManager.Controls.Add(AmongUsPathLabel);
            p.addControl(AmongUsPathLabel);

            TextBox AmongUsPathSelection = new System.Windows.Forms.TextBox();
            AmongUsPathSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsPathSelection.Location = new System.Drawing.Point(20, 310);
            AmongUsPathSelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsPathSelection.Name = "AmongUsPathSelection";
            AmongUsPathSelection.Multiline = true;
            AmongUsPathSelection.Size = new System.Drawing.Size(400, 50);
            AmongUsPathSelection.TabIndex = 7;
            this.modManager.Controls.Add(AmongUsPathSelection);
            p.addControl(AmongUsPathSelection);

            Button AmongUsDirectoryConfirm = new System.Windows.Forms.Button();
            AmongUsDirectoryConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectoryConfirm.Location = new System.Drawing.Point(20, 380);
            AmongUsDirectoryConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirectoryConfirm.Name = "AmongUsDirectoryConfirm";
            AmongUsDirectoryConfirm.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectoryConfirm.TabIndex = 19;
            AmongUsDirectoryConfirm.Text = "Confirm directory";
            AmongUsDirectoryConfirm.Click += new EventHandler(this.textChangedAmongUsPath);
            AmongUsDirectoryConfirm.UseVisualStyleBackColor = true;
            this.modManager.Controls.Add(AmongUsDirectoryConfirm);
            p.addControl(AmongUsDirectoryConfirm);

            System.Windows.Forms.Label Step1Label = new System.Windows.Forms.Label();
            Step1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Step1Label.ForeColor = System.Drawing.SystemColors.Control;
            Step1Label.Location = new System.Drawing.Point(450, 70);
            Step1Label.Name = "Step1Label";
            Step1Label.Size = new System.Drawing.Size(450, 25);
            Step1Label.TabIndex = 28;
            Step1Label.Text = "Step 1 : Open steam and browse Among Us files";
            this.modManager.Controls.Add(Step1Label);
            p.addControl(Step1Label);

            PictureBox Step1Pic = new System.Windows.Forms.PictureBox();
            Step1Pic.Image = Properties.Resources.step1;
            Step1Pic.Location = new System.Drawing.Point(450, 80);
            Step1Pic.Name = "Step1Pic";
            Step1Pic.Size = new System.Drawing.Size(230, 160);
            Step1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Step1Pic.TabIndex = 26;
            Step1Pic.TabStop = false;
            this.modManager.Controls.Add(Step1Pic);
            p.addControl(Step1Pic);

            System.Windows.Forms.Label Step2Label = new System.Windows.Forms.Label();
            Step2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Step2Label.ForeColor = System.Drawing.SystemColors.Control;
            Step2Label.Location = new System.Drawing.Point(450, 250);
            Step2Label.Name = "Step2Label";
            Step2Label.Size = new System.Drawing.Size(450, 50);
            Step2Label.TabIndex = 29;
            Step2Label.Text = "Step 2 : In the opened window, copy Among Us address in Windows Explorer";
            this.modManager.Controls.Add(Step2Label);
            p.addControl(Step2Label);

            PictureBox Step2Pic = new System.Windows.Forms.PictureBox();
            Step2Pic.Image = Properties.Resources.step2;
            Step2Pic.Location = new System.Drawing.Point(430, 300);
            Step2Pic.Name = "Step2Pic";
            Step2Pic.Size = new System.Drawing.Size(450, 160);
            Step2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Step2Pic.TabIndex = 27;
            Step2Pic.TabStop = false;
            this.modManager.Controls.Add(Step2Pic);
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
            this.modManager.Controls.Add(SettingsPic);
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
            this.modManager.Controls.Add(ThanksPic);
            p.addControl(ThanksPic);

            Button RemoveModsButton = new System.Windows.Forms.Button();
            RemoveModsButton.BackColor = System.Drawing.Color.Red;
            RemoveModsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RemoveModsButton.Location = new System.Drawing.Point(20, 485);
            RemoveModsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            RemoveModsButton.Name = "RemoveModsButton";
            RemoveModsButton.Size = new System.Drawing.Size(197, 32);
            RemoveModsButton.TabIndex = 16;
            RemoveModsButton.Text = "Uninstall all mods";
            RemoveModsButton.Click += new EventHandler(this.modManager.modlist.uninstallMods);
            this.modManager.Controls.Add(RemoveModsButton);
            p.addControl(RemoveModsButton);

            Button PlayGameButton = new System.Windows.Forms.Button();
            PlayGameButton.BackColor = System.Drawing.Color.Lime;
            PlayGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PlayGameButton.Location = new System.Drawing.Point(250, 485);
            PlayGameButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            PlayGameButton.Name = "PlayGameButton";
            PlayGameButton.Size = new System.Drawing.Size(105, 32);
            PlayGameButton.Text = "Play";
            PlayGameButton.Click += new EventHandler(this.launchGame);
            this.modManager.Controls.Add(PlayGameButton);
            p.addControl(PlayGameButton);

            System.Windows.Forms.Label ModListLabel = new System.Windows.Forms.Label();
            ModListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModListLabel.ForeColor = System.Drawing.SystemColors.Control;
            ModListLabel.Location = new System.Drawing.Point(20, 85);
            ModListLabel.Name = "ModListLabel";
            ModListLabel.Size = new System.Drawing.Size(150, 50);
            ModListLabel.Text = "Mods available :";
            this.modManager.Controls.Add(ModListLabel);
            p.addControl(ModListLabel);

            ComboBox CatListCombo = new System.Windows.Forms.ComboBox();
            CatListCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CatListCombo.Location = new System.Drawing.Point(200, 80);
            CatListCombo.Name = "CatListCombo";
            CatListCombo.Size = new System.Drawing.Size(300, 50);
            CatListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            CatListCombo.SelectedIndexChanged += new EventHandler(this.modManager.modlist.changeCat);
            this.modManager.Controls.Add(CatListCombo);
            p.addControl(CatListCombo);

            ComboBox ModListCombo = new System.Windows.Forms.ComboBox();
            ModListCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModListCombo.Location = new System.Drawing.Point(550, 80);
            ModListCombo.Name = "ModListCombo";
            ModListCombo.Size = new System.Drawing.Size(300, 50);
            ModListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ModListCombo.SelectedIndexChanged += new EventHandler(this.modManager.modlist.changeMod);
            this.modManager.Controls.Add(ModListCombo);
            p.addControl(ModListCombo);

            System.Windows.Forms.Label AuthorTitle = new System.Windows.Forms.Label();
            AuthorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AuthorTitle.ForeColor = System.Drawing.SystemColors.Control;
            AuthorTitle.Location = new System.Drawing.Point(20, 130);
            AuthorTitle.Name = "AuthorTitle";
            AuthorTitle.Size = new System.Drawing.Size(150, 25);
            AuthorTitle.Text = "Author :";
            this.modManager.Controls.Add(AuthorTitle);
            p.addControl(AuthorTitle);

            System.Windows.Forms.Label AuthorLabel = new System.Windows.Forms.Label();
            AuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AuthorLabel.ForeColor = System.Drawing.SystemColors.Control;
            AuthorLabel.Location = new System.Drawing.Point(200, 130);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new System.Drawing.Size(500, 25);
            this.modManager.Controls.Add(AuthorLabel);
            p.addControl(AuthorLabel);

            System.Windows.Forms.Label VersionTitle = new System.Windows.Forms.Label();
            VersionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionTitle.ForeColor = System.Drawing.SystemColors.Control;
            VersionTitle.Location = new System.Drawing.Point(20, 160);
            VersionTitle.Name = "VersionTitle";
            VersionTitle.Size = new System.Drawing.Size(150, 25);
            VersionTitle.Text = "Version :";
            this.modManager.Controls.Add(VersionTitle);
            p.addControl(VersionTitle);

            System.Windows.Forms.Label VersionLabel = new System.Windows.Forms.Label();
            VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionLabel.ForeColor = System.Drawing.SystemColors.Control;
            VersionLabel.Location = new System.Drawing.Point(200, 160);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new System.Drawing.Size(500, 25);
            this.modManager.Controls.Add(VersionLabel);
            p.addControl(VersionLabel);

            System.Windows.Forms.Label GithubTitle = new System.Windows.Forms.Label();
            GithubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GithubTitle.ForeColor = System.Drawing.SystemColors.Control;
            GithubTitle.Location = new System.Drawing.Point(20, 190);
            GithubTitle.Name = "GithubTitle";
            GithubTitle.Size = new System.Drawing.Size(150, 25);
            GithubTitle.Text = "Github :";
            this.modManager.Controls.Add(GithubTitle);
            p.addControl(GithubTitle);

            LinkLabel GithubLabel = new System.Windows.Forms.LinkLabel();
            GithubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GithubLabel.ForeColor = System.Drawing.SystemColors.Control;
            GithubLabel.LinkColor = System.Drawing.SystemColors.Control;
            GithubLabel.Location = new System.Drawing.Point(200, 190);
            GithubLabel.Name = "GithubLabel";
            GithubLabel.Size = new System.Drawing.Size(500, 25);
            GithubLabel.Click += new EventHandler(this.openGithub);
            this.modManager.Controls.Add(GithubLabel);
            p.addControl(GithubLabel);

            System.Windows.Forms.Label DescriptionTitle = new System.Windows.Forms.Label();
            DescriptionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DescriptionTitle.ForeColor = System.Drawing.SystemColors.Control;
            DescriptionTitle.Location = new System.Drawing.Point(20, 220);
            DescriptionTitle.Name = "DescriptionTitle";
            DescriptionTitle.Size = new System.Drawing.Size(150, 25);
            DescriptionTitle.Text = "Description :";
            this.modManager.Controls.Add(DescriptionTitle);
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
            this.modManager.Controls.Add(DescriptionLabel);
            p.addControl(DescriptionLabel);

            Button InstallModButton = new System.Windows.Forms.Button();
            InstallModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InstallModButton.ForeColor = System.Drawing.SystemColors.Control;
            InstallModButton.Location = new System.Drawing.Point(20, 425);
            InstallModButton.Name = "InstallModButton";
            InstallModButton.Size = new System.Drawing.Size(150, 32);
            InstallModButton.Text = "Install mod";
            InstallModButton.BackColor = Color.Blue;
            InstallModButton.Click += new EventHandler(this.modManager.modlist.installMod);
            this.modManager.Controls.Add(InstallModButton);
            p.addControl(InstallModButton);

            Button UninstallModButton = new System.Windows.Forms.Button();
            UninstallModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModButton.ForeColor = System.Drawing.SystemColors.ControlText;
            UninstallModButton.Location = new System.Drawing.Point(20, 425);
            UninstallModButton.Name = "UninstallModButton";
            UninstallModButton.Size = new System.Drawing.Size(150, 32);
            UninstallModButton.Text = "Uninstall mod";
            UninstallModButton.BackColor = Color.Red;
            UninstallModButton.Click += new EventHandler(this.modManager.modlist.uninstallMod);
            this.modManager.Controls.Add(UninstallModButton);
            p.addControl(UninstallModButton);

            Button UpdateModButton = new System.Windows.Forms.Button();
            UpdateModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateModButton.Visible = false;
            UpdateModButton.ForeColor = System.Drawing.SystemColors.Control;
            UpdateModButton.Location = new System.Drawing.Point(220, 425);
            UpdateModButton.Name = "UpdateModButton";
            UpdateModButton.Size = new System.Drawing.Size(150, 32);
            UpdateModButton.Text = "Update mod";
            UpdateModButton.BackColor = Color.Purple;
            UpdateModButton.Click += new EventHandler(this.modManager.modlist.updateMod);
            this.modManager.Controls.Add(UpdateModButton);
            p.addControl(UpdateModButton);

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
            this.modManager.Controls.Add(BackPic);
            p.addControl(BackPic);

            System.Windows.Forms.Label SettingsTitle = new System.Windows.Forms.Label();
            SettingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            SettingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SettingsTitle.ForeColor = System.Drawing.SystemColors.Control;
            SettingsTitle.Location = new System.Drawing.Point(20, 80);
            SettingsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            SettingsTitle.Name = "SettingsTitle";
            SettingsTitle.Size = new System.Drawing.Size(920, 40);
            SettingsTitle.Text = "Settings";
            this.modManager.Controls.Add(SettingsTitle);
            p.addControl(SettingsTitle);

            System.Windows.Forms.Label AmongUsDirSwitchLabel = new System.Windows.Forms.Label();
            AmongUsDirSwitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsDirSwitchLabel.Location = new System.Drawing.Point(20, 130);
            AmongUsDirSwitchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AmongUsDirSwitchLabel.Name = "AmongUsDirSwitchLabel";
            AmongUsDirSwitchLabel.Size = new System.Drawing.Size(200, 20);
            AmongUsDirSwitchLabel.TabIndex = 12;
            AmongUsDirSwitchLabel.Text = "Among Us directory :";
            this.modManager.Controls.Add(AmongUsDirSwitchLabel);
            p.addControl(AmongUsDirSwitchLabel);

            Button AmongUsDirSwitchButton = new System.Windows.Forms.Button();
            AmongUsDirSwitchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchButton.Location = new System.Drawing.Point(250, 130);
            AmongUsDirSwitchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirSwitchButton.Name = "AmongUsDirSwitchButton";
            AmongUsDirSwitchButton.Size = new System.Drawing.Size(150, 30);
            AmongUsDirSwitchButton.TabIndex = 11;
            AmongUsDirSwitchButton.Text = "Change";
            AmongUsDirSwitchButton.UseVisualStyleBackColor = true;
            AmongUsDirSwitchButton.Click += new EventHandler(this.backToDirectorySelection);
            this.modManager.Controls.Add(AmongUsDirSwitchButton);
            p.addControl(AmongUsDirSwitchButton);

            Button OpenAmongUs = new System.Windows.Forms.Button();
            OpenAmongUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenAmongUs.Location = new System.Drawing.Point(450, 130);
            OpenAmongUs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            OpenAmongUs.Name = "OpenAmongUs";
            OpenAmongUs.Size = new System.Drawing.Size(150, 30);
            OpenAmongUs.TabIndex = 13;
            OpenAmongUs.Text = "Open";
            OpenAmongUs.UseVisualStyleBackColor = true;
            OpenAmongUs.Click += new EventHandler(this.openAmongUsDirectory);
            this.modManager.Controls.Add(OpenAmongUs);
            p.addControl(OpenAmongUs);

            System.Windows.Forms.Label TextureLabel = new System.Windows.Forms.Label();
            TextureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TextureLabel.ForeColor = System.Drawing.SystemColors.Control;
            TextureLabel.Location = new System.Drawing.Point(20, 180);
            TextureLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            TextureLabel.Name = "TextureLabel";
            TextureLabel.Size = new System.Drawing.Size(200, 20);
            TextureLabel.TabIndex = 12;
            TextureLabel.Text = "Texture pack :";
            this.modManager.Controls.Add(TextureLabel);
            p.addControl(TextureLabel);

            ComboBox TextureBox = new System.Windows.Forms.ComboBox();
            TextureBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TextureBox.Location = new System.Drawing.Point(250, 180);
            TextureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            TextureBox.Name = "TextureBox";
            TextureBox.Size = new System.Drawing.Size(150, 30);
            TextureBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TextureBox.SelectedIndexChanged += new EventHandler(this.modManager.textureList.changeTexture);
            this.modManager.Controls.Add(TextureBox);
            p.addControl(TextureBox);

            System.Windows.Forms.Label TextureWaitLabel = new System.Windows.Forms.Label();
            TextureWaitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TextureWaitLabel.ForeColor = System.Drawing.SystemColors.Control;
            TextureWaitLabel.Location = new System.Drawing.Point(450, 180);
            TextureWaitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            TextureWaitLabel.Name = "TextureWaitLabel";
            TextureWaitLabel.Size = new System.Drawing.Size(200, 20);
            TextureWaitLabel.TabIndex = 12;
            TextureWaitLabel.Text = "";
            this.modManager.Controls.Add(TextureWaitLabel);
            p.addControl(TextureWaitLabel);

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
            this.modManager.Controls.Add(BackPic);
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
            CreditsTitle.Text = "Credits";
            this.modManager.Controls.Add(CreditsTitle);
            p.addControl(CreditsTitle);

            System.Windows.Forms.Label Line1Label = new System.Windows.Forms.Label();
            Line1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line1Label.ForeColor = System.Drawing.SystemColors.Control;
            Line1Label.Location = new System.Drawing.Point(20, 130);
            Line1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line1Label.Name = "Line1Label";
            Line1Label.Size = new System.Drawing.Size(920, 30);
            Line1Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line1Label.Text = "Mod Manager was created by Matux.";
            this.modManager.Controls.Add(Line1Label);
            p.addControl(Line1Label);

            System.Windows.Forms.Label Line2Label = new System.Windows.Forms.Label();
            Line2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line2Label.ForeColor = System.Drawing.SystemColors.Control;
            Line2Label.Location = new System.Drawing.Point(20, 180);
            Line2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line2Label.Name = "Line2Label";
            Line2Label.Size = new System.Drawing.Size(920, 30);
            Line2Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line2Label.Text = "Big thanks to each mod creator. Each mod available in Mod Manager is the property of its respective creator.";
            this.modManager.Controls.Add(Line2Label);
            p.addControl(Line2Label);

            System.Windows.Forms.Label Line3Label = new System.Windows.Forms.Label();
            Line3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line3Label.ForeColor = System.Drawing.SystemColors.Control;
            Line3Label.Location = new System.Drawing.Point(20, 210);
            Line3Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line3Label.Name = "Line3Label";
            Line3Label.Size = new System.Drawing.Size(920, 30);
            Line3Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line3Label.Text = "On each mod, you have a link to the mod Github. Don't hesitate check their Github, star their mods or follow them !";
            this.modManager.Controls.Add(Line3Label);
            p.addControl(Line3Label);
            /*
            System.Windows.Forms.Label Line4Label = new System.Windows.Forms.Label();
            Line4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Line4Label.ForeColor = System.Drawing.SystemColors.Control;
            Line4Label.Location = new System.Drawing.Point(20, 240);
            Line4Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Line4Label.Name = "Line4Label";
            Line4Label.Size = new System.Drawing.Size(920, 30);
            Line4Label.BackColor = System.Drawing.SystemColors.ControlText;
            Line4Label.Text = "- Translators : Each translation is available thanks to translators from all around the world, good job !";
            this.modManager.Controls.Add(Line4Label);
            p.addControl(Line4Label);*/

            PictureBox MatuxGithubLabel = new System.Windows.Forms.PictureBox();
            MatuxGithubLabel.Image = Properties.Resources.github;
            MatuxGithubLabel.Location = new System.Drawing.Point(20, 490);
            MatuxGithubLabel.Name = "MatuxGithubLabel";
            MatuxGithubLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MatuxGithubLabel.TabStop = false;
            MatuxGithubLabel.Cursor = Cursors.Hand;
            MatuxGithubLabel.Size = new System.Drawing.Size(25, 25);
            MatuxGithubLabel.Click += new EventHandler(this.openMatuxGithub);
            this.modManager.Controls.Add(MatuxGithubLabel);
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
            this.modManager.Controls.Add(MMDiscordLabel);
            p.addControl(MMDiscordLabel);

            this.pages.Add(p);
        }

        public void renderPage(string page)
        {
            foreach (Page p in this.pages)
            {
                p.hide();
            }
            this.get(page).show();
            if (page == "PathSelection")
            {
                if (this.modManager.config != null && this.modManager.config.amongUsPath != null)
                {
                    this.get("PathSelection").getControl("AmongUsPathSelection").Text = this.modManager.config.amongUsPath;
                }
            }
            else if (page == "ModSelection")
            {
                this.modManager.modlist.load();
                this.modManager.modlist.changeModWorker();
            }
        }

        public Page get(string name)
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

        public void openGithub(object sender, EventArgs e)
        {
            LinkLabel clickedLink = ((LinkLabel)sender);
            string link = clickedLink.Text;
            System.Diagnostics.Process.Start(link);
        }

        public void openMatuxGithub(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MatuxGG/ModManager");
        }

        public void openMMDiscord(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/yBNgKuGjNw");
        }

        public void textChangedAmongUsPath(object sender, EventArgs e)
        {
            Control pathSelect = this.get("PathSelection").getControl("AmongUsPathSelection");
            FileInfo f = new FileInfo(pathSelect.Text + "\\Among Us.exe");
            if (f.Exists)
            {
                this.modManager.config = new Config(pathSelect.Text, new List<InstalledMod>(), new List<string>(), "None");
                string json = JsonConvert.SerializeObject(this.modManager.config);
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\config3.conf", json);

                this.renderPage("ModSelection");
            }
        }
        
        public void openAmongUsDirectory(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", this.modManager.config.amongUsPath);
        }

        public void openCredits(object sender, EventArgs e)
        {
            this.renderPage("Credits");
        }

        public void backToDirectorySelection(object sender, EventArgs e)
        {
            this.renderPage("PathSelection");
        }

        public void launchGame(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                return;
            }

            string batpath = this.modManager.appPath + "\\openGame.cmd";
            this.modManager.utils.FileDelete(batpath);
            File.WriteAllText(batpath, "explorer.exe \"" + this.modManager.config.amongUsPath + "\\Among Us.exe" + "\"");
            Process.Start(batpath);
            
        }

        public void openSettings(object sender, EventArgs e)
        {
            this.renderPage("Settings");
        }

        public void backToMods(object sender, EventArgs e)
        {
            this.renderPage("ModSelection");
        }
       
    }
}