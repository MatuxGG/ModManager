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

            System.Windows.Forms.Label separator3 = new System.Windows.Forms.Label();
            separator3.Location = new System.Drawing.Point(370, 0);
            separator3.Name = "separator3";
            separator3.BorderStyle = BorderStyle.FixedSingle;
            separator3.BackColor = System.Drawing.SystemColors.Control;
            separator3.Size = new System.Drawing.Size(4, 63);
            this.modManager.Controls.Add(separator3);

            PictureBox ModListButton = new System.Windows.Forms.PictureBox();
            ModListButton.Image = global::ModManager.Properties.Resources.list;
            ModListButton.Location = new System.Drawing.Point(390, 15);
            ModListButton.Name = "ModListButton";
            ModListButton.Size = new System.Drawing.Size(32, 32);
            ModListButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ModListButton.TabStop = false;
            ModListButton.Cursor = Cursors.Hand;
            ModListButton.Click += new EventHandler(this.backToMods);
            this.modManager.Controls.Add(ModListButton);

            System.Windows.Forms.Label ModListText = new System.Windows.Forms.Label();
            ModListText.TextAlign = ContentAlignment.MiddleRight;
            ModListText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModListText.ForeColor = System.Drawing.SystemColors.Control;
            ModListText.Location = new System.Drawing.Point(390, 8);
            ModListText.Name = "ModListText";
            ModListText.Size = new System.Drawing.Size(85, 50);
            ModListText.Text = "Mods";
            ModListText.Cursor = Cursors.Hand;
            ModListText.Click += new EventHandler(this.backToMods);
            this.modManager.Controls.Add(ModListText);

            System.Windows.Forms.Label separator4 = new System.Windows.Forms.Label();
            separator4.Location = new System.Drawing.Point(485, 0);
            separator4.Name = "separator4";
            separator4.BorderStyle = BorderStyle.FixedSingle;
            separator4.BackColor = System.Drawing.SystemColors.Control;
            separator4.Size = new System.Drawing.Size(4, 63);
            this.modManager.Controls.Add(separator4);

            PictureBox InstalledModsButton = new System.Windows.Forms.PictureBox();
            InstalledModsButton.Image = global::ModManager.Properties.Resources.local;
            InstalledModsButton.Location = new System.Drawing.Point(505, 15);
            InstalledModsButton.Name = "InstalledModsButton";
            InstalledModsButton.Size = new System.Drawing.Size(32, 32);
            InstalledModsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            InstalledModsButton.TabStop = false;
            InstalledModsButton.Cursor = Cursors.Hand;
            InstalledModsButton.Click += new EventHandler(this.openInstalled);
            this.modManager.Controls.Add(InstalledModsButton);

            System.Windows.Forms.Label InstalledModsLabel = new System.Windows.Forms.Label();
            InstalledModsLabel.TextAlign = ContentAlignment.MiddleRight;
            InstalledModsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InstalledModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            InstalledModsLabel.Location = new System.Drawing.Point(505, 8);
            InstalledModsLabel.Name = "InstalledModsLabel";
            InstalledModsLabel.Size = new System.Drawing.Size(105, 50);
            InstalledModsLabel.Text = "Installed";
            InstalledModsLabel.Cursor = Cursors.Hand;
            InstalledModsLabel.Click += new EventHandler(this.openInstalled);
            this.modManager.Controls.Add(InstalledModsLabel);

            System.Windows.Forms.Label separator5 = new System.Windows.Forms.Label();
            separator5.Location = new System.Drawing.Point(620, 0);
            separator5.Name = "separator5";
            separator5.BorderStyle = BorderStyle.FixedSingle;
            separator5.BackColor = System.Drawing.SystemColors.Control;
            separator5.Size = new System.Drawing.Size(4, 63);
            this.modManager.Controls.Add(separator5);

            PictureBox TextureListButton = new System.Windows.Forms.PictureBox();
            TextureListButton.Image = global::ModManager.Properties.Resources.art;
            TextureListButton.Location = new System.Drawing.Point(640, 15);
            TextureListButton.Name = "TextureListButton";
            TextureListButton.Size = new System.Drawing.Size(32, 32);
            TextureListButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            TextureListButton.TabStop = false;
            TextureListButton.Cursor = Cursors.Hand;
            TextureListButton.Click += new EventHandler(this.openTextures);
            this.modManager.Controls.Add(TextureListButton);

            System.Windows.Forms.Label TextureListLabel = new System.Windows.Forms.Label();
            TextureListLabel.TextAlign = ContentAlignment.MiddleRight;
            TextureListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TextureListLabel.ForeColor = System.Drawing.SystemColors.Control;
            TextureListLabel.Location = new System.Drawing.Point(640, 8);
            TextureListLabel.Name = "TextureListLabel";
            TextureListLabel.Size = new System.Drawing.Size(110, 50);
            TextureListLabel.Text = "Textures";
            TextureListLabel.Cursor = Cursors.Hand;
            TextureListLabel.Click += new EventHandler(this.openTextures);
            this.modManager.Controls.Add(TextureListLabel);

            System.Windows.Forms.Label separator9 = new System.Windows.Forms.Label();
            separator9.Location = new System.Drawing.Point(760, 0);
            separator9.Name = "separator3";
            separator9.BorderStyle = BorderStyle.FixedSingle;
            separator9.BackColor = System.Drawing.SystemColors.Control;
            separator9.Size = new System.Drawing.Size(4, 63);
            this.modManager.Controls.Add(separator9);

            PictureBox ServerListPic = new System.Windows.Forms.PictureBox();
            ServerListPic.Image = global::ModManager.Properties.Resources.list;
            ServerListPic.Location = new System.Drawing.Point(780, 15);
            ServerListPic.Name = "ServerListPic";
            ServerListPic.Size = new System.Drawing.Size(32, 32);
            ServerListPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ServerListPic.TabStop = false;
            ServerListPic.Cursor = Cursors.Hand;
            ServerListPic.Click += new EventHandler(this.openServers);
            this.modManager.Controls.Add(ServerListPic);

            System.Windows.Forms.Label ServerListLabel = new System.Windows.Forms.Label();
            ServerListLabel.TextAlign = ContentAlignment.MiddleRight;
            ServerListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerListLabel.ForeColor = System.Drawing.SystemColors.Control;
            ServerListLabel.Location = new System.Drawing.Point(780, 8);
            ServerListLabel.Name = "ServerListLabel";
            ServerListLabel.Size = new System.Drawing.Size(100, 50);
            ServerListLabel.Text = "Servers";
            ServerListLabel.Cursor = Cursors.Hand;
            ServerListLabel.Click += new EventHandler(this.openServers);
            this.modManager.Controls.Add(ServerListLabel);

            System.Windows.Forms.Label separator6 = new System.Windows.Forms.Label();
            separator6.Location = new System.Drawing.Point(890, 0);
            separator6.Name = "separator6";
            separator6.BorderStyle = BorderStyle.FixedSingle;
            separator6.BackColor = System.Drawing.SystemColors.Control;
            separator6.Size = new System.Drawing.Size(4, 63);
            this.modManager.Controls.Add(separator6);

            PictureBox AnnouncePic = new System.Windows.Forms.PictureBox();
            AnnouncePic.Image = global::ModManager.Properties.Resources.announce;
            AnnouncePic.Location = new System.Drawing.Point(910, 15);
            AnnouncePic.Name = "AnnouncePic";
            AnnouncePic.Size = new System.Drawing.Size(32, 32);
            AnnouncePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            AnnouncePic.TabStop = false;
            AnnouncePic.Cursor = Cursors.Hand;
            AnnouncePic.Click += new EventHandler(this.openAnnounce);
            this.modManager.Controls.Add(AnnouncePic);

            System.Windows.Forms.Label AnnounceLabel = new System.Windows.Forms.Label();
            AnnounceLabel.TextAlign = ContentAlignment.MiddleRight;
            AnnounceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AnnounceLabel.ForeColor = System.Drawing.SystemColors.Control;
            AnnounceLabel.Location = new System.Drawing.Point(910, 8);
            AnnounceLabel.Name = "AnnounceLabel";
            AnnounceLabel.Size = new System.Drawing.Size(90, 50);
            AnnounceLabel.Text = "News";
            AnnounceLabel.Cursor = Cursors.Hand;
            AnnounceLabel.Click += new EventHandler(this.openAnnounce);
            this.modManager.Controls.Add(AnnounceLabel);

            System.Windows.Forms.Label separator7 = new System.Windows.Forms.Label();
            separator7.Location = new System.Drawing.Point(1010, 0);
            separator7.Name = "separator7";
            separator7.BorderStyle = BorderStyle.FixedSingle;
            separator7.BackColor = System.Drawing.SystemColors.Control;
            separator7.Size = new System.Drawing.Size(4, 63);
            this.modManager.Controls.Add(separator7);

            PictureBox SettingsPic = new System.Windows.Forms.PictureBox();
            SettingsPic.Image = global::ModManager.Properties.Resources.settings;
            SettingsPic.Location = new System.Drawing.Point(1030, 15);
            SettingsPic.Name = "SettingsPic";
            SettingsPic.Size = new System.Drawing.Size(32, 32);
            SettingsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            SettingsPic.TabStop = false;
            SettingsPic.Cursor = Cursors.Hand;
            SettingsPic.Click += new EventHandler(this.openSettings);
            this.modManager.Controls.Add(SettingsPic);

            System.Windows.Forms.Label SettingsLabel = new System.Windows.Forms.Label();
            SettingsLabel.TextAlign = ContentAlignment.MiddleRight;
            SettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SettingsLabel.ForeColor = System.Drawing.SystemColors.Control;
            SettingsLabel.Location = new System.Drawing.Point(1030, 8);
            SettingsLabel.Name = "SettingsLabel";
            SettingsLabel.Size = new System.Drawing.Size(110, 50);
            SettingsLabel.Text = "Settings";
            SettingsLabel.Cursor = Cursors.Hand;
            SettingsLabel.Click += new EventHandler(this.openSettings);
            this.modManager.Controls.Add(SettingsLabel);

            System.Windows.Forms.Label separator8 = new System.Windows.Forms.Label();
            separator8.Location = new System.Drawing.Point(1150, 0);
            separator8.Name = "separator8";
            separator8.BorderStyle = BorderStyle.FixedSingle;
            separator8.BackColor = System.Drawing.SystemColors.Control;
            separator8.Size = new System.Drawing.Size(4, 63);
            this.modManager.Controls.Add(separator8);

            PictureBox ThanksPic = new System.Windows.Forms.PictureBox();
            ThanksPic.Image = global::ModManager.Properties.Resources.thanks;
            ThanksPic.Location = new System.Drawing.Point(1170, 15);
            ThanksPic.Name = "ThanksPic";
            ThanksPic.Size = new System.Drawing.Size(32, 32);
            ThanksPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ThanksPic.TabStop = false;
            ThanksPic.Cursor = Cursors.Hand;
            ThanksPic.Click += new EventHandler(this.openCredits);
            this.modManager.Controls.Add(ThanksPic);

            System.Windows.Forms.Label ThanksLabel = new System.Windows.Forms.Label();
            ThanksLabel.TextAlign = ContentAlignment.MiddleRight;
            ThanksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ThanksLabel.ForeColor = System.Drawing.SystemColors.Control;
            ThanksLabel.Location = new System.Drawing.Point(1170, 8);
            ThanksLabel.Name = "ThanksLabel";
            ThanksLabel.Size = new System.Drawing.Size(100, 50);
            ThanksLabel.Text = "Credits";
            ThanksLabel.Cursor = Cursors.Hand;
            ThanksLabel.Click += new EventHandler(this.openCredits);
            this.modManager.Controls.Add(ThanksLabel);

            // Footer

            PictureBox PlayGameButton = new System.Windows.Forms.PictureBox();
            PlayGameButton.Image = global::ModManager.Properties.Resources.play;
            PlayGameButton.Location = new System.Drawing.Point(20, 620);
            PlayGameButton.Name = "PlayGameButton";
            PlayGameButton.Size = new System.Drawing.Size(32, 32);
            PlayGameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PlayGameButton.TabStop = false;
            PlayGameButton.Cursor = Cursors.Hand;
            PlayGameButton.Click += new EventHandler(this.launchGame);
            this.modManager.Controls.Add(PlayGameButton);

            System.Windows.Forms.Label PlayGameLabel = new System.Windows.Forms.Label();
            PlayGameLabel.TextAlign = ContentAlignment.MiddleLeft;
            PlayGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PlayGameLabel.ForeColor = System.Drawing.SystemColors.Control;
            PlayGameLabel.Location = new System.Drawing.Point(50, 610);
            PlayGameLabel.Name = "PlayGameLabel";
            PlayGameLabel.Size = new System.Drawing.Size(200, 50);
            PlayGameLabel.Text = "Launch the game";
            PlayGameLabel.Cursor = Cursors.Hand;
            PlayGameLabel.Click += new EventHandler(this.launchGame);
            this.modManager.Controls.Add(PlayGameLabel);

            PictureBox MatuxGithubLabel = new System.Windows.Forms.PictureBox();
            MatuxGithubLabel.Image = Properties.Resources.github;
            MatuxGithubLabel.Location = new System.Drawing.Point(1050, 625);
            MatuxGithubLabel.Name = "MatuxGithubLabel";
            MatuxGithubLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MatuxGithubLabel.TabStop = false;
            MatuxGithubLabel.Cursor = Cursors.Hand;
            MatuxGithubLabel.Size = new System.Drawing.Size(25, 25);
            MatuxGithubLabel.Click += new EventHandler(this.openMatuxGithub);
            this.modManager.Controls.Add(MatuxGithubLabel);

            PictureBox MMDiscordLabel = new System.Windows.Forms.PictureBox();
            MMDiscordLabel.Image = Properties.Resources.discord;
            MMDiscordLabel.Location = new System.Drawing.Point(1100, 625);
            MMDiscordLabel.Name = "MMDiscordLabel";
            MMDiscordLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MMDiscordLabel.TabStop = false;
            MMDiscordLabel.Cursor = Cursors.Hand;
            MMDiscordLabel.Size = new System.Drawing.Size(25, 25);
            MMDiscordLabel.Click += new EventHandler(this.openMMDiscord);
            this.modManager.Controls.Add(MMDiscordLabel);

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
            AmongUsDirectoryLabel.TabStop = false;
            AmongUsDirectoryLabel.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectoryLabel.Text = "Please select your Among Us directory";
            this.modManager.Controls.Add(AmongUsDirectoryLabel);
            p.addControl(AmongUsDirectoryLabel);

            Button AmongUsDirectorySelection = new System.Windows.Forms.Button();
            AmongUsDirectorySelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectorySelection.Location = new System.Drawing.Point(20, 150);
            AmongUsDirectorySelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirectorySelection.Name = "AmongUsDirectorySelection";
            AmongUsDirectorySelection.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectorySelection.Text = "Select directory";
            AmongUsDirectorySelection.TabStop = false;
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
            AmongUsPathLabel.TabStop = false;
            AmongUsPathLabel.Size = new System.Drawing.Size(400, 50);
            AmongUsPathLabel.Text = "Or enter Among Us directory path here (see steps on screenshots on the side)";
            this.modManager.Controls.Add(AmongUsPathLabel);
            p.addControl(AmongUsPathLabel);

            TextBox AmongUsPathSelection = new System.Windows.Forms.TextBox();
            AmongUsPathSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsPathSelection.Location = new System.Drawing.Point(20, 310);
            AmongUsPathSelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsPathSelection.Name = "AmongUsPathSelection";
            AmongUsPathSelection.Multiline = true;
            AmongUsPathSelection.TabStop = false;
            AmongUsPathSelection.Size = new System.Drawing.Size(400, 50);
            this.modManager.Controls.Add(AmongUsPathSelection);
            p.addControl(AmongUsPathSelection);

            Button AmongUsDirectoryConfirm = new System.Windows.Forms.Button();
            AmongUsDirectoryConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectoryConfirm.Location = new System.Drawing.Point(20, 380);
            AmongUsDirectoryConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirectoryConfirm.Name = "AmongUsDirectoryConfirm";
            AmongUsDirectoryConfirm.Size = new System.Drawing.Size(400, 50);
            AmongUsDirectoryConfirm.Text = "Confirm directory";
            AmongUsDirectoryConfirm.TabStop = false;
            AmongUsDirectoryConfirm.Click += new EventHandler(this.textChangedAmongUsPath);
            AmongUsDirectoryConfirm.UseVisualStyleBackColor = true;
            this.modManager.Controls.Add(AmongUsDirectoryConfirm);
            p.addControl(AmongUsDirectoryConfirm);

            System.Windows.Forms.Label Step1Label = new System.Windows.Forms.Label();
            Step1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Step1Label.ForeColor = System.Drawing.SystemColors.Control;
            Step1Label.Location = new System.Drawing.Point(450, 90);
            Step1Label.Name = "Step1Label";
            Step1Label.Size = new System.Drawing.Size(800, 25);
            Step1Label.Text = "Step 1 : Open steam and browse Among Us files";
            this.modManager.Controls.Add(Step1Label);
            p.addControl(Step1Label);

            PictureBox Step1Pic = new System.Windows.Forms.PictureBox();
            Step1Pic.Image = Properties.Resources.step1;
            Step1Pic.Location = new System.Drawing.Point(365, 120);
            Step1Pic.Name = "Step1Pic";
            Step1Pic.Size = new System.Drawing.Size(600, 200);
            Step1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Step1Pic.TabStop = false;
            this.modManager.Controls.Add(Step1Pic);
            p.addControl(Step1Pic);

            System.Windows.Forms.Label Step2Label = new System.Windows.Forms.Label();
            Step2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Step2Label.ForeColor = System.Drawing.SystemColors.Control;
            Step2Label.Location = new System.Drawing.Point(450, 330);
            Step2Label.Name = "Step2Label";
            Step2Label.Size = new System.Drawing.Size(800, 25);
            Step2Label.Text = "Step 2 : In the opened window, copy Among Us address in Windows Explorer";
            this.modManager.Controls.Add(Step2Label);
            p.addControl(Step2Label);

            PictureBox Step2Pic = new System.Windows.Forms.PictureBox();
            Step2Pic.Image = Properties.Resources.step2;
            Step2Pic.Location = new System.Drawing.Point(400, 360);
            Step2Pic.Name = "Step2Pic";
            Step2Pic.Size = new System.Drawing.Size(800, 230);
            Step2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Step2Pic.TabStop = false;
            this.modManager.Controls.Add(Step2Pic);
            p.addControl(Step2Pic);

            this.pages.Add(p);

            // Mod Selection
            p = new Page("ModSelection");

            System.Windows.Forms.Label ModsTitle = new System.Windows.Forms.Label();
            ModsTitle.TextAlign = ContentAlignment.MiddleCenter;
            ModsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModsTitle.ForeColor = System.Drawing.SystemColors.Control;
            ModsTitle.Location = new System.Drawing.Point(20, 80);
            ModsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ModsTitle.Name = "ModsTitle";
            ModsTitle.Size = new System.Drawing.Size(1245, 40);
            ModsTitle.Text = "Available mods";
            this.modManager.Controls.Add(ModsTitle);
            p.addControl(ModsTitle);

            System.Windows.Forms.Label CatListLabel = new System.Windows.Forms.Label();
            CatListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CatListLabel.ForeColor = System.Drawing.SystemColors.Control;
            CatListLabel.Location = new System.Drawing.Point(20, 135);
            CatListLabel.Name = "CatListLabel";
            CatListLabel.Size = new System.Drawing.Size(150, 30);
            CatListLabel.Text = "Category :";
            this.modManager.Controls.Add(CatListLabel);
            p.addControl(CatListLabel);

            ComboBox CatListCombo = new System.Windows.Forms.ComboBox();
            CatListCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CatListCombo.Location = new System.Drawing.Point(200, 130);
            CatListCombo.Name = "CatListCombo";
            CatListCombo.Size = new System.Drawing.Size(300, 30);
            CatListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            CatListCombo.SelectedIndexChanged += new EventHandler(this.modManager.modlist.changeCat);
            CatListCombo.TabStop = false;
            this.modManager.Controls.Add(CatListCombo);
            p.addControl(CatListCombo);

            System.Windows.Forms.Label ModListLabel = new System.Windows.Forms.Label();
            ModListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModListLabel.ForeColor = System.Drawing.SystemColors.Control;
            ModListLabel.Location = new System.Drawing.Point(620, 135);
            ModListLabel.Name = "ModListLabel";
            ModListLabel.Size = new System.Drawing.Size(150, 30);
            ModListLabel.Text = "Available mods :";
            this.modManager.Controls.Add(ModListLabel);
            p.addControl(ModListLabel);

            ComboBox ModListCombo = new System.Windows.Forms.ComboBox();
            ModListCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModListCombo.Location = new System.Drawing.Point(800, 130);
            ModListCombo.Name = "ModListCombo";
            ModListCombo.Size = new System.Drawing.Size(300, 30);
            ModListCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            ModListCombo.SelectedIndexChanged += new EventHandler(this.modManager.modlist.changeMod);
            ModListCombo.TabStop = false;
            this.modManager.Controls.Add(ModListCombo);
            p.addControl(ModListCombo);

            System.Windows.Forms.Label AuthorTitle = new System.Windows.Forms.Label();
            AuthorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AuthorTitle.ForeColor = System.Drawing.SystemColors.Control;
            AuthorTitle.Location = new System.Drawing.Point(20, 170);
            AuthorTitle.Name = "AuthorTitle";
            AuthorTitle.Size = new System.Drawing.Size(150, 25);
            AuthorTitle.Text = "Author :";
            this.modManager.Controls.Add(AuthorTitle);
            p.addControl(AuthorTitle);

            System.Windows.Forms.Label AuthorLabel = new System.Windows.Forms.Label();
            AuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AuthorLabel.ForeColor = System.Drawing.SystemColors.Control;
            AuthorLabel.Location = new System.Drawing.Point(200, 170);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new System.Drawing.Size(500, 25);
            this.modManager.Controls.Add(AuthorLabel);
            p.addControl(AuthorLabel);

            System.Windows.Forms.Label VersionTitle = new System.Windows.Forms.Label();
            VersionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionTitle.ForeColor = System.Drawing.SystemColors.Control;
            VersionTitle.Location = new System.Drawing.Point(20, 200);
            VersionTitle.Name = "VersionTitle";
            VersionTitle.Size = new System.Drawing.Size(150, 25);
            VersionTitle.Text = "Version :";
            this.modManager.Controls.Add(VersionTitle);
            p.addControl(VersionTitle);

            System.Windows.Forms.Label VersionLabel = new System.Windows.Forms.Label();
            VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionLabel.ForeColor = System.Drawing.SystemColors.Control;
            VersionLabel.Location = new System.Drawing.Point(200, 200);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new System.Drawing.Size(200, 25);
            this.modManager.Controls.Add(VersionLabel);
            p.addControl(VersionLabel);

            /*System.Windows.Forms.Label GameVersionTitle = new System.Windows.Forms.Label();
            GameVersionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GameVersionTitle.ForeColor = System.Drawing.SystemColors.Control;
            GameVersionTitle.Location = new System.Drawing.Point(620, 160);
            GameVersionTitle.Name = "GameVersionTitle";
            GameVersionTitle.Size = new System.Drawing.Size(150, 25);
            GameVersionTitle.Text = "Game version :";
            this.modManager.Controls.Add(GameVersionTitle);
            p.addControl(GameVersionTitle);*/

            System.Windows.Forms.Label GameVersionLabel = new System.Windows.Forms.Label();
            GameVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GameVersionLabel.ForeColor = System.Drawing.SystemColors.Control;
            GameVersionLabel.Location = new System.Drawing.Point(800, 200);
            GameVersionLabel.Name = "GameVersionLabel";
            GameVersionLabel.Size = new System.Drawing.Size(200, 25);
            this.modManager.Controls.Add(GameVersionLabel);
            p.addControl(GameVersionLabel);

            System.Windows.Forms.Label GithubTitle = new System.Windows.Forms.Label();
            GithubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GithubTitle.ForeColor = System.Drawing.SystemColors.Control;
            GithubTitle.Location = new System.Drawing.Point(20, 230);
            GithubTitle.Name = "GithubTitle";
            GithubTitle.Size = new System.Drawing.Size(150, 25);
            GithubTitle.Text = "Github :";
            this.modManager.Controls.Add(GithubTitle);
            p.addControl(GithubTitle);

            LinkLabel GithubLabel = new System.Windows.Forms.LinkLabel();
            GithubLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GithubLabel.ForeColor = System.Drawing.SystemColors.Control;
            GithubLabel.LinkColor = System.Drawing.SystemColors.Control;
            GithubLabel.Location = new System.Drawing.Point(200, 230);
            GithubLabel.Name = "GithubLabel";
            GithubLabel.Size = new System.Drawing.Size(500, 25);
            GithubLabel.TabStop = false;
            GithubLabel.Click += new EventHandler(this.openGithub);
            this.modManager.Controls.Add(GithubLabel);
            p.addControl(GithubLabel);

            TextBox DescriptionLabel = new System.Windows.Forms.TextBox();
            DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DescriptionLabel.ForeColor = System.Drawing.SystemColors.Control;
            DescriptionLabel.BackColor = System.Drawing.SystemColors.WindowText;
            DescriptionLabel.BorderStyle = BorderStyle.FixedSingle;
            DescriptionLabel.Location = new System.Drawing.Point(20, 260);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new System.Drawing.Size(1245, 300);
            DescriptionLabel.ScrollBars = ScrollBars.Vertical;
            DescriptionLabel.Multiline = true;
            DescriptionLabel.WordWrap = true;
            DescriptionLabel.ReadOnly = true;
            DescriptionLabel.TabStop = false;
            DescriptionLabel.Cursor = Cursors.Arrow;
            DescriptionLabel.Text = "";
            this.modManager.Controls.Add(DescriptionLabel);
            p.addControl(DescriptionLabel);

            PictureBox RemoveModsPic = new System.Windows.Forms.PictureBox();
            RemoveModsPic.Image = global::ModManager.Properties.Resources.uninstallAll;
            RemoveModsPic.Location = new System.Drawing.Point(20, 565);
            RemoveModsPic.Name = "RemoveModsPic";
            RemoveModsPic.Size = new System.Drawing.Size(32, 32);
            RemoveModsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            RemoveModsPic.TabStop = false;
            RemoveModsPic.Cursor = Cursors.Hand;
            RemoveModsPic.Click += new EventHandler(this.modManager.modlist.uninstallMods);
            this.modManager.Controls.Add(RemoveModsPic);
            p.addControl(RemoveModsPic);

            Label RemoveModsButton = new System.Windows.Forms.Label();
            RemoveModsButton.TextAlign = ContentAlignment.MiddleRight;
            RemoveModsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RemoveModsButton.Location = new System.Drawing.Point(20, 567);
            RemoveModsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            RemoveModsButton.Name = "RemoveModsButton";
            RemoveModsButton.ForeColor = System.Drawing.SystemColors.Control;
            RemoveModsButton.TabStop = false;
            RemoveModsButton.Cursor = Cursors.Hand;
            RemoveModsButton.Size = new System.Drawing.Size(130, 32);
            RemoveModsButton.Text = "Uninstall all";
            RemoveModsButton.ForeColor = System.Drawing.Color.Red;
            RemoveModsButton.Click += new EventHandler(this.modManager.modlist.uninstallMods);
            this.modManager.Controls.Add(RemoveModsButton);
            p.addControl(RemoveModsButton);

            PictureBox InstallModPic = new System.Windows.Forms.PictureBox();
            InstallModPic.Image = global::ModManager.Properties.Resources.install;
            InstallModPic.Location = new System.Drawing.Point(170, 565);
            InstallModPic.Name = "InstallModPic";
            InstallModPic.Size = new System.Drawing.Size(32, 32);
            InstallModPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            InstallModPic.TabStop = false;
            InstallModPic.Cursor = Cursors.Hand;
            InstallModPic.Click += new EventHandler(this.modManager.modlist.uninstallMods);
            this.modManager.Controls.Add(InstallModPic);
            p.addControl(InstallModPic);

            Label InstallModButton = new System.Windows.Forms.Label();
            InstallModButton.TextAlign = ContentAlignment.MiddleRight;
            InstallModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InstallModButton.ForeColor = System.Drawing.SystemColors.Control;
            InstallModButton.Location = new System.Drawing.Point(170, 567);
            InstallModButton.Name = "InstallModButton";
            InstallModButton.Size = new System.Drawing.Size(85, 32);
            InstallModButton.Text = "Install";
            InstallModButton.TabStop = false;
            InstallModButton.Cursor = Cursors.Hand;
            InstallModButton.Click += new EventHandler(this.modManager.modlist.installMod);
            this.modManager.Controls.Add(InstallModButton);
            p.addControl(InstallModButton);

            PictureBox UninstallModPic = new System.Windows.Forms.PictureBox();
            UninstallModPic.Image = global::ModManager.Properties.Resources.uninstall;
            UninstallModPic.Location = new System.Drawing.Point(170, 565);
            UninstallModPic.Name = "UninstallModPic";
            UninstallModPic.Size = new System.Drawing.Size(32, 32);
            UninstallModPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            UninstallModPic.TabStop = false;
            UninstallModPic.Cursor = Cursors.Hand;
            UninstallModPic.Click += new EventHandler(this.modManager.modlist.uninstallMods);
            this.modManager.Controls.Add(UninstallModPic);
            p.addControl(UninstallModPic);

            Label UninstallModButton = new System.Windows.Forms.Label();
            UninstallModButton.TextAlign = ContentAlignment.MiddleRight;
            UninstallModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModButton.ForeColor = System.Drawing.SystemColors.Control;
            UninstallModButton.Location = new System.Drawing.Point(170, 567);
            UninstallModButton.Name = "UninstallModButton";
            UninstallModButton.Size = new System.Drawing.Size(115, 32);
            UninstallModButton.TabStop = false;
            UninstallModButton.Cursor = Cursors.Hand;
            UninstallModButton.Text = "Uninstall";
            UninstallModButton.Click += new EventHandler(this.modManager.modlist.uninstallMod);
            this.modManager.Controls.Add(UninstallModButton);
            p.addControl(UninstallModButton);

            PictureBox UpdateModPic = new System.Windows.Forms.PictureBox();
            UpdateModPic.Image = global::ModManager.Properties.Resources.update;
            UpdateModPic.Location = new System.Drawing.Point(300, 565);
            UpdateModPic.Name = "UpdateModPic";
            UpdateModPic.Size = new System.Drawing.Size(32, 32);
            UpdateModPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            UpdateModPic.TabStop = false;
            UpdateModPic.Cursor = Cursors.Hand;
            UpdateModPic.Click += new EventHandler(this.modManager.modlist.updateMod);
            this.modManager.Controls.Add(UpdateModPic);
            p.addControl(UpdateModPic);

            Label UpdateModButton = new System.Windows.Forms.Label();
            UpdateModButton.TextAlign = ContentAlignment.MiddleRight;
            UpdateModButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateModButton.Visible = false;
            UpdateModButton.ForeColor = System.Drawing.SystemColors.Control;
            UpdateModButton.Location = new System.Drawing.Point(300, 567);
            UpdateModButton.Name = "UpdateModButton";
            UpdateModButton.Size = new System.Drawing.Size(100, 32);
            UpdateModButton.TabStop = false;
            UpdateModButton.Cursor = Cursors.Hand;
            UpdateModButton.Text = "Update";
            UpdateModButton.Click += new EventHandler(this.modManager.modlist.updateMod);
            this.modManager.Controls.Add(UpdateModButton);
            p.addControl(UpdateModButton);
            

            this.pages.Add(p);

            // Installed Mods
            p = new Page("Installed");

            System.Windows.Forms.Label InstalledTitle = new System.Windows.Forms.Label();
            InstalledTitle.TextAlign = ContentAlignment.MiddleCenter;
            InstalledTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InstalledTitle.ForeColor = System.Drawing.SystemColors.Control;
            InstalledTitle.Location = new System.Drawing.Point(20, 80);
            InstalledTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            InstalledTitle.Name = "InstalledTitle";
            InstalledTitle.Size = new System.Drawing.Size(1245, 40);
            InstalledTitle.Text = "Installed mods";
            this.modManager.Controls.Add(InstalledTitle);
            p.addControl(InstalledTitle);

            System.Windows.Forms.Label InstalledModsContent = new System.Windows.Forms.Label();
            InstalledModsContent.AutoSize = false;
            InstalledModsContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InstalledModsContent.ForeColor = System.Drawing.SystemColors.Control;
            InstalledModsContent.BackColor = System.Drawing.SystemColors.ControlText;
            InstalledModsContent.BorderStyle = BorderStyle.None;
            InstalledModsContent.Location = new System.Drawing.Point(20, 130);
            InstalledModsContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            InstalledModsContent.Name = "InstalledModsContent";
            InstalledModsContent.Size = new System.Drawing.Size(1245, 90);
            InstalledModsContent.Cursor = Cursors.Arrow;
            this.modManager.Controls.Add(InstalledModsContent);
            p.addControl(InstalledModsContent);

            System.Windows.Forms.Label DownloadCodeLabel = new System.Windows.Forms.Label();
            DownloadCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DownloadCodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            DownloadCodeLabel.Location = new System.Drawing.Point(20, 240);
            DownloadCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            DownloadCodeLabel.Name = "DownloadCodeLabel";
            DownloadCodeLabel.Size = new System.Drawing.Size(250, 20);
            DownloadCodeLabel.Text = "Current configuration code :";
            this.modManager.Controls.Add(DownloadCodeLabel);
            p.addControl(DownloadCodeLabel);

            System.Windows.Forms.TextBox DownloadCodeTextbox = new System.Windows.Forms.TextBox();
            DownloadCodeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DownloadCodeTextbox.ForeColor = System.Drawing.SystemColors.ControlText;
            DownloadCodeTextbox.Location = new System.Drawing.Point(270, 240);
            DownloadCodeTextbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            DownloadCodeTextbox.Name = "DownloadCodeTextbox";
            DownloadCodeTextbox.TabStop = false;
            DownloadCodeTextbox.Size = new System.Drawing.Size(100, 20);
            this.modManager.Controls.Add(DownloadCodeTextbox);
            p.addControl(DownloadCodeTextbox);

            System.Windows.Forms.Label UploadCodeLabel = new System.Windows.Forms.Label();
            UploadCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UploadCodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            UploadCodeLabel.Location = new System.Drawing.Point(20, 280);
            UploadCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            UploadCodeLabel.Name = "DownloadCodeLabel";
            UploadCodeLabel.Size = new System.Drawing.Size(250, 30);
            UploadCodeLabel.Text = "Load code :";
            this.modManager.Controls.Add(UploadCodeLabel);
            p.addControl(UploadCodeLabel);

            System.Windows.Forms.TextBox UploadCodeTextbox = new System.Windows.Forms.TextBox();
            UploadCodeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UploadCodeTextbox.ForeColor = System.Drawing.SystemColors.ControlText;
            UploadCodeTextbox.Location = new System.Drawing.Point(270, 280);
            UploadCodeTextbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            UploadCodeTextbox.Name = "UploadCodeTextbox";
            UploadCodeTextbox.Text = "";
            UploadCodeTextbox.TabStop = false;
            UploadCodeTextbox.Size = new System.Drawing.Size(100, 30);
            this.modManager.Controls.Add(UploadCodeTextbox);
            p.addControl(UploadCodeTextbox);

            System.Windows.Forms.Button UploadCodeButton = new System.Windows.Forms.Button();
            UploadCodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UploadCodeButton.ForeColor = System.Drawing.SystemColors.Control;
            UploadCodeButton.Location = new System.Drawing.Point(390, 280);
            UploadCodeButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            UploadCodeButton.Name = "UploadCodeButton";
            UploadCodeButton.Text = "Load";
            UploadCodeButton.TabStop = false;
            UploadCodeButton.Click += new EventHandler(this.modManager.modlist.enterCode);
            UploadCodeButton.Size = new System.Drawing.Size(100, 30);
            this.modManager.Controls.Add(UploadCodeButton);
            p.addControl(UploadCodeButton);

            PictureBox InfoPic = new System.Windows.Forms.PictureBox();
            InfoPic.Image = global::ModManager.Properties.Resources.info;
            InfoPic.Location = new System.Drawing.Point(20, 340);
            InfoPic.Name = "InfoPic";
            InfoPic.Size = new System.Drawing.Size(32, 32);
            InfoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            InfoPic.TabStop = false;
            this.modManager.Controls.Add(InfoPic);
            p.addControl(InfoPic);

            System.Windows.Forms.Label InfoCodeLabel = new System.Windows.Forms.Label();
            InfoCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InfoCodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            InfoCodeLabel.Location = new System.Drawing.Point(60, 335);
            InfoCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            InfoCodeLabel.Name = "InfoCodeLabel";
            InfoCodeLabel.Size = new System.Drawing.Size(1150, 50);
            InfoCodeLabel.Text = "You can send your code to someone. After using it, there will be same mods for both.\nYou can also enter someone's code.";
            this.modManager.Controls.Add(InfoCodeLabel);
            p.addControl(InfoCodeLabel);

            this.pages.Add(p);

            // Textures
            p = new Page("Textures");

            System.Windows.Forms.Label TexturesTitle = new System.Windows.Forms.Label();
            TexturesTitle.TextAlign = ContentAlignment.MiddleCenter;
            TexturesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TexturesTitle.ForeColor = System.Drawing.SystemColors.Control;
            TexturesTitle.Location = new System.Drawing.Point(20, 80);
            TexturesTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            TexturesTitle.Name = "TexturesTitle";
            TexturesTitle.Size = new System.Drawing.Size(1245, 40);
            TexturesTitle.Text = "Textures packs";
            this.modManager.Controls.Add(TexturesTitle);
            p.addControl(TexturesTitle);

            if (this.modManager.serverConfig.texturesEnabled == true)
            {

            } else
            {
                System.Windows.Forms.Label TexturesContent = new System.Windows.Forms.Label();
                TexturesContent.AutoSize = false;
                TexturesContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                TexturesContent.ForeColor = System.Drawing.SystemColors.Control;
                TexturesContent.BackColor = System.Drawing.SystemColors.ControlText;
                TexturesContent.BorderStyle = BorderStyle.None;
                TexturesContent.Location = new System.Drawing.Point(20, 130);
                TexturesContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                TexturesContent.Name = "TexturesContent";
                TexturesContent.Size = new System.Drawing.Size(1245, 90);
                TexturesContent.Cursor = Cursors.Arrow;
                TexturesContent.Text = "Textures have been disabled for now.\n\nThis feature will be back as soon as possible !";
                this.modManager.Controls.Add(TexturesContent);
                p.addControl(TexturesContent);
            }

            this.pages.Add(p);

            // Textures
            p = new Page("Servers");

            System.Windows.Forms.Label ServersTitle = new System.Windows.Forms.Label();
            ServersTitle.TextAlign = ContentAlignment.MiddleCenter;
            ServersTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServersTitle.ForeColor = System.Drawing.SystemColors.Control;
            ServersTitle.Location = new System.Drawing.Point(20, 80);
            ServersTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ServersTitle.Name = "ServersTitle";
            ServersTitle.Size = new System.Drawing.Size(1245, 40);
            ServersTitle.Text = "Servers";
            this.modManager.Controls.Add(ServersTitle);
            p.addControl(ServersTitle);

            if (this.modManager.serverConfig.serversEnabled == true)
            {

            }
            else
            {
                System.Windows.Forms.Label ServersContent = new System.Windows.Forms.Label();
                ServersContent.AutoSize = false;
                ServersContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ServersContent.ForeColor = System.Drawing.SystemColors.Control;
                ServersContent.BackColor = System.Drawing.SystemColors.ControlText;
                ServersContent.BorderStyle = BorderStyle.None;
                ServersContent.Location = new System.Drawing.Point(20, 130);
                ServersContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                ServersContent.Name = "ServersContent";
                ServersContent.Size = new System.Drawing.Size(1245, 90);
                ServersContent.Cursor = Cursors.Arrow;
                ServersContent.Text = "Coming soon ...";
                this.modManager.Controls.Add(ServersContent);
                p.addControl(ServersContent);
            }

            

            this.pages.Add(p);

            // Announce
            p = new Page("Announce");

            System.Windows.Forms.Label AnnounceTitle = new System.Windows.Forms.Label();
            AnnounceTitle.TextAlign = ContentAlignment.MiddleCenter;
            AnnounceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AnnounceTitle.ForeColor = System.Drawing.SystemColors.Control;
            AnnounceTitle.Location = new System.Drawing.Point(20, 80);
            AnnounceTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AnnounceTitle.Name = "AnnounceTitle";
            AnnounceTitle.Size = new System.Drawing.Size(1245, 40);
            AnnounceTitle.Text = "News";
            this.modManager.Controls.Add(AnnounceTitle);
            p.addControl(AnnounceTitle);

            System.Windows.Forms.Label AnnounceContent = new System.Windows.Forms.Label();
            AnnounceContent.AutoSize = false;
            AnnounceContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AnnounceContent.ForeColor = System.Drawing.SystemColors.Control;
            AnnounceContent.BackColor = System.Drawing.SystemColors.ControlText;
            AnnounceContent.BorderStyle = BorderStyle.None;
            AnnounceContent.Location = new System.Drawing.Point(20, 130);
            AnnounceContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AnnounceContent.Name = "AnnounceContent";
            AnnounceContent.Size = new System.Drawing.Size(1245, 330);
            AnnounceContent.Cursor = Cursors.Arrow;

            try { 
                using (var client = new WebClient())
                {
                    string news = client.DownloadString(this.modManager.serverURL + "/news.txt");
                    AnnounceContent.Text = news;
                }
            }
            catch
            {
                this.modManager.log("News text > Server unreachable");
                MessageBox.Show("Can't reach Mod Manager server.\nPlease verify your internet connection and try again !", "Mod Manager server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            this.modManager.Controls.Add(AnnounceContent);
            p.addControl(AnnounceContent);

            this.pages.Add(p);

            // Settings
            p = new Page("Settings");

            System.Windows.Forms.Label SettingsTitle = new System.Windows.Forms.Label();
            SettingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            SettingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SettingsTitle.ForeColor = System.Drawing.SystemColors.Control;
            SettingsTitle.Location = new System.Drawing.Point(20, 80);
            SettingsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            SettingsTitle.Name = "SettingsTitle";
            SettingsTitle.Size = new System.Drawing.Size(1245, 40);
            SettingsTitle.Text = "Settings";
            this.modManager.Controls.Add(SettingsTitle);
            p.addControl(SettingsTitle);

            System.Windows.Forms.Label AmongUsDirSwitchLabel = new System.Windows.Forms.Label();
            AmongUsDirSwitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsDirSwitchLabel.Location = new System.Drawing.Point(20, 150);
            AmongUsDirSwitchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AmongUsDirSwitchLabel.Name = "AmongUsDirSwitchLabel";
            AmongUsDirSwitchLabel.Size = new System.Drawing.Size(200, 20);
            AmongUsDirSwitchLabel.Text = "Among Us directory :";
            this.modManager.Controls.Add(AmongUsDirSwitchLabel);
            p.addControl(AmongUsDirSwitchLabel);

            Button AmongUsDirSwitchButton = new System.Windows.Forms.Button();
            AmongUsDirSwitchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchButton.Location = new System.Drawing.Point(250, 150);
            AmongUsDirSwitchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirSwitchButton.Name = "AmongUsDirSwitchButton";
            AmongUsDirSwitchButton.Size = new System.Drawing.Size(150, 30);
            AmongUsDirSwitchButton.Text = "Change";
            AmongUsDirSwitchButton.UseVisualStyleBackColor = true;
            AmongUsDirSwitchButton.TabStop = false;
            AmongUsDirSwitchButton.Click += new EventHandler(this.backToDirectorySelection);
            this.modManager.Controls.Add(AmongUsDirSwitchButton);
            p.addControl(AmongUsDirSwitchButton);

            Button OpenAmongUs = new System.Windows.Forms.Button();
            OpenAmongUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenAmongUs.Location = new System.Drawing.Point(450, 150);
            OpenAmongUs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            OpenAmongUs.Name = "OpenAmongUs";
            OpenAmongUs.Size = new System.Drawing.Size(150, 30);
            OpenAmongUs.Text = "Open";
            OpenAmongUs.TabStop = false;
            OpenAmongUs.UseVisualStyleBackColor = true;
            OpenAmongUs.Click += new EventHandler(this.openAmongUsDirectory);
            this.modManager.Controls.Add(OpenAmongUs);
            p.addControl(OpenAmongUs);

            System.Windows.Forms.Label TextureLabel = new System.Windows.Forms.Label();
            /*TextureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            p.addControl(TextureWaitLabel);*/

            System.Windows.Forms.Label ForegreenFixLabel = new System.Windows.Forms.Label();
            ForegreenFixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForegreenFixLabel.ForeColor = System.Drawing.SystemColors.Control;
            ForegreenFixLabel.Location = new System.Drawing.Point(20, 200);
            ForegreenFixLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ForegreenFixLabel.Name = "ForegreenFixLabel";
            ForegreenFixLabel.Size = new System.Drawing.Size(200, 20);
            ForegreenFixLabel.Text = "Foregreen skin fix :";
            this.modManager.Controls.Add(ForegreenFixLabel);
            p.addControl(ForegreenFixLabel);

            Button ForegreenFixButton = new System.Windows.Forms.Button();
            ForegreenFixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForegreenFixButton.Location = new System.Drawing.Point(250, 200);
            ForegreenFixButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            ForegreenFixButton.Name = "ForegreenFixButton";
            ForegreenFixButton.Size = new System.Drawing.Size(150, 30);
            ForegreenFixButton.Text = "Fix";
            ForegreenFixButton.UseVisualStyleBackColor = true;
            ForegreenFixButton.TabStop = false;
            ForegreenFixButton.Click += new EventHandler(this.fixForegreen);
            this.modManager.Controls.Add(ForegreenFixButton);
            p.addControl(ForegreenFixButton);

            System.Windows.Forms.Label OpenLogsLabel = new System.Windows.Forms.Label();
            OpenLogsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenLogsLabel.ForeColor = System.Drawing.SystemColors.Control;
            OpenLogsLabel.Location = new System.Drawing.Point(20, 250);
            OpenLogsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            OpenLogsLabel.Name = "OpenLogsLabel";
            OpenLogsLabel.Size = new System.Drawing.Size(200, 20);
            OpenLogsLabel.Text = "Open logs folder :";
            this.modManager.Controls.Add(OpenLogsLabel);
            p.addControl(OpenLogsLabel);

            Button OpenLogsButton = new System.Windows.Forms.Button();
            OpenLogsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenLogsButton.Location = new System.Drawing.Point(250, 250);
            OpenLogsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            OpenLogsButton.Name = "OpenLogsButton";
            OpenLogsButton.Size = new System.Drawing.Size(150, 30);
            OpenLogsButton.Text = "Open";
            OpenLogsButton.UseVisualStyleBackColor = true;
            OpenLogsButton.Click += new EventHandler(this.openLogs);
            OpenLogsButton.TabStop = false;
            this.modManager.Controls.Add(OpenLogsButton);
            p.addControl(OpenLogsButton);

            this.pages.Add(p);

            // Credits
            p = new Page("Credits");

            System.Windows.Forms.Label CreditsTitle = new System.Windows.Forms.Label();
            CreditsTitle.TextAlign = ContentAlignment.MiddleCenter;
            CreditsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CreditsTitle.ForeColor = System.Drawing.SystemColors.Control;
            CreditsTitle.Location = new System.Drawing.Point(20, 80);
            CreditsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            CreditsTitle.Name = "CreditsTitle";
            CreditsTitle.Size = new System.Drawing.Size(1245, 30);
            CreditsTitle.BackColor = System.Drawing.SystemColors.ControlText;
            CreditsTitle.Text = "Credits";
            this.modManager.Controls.Add(CreditsTitle);
            p.addControl(CreditsTitle);

            System.Windows.Forms.Label CreditsContent = new System.Windows.Forms.Label();
            CreditsContent.AutoSize = false;
            CreditsContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CreditsContent.ForeColor = System.Drawing.SystemColors.Control;
            CreditsContent.BackColor = System.Drawing.SystemColors.ControlText;
            CreditsContent.BorderStyle = BorderStyle.None;
            CreditsContent.Location = new System.Drawing.Point(20, 130);
            CreditsContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            CreditsContent.Name = "AnnounceContent";
            CreditsContent.Size = new System.Drawing.Size(1245, 330);
            CreditsContent.Cursor = Cursors.Arrow;

            try {
                using (var client = new WebClient())
                {
                    string credits = client.DownloadString(this.modManager.serverURL + "/credits.txt");
                    CreditsContent.Text = credits;
                }
            }
            catch
            {
                this.modManager.log("Credits text > Server unreachable");
                MessageBox.Show("Can't reach Mod Manager server.\nPlease verify your internet connection and try again !", "Mod Manager server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

            this.modManager.Controls.Add(CreditsContent);
            p.addControl(CreditsContent);

            this.pages.Add(p);
        }

        public void renderPage(string page)
        {
            this.modManager.log("Render page "+page);
            if (page != "PathSelection" && this.modManager.firstStart == true)
            {
                this.enableHeader();
                this.modManager.firstStart = false;
            }
            foreach (Page p in this.pages)
            {
                p.hide();
            }
            if (page == "PathSelection" && this.modManager.firstStart == true)
            {
                this.disableHeader();
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
            this.modManager.ActiveControl = null;
        }

        private void disableHeader()
        {
            foreach (Control c in this.modManager.Controls)
            {
                if (c.Name != "mainTitle" && c.Name != "Version" && c.Name != "separator1" && c.Name != "separator2" && c.Name != "VersionField" && c.Name != "AmongUsSelectionPopup")
                {
                    c.Hide();
                }
            }
        }

        private void enableHeader()
        {
            List<string> pagesControls = this.getAllPagesNames();
            foreach (Control c in this.modManager.Controls)
            {
                if (!pagesControls.Contains(c.Name))
                {
                    c.Show();
                }
            }
        }

        public List<string> getAllPagesNames()
        {
            List<string> retour = new List<string>();
            foreach (Page p in this.pages)
            {
                foreach (Control c in p.controls)
                {
                    retour.Add(c.Name);
                }
            }
            return retour;
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
            this.modManager.log("Open Github "+link);
            System.Diagnostics.Process.Start(link);
        }

        public void openMatuxGithub(object sender, EventArgs e)
        {
            this.modManager.log("Open Matux Github");
            System.Diagnostics.Process.Start("https://github.com/MatuxGG/ModManager");
        }

        public void openMMDiscord(object sender, EventArgs e)
        {
            this.modManager.log("Open Mod Manager discord");
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

        public void openInstalled(object sender, EventArgs e)
        {
            this.openInstalledWorker();
        }

        public void openInstalledWorker()
        {
            string installed = "";
            foreach (InstalledMod m in this.modManager.config.installedMods)
            {
                installed = installed + this.modManager.modlist.get(m.id).name + ", ";
            }
            if (installed == "")
            {
                installed = "No mod installed";
            }
            else
            {
                installed = installed.Substring(0, installed.Length - 2);
            }

            this.get("Installed").getControl("InstalledModsContent").Text = installed;
            this.get("Installed").getControl("DownloadCodeTextbox").Text = this.modManager.modlist.getCode();
            this.renderPage("Installed");
        }

        public void backToDirectorySelection(object sender, EventArgs e)
        {
            this.renderPage("PathSelection");
        }

        public void launchGame(object sender, EventArgs e)
        {
            this.modManager.log("Start game");
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                this.modManager.log("Game already started");
                if (MessageBox.Show("Among Us is already running or is starting.\nDo you want to retry launching it ?", "Among Us already running", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }
            }
            /*
            string batpath = this.modManager.appPath + "\\openGame.cmd";
            this.modManager.utils.FileDelete(batpath);
            File.WriteAllText(batpath, "explorer.exe \"" + this.modManager.config.amongUsPath + "\\Among Us.exe" + "\"");
            Process.Start(batpath);
            */

            Process.Start("steam://rungameid/945360");

        }
        public void openAnnounce(object sender, EventArgs e)
        {
            this.renderPage("Announce");
        }
        public void openSettings(object sender, EventArgs e)
        {
            this.renderPage("Settings");
        }

        public void openServers(object sender, EventArgs e)
        {
            this.renderPage("Servers");
        }

        public void openTextures(object sender, EventArgs e)
        {
            this.renderPage("Textures");
        }

        public void backToMods(object sender, EventArgs e)
        {
            this.renderPage("ModSelection");
        }
        /*
        public void quickFix(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please, only use this option if you encounter a bug !\n\n" +
                "This will will uninstall all mods are reset your settings.\n\n" +
                "Do you still want to apply it ?", "Open logs folder", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.modManager.log("Quick fix");
            }
        }*/

        public void openLogs(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please, don't touch anything in this folder !\n\n" +
                "This option should only be used to create a support ticket.\n\n" +
                "Do you still want to open it ?", "Open logs folder", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.modManager.log("Open logs folder");
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager";
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }

        public void fixForegreen(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                this.modManager.log("Fix foregreen skin > Game open");
                MessageBox.Show("Close Among Us to use this option", "Can't use fix", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Be careful ! Don't use this button if you don't have this issue !\n\n" +
                "This option will only help you if you can't use settings in game creation and your skin is green.\n" +
                "This will also reset all your game settings like pseudo, color, hat, ..." +
                "There is no consequence on your stats tho.\n\n" +
                "Do you still want to apply this fix ?", "Fix foregreen skin", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.modManager.log("Fix foregreen skin");
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\..\\LocalLow\\Innersloth\\Among Us\\playerPrefs";
                this.modManager.utils.FileDelete(path);
            }
        }


    }
}