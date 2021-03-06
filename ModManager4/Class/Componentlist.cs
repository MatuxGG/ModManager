﻿using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Componentlist
    {
        public List<Component> components;

        public ModManager modManager;

        public Events events;

        public Tooltips tooltips;

        public Componentlist(ModManager modManager)
        {
            this.modManager = modManager;
            this.components = new List<Component>();
            this.events = new Events(this.modManager);
            this.tooltips = new Tooltips(this.modManager);
        }

        public void load()
        {

            this.modManager.Controls.Clear();

            Fontlist fonts = new Fontlist(this.modManager.config.resolutionY);

            double ratioX = (double)this.modManager.config.resolutionX / 1300.0;
            double ratioY = (double)this.modManager.config.resolutionY / 810.0;

            Component c = new Component("Header");

            PictureBox AnnouncePic = new System.Windows.Forms.PictureBox();
            AnnouncePic.Image = global::ModManager4.Properties.Resources.news;
            AnnouncePic.BackColor = System.Drawing.Color.Transparent;
            AnnouncePic.Location = new System.Drawing.Point((int)(50* ratioX), (int)(70* ratioY));
            AnnouncePic.Name = "AnnouncePic";
            AnnouncePic.Size = new System.Drawing.Size((int)(64 * ratioX), (int)(64 * ratioY));
            AnnouncePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            AnnouncePic.TabStop = false;
            AnnouncePic.Cursor = Cursors.Hand;
            AnnouncePic.MouseLeave += new EventHandler(this.tooltips.hide);
            AnnouncePic.MouseHover += new EventHandler(this.tooltips.show);
            AnnouncePic.Click += new EventHandler(this.events.openAnnounce);
            AnnouncePic.Visible = false;
            this.modManager.Controls.Add(AnnouncePic);
            c.addControl(AnnouncePic);

            PictureBox InfoPic = new System.Windows.Forms.PictureBox();
            InfoPic.Image = Properties.Resources.info;
            InfoPic.BackColor = System.Drawing.Color.Transparent;
            InfoPic.Location = new System.Drawing.Point((int)(1000 * ratioX), (int)(20 * ratioY));
            InfoPic.Name = "InfoPic";
            InfoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            InfoPic.TabStop = false;
            InfoPic.Cursor = Cursors.Hand;
            InfoPic.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            InfoPic.MouseLeave += new EventHandler(this.tooltips.hide);
            InfoPic.MouseHover += new EventHandler(this.tooltips.show);
            InfoPic.Click += new EventHandler(this.events.openInfo);
            InfoPic.Visible = false;
            this.modManager.Controls.Add(InfoPic);
            c.addControl(InfoPic);

            this.components.Add(c);

            c = new Component("HeaderPub");

            System.Windows.Forms.Label VersionField = new System.Windows.Forms.Label();
            VersionField.BackColor = System.Drawing.Color.Transparent;
            VersionField.ForeColor = System.Drawing.Color.Yellow;
            VersionField.Name = "VersionField";
            VersionField.TextAlign = ContentAlignment.MiddleCenter;
            VersionField.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionField.Location = new System.Drawing.Point((int)(400 * ratioX), (int)(145 * ratioY));
            VersionField.Size = new System.Drawing.Size((int)(500 * ratioX), (int)(30 * ratioY));
            string version = this.modManager.version.ToString();
            VersionField.Text = "Version " + version.Remove(version.Length - 2);
            VersionField.Visible = false;
            this.modManager.Controls.Add(VersionField);
            c.addControl(VersionField);

            System.Windows.Forms.Label ByMatuxField = new System.Windows.Forms.Label();
            ByMatuxField.BackColor = System.Drawing.Color.Transparent;
            ByMatuxField.ForeColor = System.Drawing.Color.Yellow;
            ByMatuxField.Name = "ByMatuxField";
            ByMatuxField.TextAlign = ContentAlignment.MiddleLeft;
            ByMatuxField.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ByMatuxField.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(20 * ratioY));
            ByMatuxField.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(30 * ratioY));
            ByMatuxField.Text = "By Matux";
            ByMatuxField.Visible = false;
            this.modManager.Controls.Add(ByMatuxField);
            c.addControl(ByMatuxField);

            PictureBox MatuxRoadmapLabel = new System.Windows.Forms.PictureBox();
            MatuxRoadmapLabel.Image = Properties.Resources.roadmap;
            MatuxRoadmapLabel.BackColor = System.Drawing.Color.Transparent;
            MatuxRoadmapLabel.Location = new System.Drawing.Point((int)(1068 * ratioX), (int)(18 * ratioY));
            MatuxRoadmapLabel.Name = "MatuxRoadmapLabel";
            MatuxRoadmapLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            MatuxRoadmapLabel.TabStop = false;
            MatuxRoadmapLabel.Cursor = Cursors.Hand;
            MatuxRoadmapLabel.Size = new System.Drawing.Size((int)(55 * ratioX), (int)(55 * ratioY));
            MatuxRoadmapLabel.MouseLeave += new EventHandler(this.tooltips.hide);
            MatuxRoadmapLabel.MouseHover += new EventHandler(this.tooltips.show);
            MatuxRoadmapLabel.Click += new EventHandler(this.events.openMatuxRoadmap);
            MatuxRoadmapLabel.Visible = false;
            this.modManager.Controls.Add(MatuxRoadmapLabel);
            c.addControl(MatuxRoadmapLabel);

            PictureBox MMDiscordLabel = new System.Windows.Forms.PictureBox();
            MMDiscordLabel.Image = Properties.Resources.discord;
            MMDiscordLabel.Location = new System.Drawing.Point((int)(1140 * ratioX), (int)(20 * ratioY));
            MMDiscordLabel.BackColor = System.Drawing.Color.Transparent;
            MMDiscordLabel.Name = "MMDiscordLabel";
            MMDiscordLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            MMDiscordLabel.TabStop = false;
            MMDiscordLabel.Cursor = Cursors.Hand;
            MMDiscordLabel.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            MMDiscordLabel.MouseLeave += new EventHandler(this.tooltips.hide);
            MMDiscordLabel.MouseHover += new EventHandler(this.tooltips.show);
            MMDiscordLabel.Click += new EventHandler(this.events.openMMDiscord);
            MMDiscordLabel.Visible = false;
            this.modManager.Controls.Add(MMDiscordLabel);
            c.addControl(MMDiscordLabel);

            PictureBox MatuxGithubLabel = new System.Windows.Forms.PictureBox();
            MatuxGithubLabel.Image = Properties.Resources.github;
            MatuxGithubLabel.BackColor = System.Drawing.Color.Transparent;
            MatuxGithubLabel.Location = new System.Drawing.Point((int)(1210 * ratioX), (int)(20 * ratioY));
            MatuxGithubLabel.Name = "MatuxGithubLabel";
            MatuxGithubLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            MatuxGithubLabel.TabStop = false;
            MatuxGithubLabel.Cursor = Cursors.Hand;
            MatuxGithubLabel.Size = new System.Drawing.Size((int)(50 * ratioX), (int)(50 * ratioY));
            MatuxGithubLabel.MouseLeave += new EventHandler(this.tooltips.hide);
            MatuxGithubLabel.MouseHover += new EventHandler(this.tooltips.show);
            MatuxGithubLabel.Click += new EventHandler(this.events.openMatuxGithub);
            MatuxGithubLabel.Visible = false;
            this.modManager.Controls.Add(MatuxGithubLabel);
            c.addControl(MatuxGithubLabel);

            this.components.Add(c);

            c = new Component("Footer");

            PictureBox PlayGameLabel = new PictureBox();
            PlayGameLabel.BackColor = Color.Transparent;
            PlayGameLabel.Image = global::ModManager4.Properties.Resources.start_game;
            PlayGameLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PlayGameLabel.Name = "PlayGameLabel";
            PlayGameLabel.Location = new System.Drawing.Point((int)(570 * ratioX), (int)(680 * ratioY));
            PlayGameLabel.Size = new System.Drawing.Size((int)(240 * ratioX), (int)(80 * ratioY));
            PlayGameLabel.Cursor = Cursors.Hand;
            PlayGameLabel.Visible = false;
            PlayGameLabel.TabStop = false;
            PlayGameLabel.MouseLeave += new EventHandler(this.tooltips.hide);
            PlayGameLabel.MouseHover += new EventHandler(this.tooltips.show);
            PlayGameLabel.Click += new EventHandler(this.events.launchGame);
            PlayGameLabel.Visible = false;
            this.modManager.Controls.Add(PlayGameLabel);
            c.addControl(PlayGameLabel);

            PictureBox SettingsPic = new System.Windows.Forms.PictureBox();
            SettingsPic.Image = global::ModManager4.Properties.Resources.settings;
            SettingsPic.BackColor = System.Drawing.Color.Transparent;
            SettingsPic.Location = new System.Drawing.Point((int)(850 * ratioX), (int)(680 * ratioY));
            SettingsPic.Name = "SettingsPic";
            SettingsPic.Size = new System.Drawing.Size((int)(210 * ratioX), (int)(70 * ratioY));
            SettingsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            SettingsPic.TabStop = false;
            SettingsPic.Cursor = Cursors.Hand;
            SettingsPic.MouseLeave += new EventHandler(this.tooltips.hide);
            SettingsPic.MouseHover += new EventHandler(this.tooltips.show);
            SettingsPic.Click += new EventHandler(this.events.openSettings);
            SettingsPic.Visible = false;
            this.modManager.Controls.Add(SettingsPic);
            c.addControl(SettingsPic);

            PictureBox CodePic = new System.Windows.Forms.PictureBox();
            CodePic.Image = global::ModManager4.Properties.Resources.code;
            CodePic.BackColor = System.Drawing.Color.Transparent;
            CodePic.Location = new System.Drawing.Point((int)(200 * ratioX), (int)(695 * ratioY));
            CodePic.Name = "CodePic";
            CodePic.Size = new System.Drawing.Size((int)(95 * ratioX), (int)(40 * ratioY));
            CodePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            CodePic.TabStop = false;
            CodePic.Visible = false;
            this.modManager.Controls.Add(CodePic);

            c.addControl(CodePic);

            System.Windows.Forms.TextBox CodeTextbox = new System.Windows.Forms.TextBox();
            CodeTextbox.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CodeTextbox.ForeColor = SystemColors.ControlText;
            CodeTextbox.Location = new System.Drawing.Point((int)(310 * ratioX), (int)(700 * ratioY));
            CodeTextbox.Name = "CodeTextbox";
            CodeTextbox.TabStop = false;
            CodeTextbox.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(20 * ratioY));
            CodeTextbox.Visible = false;
            CodeTextbox.MouseLeave += new EventHandler(this.tooltips.hide);
            CodeTextbox.MouseHover += new EventHandler(this.tooltips.show);
            this.modManager.Controls.Add(CodeTextbox);
            c.addControl(CodeTextbox);

            PictureBox ValidCodePic = new System.Windows.Forms.PictureBox();
            ValidCodePic.Image = global::ModManager4.Properties.Resources.valid;
            ValidCodePic.BackColor = System.Drawing.Color.Transparent;
            ValidCodePic.Location = new System.Drawing.Point((int)(420 * ratioX), (int)(695 * ratioY));
            ValidCodePic.Name = "ValidCodePic";
            ValidCodePic.Cursor = Cursors.Hand;
            ValidCodePic.Size = new System.Drawing.Size((int)(40 * ratioX), (int)(40 * ratioY));
            ValidCodePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ValidCodePic.TabStop = false;
            ValidCodePic.Visible = false;
            ValidCodePic.Click += new EventHandler(this.events.validCode);
            ValidCodePic.MouseLeave += new EventHandler(this.tooltips.hide);
            ValidCodePic.MouseHover += new EventHandler(this.tooltips.show);
            this.modManager.Controls.Add(ValidCodePic);
            c.addControl(ValidCodePic);

            PictureBox ExportCodePic = new System.Windows.Forms.PictureBox();
            ExportCodePic.Image = global::ModManager4.Properties.Resources.export;
            ExportCodePic.BackColor = System.Drawing.Color.Transparent;
            ExportCodePic.Location = new System.Drawing.Point((int)(480 * ratioX), (int)(695 * ratioY));
            ExportCodePic.Name = "ExportCodePic";
            ExportCodePic.Cursor = Cursors.Hand;
            ExportCodePic.Size = new System.Drawing.Size((int)(40 * ratioX), (int)(40 * ratioY));
            ExportCodePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ExportCodePic.TabStop = false;
            ExportCodePic.Visible = false;
            ExportCodePic.Click += new EventHandler(this.events.exportCode);
            ExportCodePic.MouseLeave += new EventHandler(this.tooltips.hide);
            ExportCodePic.MouseHover += new EventHandler(this.tooltips.show);
            this.modManager.Controls.Add(ExportCodePic);
            c.addControl(ExportCodePic);

            this.components.Add(c);

            c = new Component("PathSelection");

            Panel PagePanelPath = new Panel();
            PagePanelPath.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelPath.Name = "PagePanelPath";
            PagePanelPath.BackColor = Color.Black;
            PagePanelPath.BorderStyle = BorderStyle.Fixed3D;
            PagePanelPath.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelPath.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelPath.TabStop = false;
            PagePanelPath.Visible = false;
            this.modManager.Controls.Add(PagePanelPath);
            c.addControl(PagePanelPath);

            System.Windows.Forms.Label AmongFolderTitle = new System.Windows.Forms.Label();
            AmongFolderTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongFolderTitle.BackColor = Color.Transparent;
            AmongFolderTitle.ForeColor = SystemColors.Control;
            AmongFolderTitle.TextAlign = ContentAlignment.MiddleCenter;
            AmongFolderTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            AmongFolderTitle.Name = "AmongFolderTitle";
            AmongFolderTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            AmongFolderTitle.Text = "Among Us folder selection";
            PagePanelPath.Controls.Add(AmongFolderTitle);

            System.Windows.Forms.Label AmongUsFolderInfo = new System.Windows.Forms.Label();
            AmongUsFolderInfo.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsFolderInfo.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsFolderInfo.TextAlign = ContentAlignment.MiddleCenter;
            AmongUsFolderInfo.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(150 * ratioY));
            AmongUsFolderInfo.Name = "AmongUsFolderInfo";
            AmongUsFolderInfo.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(20 * ratioY));
            AmongUsFolderInfo.Text = "Please, select the folder where Among Us is installed !";
            PagePanelPath.Controls.Add(AmongUsFolderInfo);

            Button AmongUsDirectorySelection = new System.Windows.Forms.Button();
            AmongUsDirectorySelection.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectorySelection.Location = new System.Drawing.Point((int)(258 * ratioX), (int)(300 * ratioY));
            AmongUsDirectorySelection.Name = "AmongUsDirectorySelection";
            AmongUsDirectorySelection.Size = new System.Drawing.Size((int)(400 * ratioX), (int)(50 * ratioY));
            AmongUsDirectorySelection.Text = "Select folder";
            AmongUsDirectorySelection.TabStop = false;
            AmongUsDirectorySelection.Click += new EventHandler(this.events.selectFolder);
            AmongUsDirectorySelection.UseVisualStyleBackColor = true;
            PagePanelPath.Controls.Add(AmongUsDirectorySelection);

            this.components.Add(c);

            c = new Component("BackToMods");

            PictureBox BackToMods = new System.Windows.Forms.PictureBox();
            BackToMods.Image = global::ModManager4.Properties.Resources.back;
            BackToMods.BackColor = System.Drawing.Color.Transparent;
            BackToMods.Location = new System.Drawing.Point((int)(50 * ratioX), (int)(350 * ratioY));
            BackToMods.Name = "BackToMods";
            BackToMods.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(100 * ratioY));
            BackToMods.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BackToMods.TabStop = false;
            BackToMods.Cursor = Cursors.Hand;
            BackToMods.Click += new EventHandler(this.events.openMods);
            BackToMods.Visible = false;
            this.modManager.Controls.Add(BackToMods);
            c.addControl(BackToMods);

            this.components.Add(c);

            c = new Component("ModSelection");

            c = this.loadModPage(c);

            this.components.Add(c);

            c = new Component("Info");

            Panel PagePanelInfo = new Panel();
            PagePanelInfo.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelInfo.Name = "PagePanelInfo";
            PagePanelInfo.BackColor = Color.Black;
            PagePanelInfo.BorderStyle = BorderStyle.Fixed3D;
            PagePanelInfo.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelInfo.TabStop = false;
            PagePanelInfo.Visible = false;
            this.modManager.Controls.Add(PagePanelInfo);
            c.addControl(PagePanelInfo);

            System.Windows.Forms.Label InfoTitle = new System.Windows.Forms.Label();
            InfoTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InfoTitle.BackColor = Color.Transparent;
            InfoTitle.ForeColor = SystemColors.Control;
            InfoTitle.TextAlign = ContentAlignment.MiddleCenter;
            InfoTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            InfoTitle.Name = "InfoTitle";
            InfoTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            InfoTitle.Text = "Information";
            PagePanelInfo.Controls.Add(InfoTitle);

            Panel ContentPanelInfo = new Panel();
            ContentPanelInfo.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(70 * ratioY));
            ContentPanelInfo.Name = "ContentPanelInfo";
            ContentPanelInfo.Size = new System.Drawing.Size((int)(876 * ratioX), (int)(390 * ratioY));
            ContentPanelInfo.AutoScroll = true;
            ContentPanelInfo.TabStop = false;
            PagePanelInfo.Controls.Add(ContentPanelInfo);

            System.Windows.Forms.Label InfoLabel = new System.Windows.Forms.Label();
            InfoLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            InfoLabel.TextAlign = ContentAlignment.TopLeft;
            InfoLabel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(0 * ratioY));
            InfoLabel.AutoSize = true;
            InfoLabel.MaximumSize = new Size((int)(800 * ratioX), 0);
            InfoLabel.Name = "InfoLabel";
            ContentPanelInfo.Controls.Add(InfoLabel);

            try
            {
                using (var client = new WebClient())
                {
                    string news = client.DownloadString(this.modManager.serverURL + "/info.txt");
                    InfoLabel.Text = news;
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected when loading info\n");
                this.events.exitMM();
            }

            this.components.Add(c);

            c = new Component("Settings");

            Panel PagePanelSettings = new Panel();
            PagePanelSettings.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelSettings.Name = "PagePanelSettings";
            PagePanelSettings.BackColor = Color.Black;
            PagePanelSettings.BorderStyle = BorderStyle.Fixed3D;
            PagePanelSettings.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelSettings.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelSettings.TabStop = false;
            PagePanelSettings.Visible = false;
            this.modManager.Controls.Add(PagePanelSettings);
            c.addControl(PagePanelSettings);

            System.Windows.Forms.Label SettingsTitle = new System.Windows.Forms.Label();
            SettingsTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SettingsTitle.BackColor = Color.Transparent;
            SettingsTitle.ForeColor = SystemColors.Control;
            SettingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            SettingsTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            SettingsTitle.Name = "SettingsTitle";
            SettingsTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            SettingsTitle.Text = "Settings";
            PagePanelSettings.Controls.Add(SettingsTitle);

            System.Windows.Forms.Label AmongUsDirSwitchLabel = new System.Windows.Forms.Label();
            AmongUsDirSwitchLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsDirSwitchLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(100 * ratioY));
            AmongUsDirSwitchLabel.Name = "AmongUsDirSwitchLabel";
            AmongUsDirSwitchLabel.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            AmongUsDirSwitchLabel.Text = "Among Us directory :";
            PagePanelSettings.Controls.Add(AmongUsDirSwitchLabel);

            Button AmongUsDirSwitchButton = new System.Windows.Forms.Button();
            AmongUsDirSwitchButton.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchButton.Location = new System.Drawing.Point((int)(250 * ratioX), (int)(100 * ratioY));
            AmongUsDirSwitchButton.Name = "AmongUsDirSwitchButton";
            AmongUsDirSwitchButton.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            AmongUsDirSwitchButton.Text = "Change";
            AmongUsDirSwitchButton.UseVisualStyleBackColor = true;
            AmongUsDirSwitchButton.TabStop = false;
            AmongUsDirSwitchButton.MouseLeave += new EventHandler(this.tooltips.hide);
            AmongUsDirSwitchButton.MouseHover += new EventHandler(this.tooltips.show);
            AmongUsDirSwitchButton.Click += new EventHandler(this.events.openPathSelection);
            PagePanelSettings.Controls.Add(AmongUsDirSwitchButton);

            Button OpenAmongUs = new System.Windows.Forms.Button();
            OpenAmongUs.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenAmongUs.Location = new System.Drawing.Point((int)(450 * ratioX), (int)(100 * ratioY));
            OpenAmongUs.Name = "OpenAmongUs";
            OpenAmongUs.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            OpenAmongUs.Text = "Open";
            OpenAmongUs.TabStop = false;
            OpenAmongUs.UseVisualStyleBackColor = true;
            OpenAmongUs.MouseLeave += new EventHandler(this.tooltips.hide);
            OpenAmongUs.MouseHover += new EventHandler(this.tooltips.show);
            OpenAmongUs.Click += new EventHandler(this.events.openAmongUsDirectory);
            PagePanelSettings.Controls.Add(OpenAmongUs);

            System.Windows.Forms.Label MethodLabel = new System.Windows.Forms.Label();
            MethodLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MethodLabel.ForeColor = System.Drawing.SystemColors.Control;
            MethodLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(150 * ratioY));
            MethodLabel.Name = "MethodLabel";
            MethodLabel.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            MethodLabel.Text = "Change start method :";
            PagePanelSettings.Controls.Add(MethodLabel);

            ComboBox MethodComboBox = new ComboBox();
            MethodComboBox.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MethodComboBox.Location = new System.Drawing.Point((int)(250 * ratioX), (int)(150 * ratioY));
            MethodComboBox.Name = "MethodComboBox";
            MethodComboBox.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            MethodComboBox.TabStop = false;
            MethodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MethodComboBox.MouseLeave += new EventHandler(this.tooltips.hide);
            MethodComboBox.MouseHover += new EventHandler(this.tooltips.show);

            MethodComboBox.Items.AddRange(new string[] { "Direct Link", "Steam" });
            //MethodComboBox.Items.AddRange(new string[] { "Direct Link", "Steam", "Epic Games Store" });

            string currentMethod = this.modManager.config.startMethod;

            MethodComboBox.SelectedIndex = MethodComboBox.FindStringExact(currentMethod);

            MethodComboBox.SelectedIndexChanged += new EventHandler(this.events.changeMethod);

            PagePanelSettings.Controls.Add(MethodComboBox);

            System.Windows.Forms.Label RemoveLocalLabel = new System.Windows.Forms.Label();
            RemoveLocalLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RemoveLocalLabel.ForeColor = System.Drawing.SystemColors.Control;
            RemoveLocalLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(200 * ratioY));
            RemoveLocalLabel.Name = "RemoveLocalLabel";
            RemoveLocalLabel.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            RemoveLocalLabel.Text = "Remove local mods :";
            PagePanelSettings.Controls.Add(RemoveLocalLabel);

            Button RemoveLocalButton = new System.Windows.Forms.Button();
            RemoveLocalButton.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RemoveLocalButton.Location = new System.Drawing.Point((int)(250 * ratioX), (int)(200 * ratioY));
            RemoveLocalButton.Name = "RemoveLocalButton";
            RemoveLocalButton.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            RemoveLocalButton.Text = "Remove";
            RemoveLocalButton.UseVisualStyleBackColor = true;
            RemoveLocalButton.MouseLeave += new EventHandler(this.tooltips.hide);
            RemoveLocalButton.MouseHover += new EventHandler(this.tooltips.show);
            RemoveLocalButton.Click += new EventHandler(this.events.removeLocalMods);
            RemoveLocalButton.TabStop = false;
            PagePanelSettings.Controls.Add(RemoveLocalButton);

            System.Windows.Forms.Label ResolutionLabel = new System.Windows.Forms.Label();
            ResolutionLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ResolutionLabel.ForeColor = System.Drawing.SystemColors.Control;
            ResolutionLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(250 * ratioY));
            ResolutionLabel.Name = "ResolutionLabel";
            ResolutionLabel.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            ResolutionLabel.Text = "Change resolution :";
            PagePanelSettings.Controls.Add(ResolutionLabel);

            ComboBox ResolutionComboBox = new ComboBox();
            ResolutionComboBox.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ResolutionComboBox.Location = new System.Drawing.Point((int)(250 * ratioX), (int)(250 * ratioY));
            ResolutionComboBox.Name = "ResolutionComboBox";
            ResolutionComboBox.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            ResolutionComboBox.TabStop = false;
            ResolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ResolutionComboBox.MouseLeave += new EventHandler(this.tooltips.hide);
            ResolutionComboBox.MouseHover += new EventHandler(this.tooltips.show);

            foreach (int[] res in this.modManager.config.getResolutions())
            {
                ResolutionComboBox.Items.Add(res[0] + "x" + res[1]);
            }

            string currentResolution = this.modManager.config.resolutionX.ToString() + "x" + this.modManager.config.resolutionY.ToString();

            ResolutionComboBox.SelectedIndex = ResolutionComboBox.FindStringExact(currentResolution);

            ResolutionComboBox.SelectedIndexChanged += new EventHandler(this.events.changeResolution);

            PagePanelSettings.Controls.Add(ResolutionComboBox);


            System.Windows.Forms.Label EnableCacheLabel = new System.Windows.Forms.Label();
            EnableCacheLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            EnableCacheLabel.ForeColor = System.Drawing.SystemColors.Control;
            EnableCacheLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(300 * ratioY));
            EnableCacheLabel.Name = "EnableCacheLabel";
            EnableCacheLabel.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            EnableCacheLabel.Text = "Enable cache :";
            PagePanelSettings.Controls.Add(EnableCacheLabel);

            MMCheckbox EnableCacheCheckbox = new MMCheckbox(this.modManager);
            EnableCacheCheckbox.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            EnableCacheCheckbox.Location = new System.Drawing.Point((int)(300 * ratioX), (int)(300 * ratioY));
            EnableCacheCheckbox.Name = "EnableCacheCheckbox";
            EnableCacheCheckbox.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            EnableCacheCheckbox.UseVisualStyleBackColor = true;
            EnableCacheCheckbox.MouseLeave += new EventHandler(this.tooltips.hide);
            EnableCacheCheckbox.MouseHover += new EventHandler(this.tooltips.show);
            EnableCacheCheckbox.Click += new EventHandler(this.events.enableCache);
            EnableCacheCheckbox.TabStop = false;

            if (this.modManager.config.enableCache == false)
            {
                EnableCacheCheckbox.CheckState = CheckState.Unchecked;
            } else
            {
                EnableCacheCheckbox.CheckState = CheckState.Checked;
            }

            PagePanelSettings.Controls.Add(EnableCacheCheckbox);

            System.Windows.Forms.Label OpenLogsLabel = new System.Windows.Forms.Label();
            OpenLogsLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenLogsLabel.ForeColor = System.Drawing.SystemColors.Control;
            OpenLogsLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(350 * ratioY));
            OpenLogsLabel.Name = "OpenLogsLabel";
            OpenLogsLabel.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            OpenLogsLabel.Text = "Open logs folder :";
            PagePanelSettings.Controls.Add(OpenLogsLabel);

            Button OpenLogsButton = new System.Windows.Forms.Button();
            OpenLogsButton.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenLogsButton.Location = new System.Drawing.Point((int)(250 * ratioX), (int)(350 * ratioY));
            OpenLogsButton.Name = "OpenLogsButton";
            OpenLogsButton.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            OpenLogsButton.Text = "Open";
            OpenLogsButton.UseVisualStyleBackColor = true;
            OpenLogsButton.MouseLeave += new EventHandler(this.tooltips.hide);
            OpenLogsButton.MouseHover += new EventHandler(this.tooltips.show);
            OpenLogsButton.Click += new EventHandler(this.events.openLogs);
            OpenLogsButton.TabStop = false;
            PagePanelSettings.Controls.Add(OpenLogsButton);

            this.components.Add(c);

            c = new Component("News");

            Panel PagePanelNews = new Panel();
            PagePanelNews.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelNews.Name = "PagePanelNews";
            PagePanelNews.BackColor = Color.Black;
            PagePanelNews.BorderStyle = BorderStyle.Fixed3D;
            PagePanelNews.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelNews.TabStop = false;
            PagePanelNews.Visible = false;
            this.modManager.Controls.Add(PagePanelNews);
            c.addControl(PagePanelNews);

            System.Windows.Forms.Label NewsTitle = new System.Windows.Forms.Label();
            NewsTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NewsTitle.BackColor = Color.Transparent;
            NewsTitle.ForeColor = SystemColors.Control;
            NewsTitle.TextAlign = ContentAlignment.MiddleCenter;
            NewsTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            NewsTitle.Name = "NewsTitle";
            NewsTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            NewsTitle.Text = "News";
            PagePanelNews.Controls.Add(NewsTitle);

            Panel ContentPanelNews = new Panel();
            ContentPanelNews.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(70 * ratioY));
            ContentPanelNews.Name = "ContentPanelNews";
            ContentPanelNews.Size = new System.Drawing.Size((int)(876 * ratioX), (int)(390 * ratioY));
            ContentPanelNews.AutoScroll = true;
            ContentPanelNews.TabStop = false;
            PagePanelNews.Controls.Add(ContentPanelNews);

            System.Windows.Forms.Label NewsLabel = new System.Windows.Forms.Label();
            NewsLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NewsLabel.ForeColor = System.Drawing.SystemColors.Control;
            NewsLabel.TextAlign = ContentAlignment.TopLeft;
            NewsLabel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(0 * ratioY));
            NewsLabel.Name = "NewsLabel";
            NewsLabel.AutoSize = true;
            NewsLabel.MaximumSize = new Size((int)(800 * ratioX), 0);
            ContentPanelNews.Controls.Add(NewsLabel);

            try
            {
                using (var client = new WebClient())
                {
                    string news = client.DownloadString(this.modManager.serverURL + "/news.txt");
                    NewsLabel.Text = news;
                }
            }
            catch
            {
                this.modManager.logs.log("Error : Disconnected when loading news\n");
                this.events.exitMM();
            }

            this.components.Add(c);

            c = new Component("AfterUninstallMods");

            Panel PagePanelUnMods = new Panel();
            PagePanelUnMods.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelUnMods.Name = "PagePanelUnMods";
            PagePanelUnMods.BackColor = Color.Black;
            PagePanelUnMods.BorderStyle = BorderStyle.Fixed3D;
            PagePanelUnMods.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelUnMods.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelUnMods.TabStop = false;
            PagePanelUnMods.Visible = false;
            this.modManager.Controls.Add(PagePanelUnMods);
            c.addControl(PagePanelUnMods);

            System.Windows.Forms.Label UninstallModsTitle = new System.Windows.Forms.Label();
            UninstallModsTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModsTitle.BackColor = Color.Transparent;
            UninstallModsTitle.ForeColor = SystemColors.Control;
            UninstallModsTitle.TextAlign = ContentAlignment.MiddleCenter;
            UninstallModsTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            UninstallModsTitle.Name = "UninstallModsTitle";
            UninstallModsTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            UninstallModsTitle.Text = "All mods uninstalled";
            PagePanelUnMods.Controls.Add(UninstallModsTitle);

            System.Windows.Forms.Label UninstallModsLabel = new System.Windows.Forms.Label();
            UninstallModsLabel.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            UninstallModsLabel.TextAlign = ContentAlignment.MiddleCenter;
            UninstallModsLabel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(150 * ratioY));
            UninstallModsLabel.Name = "UninstallModsLabel";
            UninstallModsLabel.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(20 * ratioY));
            UninstallModsLabel.Text = "All mods have been succesfully uninstalled !";
            PagePanelUnMods.Controls.Add(UninstallModsLabel);

            Button UninstallModsButton = new System.Windows.Forms.Button();
            UninstallModsButton.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModsButton.Location = new System.Drawing.Point((int)(258 * ratioX), (int)(300 * ratioY));
            UninstallModsButton.Name = "UninstallModsButton";
            UninstallModsButton.Size = new System.Drawing.Size((int)(400 * ratioX), (int)(50 * ratioY));
            UninstallModsButton.Text = "OK";
            UninstallModsButton.TabStop = false;
            UninstallModsButton.Click += new EventHandler(this.events.openMods);
            UninstallModsButton.UseVisualStyleBackColor = true;
            PagePanelUnMods.Controls.Add(UninstallModsButton);

            this.components.Add(c);

            c = new Component("BeforeUpdateMods");

            Panel PagePaneBefUp = new Panel();
            PagePaneBefUp.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePaneBefUp.Name = "PagePaneBefUp";
            PagePaneBefUp.BackColor = Color.Black;
            PagePaneBefUp.BorderStyle = BorderStyle.Fixed3D;
            PagePaneBefUp.BackgroundImageLayout = ImageLayout.Stretch;
            PagePaneBefUp.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePaneBefUp.TabStop = false;
            PagePaneBefUp.Visible = false;
            this.modManager.Controls.Add(PagePaneBefUp);
            c.addControl(PagePaneBefUp);

            System.Windows.Forms.Label UpdateModsTitle = new System.Windows.Forms.Label();
            UpdateModsTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateModsTitle.BackColor = Color.Transparent;
            UpdateModsTitle.ForeColor = SystemColors.Control;
            UpdateModsTitle.TextAlign = ContentAlignment.MiddleCenter;
            UpdateModsTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            UpdateModsTitle.Name = "UpdateModsTitle";
            UpdateModsTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            UpdateModsTitle.Text = "Updating mods";
            PagePaneBefUp.Controls.Add(UpdateModsTitle);

            System.Windows.Forms.Label UpdateModsLabel = new System.Windows.Forms.Label();
            UpdateModsLabel.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            UpdateModsLabel.TextAlign = ContentAlignment.MiddleCenter;
            UpdateModsLabel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(150 * ratioY));
            UpdateModsLabel.Name = "UpdateModsLabel";
            UpdateModsLabel.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(20 * ratioY));
            UpdateModsLabel.Text = "Mod Manager is updating your mods. Please wait ...";
            PagePaneBefUp.Controls.Add(UpdateModsLabel);

            ProgressBar UpdateBar = new ProgressBar();
            UpdateBar.Location = new System.Drawing.Point((int)(300 * ratioX), (int)(300 * ratioY));
            UpdateBar.Size = new System.Drawing.Size((int)(300 * ratioX), (int)(20 * ratioY));
            UpdateBar.Name = "UpdateBar";
            UpdateBar.Maximum = 100;
            UpdateBar.Minimum = 0;
            UpdateBar.Step = 1;
            PagePaneBefUp.Controls.Add(UpdateBar);

            this.components.Add(c);

            c = new Component("BeforeApplyCode");

            Panel PagePanelApplyCode = new Panel();
            PagePanelApplyCode.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelApplyCode.Name = "PagePanelApplyCode";
            PagePanelApplyCode.BackColor = Color.Black;
            PagePanelApplyCode.BorderStyle = BorderStyle.Fixed3D;
            PagePanelApplyCode.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelApplyCode.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelApplyCode.TabStop = false;
            PagePanelApplyCode.Visible = false;
            this.modManager.Controls.Add(PagePanelApplyCode);
            c.addControl(PagePanelApplyCode);

            System.Windows.Forms.Label ApplyCodeTitle = new System.Windows.Forms.Label();
            ApplyCodeTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ApplyCodeTitle.BackColor = Color.Transparent;
            ApplyCodeTitle.ForeColor = SystemColors.Control;
            ApplyCodeTitle.TextAlign = ContentAlignment.MiddleCenter;
            ApplyCodeTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            ApplyCodeTitle.Name = "ApplyCodeTitle";
            ApplyCodeTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            ApplyCodeTitle.Text = "Updating mods";
            PagePanelApplyCode.Controls.Add(ApplyCodeTitle);

            System.Windows.Forms.Label ApplyCodeLabel = new System.Windows.Forms.Label();
            ApplyCodeLabel.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ApplyCodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            ApplyCodeLabel.TextAlign = ContentAlignment.MiddleCenter;
            ApplyCodeLabel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(150 * ratioY));
            ApplyCodeLabel.Name = "ApplyCodeLabel";
            ApplyCodeLabel.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(20 * ratioY));
            ApplyCodeLabel.Text = "Mod Manager is updating your mods. Please wait ...";
            PagePanelApplyCode.Controls.Add(ApplyCodeLabel);

            ProgressBar UpdateCodeBar = new ProgressBar();
            UpdateCodeBar.Location = new System.Drawing.Point((int)(300 * ratioX), (int)(300 * ratioY));
            UpdateCodeBar.Size = new System.Drawing.Size((int)(300 * ratioX), (int)(20 * ratioY));
            UpdateCodeBar.Name = "UpdateCodeBar";
            UpdateCodeBar.Maximum = 100;
            UpdateCodeBar.Minimum = 0;
            UpdateCodeBar.Step = 1;
            PagePanelApplyCode.Controls.Add(UpdateCodeBar);

            this.components.Add(c);

            c = new Component("LocalAdd");

            Panel PagePanelLocal = new Panel();
            PagePanelLocal.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelLocal.Name = "PagePanelLocal";
            PagePanelLocal.BackColor = Color.Black;
            PagePanelLocal.BorderStyle = BorderStyle.Fixed3D;
            PagePanelLocal.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelLocal.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelLocal.TabStop = false;
            PagePanelLocal.Visible = false;
            this.modManager.Controls.Add(PagePanelLocal);
            c.addControl(PagePanelLocal);

            System.Windows.Forms.Label LocalTitle = new System.Windows.Forms.Label();
            LocalTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LocalTitle.BackColor = Color.Transparent;
            LocalTitle.ForeColor = SystemColors.Control;
            LocalTitle.TextAlign = ContentAlignment.MiddleCenter;
            LocalTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            LocalTitle.Name = "LocalTitle";
            LocalTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            LocalTitle.Text = "Add local mod";
            PagePanelLocal.Controls.Add(LocalTitle);

            System.Windows.Forms.Label ModNameLabel = new System.Windows.Forms.Label();
            ModNameLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            ModNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            ModNameLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(90 * ratioY));
            ModNameLabel.Name = "ModNameLabel";
            ModNameLabel.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
            ModNameLabel.Text = "Mod name :";
            PagePanelLocal.Controls.Add(ModNameLabel);

            System.Windows.Forms.TextBox ModNameField = new System.Windows.Forms.TextBox();
            ModNameField.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameField.ForeColor = System.Drawing.SystemColors.ControlText;
            ModNameField.Location = new System.Drawing.Point((int)(200 * ratioX), (int)(90 * ratioY));
            ModNameField.Name = "ModNameField";
            ModNameField.Text = "";
            ModNameField.TabStop = false;
            ModNameField.Size = new System.Drawing.Size((int)(300 * ratioX), (int)(25 * ratioY));
            PagePanelLocal.Controls.Add(ModNameField);

            System.Windows.Forms.Label ModDepsLabel = new System.Windows.Forms.Label();
            ModDepsLabel.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModDepsLabel.ForeColor = System.Drawing.SystemColors.Control;
            ModDepsLabel.TextAlign = ContentAlignment.MiddleLeft;
            ModDepsLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(130 * ratioY));
            ModDepsLabel.Name = "ModDepsLabel";
            ModDepsLabel.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
            ModDepsLabel.Text = "Mod dependencies :";
            PagePanelLocal.Controls.Add(ModDepsLabel);

            int offset = 0;
            foreach (Dependency d in this.modManager.modlist.availableDependencies)
            {
                MMCheckbox ModDepCheckbox = new MMCheckbox(this.modManager);
                ModDepCheckbox.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ModDepCheckbox.ForeColor = System.Drawing.SystemColors.Control;
                ModDepCheckbox.Location = new System.Drawing.Point((int)((20 + 200*(offset%4)) * ratioX), (int)((170 + 40*(offset/4)) * ratioY));
                ModDepCheckbox.Name = d.name;
                ModDepCheckbox.TabStop = false;
                ModDepCheckbox.Size = new System.Drawing.Size((int)(25 * ratioX), (int)(25 * ratioY));
                
                if (offset == 0)
                {
                    ModDepCheckbox.Checked = true;
                }
                
                PagePanelLocal.Controls.Add(ModDepCheckbox);

                System.Windows.Forms.Label ModDepField = new System.Windows.Forms.Label();
                ModDepField.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ModDepField.ForeColor = System.Drawing.SystemColors.Control;
                ModDepField.TextAlign = ContentAlignment.MiddleLeft;
                ModDepField.Location = new System.Drawing.Point((int)((50 + 200*(offset%4)) * ratioX), (int)((170 + 40*(offset/4)) * ratioY));
                ModDepField.Name = "ModDepField" + d.name;
                ModDepField.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
                ModDepField.Text = d.name;
                PagePanelLocal.Controls.Add(ModDepField);

                offset++;
            }

            System.Windows.Forms.Label ModAddField = new System.Windows.Forms.Label();
            ModAddField.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddField.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(300 * ratioY));
            ModAddField.ForeColor = System.Drawing.SystemColors.Control;
            ModAddField.Name = "ModAddField";
            ModAddField.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(30 * ratioY));
            ModAddField.Text = "Mod file :";
            ModAddField.TabStop = false;
            PagePanelLocal.Controls.Add(ModAddField);

            Button ModAddButton = new System.Windows.Forms.Button();
            ModAddButton.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddButton.Location = new System.Drawing.Point((int)(200 * ratioX), (int)(300 * ratioY));
            ModAddButton.Name = "ModAddButton";
            ModAddButton.TextAlign = ContentAlignment.MiddleCenter;
            ModAddButton.Size = new System.Drawing.Size((int)(180 * ratioX), (int)(30 * ratioY));
            ModAddButton.Text = "Select file (zip or dll)";
            ModAddButton.TabStop = false;
            ModAddButton.Click += new EventHandler(this.events.addMod);
            ModAddButton.UseVisualStyleBackColor = true;
            PagePanelLocal.Controls.Add(ModAddButton);

            System.Windows.Forms.Label ModAddFileName = new System.Windows.Forms.Label();
            ModAddFileName.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddFileName.Location = new System.Drawing.Point((int)(400 * ratioX), (int)(300 * ratioY));
            ModAddFileName.TextAlign = ContentAlignment.MiddleLeft;
            ModAddFileName.ForeColor = System.Drawing.SystemColors.Control;
            ModAddFileName.Name = "ModAddFileName";
            ModAddFileName.Size = new System.Drawing.Size((int)(490 * ratioX), (int)(30 * ratioY));
            ModAddFileName.Text = "No file selected";
            ModAddFileName.TabStop = false;
            PagePanelLocal.Controls.Add(ModAddFileName);

            Button ModAddValid = new System.Windows.Forms.Button();
            ModAddValid.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddValid.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(410 * ratioY));
            ModAddValid.Name = "ModAddValid";
            ModAddValid.Size = new System.Drawing.Size((int)(870 * ratioX), (int)(40 * ratioY));
            ModAddValid.Text = "Add mod";
            ModAddValid.TabStop = false;
            ModAddValid.Click += new EventHandler(this.events.validAddMod);
            ModAddValid.UseVisualStyleBackColor = true;
            PagePanelLocal.Controls.Add(ModAddValid);

            this.components.Add(c);

            c = new Component("LocalEdit");

            Panel PagePanelLocalEdit = new Panel();
            PagePanelLocalEdit.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelLocalEdit.Name = "PagePanelLocalEdit";
            PagePanelLocalEdit.BackColor = Color.Black;
            PagePanelLocalEdit.BorderStyle = BorderStyle.Fixed3D;
            PagePanelLocalEdit.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelLocalEdit.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelLocalEdit.TabStop = false;
            PagePanelLocalEdit.Visible = false;
            this.modManager.Controls.Add(PagePanelLocalEdit);
            c.addControl(PagePanelLocalEdit);

            System.Windows.Forms.Label LocalEditTitle = new System.Windows.Forms.Label();
            LocalEditTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LocalEditTitle.BackColor = Color.Transparent;
            LocalEditTitle.ForeColor = SystemColors.Control;
            LocalEditTitle.TextAlign = ContentAlignment.MiddleCenter;
            LocalEditTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            LocalEditTitle.Name = "LocalEditTitle";
            LocalEditTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            LocalEditTitle.Text = "Edit local mod";
            PagePanelLocalEdit.Controls.Add(LocalEditTitle);

            System.Windows.Forms.Label LocalEditId = new System.Windows.Forms.Label();
            LocalEditId.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LocalEditId.BackColor = Color.Transparent;
            LocalEditId.ForeColor = SystemColors.Control;
            LocalEditId.TextAlign = ContentAlignment.MiddleCenter;
            LocalEditId.Location = new System.Drawing.Point(0, 0);
            LocalEditId.Name = "LocalEditId";
            LocalEditId.Size = new System.Drawing.Size(20,20);
            LocalEditId.Visible = false;
            LocalEditId.Text = "";
            PagePanelLocalEdit.Controls.Add(LocalEditId);

            System.Windows.Forms.Label ModNameLabelEdit = new System.Windows.Forms.Label();
            ModNameLabelEdit.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameLabelEdit.ForeColor = System.Drawing.SystemColors.Control;
            ModNameLabelEdit.TextAlign = ContentAlignment.MiddleLeft;
            ModNameLabelEdit.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(90 * ratioY));
            ModNameLabelEdit.Name = "ModNameLabelEdit";
            ModNameLabelEdit.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
            ModNameLabelEdit.Text = "Mod name :";
            PagePanelLocalEdit.Controls.Add(ModNameLabelEdit);

            System.Windows.Forms.TextBox ModNameFieldEdit = new System.Windows.Forms.TextBox();
            ModNameFieldEdit.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameFieldEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            ModNameFieldEdit.Location = new System.Drawing.Point((int)(200 * ratioX), (int)(90 * ratioY));
            ModNameFieldEdit.Name = "ModNameFieldEdit";
            ModNameFieldEdit.Text = "";
            ModNameFieldEdit.TabStop = false;
            ModNameFieldEdit.Size = new System.Drawing.Size((int)(300 * ratioX), (int)(25 * ratioY));
            PagePanelLocalEdit.Controls.Add(ModNameFieldEdit);

            System.Windows.Forms.Label ModDepsLabelEdit = new System.Windows.Forms.Label();
            ModDepsLabelEdit.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModDepsLabelEdit.ForeColor = System.Drawing.SystemColors.Control;
            ModDepsLabelEdit.TextAlign = ContentAlignment.MiddleLeft;
            ModDepsLabelEdit.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(130 * ratioY));
            ModDepsLabelEdit.Name = "ModDepsLabel";
            ModDepsLabelEdit.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
            ModDepsLabelEdit.Text = "Mod dependencies :";
            PagePanelLocalEdit.Controls.Add(ModDepsLabelEdit);

            offset = 0;
            foreach (Dependency d in this.modManager.modlist.availableDependencies)
            {
                MMCheckbox ModDepCheckbox = new MMCheckbox(this.modManager);
                ModDepCheckbox.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ModDepCheckbox.ForeColor = System.Drawing.SystemColors.Control;
                ModDepCheckbox.Location = new System.Drawing.Point((int)((20 + 200 * (offset % 4)) * ratioX), (int)((170 + 40 * (offset / 4)) * ratioY));
                ModDepCheckbox.Name = d.name;
                ModDepCheckbox.TabStop = false;
                ModDepCheckbox.Size = new System.Drawing.Size((int)(25 * ratioX), (int)(25 * ratioY));

                PagePanelLocalEdit.Controls.Add(ModDepCheckbox);

                System.Windows.Forms.Label ModDepField = new System.Windows.Forms.Label();
                ModDepField.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ModDepField.ForeColor = System.Drawing.SystemColors.Control;
                ModDepField.TextAlign = ContentAlignment.MiddleLeft;
                ModDepField.Location = new System.Drawing.Point((int)((50 + 200 * (offset % 4)) * ratioX), (int)((170 + 40 * (offset / 4)) * ratioY));
                ModDepField.Name = "ModDepField" + d.name;
                ModDepField.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
                ModDepField.Text = d.name;
                PagePanelLocalEdit.Controls.Add(ModDepField);

                offset++;
            }

            System.Windows.Forms.Label ModAddFieldEdit = new System.Windows.Forms.Label();
            ModAddFieldEdit.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddFieldEdit.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(300 * ratioY));
            ModAddFieldEdit.ForeColor = System.Drawing.SystemColors.Control;
            ModAddFieldEdit.Name = "ModAddFieldEdit";
            ModAddFieldEdit.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(30 * ratioY));
            ModAddFieldEdit.Text = "Mod file :";
            ModAddFieldEdit.TabStop = false;
            PagePanelLocalEdit.Controls.Add(ModAddFieldEdit);

            Button ModAddButtonEdit = new System.Windows.Forms.Button();
            ModAddButtonEdit.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddButtonEdit.Location = new System.Drawing.Point((int)(200 * ratioX), (int)(300 * ratioY));
            ModAddButtonEdit.Name = "ModAddButtonEdit";
            ModAddButtonEdit.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(30 * ratioY));
            ModAddButtonEdit.Text = "Select file";
            ModAddButtonEdit.TabStop = false;
            ModAddButtonEdit.Click += new EventHandler(this.events.editMod);
            ModAddButtonEdit.UseVisualStyleBackColor = true;
            PagePanelLocalEdit.Controls.Add(ModAddButtonEdit);

            System.Windows.Forms.Label ModAddFileNameEdit = new System.Windows.Forms.Label();
            ModAddFileNameEdit.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddFileNameEdit.Location = new System.Drawing.Point((int)(370 * ratioX), (int)(300 * ratioY));
            ModAddFileNameEdit.TextAlign = ContentAlignment.MiddleLeft;
            ModAddFileNameEdit.ForeColor = System.Drawing.SystemColors.Control;
            ModAddFileNameEdit.Name = "ModAddFileNameEdit";
            ModAddFileNameEdit.Size = new System.Drawing.Size((int)(520 * ratioX), (int)(30 * ratioY));
            ModAddFileNameEdit.Text = "No file selected";
            ModAddFileNameEdit.TabStop = false;
            PagePanelLocalEdit.Controls.Add(ModAddFileNameEdit);

            Button ModEditValid = new System.Windows.Forms.Button();
            ModEditValid.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModEditValid.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(410 * ratioY));
            ModEditValid.Name = "ModEditValid";
            ModEditValid.Size = new System.Drawing.Size((int)(870 * ratioX), (int)(40 * ratioY));
            ModEditValid.Text = "Edit mod";
            ModEditValid.TabStop = false;
            ModEditValid.Click += new EventHandler(this.events.validEditMod);
            ModEditValid.UseVisualStyleBackColor = true;
            PagePanelLocalEdit.Controls.Add(ModEditValid);

            this.components.Add(c);

            c = new Component("Unreacheable");

            Panel PagePanelUnreacheable = new Panel();
            PagePanelUnreacheable.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelUnreacheable.Name = "PagePanelUnreacheable";
            PagePanelUnreacheable.BackColor = Color.Black;
            PagePanelUnreacheable.BorderStyle = BorderStyle.Fixed3D;
            PagePanelUnreacheable.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelUnreacheable.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelUnreacheable.TabStop = false;
            PagePanelUnreacheable.Visible = false;
            this.modManager.Controls.Add(PagePanelUnreacheable);
            c.addControl(PagePanelUnreacheable);

            System.Windows.Forms.Label UnreacheableTitle = new System.Windows.Forms.Label();
            UnreacheableTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnreacheableTitle.BackColor = Color.Transparent;
            UnreacheableTitle.ForeColor = SystemColors.Control;
            UnreacheableTitle.TextAlign = ContentAlignment.MiddleCenter;
            UnreacheableTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            UnreacheableTitle.Name = "UnreacheableTitle";
            UnreacheableTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            UnreacheableTitle.Text = "Server unreacheable";
            PagePanelUnreacheable.Controls.Add(UnreacheableTitle);

            System.Windows.Forms.Label UnreacheableLabel = new System.Windows.Forms.Label();
            UnreacheableLabel.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnreacheableLabel.ForeColor = System.Drawing.SystemColors.Control;
            UnreacheableLabel.TextAlign = ContentAlignment.TopLeft;
            UnreacheableLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(150 * ratioY));
            UnreacheableLabel.Name = "UnreacheableLabel";
            UnreacheableLabel.Size = new System.Drawing.Size((int)(896 * ratioX), (int)(300 * ratioY));
            UnreacheableLabel.Text = "Mod Manager's server is unreacheable.\n" +
                "\n" +
                "There are many possible reasons for this :\n" +
                "- You are disconnected from internet\n" +
                "- Your antivirus blocks Mod Manager\n" +
                "- Mod Manager server is down. Check its status on matux.fr\n" +
                "\n" +
                "If this problem persists, please send a ticket on Mod Manager's discord.";
            PagePanelUnreacheable.Controls.Add(UnreacheableLabel);

            this.components.Add(c);

            c = new Component("UnsavedChanges");

            Panel PagePanelUnsavedChanges = new Panel();
            PagePanelUnsavedChanges.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelUnsavedChanges.Name = "PagePanelUnsavedChanges";
            PagePanelUnsavedChanges.BackColor = Color.Black;
            PagePanelUnsavedChanges.BorderStyle = BorderStyle.Fixed3D;
            PagePanelUnsavedChanges.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelUnsavedChanges.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelUnsavedChanges.TabStop = false;
            PagePanelUnsavedChanges.Visible = false;
            this.modManager.Controls.Add(PagePanelUnsavedChanges);
            c.addControl(PagePanelUnsavedChanges);

            System.Windows.Forms.Label UnsavedChangesTitle = new System.Windows.Forms.Label();
            UnsavedChangesTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnsavedChangesTitle.BackColor = Color.Transparent;
            UnsavedChangesTitle.ForeColor = SystemColors.Control;
            UnsavedChangesTitle.TextAlign = ContentAlignment.MiddleCenter;
            UnsavedChangesTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            UnsavedChangesTitle.Name = "UnsavedChangesTitle";
            UnsavedChangesTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            UnsavedChangesTitle.Text = "Unsaved Changes";
            PagePanelUnsavedChanges.Controls.Add(UnsavedChangesTitle);

            System.Windows.Forms.Label UnsavedChangesLabel = new System.Windows.Forms.Label();
            UnsavedChangesLabel.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnsavedChangesLabel.ForeColor = System.Drawing.SystemColors.Control;
            UnsavedChangesLabel.TextAlign = ContentAlignment.TopCenter;
            UnsavedChangesLabel.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(150 * ratioY));
            UnsavedChangesLabel.Name = "UnsavedChangesLabel";
            UnsavedChangesLabel.Size = new System.Drawing.Size((int)(896 * ratioX), (int)(50 * ratioY));
            UnsavedChangesLabel.Text = "There are unsaved changes in your mod configuration.\n" +
                "Do you want to save them before starting game ?";
            PagePanelUnsavedChanges.Controls.Add(UnsavedChangesLabel);

            PictureBox SaveChanges = new System.Windows.Forms.PictureBox();
            SaveChanges.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SaveChanges.Location = new System.Drawing.Point((int)(80 * ratioX), (int)(300 * ratioY));
            SaveChanges.BackgroundImage = global::ModManager4.Properties.Resources.save;
            SaveChanges.BackgroundImageLayout = ImageLayout.Stretch;
            SaveChanges.Name = "SaveChanges";
            SaveChanges.Size = new System.Drawing.Size((int)(300 * ratioX), (int)(80 * ratioY));
            SaveChanges.Cursor = Cursors.Hand;
            SaveChanges.TabStop = false;
            SaveChanges.Click += new EventHandler(this.events.saveAndStart);
            PagePanelUnsavedChanges.Controls.Add(SaveChanges);

            PictureBox StartAnyway = new System.Windows.Forms.PictureBox();
            StartAnyway.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            StartAnyway.Location = new System.Drawing.Point((int)(450 * ratioX), (int)(300 * ratioY));
            StartAnyway.BackgroundImage = global::ModManager4.Properties.Resources.dontsave;
            StartAnyway.BackgroundImageLayout = ImageLayout.Stretch;
            StartAnyway.Name = "StartAnyway";
            StartAnyway.Size = new System.Drawing.Size((int)(400 * ratioX), (int)(80 * ratioY));
            StartAnyway.Cursor = Cursors.Hand;
            StartAnyway.TabStop = false;
            StartAnyway.Click += new EventHandler(this.events.startAnyway);
            PagePanelUnsavedChanges.Controls.Add(StartAnyway);

            this.components.Add(c);

            c = new Component("Servers");

            c = this.loadServers(c);

            this.components.Add(c);

            c = new Component("WIP");

            Panel PagePanelWIP = new Panel();
            PagePanelWIP.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelWIP.Name = "PagePanelWIP";
            PagePanelWIP.BackColor = Color.Black;
            PagePanelWIP.BorderStyle = BorderStyle.Fixed3D;
            PagePanelWIP.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelWIP.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelWIP.TabStop = false;
            PagePanelWIP.Visible = false;
            this.modManager.Controls.Add(PagePanelWIP);
            c.addControl(PagePanelWIP);

            System.Windows.Forms.Label WIPTitle = new System.Windows.Forms.Label();
            WIPTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            WIPTitle.BackColor = Color.Transparent;
            WIPTitle.ForeColor = SystemColors.Control;
            WIPTitle.TextAlign = ContentAlignment.MiddleCenter;
            WIPTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            WIPTitle.Name = "WIPTitle";
            WIPTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            WIPTitle.Text = "Work In progress";
            PagePanelWIP.Controls.Add(WIPTitle);

            System.Windows.Forms.Label WIPLabel = new System.Windows.Forms.Label();
            WIPLabel.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            WIPLabel.ForeColor = System.Drawing.SystemColors.Control;
            WIPLabel.TextAlign = ContentAlignment.MiddleCenter;
            WIPLabel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(150 * ratioY));
            WIPLabel.Name = "WIPLabel";
            WIPLabel.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            WIPLabel.Text = "This page is being developped and is unavailable for now.";
            PagePanelWIP.Controls.Add(WIPLabel);

            this.components.Add(c);

            c = new Component("Disabled");

            Panel PagePanelDisabled = new Panel();
            PagePanelDisabled.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelDisabled.Name = "PagePanelDisabled";
            PagePanelDisabled.BackColor = Color.Black;
            PagePanelDisabled.BorderStyle = BorderStyle.Fixed3D;
            PagePanelDisabled.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelDisabled.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelDisabled.TabStop = false;
            PagePanelDisabled.Visible = false;
            this.modManager.Controls.Add(PagePanelDisabled);
            c.addControl(PagePanelDisabled);

            System.Windows.Forms.Label DisabledTitle = new System.Windows.Forms.Label();
            DisabledTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DisabledTitle.BackColor = Color.Transparent;
            DisabledTitle.ForeColor = SystemColors.Control;
            DisabledTitle.TextAlign = ContentAlignment.MiddleCenter;
            DisabledTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            DisabledTitle.Name = "DisabledTitle";
            DisabledTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            DisabledTitle.Text = "Mod Manager disabled";
            PagePanelDisabled.Controls.Add(DisabledTitle);

            System.Windows.Forms.Label DisabledLabel = new System.Windows.Forms.Label();
            DisabledLabel.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DisabledLabel.ForeColor = System.Drawing.SystemColors.Control;
            DisabledLabel.TextAlign = ContentAlignment.MiddleCenter;
            DisabledLabel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(150 * ratioY));
            DisabledLabel.Name = "UpdateModsLabel";
            DisabledLabel.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(150 * ratioY));
            DisabledLabel.Text = "Mod Manager has been temporary disabled !\n" +
                "Mod Manager will be back again soon !\n\n" +
                "Please, consider joining the discord (link on github) to get notified when it goes live again.\n\n" +
                "Thanks for your patience !";
            PagePanelDisabled.Controls.Add(DisabledLabel);

            this.components.Add(c);

        }

        public void renderComponents(string[] components)
        {
            foreach (Component c in this.components)
            {
                if (components.Contains(c.name))
                {
                    c.show();
                } else
                {
                    c.hide();
                }
            }
        }

        public void refreshModSelection()
        {
            Component c = this.get("ModSelection");
            c.removeControls();
            c = this.loadModPage(c);
        }

        public void refreshServers()
        {
            Component c = this.get("Servers");
            c.removeControls();
            c = this.loadServers(c);
        }

        public Component loadModPage(Component c) { 
        
            Fontlist fonts = new Fontlist(this.modManager.config.resolutionY);

            double ratioX = (double)this.modManager.config.resolutionX / 1300.0;
            double ratioY = (double)this.modManager.config.resolutionY / 810.0;

            PictureBox UpdateModsPic = new System.Windows.Forms.PictureBox();
            UpdateModsPic.Image = global::ModManager4.Properties.Resources.update;
            UpdateModsPic.BackColor = System.Drawing.Color.Transparent;
            UpdateModsPic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(250 * ratioY));
            UpdateModsPic.Name = "UpdateModsPic";
            UpdateModsPic.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(100 * ratioY));
            UpdateModsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            UpdateModsPic.TabStop = false;
            UpdateModsPic.Cursor = Cursors.Hand;
            UpdateModsPic.Click += new EventHandler(this.events.updateMods);
            UpdateModsPic.MouseLeave += new EventHandler(this.tooltips.hide);
            UpdateModsPic.MouseHover += new EventHandler(this.tooltips.show);
            UpdateModsPic.Visible = false;
            this.modManager.Controls.Add(UpdateModsPic);
            c.addControl(UpdateModsPic);

            PictureBox RemoveModsPic = new System.Windows.Forms.PictureBox();
            RemoveModsPic.Image = global::ModManager4.Properties.Resources.uninstallall;
            RemoveModsPic.BackColor = System.Drawing.Color.Transparent;
            RemoveModsPic.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(450 * ratioY));
            RemoveModsPic.Name = "RemoveModsPic";
            RemoveModsPic.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(100 * ratioY));
            RemoveModsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            RemoveModsPic.TabStop = false;
            RemoveModsPic.Cursor = Cursors.Hand;
            RemoveModsPic.MouseLeave += new EventHandler(this.tooltips.hide);
            RemoveModsPic.MouseHover += new EventHandler(this.tooltips.show);
            RemoveModsPic.Click += new EventHandler(this.events.uninstallMods);
            RemoveModsPic.Visible = false;
            this.modManager.Controls.Add(RemoveModsPic);
            c.addControl(RemoveModsPic);

            PictureBox AddLocalPic = new System.Windows.Forms.PictureBox();
            AddLocalPic.Image = global::ModManager4.Properties.Resources.localadd;
            AddLocalPic.BackColor = System.Drawing.Color.Transparent;
            AddLocalPic.Location = new System.Drawing.Point((int)(1130 * ratioX), (int)(220 * ratioY));
            AddLocalPic.Name = "AddLocalPic";
            AddLocalPic.Size = new System.Drawing.Size((int)(110 * ratioX), (int)(80 * ratioY));
            AddLocalPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            AddLocalPic.TabStop = false;
            AddLocalPic.Cursor = Cursors.Hand;
            AddLocalPic.MouseLeave += new EventHandler(this.tooltips.hide);
            AddLocalPic.MouseHover += new EventHandler(this.tooltips.show);
            AddLocalPic.Click += new EventHandler(this.events.localAdd);
            AddLocalPic.Visible = false;
            this.modManager.Controls.Add(AddLocalPic);
            c.addControl(AddLocalPic);

            PictureBox BetterCrewlinkPic = new System.Windows.Forms.PictureBox();
            BetterCrewlinkPic.Image = global::ModManager4.Properties.Resources.bettercrewlink;
            BetterCrewlinkPic.BackColor = System.Drawing.Color.Transparent;
            BetterCrewlinkPic.Location = new System.Drawing.Point((int)(1130 * ratioX), (int)(360 * ratioY));
            BetterCrewlinkPic.Name = "BetterCrewlinkPic";
            BetterCrewlinkPic.Size = new System.Drawing.Size((int)(110 * ratioX), (int)(110 * ratioY));
            BetterCrewlinkPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BetterCrewlinkPic.TabStop = false;
            BetterCrewlinkPic.Cursor = Cursors.Hand;
            BetterCrewlinkPic.MouseLeave += new EventHandler(this.tooltips.hide);
            BetterCrewlinkPic.MouseHover += new EventHandler(this.tooltips.show);
            BetterCrewlinkPic.Click += new EventHandler(this.events.openBcl);
            BetterCrewlinkPic.Visible = false;
            this.modManager.Controls.Add(BetterCrewlinkPic);
            c.addControl(BetterCrewlinkPic);

            PictureBox ServersPic = new System.Windows.Forms.PictureBox();
            ServersPic.Image = global::ModManager4.Properties.Resources.server;
            ServersPic.BackColor = System.Drawing.Color.Transparent;
            ServersPic.Location = new System.Drawing.Point((int)(1130 * ratioX), (int)(520 * ratioY));
            ServersPic.Name = "ServersPic";
            ServersPic.Size = new System.Drawing.Size((int)(110 * ratioX), (int)(100 * ratioY));
            ServersPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ServersPic.TabStop = false;
            ServersPic.Cursor = Cursors.Hand;
            ServersPic.MouseLeave += new EventHandler(this.tooltips.hide);
            ServersPic.MouseHover += new EventHandler(this.tooltips.show);
            ServersPic.Click += new EventHandler(this.events.openServers);
            ServersPic.Visible = false;
            this.modManager.Controls.Add(ServersPic);
            c.addControl(ServersPic);

            Panel PagePanel = new Panel();
            PagePanel.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanel.Name = "PagePanel";
            PagePanel.BackColor = Color.Black;
            PagePanel.BorderStyle = BorderStyle.Fixed3D;
            PagePanel.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanel.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanel.TabStop = false;
            PagePanel.Visible = false;
            this.modManager.Controls.Add(PagePanel);
            c.addControl(PagePanel);

            System.Windows.Forms.Label CheckedTitle = new System.Windows.Forms.Label();
            CheckedTitle.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CheckedTitle.BackColor = Color.Transparent;
            CheckedTitle.ForeColor = SystemColors.Control;
            CheckedTitle.Location = new System.Drawing.Point((int)(30 * ratioX), (int)(20 * ratioY));
            CheckedTitle.Name = "Sort=Checked";
            CheckedTitle.Size = new System.Drawing.Size((int)(30 * ratioX), (int)(20 * ratioY));
            CheckedTitle.Text = "X";
            CheckedTitle.Click += new EventHandler(this.events.sortMods);
            CheckedTitle.Cursor = Cursors.Hand;
            PagePanel.Controls.Add(CheckedTitle);

            System.Windows.Forms.Label ModNameTitle = new System.Windows.Forms.Label();
            ModNameTitle.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameTitle.BackColor = Color.Transparent;
            ModNameTitle.ForeColor = SystemColors.Control;
            ModNameTitle.Location = new System.Drawing.Point((int)(60 * ratioX), (int)(20 * ratioY));
            ModNameTitle.Name = "Sort=Name";
            ModNameTitle.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(20 * ratioY));
            ModNameTitle.Text = "Name";
            ModNameTitle.Click += new EventHandler(this.events.sortMods);
            ModNameTitle.Cursor = Cursors.Hand;
            PagePanel.Controls.Add(ModNameTitle);

            System.Windows.Forms.Label ModAuthorTitle = new System.Windows.Forms.Label();
            ModAuthorTitle.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAuthorTitle.BackColor = Color.Transparent;
            ModAuthorTitle.ForeColor = SystemColors.Control;
            ModAuthorTitle.Location = new System.Drawing.Point((int)(210 * ratioX), (int)(20 * ratioY));
            ModAuthorTitle.Name = "Sort=Author";
            ModAuthorTitle.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(20 * ratioY));
            ModAuthorTitle.Text = "Author";
            ModAuthorTitle.Click += new EventHandler(this.events.sortMods);
            ModAuthorTitle.Cursor = Cursors.Hand;
            PagePanel.Controls.Add(ModAuthorTitle);

            System.Windows.Forms.Label ModVersionTitle = new System.Windows.Forms.Label();
            ModVersionTitle.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModVersionTitle.BackColor = Color.Transparent;
            ModVersionTitle.ForeColor = SystemColors.Control;
            ModVersionTitle.Location = new System.Drawing.Point((int)(360 * ratioX), (int)(20 * ratioY));
            ModVersionTitle.Name = "Sort=Version";
            ModVersionTitle.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(20 * ratioY));
            ModVersionTitle.Text = "Version";
            ModVersionTitle.Click += new EventHandler(this.events.sortMods);
            ModVersionTitle.Cursor = Cursors.Hand;
            PagePanel.Controls.Add(ModVersionTitle);

            System.Windows.Forms.Label ModGithubTitle = new System.Windows.Forms.Label();
            ModGithubTitle.Font = new System.Drawing.Font("Arial", fonts.sizeL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModGithubTitle.ForeColor = SystemColors.Control;
            ModGithubTitle.Location = new System.Drawing.Point((int)(510 * ratioX), (int)(20 * ratioY));
            ModGithubTitle.Name = "ModGithubTitle";
            ModGithubTitle.Size = new System.Drawing.Size((int)(396 * ratioX), (int)(20 * ratioY));
            ModGithubTitle.Text = "More information";
            PagePanel.Controls.Add(ModGithubTitle);

            Panel ModsGroupbox = new Panel();
            ModsGroupbox.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(45 * ratioY));
            ModsGroupbox.Name = "ModsGroupbox";
            ModsGroupbox.Size = new System.Drawing.Size((int)(876 * ratioX), (int)(410 * ratioY));
            ModsGroupbox.AutoScroll = false;
            ModsGroupbox.HorizontalScroll.Enabled = false;
            ModsGroupbox.HorizontalScroll.Visible = false;
            ModsGroupbox.HorizontalScroll.Maximum = 0;
            ModsGroupbox.AutoScroll = true;
            ModsGroupbox.TabStop = false;
            PagePanel.Controls.Add(ModsGroupbox);

            int i = 0;
            int offset = 10;
            foreach (string cat in this.modManager.modlist.getAvailableCategories())
            {
                Panel CategoryTitlePanel = new Panel();
                CategoryTitlePanel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(offset * ratioY));
                CategoryTitlePanel.Name = "CategoryTitlePanel=" + cat;
                CategoryTitlePanel.BackColor = Color.Black;
                CategoryTitlePanel.BorderStyle = BorderStyle.FixedSingle;
                CategoryTitlePanel.BackgroundImageLayout = ImageLayout.Stretch;
                CategoryTitlePanel.Size = new System.Drawing.Size((int)(850 * ratioX), (int)(30 * ratioY));
                CategoryTitlePanel.Padding = new Padding(10);
                CategoryTitlePanel.Click += new EventHandler(this.events.rollCategory);
                CategoryTitlePanel.TabStop = false;
                CategoryTitlePanel.Cursor = Cursors.Hand;
                ModsGroupbox.Controls.Add(CategoryTitlePanel);

                // Affichage Mod
                System.Windows.Forms.Label CategoryField = new System.Windows.Forms.Label();
                CategoryField.Font = new System.Drawing.Font("Arial", fonts.sizeM, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                CategoryField.ForeColor = System.Drawing.SystemColors.Control;
                CategoryField.Location = new System.Drawing.Point((int)(5 * ratioX), (int)(5 * ratioY));
                CategoryField.Name = "CategoryField=" + cat;
                CategoryField.Size = new System.Drawing.Size((int)(780 * ratioX), (int)(20 * ratioY));
                CategoryField.Text = cat;
                CategoryField.Click += new EventHandler(this.events.rollCategory);
                CategoryTitlePanel.Controls.Add(CategoryField);

                PictureBox CategoryArrowPic = new System.Windows.Forms.PictureBox();

                if (this.modManager.config.hiddenCategories.Contains(cat))
                {
                    CategoryArrowPic.Image = global::ModManager4.Properties.Resources.up;
                } else
                {
                    CategoryArrowPic.Image = global::ModManager4.Properties.Resources.down;
                }
                    
                CategoryArrowPic.BackColor = System.Drawing.Color.Transparent;
                CategoryArrowPic.Location = new System.Drawing.Point((int)(820 * ratioX), (int)(5 * ratioY));
                CategoryArrowPic.Name = "CategoryArrowPic=" + cat;
                CategoryArrowPic.Size = new System.Drawing.Size((int)(20 * ratioX), (int)(20 * ratioY));
                CategoryArrowPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                CategoryArrowPic.TabStop = false;
                CategoryArrowPic.Click += new EventHandler(this.events.rollCategory);
                CategoryTitlePanel.Controls.Add(CategoryArrowPic);

                offset = offset + 50;

                Panel CategoryPanel = new Panel();
                CategoryPanel.Location = new System.Drawing.Point((int)(10 * ratioX), (int)(offset * ratioY));
                CategoryPanel.Name = "CategoryPanel="+ cat;
                CategoryPanel.BackColor = Color.Black;
                CategoryPanel.BackgroundImageLayout = ImageLayout.Stretch;
                CategoryPanel.TabStop = false;
                ModsGroupbox.Controls.Add(CategoryPanel);

                int categoryOffset = 0;

                if (this.modManager.config.hiddenCategories.Contains(cat) == false)
                {
                    foreach (Mod mod in this.modManager.modlist.getAvailableModsByCategory(cat))
                    {
                        if (mod.type == "mod" || mod.type == "localMod")
                        {
                            MMCheckbox ModCheckbox = new MMCheckbox(this.modManager);
                            ModCheckbox.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            ModCheckbox.ForeColor = System.Drawing.SystemColors.Control;
                            ModCheckbox.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(categoryOffset * ratioY));
                            ModCheckbox.Name = mod.id;
                            ModCheckbox.TabStop = false;
                            ModCheckbox.Size = new System.Drawing.Size((int)(20 * ratioX), (int)(20 * ratioY));
                            ModCheckbox.Click += new EventHandler(this.events.checkBox);

                            if ((this.modManager.config.containsMod(mod.id) && this.modManager.modlist.toUninstall.Contains(mod.id) == false) || this.modManager.modlist.toInstall.Contains(mod.id))
                            {
                                ModCheckbox.Checked = true;
                            }

                            CategoryPanel.Controls.Add(ModCheckbox);

                        }
                        else
                        {
                            if (this.modManager.config.containsMod(mod.id) == false)
                            {
                                // Download
                                PictureBox ModDownload = new System.Windows.Forms.PictureBox();
                                ModDownload.Image = global::ModManager4.Properties.Resources.download;
                                ModDownload.BackColor = System.Drawing.Color.Transparent;
                                ModDownload.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(categoryOffset * ratioY));
                                ModDownload.Name = "ModDownload=" + mod.id;
                                ModDownload.Size = new System.Drawing.Size((int)(20 * ratioX), (int)(20 * ratioY));
                                ModDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                ModDownload.TabStop = false;
                                ModDownload.Cursor = Cursors.Hand;
                                ModDownload.Click += new EventHandler(this.events.downloadAllInOne);
                                CategoryPanel.Controls.Add(ModDownload);
                            }
                            else if (mod.id == "Challenger" && this.modManager.config.getInstalledModById(mod.id).version != this.modManager.modlist.challengerMod.TagName)
                            {
                                // Update
                                PictureBox ModDownload = new System.Windows.Forms.PictureBox();
                                ModDownload.Image = global::ModManager4.Properties.Resources.updateMod;
                                ModDownload.BackColor = System.Drawing.Color.Transparent;
                                ModDownload.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(categoryOffset * ratioY));
                                ModDownload.Name = "ModDownload=" + mod.id;
                                ModDownload.Size = new System.Drawing.Size((int)(20 * ratioX), (int)(20 * ratioY));
                                ModDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                ModDownload.TabStop = false;
                                ModDownload.Cursor = Cursors.Hand;
                                ModDownload.Click += new EventHandler(this.events.downloadAllInOne);
                                CategoryPanel.Controls.Add(ModDownload);
                            }
                            else
                            {
                                // Play
                                PictureBox ModPlay = new System.Windows.Forms.PictureBox();
                                ModPlay.Image = global::ModManager4.Properties.Resources.play;
                                ModPlay.BackColor = System.Drawing.Color.Transparent;
                                ModPlay.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(categoryOffset * ratioY));
                                ModPlay.Name = "ModPlay=" + mod.id;
                                ModPlay.Size = new System.Drawing.Size((int)(15 * ratioX), (int)(15 * ratioY));
                                ModPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                ModPlay.TabStop = false;
                                ModPlay.Cursor = Cursors.Hand;
                                ModPlay.Click += new EventHandler(this.events.startAllInOne);
                                CategoryPanel.Controls.Add(ModPlay);
                            }
                        }

                        System.Windows.Forms.Label ModNameField = new System.Windows.Forms.Label();
                        ModNameField.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ModNameField.ForeColor = System.Drawing.SystemColors.Control;
                        ModNameField.Location = new System.Drawing.Point((int)(30 * ratioX), (int)(categoryOffset * ratioY));
                        ModNameField.Name = "ModNameField=" + mod.id;
                        ModNameField.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(20 * ratioY));
                        ModNameField.Text = mod.name;
                        CategoryPanel.Controls.Add(ModNameField);


                        if (mod.author != "")
                        {
                            System.Windows.Forms.LinkLabel ModAuthorField = new System.Windows.Forms.LinkLabel();
                            ModAuthorField.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            ModAuthorField.LinkColor = System.Drawing.SystemColors.Control;
                            ModAuthorField.ForeColor = System.Drawing.SystemColors.Control;
                            ModAuthorField.Location = new System.Drawing.Point((int)(180 * ratioX), (int)(categoryOffset * ratioY));
                            ModAuthorField.Name = "ModAuthorField=" + mod.id;
                            ModAuthorField.TabStop = false;
                            ModAuthorField.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(20 * ratioY));
                            ModAuthorField.Text = mod.author;

                            if (mod.type == "mod" || mod.id == "Challenger")
                            {
                                ModAuthorField.Click += new EventHandler(this.events.openAuthorGithub);
                            }
                            if (mod.type == "localMod")
                            {
                                ModAuthorField.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                            }
                            if (mod.id == "Skeld")
                            {
                                ModAuthorField.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                            }
                            CategoryPanel.Controls.Add(ModAuthorField);
                        }

                        System.Windows.Forms.Label ModVersionField = new System.Windows.Forms.Label();
                        ModVersionField.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ModVersionField.ForeColor = System.Drawing.SystemColors.Control;
                        ModVersionField.Location = new System.Drawing.Point((int)(330 * ratioX), (int)(categoryOffset * ratioY));
                        ModVersionField.Name = "ModVersionField=" + mod.id;
                        ModVersionField.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(20 * ratioY));
                        if (mod.type == "mod")
                        {
                            ModVersionField.Text = mod.release.TagName;
                        }
                        else
                        {
                            ModVersionField.Text = "";
                        }
                        CategoryPanel.Controls.Add(ModVersionField);

                        if (mod.type == "mod" || mod.type == "allInOne")
                        {
                            System.Windows.Forms.LinkLabel ModGithubField = new System.Windows.Forms.LinkLabel();
                            ModGithubField.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            ModGithubField.LinkColor = System.Drawing.SystemColors.Control;
                            ModGithubField.ForeColor = System.Drawing.SystemColors.Control;
                            ModGithubField.Location = new System.Drawing.Point((int)(480 * ratioX), (int)(categoryOffset * ratioY));
                            ModGithubField.Name = "ModGithubField=" + mod.id;
                            ModGithubField.Size = new System.Drawing.Size((int)(400 * ratioX), (int)(20 * ratioY));
                            ModGithubField.TabStop = false;

                            if (mod.type == "mod")
                            {
                                ModGithubField.Text = "https://github.com/" + mod.author + "/" + mod.github;
                            }
                            else if (mod.id == "Challenger")
                            {
                                ModGithubField.Text = "https://github.com/" + mod.author + "/" + mod.github;
                            }
                            else if (mod.id == "Skeld")
                            {
                                ModGithubField.Text = mod.github;
                            }

                            ModGithubField.Click += new EventHandler(this.events.openGithub);

                            CategoryPanel.Controls.Add(ModGithubField);
                        }

                        else
                        {

                            PictureBox EditLocalField = new System.Windows.Forms.PictureBox();
                            EditLocalField.Image = global::ModManager4.Properties.Resources.edit;
                            EditLocalField.BackColor = System.Drawing.Color.Transparent;
                            EditLocalField.Location = new System.Drawing.Point((int)(770 * ratioX), (int)(categoryOffset * ratioY));
                            EditLocalField.Name = "EditLocalField=" + mod.id;
                            EditLocalField.Size = new System.Drawing.Size((int)(20 * ratioX), (int)(20 * ratioY));
                            EditLocalField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            EditLocalField.TabStop = false;
                            EditLocalField.Cursor = Cursors.Hand;
                            EditLocalField.Click += new EventHandler(this.events.editLocalMod);

                            CategoryPanel.Controls.Add(EditLocalField);

                            PictureBox RemoveLocalField = new System.Windows.Forms.PictureBox();
                            RemoveLocalField.Image = global::ModManager4.Properties.Resources.remove;
                            RemoveLocalField.BackColor = System.Drawing.Color.Transparent;
                            RemoveLocalField.Location = new System.Drawing.Point((int)(800 * ratioX), (int)(categoryOffset * ratioY));
                            RemoveLocalField.Name = "RemoveLocalField=" + mod.id;
                            RemoveLocalField.Size = new System.Drawing.Size((int)(20 * ratioX), (int)(20 * ratioY));
                            RemoveLocalField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            RemoveLocalField.TabStop = false;
                            RemoveLocalField.Cursor = Cursors.Hand;
                            RemoveLocalField.Click += new EventHandler(this.events.removeLocalMod);

                            CategoryPanel.Controls.Add(RemoveLocalField);

                        }


                        categoryOffset = categoryOffset + 30;
                    }
                }

                CategoryPanel.Size = new System.Drawing.Size((int)(820 * ratioX), (int)(categoryOffset * ratioY));
                offset = offset + categoryOffset;

                i++;
            }

            return c;
        }

        public Component loadServers(Component c)
        {

            Fontlist fonts = new Fontlist(this.modManager.config.resolutionY);

            double ratioX = (double)this.modManager.config.resolutionX / 1300.0;
            double ratioY = (double)this.modManager.config.resolutionY / 810.0;

            Panel PagePanelServers = new Panel();
            PagePanelServers.Location = new System.Drawing.Point((int)(184 * ratioX), (int)(190 * ratioY));
            PagePanelServers.Name = "PagePanelServers";
            PagePanelServers.BackColor = Color.Black;
            PagePanelServers.BorderStyle = BorderStyle.Fixed3D;
            PagePanelServers.BackgroundImageLayout = ImageLayout.Stretch;
            PagePanelServers.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(477 * ratioY));
            PagePanelServers.TabStop = false;
            PagePanelServers.Visible = false;
            this.modManager.Controls.Add(PagePanelServers);
            c.addControl(PagePanelServers);

            System.Windows.Forms.Label ServersTitle = new System.Windows.Forms.Label();
            ServersTitle.Font = new System.Drawing.Font("Arial", fonts.sizeXL, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServersTitle.BackColor = Color.Transparent;
            ServersTitle.ForeColor = SystemColors.Control;
            ServersTitle.TextAlign = ContentAlignment.MiddleCenter;
            ServersTitle.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(20 * ratioY));
            ServersTitle.Name = "ServersTitle";
            ServersTitle.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(30 * ratioY));
            ServersTitle.Text = "Servers";
            PagePanelServers.Controls.Add(ServersTitle);

            System.Windows.Forms.Label ServerNameTitle = new System.Windows.Forms.Label();
            ServerNameTitle.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerNameTitle.BackColor = Color.Transparent;
            ServerNameTitle.ForeColor = SystemColors.Control;
            ServerNameTitle.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(80 * ratioY));
            ServerNameTitle.Name = "ServerNameTitle";
            ServerNameTitle.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            ServerNameTitle.Text = "Name";
            PagePanelServers.Controls.Add(ServerNameTitle);

            System.Windows.Forms.Label ServerIPTitle = new System.Windows.Forms.Label();
            ServerIPTitle.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerIPTitle.BackColor = Color.Transparent;
            ServerIPTitle.ForeColor = SystemColors.Control;
            ServerIPTitle.Location = new System.Drawing.Point((int)(220 * ratioX), (int)(80 * ratioY));
            ServerIPTitle.Name = "ServerIPTitle";
            ServerIPTitle.Size = new System.Drawing.Size((int)(400 * ratioX), (int)(20 * ratioY));
            ServerIPTitle.Text = "IP Address";
            PagePanelServers.Controls.Add(ServerIPTitle);

            System.Windows.Forms.Label ServerPortTitle = new System.Windows.Forms.Label();
            ServerPortTitle.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerPortTitle.BackColor = Color.Transparent;
            ServerPortTitle.ForeColor = SystemColors.Control;
            ServerPortTitle.Location = new System.Drawing.Point((int)(620 * ratioX), (int)(80 * ratioY));
            ServerPortTitle.Name = "ServerPortTitle";
            ServerPortTitle.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(20 * ratioY));
            ServerPortTitle.Text = "Port";
            PagePanelServers.Controls.Add(ServerPortTitle);

            Panel ServersPanel = new Panel();
            ServersPanel.Location = new System.Drawing.Point((int)(0 * ratioX), (int)(130 * ratioY));
            ServersPanel.Name = "ServersPanel";
            ServersPanel.BackColor = Color.Transparent;
            ServersPanel.Size = new System.Drawing.Size((int)(916 * ratioX), (int)(280 * ratioY));
            ServersPanel.AutoScroll = false;
            ServersPanel.HorizontalScroll.Enabled = false;
            ServersPanel.HorizontalScroll.Visible = false;
            ServersPanel.HorizontalScroll.Maximum = 0;
            ServersPanel.AutoScroll = true;
            ServersPanel.TabStop = false;
            PagePanelServers.Controls.Add(ServersPanel);

            int offset = 0;
            foreach (Server s in this.modManager.serverlist.Regions)
            {
                this.addServer(s, offset, ServersPanel);

                offset++;
            }

            Button ServersReset = new System.Windows.Forms.Button();
            ServersReset.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServersReset.Location = new System.Drawing.Point((int)(20 * ratioX), (int)(430 * ratioY));
            ServersReset.Name = "ServersReset";
            ServersReset.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
            ServersReset.Text = "Reset to default";
            ServersReset.TabStop = false;
            ServersReset.Click += new EventHandler(this.events.resetServers);
            ServersReset.UseVisualStyleBackColor = true;
            PagePanelServers.Controls.Add(ServersReset);

            Button AddServer = new System.Windows.Forms.Button();
            AddServer.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AddServer.Location = new System.Drawing.Point((int)(220 * ratioX), (int)(430 * ratioY));
            AddServer.Name = "AddServer";
            AddServer.Size = new System.Drawing.Size((int)(150 * ratioX), (int)(25 * ratioY));
            AddServer.Text = "Add Server";
            AddServer.TabStop = false;
            AddServer.Click += new EventHandler(this.events.addServer);
            AddServer.UseVisualStyleBackColor = true;
            PagePanelServers.Controls.Add(AddServer);

            return c;
        }

        public void addServer(Server s, int offset, Panel p)
        {

            Fontlist fonts = new Fontlist(this.modManager.config.resolutionY);

            double ratioX = (double)this.modManager.config.resolutionX / 1300.0;
            double ratioY = (double)this.modManager.config.resolutionY / 810.0;

            System.Windows.Forms.TextBox ServerName = new System.Windows.Forms.TextBox();
            ServerName.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerName.BackColor = SystemColors.ControlText;
            ServerName.ForeColor = SystemColors.Control;
            ServerName.BorderStyle = BorderStyle.None;
            ServerName.Location = new System.Drawing.Point((int)(20 * ratioX), (int)((40 * offset) * ratioY));
            ServerName.Name = "ServerName=" + offset;
            ServerName.Size = new System.Drawing.Size((int)(200 * ratioX), (int)(20 * ratioY));
            ServerName.Text = s.name;
            ServerName.TextChanged += new EventHandler(this.events.showSaveServer);

            if (offset < 3)
            {
                ServerName.Enabled = false;
            }

            p.Controls.Add(ServerName);

            System.Windows.Forms.TextBox ServerIP = new System.Windows.Forms.TextBox();
            ServerIP.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerIP.BackColor = SystemColors.ControlText;
            ServerIP.ForeColor = SystemColors.Control;
            ServerIP.BorderStyle = BorderStyle.None;
            ServerIP.Location = new System.Drawing.Point((int)(220 * ratioX), (int)((40 * offset) * ratioY));
            ServerIP.Name = "ServerIP=" + offset;
            ServerIP.Size = new System.Drawing.Size((int)(400 * ratioX), (int)(20 * ratioY));
            ServerIP.Text = s.DefaultIp;
            ServerIP.TextChanged += new EventHandler(this.events.showSaveServer);

            if (offset < 3)
            {
                ServerIP.Enabled = false;
            }

            p.Controls.Add(ServerIP);

            System.Windows.Forms.NumericUpDown ServerPort = new System.Windows.Forms.NumericUpDown();
            ServerPort.Font = new System.Drawing.Font("Arial", fonts.sizeS, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerPort.BackColor = SystemColors.ControlText;
            ServerPort.ForeColor = SystemColors.Control;
            ServerPort.BorderStyle = BorderStyle.None;
            ServerPort.Location = new System.Drawing.Point((int)(620 * ratioX), (int)((40 * offset) * ratioY));
            ServerPort.Name = "ServerPort=" + offset;
            ServerPort.Size = new System.Drawing.Size((int)(100 * ratioX), (int)(20 * ratioY));
            ServerPort.Minimum = 0;
            ServerPort.Maximum = 65536;
            ServerPort.Value = s.port;
            ServerPort.Controls[0].Visible = false;
            ServerPort.TextChanged += new EventHandler(this.events.showSaveServer);

            if (offset < 3)
            {
                ServerPort.Enabled = false;
            }

            p.Controls.Add(ServerPort);

            if (offset >= 3)
            {
                PictureBox ServerValidPic = new System.Windows.Forms.PictureBox();
                ServerValidPic.Image = global::ModManager4.Properties.Resources.valid;
                ServerValidPic.BackColor = System.Drawing.Color.Transparent;
                ServerValidPic.Location = new System.Drawing.Point((int)(770 * ratioX), (int)(((40 * offset) - 5) * ratioY));
                ServerValidPic.Name = "ServerValidPic=" + offset;
                ServerValidPic.Cursor = Cursors.Hand;
                ServerValidPic.Size = new System.Drawing.Size((int)(25 * ratioX), (int)(25 * ratioY));
                ServerValidPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                ServerValidPic.TabStop = false;
                ServerValidPic.Hide();
                ServerValidPic.Click += new EventHandler(this.events.saveServer);
                p.Controls.Add(ServerValidPic);

                PictureBox ServerRemovePic = new System.Windows.Forms.PictureBox();
                ServerRemovePic.Image = global::ModManager4.Properties.Resources.remove;
                ServerRemovePic.BackColor = System.Drawing.Color.Transparent;
                ServerRemovePic.Location = new System.Drawing.Point((int)(815 * ratioX), (int)(((40 * offset) - 5) * ratioY));
                ServerRemovePic.Name = "ServerRemovePic=" + offset;
                ServerRemovePic.Cursor = Cursors.Hand;
                ServerRemovePic.Size = new System.Drawing.Size((int)(25 * ratioX), (int)(25 * ratioY));
                ServerRemovePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                ServerRemovePic.TabStop = false;
                ServerRemovePic.Click += new EventHandler(this.events.removeServer);
                p.Controls.Add(ServerRemovePic);
            }
        }

        /*public string processIP(string ip)
        {
            if (ip == "")
            {
                return "";
            }
            string ret = "";
            string toProcess = ip;
            bool isLast = false;
            int part = 1;
            while (toProcess.Length > 0 || part <= 4)
            {
                int i = toProcess.IndexOf(".");
                if (i != -1)
                {
                    string start = toProcess.Substring(0, i);
                    string next = toProcess.Substring(i + 1);
                    string output = "";
                    for (int j = 0; j < 3; j++)
                    {
                        if (j < start.Length)
                        {
                            if (start[j] == ' ')
                            {
                                output = output + "0";
                            } else
                            {
                                output = output + start[j];
                            }
                        } else
                        {
                            output = "0" + output;
                        }
                    }
                    ret = ret + output + ".";
                    toProcess = next;
                } else
                {
                    string start = toProcess;
                    string output = "";
                    for (int j = 0; j < 3; j++)
                    {
                        if (j < start.Length)
                        {
                            if (start[j] == ' ')
                            {
                                output = output + "0";
                            }
                            else
                            {
                                output = output + start[j] ;
                            }
                        }
                        else
                        {
                            output = "0" + output;
                        }
                    }
                    ret = ret + output;
                    toProcess = "";
                }
                part++;
            }
            
            return ret;
        }
        */

        public void loadEditModPage(Mod m)
        {
            Component c = this.get("LocalEdit");

            Panel p = (Panel) c.getControl("PagePanelLocalEdit");

            System.Windows.Forms.Label LocalEditId = (System.Windows.Forms.Label)p.Controls["LocalEditId"];
            LocalEditId.Text = m.id;

            System.Windows.Forms.TextBox ModNameFieldEdit = (System.Windows.Forms.TextBox) p.Controls["ModNameFieldEdit"];
            ModNameFieldEdit.Text = m.name;

            foreach (Control control in p.Controls)
            {
                if (control is MMCheckbox)
                {
                    MMCheckbox cb = (MMCheckbox)control;
                    if (m.dependencies.Contains(control.Name))
                    {
                        cb.CheckState = CheckState.Checked;
                    } else
                    {
                        cb.CheckState = CheckState.Unchecked;
                    }
                    
                }
            }

            System.Windows.Forms.Label ModAddFileNameEdit = (System.Windows.Forms.Label)p.Controls["ModAddFileNameEdit"];
            ModAddFileNameEdit.Text = m.github;

        }

        public Component get(string name)
        {
            foreach (Component c in this.components)
            {
                if (c.name == name)
                {
                    return c;
                }
            }
            return null;
        }

        public string toString()
        {
            string ret = "Component list :\n";

            foreach (Component c in this.components)
            {
                ret = ret + "- Component " + c.name + "\n";
            }
            return ret;
        }

    }
}
