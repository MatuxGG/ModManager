using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Componentlist(ModManager modManager)
        {
            this.modManager = modManager;
            this.components = new List<Component>();
            this.events = new Events(this.modManager);
        }

        public void load()
        {
            Component c = new Component("Header");

            PictureBox AnnouncePic = new System.Windows.Forms.PictureBox();
            AnnouncePic.Image = global::ModManager4.Properties.Resources.news;
            AnnouncePic.BackColor = System.Drawing.Color.Transparent;
            AnnouncePic.Location = new System.Drawing.Point(50, 70);
            AnnouncePic.Name = "AnnouncePic";
            AnnouncePic.Size = new System.Drawing.Size(64, 64);
            AnnouncePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            AnnouncePic.TabStop = false;
            AnnouncePic.Cursor = Cursors.Hand;
            AnnouncePic.Click += new EventHandler(this.events.openAnnounce);
            AnnouncePic.Visible = false;
            this.modManager.Controls.Add(AnnouncePic);
            c.addControl(AnnouncePic);

            PictureBox InfoPic = new System.Windows.Forms.PictureBox();
            InfoPic.Image = Properties.Resources.info;
            InfoPic.BackColor = System.Drawing.Color.Transparent;
            InfoPic.Location = new System.Drawing.Point(1070, 20);
            InfoPic.Name = "InfoPic";
            InfoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            InfoPic.TabStop = false;
            InfoPic.Cursor = Cursors.Hand;
            InfoPic.Size = new System.Drawing.Size(50, 50);
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
            VersionField.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            VersionField.Location = new System.Drawing.Point(400, 145);
            VersionField.Size = new System.Drawing.Size(500, 30);
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
            ByMatuxField.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ByMatuxField.Location = new System.Drawing.Point(20, 20);
            ByMatuxField.Size = new System.Drawing.Size(200, 30);
            ByMatuxField.Text = "By Matux";
            ByMatuxField.Visible = false;
            this.modManager.Controls.Add(ByMatuxField);
            c.addControl(ByMatuxField);

            PictureBox MMDiscordLabel = new System.Windows.Forms.PictureBox();
            MMDiscordLabel.Image = Properties.Resources.discord;
            MMDiscordLabel.Location = new System.Drawing.Point(1140, 20);
            MMDiscordLabel.BackColor = System.Drawing.Color.Transparent;
            MMDiscordLabel.Name = "MMDiscordLabel";
            MMDiscordLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MMDiscordLabel.TabStop = false;
            MMDiscordLabel.Cursor = Cursors.Hand;
            MMDiscordLabel.Size = new System.Drawing.Size(50, 50);
            MMDiscordLabel.Click += new EventHandler(this.events.openMMDiscord);
            MMDiscordLabel.Visible = false;
            this.modManager.Controls.Add(MMDiscordLabel);
            c.addControl(MMDiscordLabel);

            PictureBox MatuxGithubLabel = new System.Windows.Forms.PictureBox();
            MatuxGithubLabel.Image = Properties.Resources.github;
            MatuxGithubLabel.BackColor = System.Drawing.Color.Transparent;
            MatuxGithubLabel.Location = new System.Drawing.Point(1210, 20);
            MatuxGithubLabel.Name = "MatuxGithubLabel";
            MatuxGithubLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MatuxGithubLabel.TabStop = false;
            MatuxGithubLabel.Cursor = Cursors.Hand;
            MatuxGithubLabel.Size = new System.Drawing.Size(50, 50);
            MatuxGithubLabel.Click += new EventHandler(this.events.openMatuxGithub);
            MatuxGithubLabel.Visible = false;
            this.modManager.Controls.Add(MatuxGithubLabel);
            c.addControl(MatuxGithubLabel);

            this.components.Add(c);

            c = new Component("Footer");

            PictureBox PlayGameLabel = new PictureBox();
            PlayGameLabel.BackColor = Color.Transparent;
            PlayGameLabel.Image = global::ModManager4.Properties.Resources.start_game;
            PlayGameLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PlayGameLabel.Name = "PlayGameLabel";
            PlayGameLabel.Location = new System.Drawing.Point(540, 680);
            PlayGameLabel.Size = new System.Drawing.Size(240, 80);
            PlayGameLabel.Cursor = Cursors.Hand;
            PlayGameLabel.Visible = false;
            PlayGameLabel.TabStop = false;
            PlayGameLabel.Click += new EventHandler(this.events.launchGame);
            PlayGameLabel.Visible = false;
            this.modManager.Controls.Add(PlayGameLabel);
            c.addControl(PlayGameLabel);

            PictureBox SettingsPic = new System.Windows.Forms.PictureBox();
            SettingsPic.Image = global::ModManager4.Properties.Resources.settings;
            SettingsPic.BackColor = System.Drawing.Color.Transparent;
            SettingsPic.Location = new System.Drawing.Point(800, 680);
            SettingsPic.Name = "SettingsPic";
            SettingsPic.Size = new System.Drawing.Size(210, 70);
            SettingsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            SettingsPic.TabStop = false;
            SettingsPic.Cursor = Cursors.Hand;
            SettingsPic.Click += new EventHandler(this.events.openSettings);
            SettingsPic.Visible = false;
            this.modManager.Controls.Add(SettingsPic);
            c.addControl(SettingsPic);

            PictureBox CodePic = new System.Windows.Forms.PictureBox();
            CodePic.Image = global::ModManager4.Properties.Resources.code;
            CodePic.BackColor = System.Drawing.Color.Transparent;
            CodePic.Location = new System.Drawing.Point(230, 695);
            CodePic.Name = "CodePic";
            CodePic.Size = new System.Drawing.Size(95, 40);
            CodePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            CodePic.TabStop = false;
            CodePic.Visible = false;
            this.modManager.Controls.Add(CodePic);
            c.addControl(CodePic);

            System.Windows.Forms.TextBox CodeTextbox = new System.Windows.Forms.TextBox();
            CodeTextbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CodeTextbox.ForeColor = SystemColors.ControlText;
            CodeTextbox.Location = new System.Drawing.Point(340, 700);
            CodeTextbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            CodeTextbox.Name = "CodeTextbox";
            CodeTextbox.TabStop = false;
            CodeTextbox.Size = new System.Drawing.Size(100, 20);
            CodeTextbox.Visible = false;
            this.modManager.Controls.Add(CodeTextbox);
            c.addControl(CodeTextbox);

            PictureBox ValidCodePic = new System.Windows.Forms.PictureBox();
            ValidCodePic.Image = global::ModManager4.Properties.Resources.valid;
            ValidCodePic.BackColor = System.Drawing.Color.Transparent;
            ValidCodePic.Location = new System.Drawing.Point(450, 695);
            ValidCodePic.Name = "CodePic";
            ValidCodePic.Cursor = Cursors.Hand;
            ValidCodePic.Size = new System.Drawing.Size(40, 40);
            ValidCodePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ValidCodePic.TabStop = false;
            ValidCodePic.Visible = false;
            ValidCodePic.Click += new EventHandler(this.events.validCode);
            this.modManager.Controls.Add(ValidCodePic);
            c.addControl(ValidCodePic);

            this.components.Add(c);

            c = new Component("PathSelection");

            Panel PagePanelPath = new Panel();
            PagePanelPath.Location = new System.Drawing.Point(184, 190);
            PagePanelPath.Name = "PagePanelPath";
            PagePanelPath.BackColor = Color.Black;
            PagePanelPath.BorderStyle = BorderStyle.Fixed3D;
            PagePanelPath.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelPath.Size = new System.Drawing.Size(916, 477);
            PagePanelPath.TabStop = false;
            PagePanelPath.Visible = false;
            this.modManager.Controls.Add(PagePanelPath);
            c.addControl(PagePanelPath);

            System.Windows.Forms.Label AmongFolderTitle = new System.Windows.Forms.Label();
            AmongFolderTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongFolderTitle.BackColor = Color.Transparent;
            AmongFolderTitle.ForeColor = SystemColors.Control;
            AmongFolderTitle.TextAlign = ContentAlignment.MiddleCenter;
            AmongFolderTitle.Location = new System.Drawing.Point(0, 20);
            AmongFolderTitle.Name = "AmongFolderTitle";
            AmongFolderTitle.Size = new System.Drawing.Size(916, 30);
            AmongFolderTitle.Text = "Among Us folder selection";
            PagePanelPath.Controls.Add(AmongFolderTitle);

            System.Windows.Forms.Label AmongUsFolderInfo = new System.Windows.Forms.Label();
            AmongUsFolderInfo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsFolderInfo.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsFolderInfo.TextAlign = ContentAlignment.MiddleCenter;
            AmongUsFolderInfo.Location = new System.Drawing.Point(0, 150);
            AmongUsFolderInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AmongUsFolderInfo.Name = "AmongUsFolderInfo";
            AmongUsFolderInfo.Size = new System.Drawing.Size(916, 20);
            AmongUsFolderInfo.Text = "Please, select the folder where Among Us is installed !";
            PagePanelPath.Controls.Add(AmongUsFolderInfo);

            Button AmongUsDirectorySelection = new System.Windows.Forms.Button();
            AmongUsDirectorySelection.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirectorySelection.Location = new System.Drawing.Point(258, 300);
            AmongUsDirectorySelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirectorySelection.Name = "AmongUsDirectorySelection";
            AmongUsDirectorySelection.Size = new System.Drawing.Size(400, 50);
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
            BackToMods.Location = new System.Drawing.Point(50, 350);
            BackToMods.Name = "BackToMods";
            BackToMods.Size = new System.Drawing.Size(100, 100);
            BackToMods.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            PagePanelInfo.Location = new System.Drawing.Point(184, 190);
            PagePanelInfo.Name = "PagePanelInfo";
            PagePanelInfo.BackColor = Color.Black;
            PagePanelInfo.BorderStyle = BorderStyle.Fixed3D;
            PagePanelInfo.Size = new System.Drawing.Size(916, 477);
            PagePanelInfo.TabStop = false;
            PagePanelInfo.Visible = false;
            this.modManager.Controls.Add(PagePanelInfo);
            c.addControl(PagePanelInfo);

            System.Windows.Forms.Label InfoTitle = new System.Windows.Forms.Label();
            InfoTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InfoTitle.BackColor = Color.Transparent;
            InfoTitle.ForeColor = SystemColors.Control;
            InfoTitle.TextAlign = ContentAlignment.MiddleCenter;
            InfoTitle.Location = new System.Drawing.Point(0, 20);
            InfoTitle.Name = "InfoTitle";
            InfoTitle.Size = new System.Drawing.Size(916, 30);
            InfoTitle.Text = "Information";
            PagePanelInfo.Controls.Add(InfoTitle);

            Panel ContentPanelInfo = new Panel();
            ContentPanelInfo.Location = new System.Drawing.Point(20, 70);
            ContentPanelInfo.Name = "ContentPanelInfo";
            ContentPanelInfo.Size = new System.Drawing.Size(876, 390);
            ContentPanelInfo.AutoScroll = false;
            ContentPanelInfo.HorizontalScroll.Enabled = false;
            ContentPanelInfo.HorizontalScroll.Visible = false;
            ContentPanelInfo.HorizontalScroll.Maximum = 0;
            ContentPanelInfo.AutoScroll = true;
            ContentPanelInfo.TabStop = false;
            PagePanelInfo.Controls.Add(ContentPanelInfo);

            System.Windows.Forms.Label InfoLabel = new System.Windows.Forms.Label();
            InfoLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            InfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            InfoLabel.TextAlign = ContentAlignment.TopLeft;
            InfoLabel.Location = new System.Drawing.Point(0, 0);
            InfoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.AutoSize = true;
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
            PagePanelSettings.Location = new System.Drawing.Point(184, 190);
            PagePanelSettings.Name = "PagePanelSettings";
            PagePanelSettings.BackColor = Color.Black;
            PagePanelSettings.BorderStyle = BorderStyle.Fixed3D;
            PagePanelSettings.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelSettings.Size = new System.Drawing.Size(916, 477);
            PagePanelSettings.TabStop = false;
            PagePanelSettings.Visible = false;
            this.modManager.Controls.Add(PagePanelSettings);
            c.addControl(PagePanelSettings);

            System.Windows.Forms.Label SettingsTitle = new System.Windows.Forms.Label();
            SettingsTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SettingsTitle.BackColor = Color.Transparent;
            SettingsTitle.ForeColor = SystemColors.Control;
            SettingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            SettingsTitle.Location = new System.Drawing.Point(0, 20);
            SettingsTitle.Name = "SettingsTitle";
            SettingsTitle.Size = new System.Drawing.Size(916, 30);
            SettingsTitle.Text = "Settings";
            PagePanelSettings.Controls.Add(SettingsTitle);

            System.Windows.Forms.Label AmongUsDirSwitchLabel = new System.Windows.Forms.Label();
            AmongUsDirSwitchLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            AmongUsDirSwitchLabel.Location = new System.Drawing.Point(20, 150);
            AmongUsDirSwitchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            AmongUsDirSwitchLabel.Name = "AmongUsDirSwitchLabel";
            AmongUsDirSwitchLabel.Size = new System.Drawing.Size(200, 20);
            AmongUsDirSwitchLabel.Text = "Among Us directory :";
            PagePanelSettings.Controls.Add(AmongUsDirSwitchLabel);

            Button AmongUsDirSwitchButton = new System.Windows.Forms.Button();
            AmongUsDirSwitchButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            AmongUsDirSwitchButton.Location = new System.Drawing.Point(250, 150);
            AmongUsDirSwitchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            AmongUsDirSwitchButton.Name = "AmongUsDirSwitchButton";
            AmongUsDirSwitchButton.Size = new System.Drawing.Size(150, 30);
            AmongUsDirSwitchButton.Text = "Change";
            AmongUsDirSwitchButton.UseVisualStyleBackColor = true;
            AmongUsDirSwitchButton.TabStop = false;
            AmongUsDirSwitchButton.Click += new EventHandler(this.events.openPathSelection);
            PagePanelSettings.Controls.Add(AmongUsDirSwitchButton);

            Button OpenAmongUs = new System.Windows.Forms.Button();
            OpenAmongUs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenAmongUs.Location = new System.Drawing.Point(450, 150);
            OpenAmongUs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            OpenAmongUs.Name = "OpenAmongUs";
            OpenAmongUs.Size = new System.Drawing.Size(150, 30);
            OpenAmongUs.Text = "Open";
            OpenAmongUs.TabStop = false;
            OpenAmongUs.UseVisualStyleBackColor = true;
            OpenAmongUs.Click += new EventHandler(this.events.openAmongUsDirectory);
            PagePanelSettings.Controls.Add(OpenAmongUs);

            System.Windows.Forms.Label RemoveLocalLabel = new System.Windows.Forms.Label();
            RemoveLocalLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RemoveLocalLabel.ForeColor = System.Drawing.SystemColors.Control;
            RemoveLocalLabel.Location = new System.Drawing.Point(20, 200);
            RemoveLocalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            RemoveLocalLabel.Name = "RemoveLocalLabel";
            RemoveLocalLabel.Size = new System.Drawing.Size(200, 20);
            RemoveLocalLabel.Text = "Remove local mods :";
            PagePanelSettings.Controls.Add(RemoveLocalLabel);

            Button RemoveLocalButton = new System.Windows.Forms.Button();
            RemoveLocalButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RemoveLocalButton.Location = new System.Drawing.Point(250, 200);
            RemoveLocalButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            RemoveLocalButton.Name = "RemoveLocalButton";
            RemoveLocalButton.Size = new System.Drawing.Size(150, 30);
            RemoveLocalButton.Text = "Remove";
            RemoveLocalButton.UseVisualStyleBackColor = true;
            RemoveLocalButton.Click += new EventHandler(this.events.removeLocalMods);
            RemoveLocalButton.TabStop = false;
            PagePanelSettings.Controls.Add(RemoveLocalButton);

            System.Windows.Forms.Label OpenLogsLabel = new System.Windows.Forms.Label();
            OpenLogsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenLogsLabel.ForeColor = System.Drawing.SystemColors.Control;
            OpenLogsLabel.Location = new System.Drawing.Point(20, 250);
            OpenLogsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            OpenLogsLabel.Name = "OpenLogsLabel";
            OpenLogsLabel.Size = new System.Drawing.Size(200, 20);
            OpenLogsLabel.Text = "Open logs folder :";
            PagePanelSettings.Controls.Add(OpenLogsLabel);

            Button OpenLogsButton = new System.Windows.Forms.Button();
            OpenLogsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OpenLogsButton.Location = new System.Drawing.Point(250, 250);
            OpenLogsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            OpenLogsButton.Name = "OpenLogsButton";
            OpenLogsButton.Size = new System.Drawing.Size(150, 30);
            OpenLogsButton.Text = "Open";
            OpenLogsButton.UseVisualStyleBackColor = true;
            OpenLogsButton.Click += new EventHandler(this.events.openLogs);
            OpenLogsButton.TabStop = false;
            PagePanelSettings.Controls.Add(OpenLogsButton);

            this.components.Add(c);

            c = new Component("News");

            Panel PagePanelNews = new Panel();
            PagePanelNews.Location = new System.Drawing.Point(184, 190);
            PagePanelNews.Name = "PagePanelNews";
            PagePanelNews.BackColor = Color.Black;
            PagePanelNews.BorderStyle = BorderStyle.Fixed3D;
            PagePanelNews.Size = new System.Drawing.Size(916, 477);
            PagePanelNews.TabStop = false;
            PagePanelNews.Visible = false;
            this.modManager.Controls.Add(PagePanelNews);
            c.addControl(PagePanelNews);

            System.Windows.Forms.Label NewsTitle = new System.Windows.Forms.Label();
            NewsTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NewsTitle.BackColor = Color.Transparent;
            NewsTitle.ForeColor = SystemColors.Control;
            NewsTitle.TextAlign = ContentAlignment.MiddleCenter;
            NewsTitle.Location = new System.Drawing.Point(0, 20);
            NewsTitle.Name = "NewsTitle";
            NewsTitle.Size = new System.Drawing.Size(916, 30);
            NewsTitle.Text = "News";
            PagePanelNews.Controls.Add(NewsTitle);

            Panel ContentPanelNews = new Panel();
            ContentPanelNews.Location = new System.Drawing.Point(20, 70);
            ContentPanelNews.Name = "ContentPanelNews";
            ContentPanelNews.Size = new System.Drawing.Size(876, 390);
            ContentPanelNews.AutoScroll = false;
            ContentPanelNews.HorizontalScroll.Enabled = false;
            ContentPanelNews.HorizontalScroll.Visible = false;
            ContentPanelNews.HorizontalScroll.Maximum = 0;
            ContentPanelNews.AutoScroll = true;
            ContentPanelNews.TabStop = false;
            PagePanelNews.Controls.Add(ContentPanelNews);

            System.Windows.Forms.Label NewsLabel = new System.Windows.Forms.Label();
            NewsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NewsLabel.ForeColor = System.Drawing.SystemColors.Control;
            NewsLabel.TextAlign = ContentAlignment.TopLeft;
            NewsLabel.Location = new System.Drawing.Point(0, 0);
            NewsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            NewsLabel.Name = "NewsLabel";
            NewsLabel.AutoSize = true;
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
            PagePanelUnMods.Location = new System.Drawing.Point(184, 190);
            PagePanelUnMods.Name = "PagePanelUnMods";
            PagePanelUnMods.BackColor = Color.Black;
            PagePanelUnMods.BorderStyle = BorderStyle.Fixed3D;
            PagePanelUnMods.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelUnMods.Size = new System.Drawing.Size(916, 477);
            PagePanelUnMods.TabStop = false;
            PagePanelUnMods.Visible = false;
            this.modManager.Controls.Add(PagePanelUnMods);
            c.addControl(PagePanelUnMods);

            System.Windows.Forms.Label UninstallModsTitle = new System.Windows.Forms.Label();
            UninstallModsTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModsTitle.BackColor = Color.Transparent;
            UninstallModsTitle.ForeColor = SystemColors.Control;
            UninstallModsTitle.TextAlign = ContentAlignment.MiddleCenter;
            UninstallModsTitle.Location = new System.Drawing.Point(0, 20);
            UninstallModsTitle.Name = "UninstallModsTitle";
            UninstallModsTitle.Size = new System.Drawing.Size(916, 30);
            UninstallModsTitle.Text = "All mods uninstalled";
            PagePanelUnMods.Controls.Add(UninstallModsTitle);

            System.Windows.Forms.Label UninstallModsLabel = new System.Windows.Forms.Label();
            UninstallModsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            UninstallModsLabel.TextAlign = ContentAlignment.MiddleCenter;
            UninstallModsLabel.Location = new System.Drawing.Point(0, 150);
            UninstallModsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            UninstallModsLabel.Name = "UninstallModsLabel";
            UninstallModsLabel.Size = new System.Drawing.Size(916, 20);
            UninstallModsLabel.Text = "All mods have been succesfully uninstalled !";
            PagePanelUnMods.Controls.Add(UninstallModsLabel);

            Button UninstallModsButton = new System.Windows.Forms.Button();
            UninstallModsButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UninstallModsButton.Location = new System.Drawing.Point(258, 300);
            UninstallModsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            UninstallModsButton.Name = "UninstallModsButton";
            UninstallModsButton.Size = new System.Drawing.Size(400, 50);
            UninstallModsButton.Text = "OK";
            UninstallModsButton.TabStop = false;
            UninstallModsButton.Click += new EventHandler(this.events.openMods);
            UninstallModsButton.UseVisualStyleBackColor = true;
            PagePanelUnMods.Controls.Add(UninstallModsButton);

            this.components.Add(c);

            c = new Component("BeforeUpdateMods");

            Panel PagePaneBefUp = new Panel();
            PagePaneBefUp.Location = new System.Drawing.Point(184, 190);
            PagePaneBefUp.Name = "PagePaneBefUp";
            PagePaneBefUp.BackColor = Color.Black;
            PagePaneBefUp.BorderStyle = BorderStyle.Fixed3D;
            PagePaneBefUp.BackgroundImageLayout = ImageLayout.Zoom;
            PagePaneBefUp.Size = new System.Drawing.Size(916, 477);
            PagePaneBefUp.TabStop = false;
            PagePaneBefUp.Visible = false;
            this.modManager.Controls.Add(PagePaneBefUp);
            c.addControl(PagePaneBefUp);

            System.Windows.Forms.Label UpdateModsTitle = new System.Windows.Forms.Label();
            UpdateModsTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateModsTitle.BackColor = Color.Transparent;
            UpdateModsTitle.ForeColor = SystemColors.Control;
            UpdateModsTitle.TextAlign = ContentAlignment.MiddleCenter;
            UpdateModsTitle.Location = new System.Drawing.Point(0, 20);
            UpdateModsTitle.Name = "UpdateModsTitle";
            UpdateModsTitle.Size = new System.Drawing.Size(916, 30);
            UpdateModsTitle.Text = "Updating mods";
            PagePaneBefUp.Controls.Add(UpdateModsTitle);

            System.Windows.Forms.Label UpdateModsLabel = new System.Windows.Forms.Label();
            UpdateModsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UpdateModsLabel.ForeColor = System.Drawing.SystemColors.Control;
            UpdateModsLabel.TextAlign = ContentAlignment.MiddleCenter;
            UpdateModsLabel.Location = new System.Drawing.Point(0, 150);
            UpdateModsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            UpdateModsLabel.Name = "UpdateModsLabel";
            UpdateModsLabel.Size = new System.Drawing.Size(916, 20);
            UpdateModsLabel.Text = "Mod Manager is updating your mods. Please wait ...";
            PagePaneBefUp.Controls.Add(UpdateModsLabel);

            ProgressBar UpdateBar = new ProgressBar();
            UpdateBar.Location = new System.Drawing.Point(300, 300);
            UpdateBar.Size = new System.Drawing.Size(300, 20);
            UpdateBar.Name = "UpdateBar";
            UpdateBar.Maximum = 100;
            UpdateBar.Minimum = 0;
            UpdateBar.Step = 1;
            PagePaneBefUp.Controls.Add(UpdateBar);

            this.components.Add(c);

            c = new Component("BeforeApplyCode");

            Panel PagePanelApplyCode = new Panel();
            PagePanelApplyCode.Location = new System.Drawing.Point(184, 190);
            PagePanelApplyCode.Name = "PagePanelApplyCode";
            PagePanelApplyCode.BackColor = Color.Black;
            PagePanelApplyCode.BorderStyle = BorderStyle.Fixed3D;
            PagePanelApplyCode.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelApplyCode.Size = new System.Drawing.Size(916, 477);
            PagePanelApplyCode.TabStop = false;
            PagePanelApplyCode.Visible = false;
            this.modManager.Controls.Add(PagePanelApplyCode);
            c.addControl(PagePanelApplyCode);

            System.Windows.Forms.Label ApplyCodeTitle = new System.Windows.Forms.Label();
            ApplyCodeTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ApplyCodeTitle.BackColor = Color.Transparent;
            ApplyCodeTitle.ForeColor = SystemColors.Control;
            ApplyCodeTitle.TextAlign = ContentAlignment.MiddleCenter;
            ApplyCodeTitle.Location = new System.Drawing.Point(0, 20);
            ApplyCodeTitle.Name = "ApplyCodeTitle";
            ApplyCodeTitle.Size = new System.Drawing.Size(916, 30);
            ApplyCodeTitle.Text = "Updating mods";
            PagePanelApplyCode.Controls.Add(ApplyCodeTitle);

            System.Windows.Forms.Label ApplyCodeLabel = new System.Windows.Forms.Label();
            ApplyCodeLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ApplyCodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            ApplyCodeLabel.TextAlign = ContentAlignment.MiddleCenter;
            ApplyCodeLabel.Location = new System.Drawing.Point(0, 150);
            ApplyCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ApplyCodeLabel.Name = "ApplyCodeLabel";
            ApplyCodeLabel.Size = new System.Drawing.Size(916, 20);
            ApplyCodeLabel.Text = "Mod Manager is updating your mods. Please wait ...";
            PagePanelApplyCode.Controls.Add(ApplyCodeLabel);

            ProgressBar UpdateCodeBar = new ProgressBar();
            UpdateCodeBar.Location = new System.Drawing.Point(300, 300);
            UpdateCodeBar.Size = new System.Drawing.Size(300, 20);
            UpdateCodeBar.Name = "UpdateCodeBar";
            UpdateCodeBar.Maximum = 100;
            UpdateCodeBar.Minimum = 0;
            UpdateCodeBar.Step = 1;
            PagePanelApplyCode.Controls.Add(UpdateCodeBar);

            this.components.Add(c);

            c = new Component("LocalAdd");

            Panel PagePanelLocal = new Panel();
            PagePanelLocal.Location = new System.Drawing.Point(184, 190);
            PagePanelLocal.Name = "PagePanelLocal";
            PagePanelLocal.BackColor = Color.Black;
            PagePanelLocal.BorderStyle = BorderStyle.Fixed3D;
            PagePanelLocal.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelLocal.Size = new System.Drawing.Size(916, 477);
            PagePanelLocal.TabStop = false;
            PagePanelLocal.Visible = false;
            this.modManager.Controls.Add(PagePanelLocal);
            c.addControl(PagePanelLocal);

            System.Windows.Forms.Label LocalTitle = new System.Windows.Forms.Label();
            LocalTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LocalTitle.BackColor = Color.Transparent;
            LocalTitle.ForeColor = SystemColors.Control;
            LocalTitle.TextAlign = ContentAlignment.MiddleCenter;
            LocalTitle.Location = new System.Drawing.Point(0, 20);
            LocalTitle.Name = "LocalTitle";
            LocalTitle.Size = new System.Drawing.Size(916, 30);
            LocalTitle.Text = "Add local mod";
            PagePanelLocal.Controls.Add(LocalTitle);

            System.Windows.Forms.Label ModNameLabel = new System.Windows.Forms.Label();
            ModNameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            ModNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            ModNameLabel.Location = new System.Drawing.Point(20, 90);
            ModNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ModNameLabel.Name = "ModNameLabel";
            ModNameLabel.Size = new System.Drawing.Size(150, 25);
            ModNameLabel.Text = "Mod name :";
            PagePanelLocal.Controls.Add(ModNameLabel);

            System.Windows.Forms.TextBox ModNameField = new System.Windows.Forms.TextBox();
            ModNameField.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameField.ForeColor = System.Drawing.SystemColors.ControlText;
            ModNameField.Location = new System.Drawing.Point(200, 90);
            ModNameField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ModNameField.Name = "ModNameField";
            ModNameField.Text = "";
            ModNameField.TabStop = false;
            ModNameField.Size = new System.Drawing.Size(300, 25);
            PagePanelLocal.Controls.Add(ModNameField);

            System.Windows.Forms.Label ModDepsLabel = new System.Windows.Forms.Label();
            ModDepsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModDepsLabel.ForeColor = System.Drawing.SystemColors.Control;
            ModDepsLabel.TextAlign = ContentAlignment.MiddleLeft;
            ModDepsLabel.Location = new System.Drawing.Point(20, 130);
            ModDepsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            ModDepsLabel.Name = "ModDepsLabel";
            ModDepsLabel.Size = new System.Drawing.Size(150, 25);
            ModDepsLabel.Text = "Mod dependencies :";
            PagePanelLocal.Controls.Add(ModDepsLabel);

            int offset = 0;
            foreach (Dependency d in this.modManager.modlist.availableDependencies)
            {
                System.Windows.Forms.CheckBox ModDepCheckbox = new System.Windows.Forms.CheckBox();
                ModDepCheckbox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ModDepCheckbox.ForeColor = System.Drawing.SystemColors.Control;
                ModDepCheckbox.Location = new System.Drawing.Point(20 + 200*(offset%4), 170 + 40*(offset/4));
                ModDepCheckbox.Name = d.name;
                ModDepCheckbox.TabStop = false;
                ModDepCheckbox.Size = new System.Drawing.Size(25, 25);
                
                if (offset == 0)
                {
                    ModDepCheckbox.Checked = true;
                }
                
                PagePanelLocal.Controls.Add(ModDepCheckbox);

                System.Windows.Forms.Label ModDepField = new System.Windows.Forms.Label();
                ModDepField.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ModDepField.ForeColor = System.Drawing.SystemColors.Control;
                ModDepField.TextAlign = ContentAlignment.MiddleLeft;
                ModDepField.Location = new System.Drawing.Point(50 + 200*(offset%4), 170 + 40*(offset/4));
                ModDepField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                ModDepField.Name = "ModDepField" + d.name;
                ModDepField.Size = new System.Drawing.Size(150, 25);
                ModDepField.Text = d.name;
                PagePanelLocal.Controls.Add(ModDepField);

                offset++;
            }

            System.Windows.Forms.Label ModAddField = new System.Windows.Forms.Label();
            ModAddField.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddField.Location = new System.Drawing.Point(20, 300);
            ModAddField.ForeColor = System.Drawing.SystemColors.Control;
            ModAddField.Name = "ModAddField";
            ModAddField.Size = new System.Drawing.Size(200, 30);
            ModAddField.Text = "Mod file :";
            ModAddField.TabStop = false;
            PagePanelLocal.Controls.Add(ModAddField);

            Button ModAddButton = new System.Windows.Forms.Button();
            ModAddButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddButton.Location = new System.Drawing.Point(200, 300);
            ModAddButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            ModAddButton.Name = "ModAddButton";
            ModAddButton.Size = new System.Drawing.Size(150, 30);
            ModAddButton.Text = "Select file";
            ModAddButton.TabStop = false;
            ModAddButton.Click += new EventHandler(this.events.addMod);
            ModAddButton.UseVisualStyleBackColor = true;
            PagePanelLocal.Controls.Add(ModAddButton);

            System.Windows.Forms.Label ModAddFileName = new System.Windows.Forms.Label();
            ModAddFileName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddFileName.Location = new System.Drawing.Point(370, 300);
            ModAddFileName.TextAlign = ContentAlignment.MiddleLeft;
            ModAddFileName.ForeColor = System.Drawing.SystemColors.Control;
            ModAddFileName.Name = "ModAddFileName";
            ModAddFileName.Size = new System.Drawing.Size(520, 30);
            ModAddFileName.Text = "No file selected";
            ModAddFileName.TabStop = false;
            PagePanelLocal.Controls.Add(ModAddFileName);

            Button ModAddValid = new System.Windows.Forms.Button();
            ModAddValid.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAddValid.Location = new System.Drawing.Point(20, 410);
            ModAddValid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            ModAddValid.Name = "ModAddValid";
            ModAddValid.Size = new System.Drawing.Size(870, 40);
            ModAddValid.Text = "Add mod";
            ModAddValid.TabStop = false;
            ModAddValid.Click += new EventHandler(this.events.validAddMod);
            ModAddValid.UseVisualStyleBackColor = true;
            PagePanelLocal.Controls.Add(ModAddValid);

            this.components.Add(c);

            c = new Component("Unreacheable");

            Panel PagePanelUnreacheable = new Panel();
            PagePanelUnreacheable.Location = new System.Drawing.Point(184, 190);
            PagePanelUnreacheable.Name = "PagePanelUnreacheable";
            PagePanelUnreacheable.BackColor = Color.Black;
            PagePanelUnreacheable.BorderStyle = BorderStyle.Fixed3D;
            PagePanelUnreacheable.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelUnreacheable.Size = new System.Drawing.Size(916, 477);
            PagePanelUnreacheable.TabStop = false;
            PagePanelUnreacheable.Visible = false;
            this.modManager.Controls.Add(PagePanelUnreacheable);
            c.addControl(PagePanelUnreacheable);

            System.Windows.Forms.Label UnreacheableTitle = new System.Windows.Forms.Label();
            UnreacheableTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnreacheableTitle.BackColor = Color.Transparent;
            UnreacheableTitle.ForeColor = SystemColors.Control;
            UnreacheableTitle.TextAlign = ContentAlignment.MiddleCenter;
            UnreacheableTitle.Location = new System.Drawing.Point(0, 20);
            UnreacheableTitle.Name = "UnreacheableTitle";
            UnreacheableTitle.Size = new System.Drawing.Size(916, 30);
            UnreacheableTitle.Text = "Server unreacheable";
            PagePanelUnreacheable.Controls.Add(UnreacheableTitle);

            System.Windows.Forms.Label UnreacheableLabel = new System.Windows.Forms.Label();
            UnreacheableLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnreacheableLabel.ForeColor = System.Drawing.SystemColors.Control;
            UnreacheableLabel.TextAlign = ContentAlignment.TopLeft;
            UnreacheableLabel.Location = new System.Drawing.Point(20, 150);
            UnreacheableLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            UnreacheableLabel.Name = "UnreacheableLabel";
            UnreacheableLabel.Size = new System.Drawing.Size(896, 300);
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
            PagePanelUnsavedChanges.Location = new System.Drawing.Point(184, 190);
            PagePanelUnsavedChanges.Name = "PagePanelUnsavedChanges";
            PagePanelUnsavedChanges.BackColor = Color.Black;
            PagePanelUnsavedChanges.BorderStyle = BorderStyle.Fixed3D;
            PagePanelUnsavedChanges.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelUnsavedChanges.Size = new System.Drawing.Size(916, 477);
            PagePanelUnsavedChanges.TabStop = false;
            PagePanelUnsavedChanges.Visible = false;
            this.modManager.Controls.Add(PagePanelUnsavedChanges);
            c.addControl(PagePanelUnsavedChanges);

            System.Windows.Forms.Label UnsavedChangesTitle = new System.Windows.Forms.Label();
            UnsavedChangesTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnsavedChangesTitle.BackColor = Color.Transparent;
            UnsavedChangesTitle.ForeColor = SystemColors.Control;
            UnsavedChangesTitle.TextAlign = ContentAlignment.MiddleCenter;
            UnsavedChangesTitle.Location = new System.Drawing.Point(0, 20);
            UnsavedChangesTitle.Name = "UnsavedChangesTitle";
            UnsavedChangesTitle.Size = new System.Drawing.Size(916, 30);
            UnsavedChangesTitle.Text = "Unsaved Changes";
            PagePanelUnsavedChanges.Controls.Add(UnsavedChangesTitle);

            System.Windows.Forms.Label UnsavedChangesLabel = new System.Windows.Forms.Label();
            UnsavedChangesLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            UnsavedChangesLabel.ForeColor = System.Drawing.SystemColors.Control;
            UnsavedChangesLabel.TextAlign = ContentAlignment.TopCenter;
            UnsavedChangesLabel.Location = new System.Drawing.Point(20, 150);
            UnsavedChangesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            UnsavedChangesLabel.Name = "UnsavedChangesLabel";
            UnsavedChangesLabel.Size = new System.Drawing.Size(896, 50);
            UnsavedChangesLabel.Text = "There are unsaved changes in your mod configuration.\n" +
                "Do you want to save them before starting game ?";
            PagePanelUnsavedChanges.Controls.Add(UnsavedChangesLabel);

            PictureBox SaveChanges = new System.Windows.Forms.PictureBox();
            SaveChanges.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SaveChanges.Location = new System.Drawing.Point(30, 300);
            SaveChanges.BackgroundImage = global::ModManager4.Properties.Resources.save;
            SaveChanges.BackgroundImageLayout = ImageLayout.Zoom;
            SaveChanges.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            SaveChanges.Name = "SaveChanges";
            SaveChanges.Size = new System.Drawing.Size(400, 80);
            SaveChanges.Cursor = Cursors.Hand;
            SaveChanges.TabStop = false;
            SaveChanges.Click += new EventHandler(this.events.saveAndStart);
            PagePanelUnsavedChanges.Controls.Add(SaveChanges);

            PictureBox StartAnyway = new System.Windows.Forms.PictureBox();
            StartAnyway.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            StartAnyway.Location = new System.Drawing.Point(450, 300);
            StartAnyway.BackgroundImage = global::ModManager4.Properties.Resources.dontsave;
            StartAnyway.BackgroundImageLayout = ImageLayout.Zoom;
            StartAnyway.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            StartAnyway.Name = "StartAnyway";
            StartAnyway.Size = new System.Drawing.Size(400, 80);
            StartAnyway.Cursor = Cursors.Hand;
            StartAnyway.TabStop = false;
            StartAnyway.Click += new EventHandler(this.events.startAnyway);
            PagePanelUnsavedChanges.Controls.Add(StartAnyway);

            this.components.Add(c);

            c = new Component("ModTools");

            this.loadTools(c);

            this.components.Add(c);

            c = new Component("WIP");

            Panel PagePanelWIP = new Panel();
            PagePanelWIP.Location = new System.Drawing.Point(184, 190);
            PagePanelWIP.Name = "PagePanelWIP";
            PagePanelWIP.BackColor = Color.Black;
            PagePanelWIP.BorderStyle = BorderStyle.Fixed3D;
            PagePanelWIP.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelWIP.Size = new System.Drawing.Size(916, 477);
            PagePanelWIP.TabStop = false;
            PagePanelWIP.Visible = false;
            this.modManager.Controls.Add(PagePanelWIP);
            c.addControl(PagePanelWIP);

            System.Windows.Forms.Label WIPTitle = new System.Windows.Forms.Label();
            WIPTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            WIPTitle.BackColor = Color.Transparent;
            WIPTitle.ForeColor = SystemColors.Control;
            WIPTitle.TextAlign = ContentAlignment.MiddleCenter;
            WIPTitle.Location = new System.Drawing.Point(0, 20);
            WIPTitle.Name = "WIPTitle";
            WIPTitle.Size = new System.Drawing.Size(916, 30);
            WIPTitle.Text = "Work In progress";
            PagePanelWIP.Controls.Add(WIPTitle);

            System.Windows.Forms.Label WIPLabel = new System.Windows.Forms.Label();
            WIPLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            WIPLabel.ForeColor = System.Drawing.SystemColors.Control;
            WIPLabel.TextAlign = ContentAlignment.MiddleCenter;
            WIPLabel.Location = new System.Drawing.Point(0, 150);
            WIPLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            WIPLabel.Name = "WIPLabel";
            WIPLabel.Size = new System.Drawing.Size(916, 30);
            WIPLabel.Text = "This page is being developped and is unavailable for now.";
            PagePanelWIP.Controls.Add(WIPLabel);

            this.components.Add(c);

            c = new Component("Disabled");

            Panel PagePanelDisabled = new Panel();
            PagePanelDisabled.Location = new System.Drawing.Point(184, 190);
            PagePanelDisabled.Name = "PagePanelDisabled";
            PagePanelDisabled.BackColor = Color.Black;
            PagePanelDisabled.BorderStyle = BorderStyle.Fixed3D;
            PagePanelDisabled.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelDisabled.Size = new System.Drawing.Size(916, 477);
            PagePanelDisabled.TabStop = false;
            PagePanelDisabled.Visible = false;
            this.modManager.Controls.Add(PagePanelDisabled);
            c.addControl(PagePanelDisabled);

            System.Windows.Forms.Label DisabledTitle = new System.Windows.Forms.Label();
            DisabledTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DisabledTitle.BackColor = Color.Transparent;
            DisabledTitle.ForeColor = SystemColors.Control;
            DisabledTitle.TextAlign = ContentAlignment.MiddleCenter;
            DisabledTitle.Location = new System.Drawing.Point(0, 20);
            DisabledTitle.Name = "DisabledTitle";
            DisabledTitle.Size = new System.Drawing.Size(916, 30);
            DisabledTitle.Text = "Mod Manager disabled";
            PagePanelDisabled.Controls.Add(DisabledTitle);

            System.Windows.Forms.Label DisabledLabel = new System.Windows.Forms.Label();
            DisabledLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DisabledLabel.ForeColor = System.Drawing.SystemColors.Control;
            DisabledLabel.TextAlign = ContentAlignment.MiddleCenter;
            DisabledLabel.Location = new System.Drawing.Point(0, 150);
            DisabledLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            DisabledLabel.Name = "UpdateModsLabel";
            DisabledLabel.Size = new System.Drawing.Size(916, 150);
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

        public Component loadModPage(Component c)
        {
            PictureBox UpdateModsPic = new System.Windows.Forms.PictureBox();
            UpdateModsPic.Image = global::ModManager4.Properties.Resources.update;
            UpdateModsPic.BackColor = System.Drawing.Color.Transparent;
            UpdateModsPic.Location = new System.Drawing.Point(20, 250);
            UpdateModsPic.Name = "UpdateModsPic";
            UpdateModsPic.Size = new System.Drawing.Size(150, 138);
            UpdateModsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            UpdateModsPic.TabStop = false;
            UpdateModsPic.Cursor = Cursors.Hand;
            UpdateModsPic.Click += new EventHandler(this.events.updateMods);
            UpdateModsPic.Visible = false;
            this.modManager.Controls.Add(UpdateModsPic);
            c.addControl(UpdateModsPic);

            PictureBox RemoveModsPic = new System.Windows.Forms.PictureBox();
            RemoveModsPic.Image = global::ModManager4.Properties.Resources.uninstallall;
            RemoveModsPic.BackColor = System.Drawing.Color.Transparent;
            RemoveModsPic.Location = new System.Drawing.Point(20, 450);
            RemoveModsPic.Name = "RemoveModsPic";
            RemoveModsPic.Size = new System.Drawing.Size(150, 138);
            RemoveModsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            RemoveModsPic.TabStop = false;
            RemoveModsPic.Cursor = Cursors.Hand;
            RemoveModsPic.Click += new EventHandler(this.events.uninstallMods);
            RemoveModsPic.Visible = false;
            this.modManager.Controls.Add(RemoveModsPic);
            c.addControl(RemoveModsPic);

            PictureBox AddLocalPic = new System.Windows.Forms.PictureBox();
            AddLocalPic.Image = global::ModManager4.Properties.Resources.localadd;
            AddLocalPic.BackColor = System.Drawing.Color.Transparent;
            AddLocalPic.Location = new System.Drawing.Point(1130, 250);
            AddLocalPic.Name = "AddLocalPic";
            AddLocalPic.Size = new System.Drawing.Size(110, 110);
            AddLocalPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            AddLocalPic.TabStop = false;
            AddLocalPic.Cursor = Cursors.Hand;
            AddLocalPic.Click += new EventHandler(this.events.localAdd);
            AddLocalPic.Visible = false;
            this.modManager.Controls.Add(AddLocalPic);
            c.addControl(AddLocalPic);

            PictureBox ToolsPic = new System.Windows.Forms.PictureBox();
            ToolsPic.Image = global::ModManager4.Properties.Resources.tools;
            ToolsPic.BackColor = System.Drawing.Color.Transparent;
            ToolsPic.Location = new System.Drawing.Point(1150, 460);
            ToolsPic.Name = "ToolsPic";
            ToolsPic.Size = new System.Drawing.Size(80, 80);
            ToolsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ToolsPic.TabStop = false;
            ToolsPic.Cursor = Cursors.Hand;
            ToolsPic.Click += new EventHandler(this.events.openTools);
            ToolsPic.Visible = false;
            this.modManager.Controls.Add(ToolsPic);
            c.addControl(ToolsPic);

            System.Windows.Forms.Label ToolsText = new System.Windows.Forms.Label();
            ToolsText.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ToolsText.BackColor = Color.Transparent;
            ToolsText.ForeColor = SystemColors.Control;
            ToolsText.Location = new System.Drawing.Point(1155, 550);
            ToolsText.Name = "ToolsText";
            ToolsText.Size = new System.Drawing.Size(150, 20);
            ToolsText.Text = "Tools";
            ToolsText.Cursor = Cursors.Hand;
            ToolsText.Click += new EventHandler(this.events.openTools);
            ToolsText.Visible = false;
            this.modManager.Controls.Add(ToolsText);
            c.addControl(ToolsText);

            Panel PagePanel = new Panel();
            PagePanel.Location = new System.Drawing.Point(184, 190);
            PagePanel.Name = "PagePanel";
            PagePanel.BackColor = Color.Black;
            PagePanel.BorderStyle = BorderStyle.Fixed3D;
            PagePanel.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanel.Size = new System.Drawing.Size(916, 477);
            PagePanel.TabStop = false;
            PagePanel.Visible = false;
            this.modManager.Controls.Add(PagePanel);
            c.addControl(PagePanel);

            System.Windows.Forms.Label ModNameTitle = new System.Windows.Forms.Label();
            ModNameTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModNameTitle.BackColor = Color.Transparent;
            ModNameTitle.ForeColor = SystemColors.Control;
            ModNameTitle.Location = new System.Drawing.Point(60, 20);
            ModNameTitle.Name = "ModNameTitle";
            ModNameTitle.Size = new System.Drawing.Size(150, 20);
            ModNameTitle.Text = "Name";
            PagePanel.Controls.Add(ModNameTitle);

            System.Windows.Forms.Label ModAuthorTitle = new System.Windows.Forms.Label();
            ModAuthorTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModAuthorTitle.BackColor = Color.Transparent;
            ModAuthorTitle.ForeColor = SystemColors.Control;
            ModAuthorTitle.Location = new System.Drawing.Point(210, 20);
            ModAuthorTitle.Name = "ModAuthorTitle";
            ModAuthorTitle.Size = new System.Drawing.Size(150, 20);
            ModAuthorTitle.Text = "Author";
            PagePanel.Controls.Add(ModAuthorTitle);

            System.Windows.Forms.Label ModVersionTitle = new System.Windows.Forms.Label();
            ModVersionTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModVersionTitle.BackColor = Color.Transparent;
            ModVersionTitle.ForeColor = SystemColors.Control;
            ModVersionTitle.Location = new System.Drawing.Point(360, 20);
            ModVersionTitle.Name = "ModVersionTitle";
            ModVersionTitle.Size = new System.Drawing.Size(150, 20);
            ModVersionTitle.Text = "Version";
            PagePanel.Controls.Add(ModVersionTitle);

            System.Windows.Forms.Label ModGithubTitle = new System.Windows.Forms.Label();
            ModGithubTitle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModGithubTitle.ForeColor = SystemColors.Control;
            ModGithubTitle.Location = new System.Drawing.Point(510, 20);
            ModGithubTitle.Name = "ModGithubTitle";
            ModGithubTitle.Size = new System.Drawing.Size(396, 20);
            ModGithubTitle.Text = "More information";
            PagePanel.Controls.Add(ModGithubTitle);

            Panel ModsGroupbox = new Panel();
            ModsGroupbox.Location = new System.Drawing.Point(20, 45);
            ModsGroupbox.Name = "ModsGroupbox";
            ModsGroupbox.Size = new System.Drawing.Size(876, 410);
            ModsGroupbox.AutoScroll = false;
            ModsGroupbox.HorizontalScroll.Enabled = false;
            ModsGroupbox.HorizontalScroll.Visible = false;
            ModsGroupbox.HorizontalScroll.Maximum = 0;
            ModsGroupbox.AutoScroll = true;
            ModsGroupbox.TabStop = false;
            PagePanel.Controls.Add(ModsGroupbox);

            int i = 0;
            int offset = 0;
            foreach (string cat in this.modManager.modlist.getAvailableCategories())
            {
                // Affichage Mod
                System.Windows.Forms.Label CategoryField = new System.Windows.Forms.Label();
                CategoryField.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                CategoryField.ForeColor = System.Drawing.SystemColors.Control;
                CategoryField.Location = new System.Drawing.Point(10, offset);
                CategoryField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                CategoryField.Name = "CategoryField" + i;
                CategoryField.Size = new System.Drawing.Size(200, 20);
                CategoryField.Text = cat;
                ModsGroupbox.Controls.Add(CategoryField);

                offset = offset + 30;

                foreach (Mod mod in this.modManager.modlist.getAvailableModsByCategory(cat))
                {
                    System.Windows.Forms.CheckBox ModCheckbox = new System.Windows.Forms.CheckBox();
                    ModCheckbox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModCheckbox.ForeColor = System.Drawing.SystemColors.Control;
                    ModCheckbox.Location = new System.Drawing.Point(10, offset);
                    //ModCheckbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                    ModCheckbox.Name = mod.id;
                    ModCheckbox.TabStop = false;
                    ModCheckbox.Size = new System.Drawing.Size(20, 20);
                    ModCheckbox.Click += new EventHandler(this.events.checkBox);

                    if (this.modManager.config.containsMod(mod.id))
                    {
                        ModCheckbox.Checked = true;
                    }

                    ModsGroupbox.Controls.Add(ModCheckbox);

                    System.Windows.Forms.Label ModNameField = new System.Windows.Forms.Label();
                    ModNameField.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModNameField.ForeColor = System.Drawing.SystemColors.Control;
                    ModNameField.Location = new System.Drawing.Point(40, offset);
                    //ModNameField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                    ModNameField.Name = "ModNameField=" + mod.id;
                    ModNameField.Size = new System.Drawing.Size(150, 20);
                    ModNameField.Text = mod.name;
                    ModsGroupbox.Controls.Add(ModNameField);

                    System.Windows.Forms.Label ModAuthorField = new System.Windows.Forms.Label();
                    ModAuthorField.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModAuthorField.ForeColor = System.Drawing.SystemColors.Control;
                    ModAuthorField.Location = new System.Drawing.Point(190, offset);
                    //ModAuthorField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                    ModAuthorField.Name = "ModAuthorField=" + mod.id;
                    ModAuthorField.Size = new System.Drawing.Size(150, 20);
                    ModAuthorField.Text = mod.author;
                    ModsGroupbox.Controls.Add(ModAuthorField);

                    System.Windows.Forms.Label ModVersionField = new System.Windows.Forms.Label();
                    ModVersionField.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModVersionField.ForeColor = System.Drawing.SystemColors.Control;
                    ModVersionField.Location = new System.Drawing.Point(340, offset);
                    //ModVersionField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                    ModVersionField.Name = "ModVersionField=" + mod.id;
                    ModVersionField.Size = new System.Drawing.Size(150, 20);
                    if (mod.type == "mod")
                    {
                        ModVersionField.Text = mod.release.TagName;
                    } else
                    {
                        ModVersionField.Text = "1.0";
                    }
                    ModsGroupbox.Controls.Add(ModVersionField);

                    if (mod.type == "mod")
                    {
                        System.Windows.Forms.LinkLabel ModGithubField = new System.Windows.Forms.LinkLabel();
                        ModGithubField.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        ModGithubField.LinkColor = System.Drawing.SystemColors.Control;
                        ModGithubField.ForeColor = System.Drawing.SystemColors.Control;
                        ModGithubField.Location = new System.Drawing.Point(490, offset);
                        //ModGithubField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                        ModGithubField.Name = "ModGithubField=" + mod.id;
                        ModGithubField.Size = new System.Drawing.Size(350, 20);
                        ModGithubField.TabStop = false;
                        ModGithubField.Text = "https://github.com/" + mod.author + "/" + mod.github;
                        ModGithubField.Click += new EventHandler(this.events.openGithub);

                        ModsGroupbox.Controls.Add(ModGithubField);
                    }
                    /*
                    else
                    {
                        System.Windows.Forms.Label RemoveField = new System.Windows.Forms.Label();
                        RemoveField.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        RemoveField.ForeColor = System.Drawing.SystemColors.Control;
                        RemoveField.Location = new System.Drawing.Point(850, offset);
                        RemoveField.Name = "RemoveField=" + mod.id;
                        RemoveField.Size = new System.Drawing.Size(50, 20);
                        RemoveField.Text = "X";
                        RemoveField.Cursor = Cursors.Hand;
                        RemoveField.Click += new EventHandler(this.events.removeLocalMod);

                        ModsGroupbox.Controls.Add(RemoveField);
                    }
                    */

                    offset = offset + 30;
                }

                i++;
            }

            return c;
        }

        public void loadTools(Component c)
        {
            Panel PagePanelTools = new Panel();
            PagePanelTools.Location = new System.Drawing.Point(184, 190);
            PagePanelTools.Name = "PagePanelTools";
            PagePanelTools.BackColor = Color.Black;
            PagePanelTools.BorderStyle = BorderStyle.Fixed3D;
            PagePanelTools.BackgroundImageLayout = ImageLayout.Zoom;
            PagePanelTools.Size = new System.Drawing.Size(916, 477);
            PagePanelTools.TabStop = false;
            PagePanelTools.Visible = false;

            if (this.modManager.toollist.tools.Count > 8)
            {
                PagePanelTools.AutoScroll = false;
                PagePanelTools.HorizontalScroll.Enabled = false;
                PagePanelTools.HorizontalScroll.Visible = false;
                PagePanelTools.HorizontalScroll.Maximum = 0;
                PagePanelTools.AutoScroll = true;
            }

            this.modManager.Controls.Add(PagePanelTools);
            c.addControl(PagePanelTools);

            System.Windows.Forms.Label ToolsTitle = new System.Windows.Forms.Label();
            ToolsTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ToolsTitle.BackColor = Color.Transparent;
            ToolsTitle.ForeColor = SystemColors.Control;
            ToolsTitle.TextAlign = ContentAlignment.MiddleCenter;
            ToolsTitle.Location = new System.Drawing.Point(0, 20);
            ToolsTitle.Name = "ToolsTitle";
            ToolsTitle.Size = new System.Drawing.Size(916, 30);
            ToolsTitle.Text = "Tools";
            PagePanelTools.Controls.Add(ToolsTitle);

            int i = 0;
            foreach ( Tool t in this.modManager.toollist.tools)
            {
                System.Windows.Forms.Label ToolNameField = new System.Windows.Forms.Label();
                ToolNameField.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ToolNameField.ForeColor = System.Drawing.SystemColors.Control;
                ToolNameField.TextAlign = ContentAlignment.MiddleCenter;
                ToolNameField.Location = new System.Drawing.Point(40 + 220*(i%4), 80 + 170*(i/4));
                //ModNameField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                ToolNameField.Name = "ToolNameField=" + t.name;
                ToolNameField.Size = new System.Drawing.Size(150, 20);
                ToolNameField.Text = t.name;
                PagePanelTools.Controls.Add(ToolNameField);
                
                PictureBox ToolPic = new System.Windows.Forms.PictureBox();
                ToolPic.BackColor = System.Drawing.Color.Transparent;
                ToolPic.Location = new System.Drawing.Point(65 + 220*(i%4), 110 + 170*(i/4));
                ToolPic.Name = "ToolPic="+t.name;
                ToolPic.Size = new System.Drawing.Size(100, 100);
                ToolPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                ToolPic.TabStop = false;
                ToolPic.Cursor = Cursors.Hand;
                ToolPic.Click += new EventHandler(this.events.openTool);
                if (t.image == "")
                {
                    ToolPic.Load(this.modManager.serverURL + "\\toolIcons\\default.png");
                } else
                {
                    ToolPic.Load(this.modManager.serverURL + "\\toolIcons\\" + t.image);
                }
                PagePanelTools.Controls.Add(ToolPic);

                if (t.downloadLink != "")
                {
                    System.Windows.Forms.LinkLabel ToolLink = new System.Windows.Forms.LinkLabel();
                    ToolLink.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ToolLink.LinkColor = System.Drawing.SystemColors.Control;
                    ToolLink.ForeColor = System.Drawing.SystemColors.Control;
                    ToolLink.TextAlign = ContentAlignment.MiddleCenter;
                    ToolLink.Location = new System.Drawing.Point(40 + 220 * (i % 4), 220 + 170 * (i / 4));
                    ToolLink.Name = "ToolLink=" + t.name;
                    ToolLink.Size = new System.Drawing.Size(150, 20);
                    ToolLink.Text = "Download";
                    ToolLink.TabStop = false;
                    ToolLink.Click += new EventHandler(this.events.downloadTool);
                    PagePanelTools.Controls.Add(ToolLink);
                }

                i++;
            }
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
