﻿using Microsoft.Win32;
using ModManager5.Forms;
using ModManager5.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class ModManagerUI
    {
        public static Panel MenuPanel;
        public static PictureBox LogoPict;
        public static Panel BottomRightPanel;
        public static Button ModsMenuButton;
        public static Panel BottomLeftPanel;
        public static Panel IconsMenuPanel;
        public static PictureBox RoadmapPict;
        public static PictureBox GithubPict;
        public static PictureBox DiscordPict;
        public static Label VersionLabel;
        public static Panel AppPanel;
        public static Label LoadingLabel;
        public static Button CreditsMenuButton;
        public static Button SettingsMenuButton;
        public static Button FaqMenuButton;
        public static Button NewsMenuButton;
        public static Button AccountMenuButton;
        public static Button ServersMenuButton;
        public static Label StatusLabel;
        public static Panel ModsCategoriesPanel;
        public static Panel AccountPanel;
        public static MMButton StartButton;
        public static Panel StartPanel;

        public static List<Form> CategoryForms;
        public static Form LoginForm;
        public static Form RegisterForm;
        public static Form MyModsForm;
        public static Form MyStatsForm;
        public static Form MyTranslationsForm;
        public static Form MyAccountForm;
        public static Form ServersForm;
        public static Form NewsForm;
        public static Form FaqForm;
        public static Form SettingsForm;
        public static Form CreditsForm;
        public static Form EmptyForm;

        public static TextBox LoginPseudoText;
        public static TextBox LoginPasswordText;
        public static List<Control> allocatedControls;

        public static void load(ModManager modManager)
        {
            Graphics graphics = modManager.CreateGraphics();
            float ratio = 4 / (4 + ((graphics.DpiX - 96) / 24));

            ThemeList.theme.TitleSize = (int) (ratio * ThemeList.theme.TitleSize);
            ThemeList.theme.SubTitleSize = (int)(ratio * ThemeList.theme.SubTitleSize);
            ThemeList.theme.XLSize = (int)(ratio * ThemeList.theme.XLSize);
            ThemeList.theme.MSize = (int)(ratio * ThemeList.theme.MSize);

            MenuPanel = new Panel();
            CreditsMenuButton = new Button();
            SettingsMenuButton = new Button();
            FaqMenuButton = new Button();
            NewsMenuButton = new Button();
            AccountPanel = new Panel();
            AccountMenuButton = new Button();
            ServersMenuButton = new Button();
            ModsCategoriesPanel = new Panel();
            BottomLeftPanel = new Panel();
            IconsMenuPanel = new Panel();
            RoadmapPict = new PictureBox();
            GithubPict = new PictureBox();
            DiscordPict = new PictureBox();
            VersionLabel = new MMLabel();
            ModsMenuButton = new Button();
            LogoPict = new PictureBox();
            BottomRightPanel = new Panel();
            AppPanel = new Panel();
            LoadingLabel = new MMLabel();
            StatusLabel = new MMLabel();
            StartButton = new MMButton("rounded");
            StartPanel = new Panel();

            CategoryForms = new List<Form>() { };
            allocatedControls = new List<Control>() { };

            modManager.BackColor = ThemeList.theme.AppBackgroundColor;

            // 
            // MenuPanel
            // 
            MenuPanel.AutoScroll = true;
            MenuPanel.BackColor = ThemeList.theme.MenuBackgroundColor;
            MenuPanel.Controls.Add(CreditsMenuButton);
            MenuPanel.Controls.Add(SettingsMenuButton);
            MenuPanel.Controls.Add(FaqMenuButton);
            MenuPanel.Controls.Add(NewsMenuButton);
            MenuPanel.Controls.Add(ServersMenuButton);
            MenuPanel.Controls.Add(AccountPanel);
            MenuPanel.Controls.Add(AccountMenuButton);
            MenuPanel.Controls.Add(ModsCategoriesPanel);
            MenuPanel.Controls.Add(BottomLeftPanel);
            MenuPanel.Controls.Add(ModsMenuButton);
            MenuPanel.Controls.Add(LogoPict);
            MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            MenuPanel.Location = new System.Drawing.Point(0, 0);
            MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new System.Drawing.Size(300, 1041);
            // 
            // CreditsMenuButton
            // 
            CreditsMenuButton.BackColor = ThemeList.theme.MenuButtonsColor;
            CreditsMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            CreditsMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            CreditsMenuButton.FlatAppearance.BorderSize = 0;
            CreditsMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreditsMenuButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CreditsMenuButton.ForeColor = ThemeList.theme.TextColor;
            CreditsMenuButton.Location = new System.Drawing.Point(0, 455);
            CreditsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            CreditsMenuButton.Name = "CreditsMenuButton";
            CreditsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            CreditsMenuButton.Size = new System.Drawing.Size(300, 50);
            CreditsMenuButton.Text = Translator.get("Credits");
            CreditsMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            CreditsMenuButton.UseVisualStyleBackColor = false;
            CreditsMenuButton.TabStop = false;

            // 
            // SettingsMenuButton
            // 
            SettingsMenuButton.BackColor = ThemeList.theme.MenuButtonsColor;
            SettingsMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            SettingsMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            SettingsMenuButton.FlatAppearance.BorderSize = 0;
            SettingsMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SettingsMenuButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SettingsMenuButton.ForeColor = ThemeList.theme.TextColor;
            SettingsMenuButton.Location = new System.Drawing.Point(0, 405);
            SettingsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            SettingsMenuButton.Name = "SettingsMenuButton";
            SettingsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            SettingsMenuButton.Size = new System.Drawing.Size(300, 50);
            SettingsMenuButton.Text = Translator.get("Settings");
            SettingsMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            SettingsMenuButton.UseVisualStyleBackColor = false;
            SettingsMenuButton.TabStop = false;

            // 
            // FaqMenuButton
            // 
            FaqMenuButton.BackColor = ThemeList.theme.MenuButtonsColor;
            FaqMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            FaqMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            FaqMenuButton.FlatAppearance.BorderSize = 0;
            FaqMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            FaqMenuButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FaqMenuButton.ForeColor = ThemeList.theme.TextColor;
            FaqMenuButton.Location = new System.Drawing.Point(0, 355);
            FaqMenuButton.Margin = new System.Windows.Forms.Padding(0);
            FaqMenuButton.Name = "FaqMenuButton";
            FaqMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            FaqMenuButton.Size = new System.Drawing.Size(300, 50);
            FaqMenuButton.Text = Translator.get("FAQ");
            FaqMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            FaqMenuButton.UseVisualStyleBackColor = false;
            FaqMenuButton.TabStop = false;

            // 
            // NewsMenuButton
            // 
            NewsMenuButton.BackColor = ThemeList.theme.MenuButtonsColor;
            NewsMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            NewsMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            NewsMenuButton.FlatAppearance.BorderSize = 0;
            NewsMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NewsMenuButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NewsMenuButton.ForeColor = ThemeList.theme.TextColor;
            NewsMenuButton.Location = new System.Drawing.Point(0, 305);
            NewsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            NewsMenuButton.Name = "NewsMenuButton";
            NewsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            NewsMenuButton.Size = new System.Drawing.Size(300, 50);
            NewsMenuButton.Text = Translator.get("News");
            NewsMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            NewsMenuButton.UseVisualStyleBackColor = false;
            NewsMenuButton.TabStop = false;

            // 
            // NewsMenuButton
            // 
            ServersMenuButton.BackColor = ThemeList.theme.MenuButtonsColor;
            ServersMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            ServersMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            ServersMenuButton.FlatAppearance.BorderSize = 0;
            ServersMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ServersMenuButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ServersMenuButton.ForeColor = ThemeList.theme.TextColor;
            ServersMenuButton.Location = new System.Drawing.Point(0, 305);
            ServersMenuButton.Margin = new System.Windows.Forms.Padding(0);
            ServersMenuButton.Name = "ServersMenuButton";
            ServersMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            ServersMenuButton.Size = new System.Drawing.Size(300, 50);
            ServersMenuButton.Text = Translator.get("Servers");
            ServersMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ServersMenuButton.UseVisualStyleBackColor = false;
            ServersMenuButton.TabStop = false;

            // 
            // AccountPanel
            // 
            AccountPanel.Dock = System.Windows.Forms.DockStyle.Top;
            AccountPanel.Name = "AccountPanel";
            AccountPanel.Size = new System.Drawing.Size(300, 0);

            // 
            // AccountMenuButton
            // 
            AccountMenuButton.BackColor = ThemeList.theme.MenuButtonsColor;
            AccountMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            AccountMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            AccountMenuButton.FlatAppearance.BorderSize = 0;
            AccountMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            AccountMenuButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            AccountMenuButton.ForeColor = ThemeList.theme.TextColor;
            AccountMenuButton.Location = new System.Drawing.Point(0, 255);
            AccountMenuButton.Margin = new System.Windows.Forms.Padding(0);
            AccountMenuButton.Name = "AccountMenuButton";
            AccountMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            AccountMenuButton.Size = new System.Drawing.Size(300, 50);
            AccountMenuButton.Text = Translator.get("Account");
            AccountMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            AccountMenuButton.UseVisualStyleBackColor = false;
            AccountMenuButton.TabStop = false;

            // 
            // ModsCategoriesPanel
            // 
            ModsCategoriesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            ModsCategoriesPanel.Name = "ModsCategoriesPanel";
            ModsCategoriesPanel.Size = new System.Drawing.Size(300, 0);
            // 
            // BottomLeftPanel
            // 
            BottomLeftPanel.BackColor = ThemeList.theme.MenuButtonsColor;
            BottomLeftPanel.Controls.Add(IconsMenuPanel);
            BottomLeftPanel.Controls.Add(VersionLabel);
            BottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            BottomLeftPanel.Location = new System.Drawing.Point(0, 941);
            BottomLeftPanel.Name = "BottomLeftPanel";
            BottomLeftPanel.Size = new System.Drawing.Size(300, 100);
            // 
            // IconsMenuPanel
            // 
            IconsMenuPanel.BackColor = ThemeList.theme.MenuButtonsColor;
            IconsMenuPanel.Controls.Add(RoadmapPict);
            IconsMenuPanel.Controls.Add(GithubPict);
            IconsMenuPanel.Controls.Add(DiscordPict);
            IconsMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            IconsMenuPanel.Location = new System.Drawing.Point(0, 30);
            IconsMenuPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IconsMenuPanel.Name = "IconsMenuPanel";
            IconsMenuPanel.Size = new System.Drawing.Size(300, 60);
            IconsMenuPanel.Padding = new Padding(0, 15, 0, 15);
            // 
            // RoadmapPict
            // 
            RoadmapPict.Cursor = System.Windows.Forms.Cursors.Hand;
            RoadmapPict.Dock = System.Windows.Forms.DockStyle.Left;
            RoadmapPict.Image = global::ModManager5.Properties.Resources.roadmap;
            RoadmapPict.Location = new System.Drawing.Point(163, 0);
            RoadmapPict.Margin = new System.Windows.Forms.Padding(0);
            RoadmapPict.Name = "RoadmapPict";
            RoadmapPict.Size = new System.Drawing.Size(90, 30);
            RoadmapPict.Padding = new Padding(30, 0, 30, 0);
            RoadmapPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            RoadmapPict.TabStop = false;
            
            // 
            // GithubPict
            // 
            GithubPict.Cursor = System.Windows.Forms.Cursors.Hand;
            GithubPict.Dock = System.Windows.Forms.DockStyle.Left;
            GithubPict.Image = global::ModManager5.Properties.Resources.github;
            GithubPict.Location = new System.Drawing.Point(93, 0);
            GithubPict.Margin = new System.Windows.Forms.Padding(0);
            GithubPict.Name = "GithubPict";
            GithubPict.Size = new System.Drawing.Size(90, 30);
            GithubPict.Padding = new Padding(30, 0, 30, 0);
            GithubPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            GithubPict.TabStop = false;
            
            // 
            // DiscordPict
            // 
            DiscordPict.Cursor = System.Windows.Forms.Cursors.Hand;
            DiscordPict.Dock = System.Windows.Forms.DockStyle.Left;
            DiscordPict.Image = global::ModManager5.Properties.Resources.discord;
            DiscordPict.Location = new System.Drawing.Point(23, 0);
            DiscordPict.Margin = new System.Windows.Forms.Padding(0);
            DiscordPict.Name = "DiscordPict";
            DiscordPict.Size = new System.Drawing.Size(90, 30);
            DiscordPict.Padding = new Padding(30, 0, 30, 0);
            DiscordPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            DiscordPict.TabStop = false;
            
            // 
            // VersionLabel
            // 
            VersionLabel.BackColor = ThemeList.theme.MenuButtonsColor;
            VersionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            VersionLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            VersionLabel.ForeColor = ThemeList.theme.TextColor;
            VersionLabel.Location = new System.Drawing.Point(0, 60);
            VersionLabel.Margin = new System.Windows.Forms.Padding(0);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            VersionLabel.Size = new System.Drawing.Size(300, 40);
            VersionLabel.Text = "Mod Manager Version " + (ModManager.version.Major == 5 ? ModManager.visibleVersion : "5 Beta");
            VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModsMenuButton
            // 
            ModsMenuButton.BackColor = ThemeList.theme.MenuButtonsColor;
            ModsMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            ModsMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            ModsMenuButton.FlatAppearance.BorderSize = 0;
            ModsMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ModsMenuButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ModsMenuButton.ForeColor = ThemeList.theme.TextColor;
            ModsMenuButton.Location = new System.Drawing.Point(0, 115);
            ModsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            ModsMenuButton.Name = "ModsMenuButton";
            ModsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            ModsMenuButton.Size = new System.Drawing.Size(300, 50);
            ModsMenuButton.Text = Translator.get("Mods");
            ModsMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ModsMenuButton.UseVisualStyleBackColor = false;
            ModsMenuButton.TabStop = false;

            // 
            // LogoPict
            // 
            LogoPict.Dock = System.Windows.Forms.DockStyle.Top;
            LogoPict.Image = global::ModManager5.Properties.Resources.modmanager_logo;
            LogoPict.Location = new System.Drawing.Point(0, 0);
            LogoPict.Margin = new System.Windows.Forms.Padding(0);
            LogoPict.Name = "LogoPict";
            LogoPict.Size = new System.Drawing.Size(300, 115);
            LogoPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            LogoPict.TabStop = false;
            // 
            // BottomRightPanel
            // 
            BottomRightPanel.BackColor = ThemeList.theme.StatusBarColor;
            BottomRightPanel.Controls.Add(StatusLabel);
            BottomRightPanel.Controls.Add(StartPanel);
            BottomRightPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            BottomRightPanel.ForeColor = ThemeList.theme.TextColor;
            BottomRightPanel.Location = new System.Drawing.Point(300, 941);
            BottomRightPanel.Margin = new System.Windows.Forms.Padding(0);
            BottomRightPanel.Name = "BottomRightPanel";
            BottomRightPanel.Size = new System.Drawing.Size(1604, 100);
            
            // 
            // AppPanel
            // 
            AppPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            AppPanel.ForeColor = ThemeList.theme.TextColor;
            AppPanel.BackColor = ThemeList.theme.AppBackgroundColor;
            AppPanel.Location = new System.Drawing.Point(320, 20);
            AppPanel.Margin = new System.Windows.Forms.Padding(0);
            AppPanel.Padding = new Padding(10, 10, 10, 10);
            AppPanel.Name = "AppPanel";
            AppPanel.Size = new System.Drawing.Size(1564, 901);
            // 
            // LoadingLabel
            // 
            LoadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            LoadingLabel.AutoSize = true;
            LoadingLabel.Font = new System.Drawing.Font(ThemeList.theme.TitleFont, ThemeList.theme.TitleSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LoadingLabel.Location = new System.Drawing.Point(0, 424);
            LoadingLabel.Name = "LoadingLabel";
            LoadingLabel.Size = new System.Drawing.Size(1564, 30);
            LoadingLabel.AutoSize = false;
            LoadingLabel.TextAlign = ContentAlignment.MiddleCenter;
            LoadingLabel.Text = Translator.get("Loading Mod Manager, please wait...");
            AppPanel.Controls.Add(LoadingLabel);

            // 
            // StartButton
            // 

            StartPanel.Controls.Add(StartButton);
            StartPanel.Dock = DockStyle.Right;
            StartPanel.ForeColor = ThemeList.theme.TextColor;
            StartPanel.Size = new Size(300, 60);
            StartPanel.Margin = new System.Windows.Forms.Padding(0);
            StartPanel.Padding = new Padding(20, 20, 20, 20);
            StartPanel.Name = "StartPanel";

            StartButton.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StartButton.Dock = DockStyle.Bottom;
            StartButton.BackColor = ThemeList.theme.ButtonsColor;
            StartButton.Size = new Size(300, 60);
            StartButton.TextAlign = ContentAlignment.MiddleCenter;
            StartButton.Name = "StartButton";
            StartButton.Text = Translator.get("Start Vanilla Among Us");
            StartButton.TabStop = false;

            // 
            // StatusLabel
            // 
            StatusLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StatusLabel.Dock = DockStyle.Left;
            StatusLabel.Size = new Size(500, 30);
            StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            StatusLabel.Padding = new Padding(10, 10, 10, 10);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Text = Translator.get("Loading...");
            StatusLabel.TabStop = false;


            modManager.Controls.Add(AppPanel);
            modManager.Controls.Add(BottomRightPanel);
            modManager.Controls.Add(MenuPanel);
        }

        public static void InitUI()
        {
            foreach(Control c in allocatedControls)
            {
                c.Dispose();
            }
            allocatedControls.Clear();
            //loadLocalMods();
            loadEmpty();
            loadMods();
            loadAccount();
            loadServers();
            loadNews();
            loadFaq();
            loadSettings();
            loadCredits();
        }

        public static void InitForm()
        {
            if (CategoryForms.Count() > 0)
            {
                showMenuPanel(ModsCategoriesPanel);
                openForm(CategoryForms.Last());
            } else
            {
                openForm(EmptyForm);
            }
        }

        public static void InitListeners()
        {
            ModsMenuButton.Click += new EventHandler((object sender, EventArgs e) => {
                showMenuPanel(ModsCategoriesPanel);
            });
            CreditsMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                showMenuPanel();
            });
            SettingsMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                showMenuPanel();
            });
            FaqMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                showMenuPanel();
            });
            NewsMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                showMenuPanel();
            });
            AccountMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                showMenuPanel(AccountPanel);
            });
            RoadmapPict.Click += new EventHandler((object sender, EventArgs e) => {

                Process.Start("explorer", ModManager.serverURL + @"\roadmap");
            });
            GithubPict.Click += new EventHandler((object sender, EventArgs e) => {

                Process.Start("explorer", ModManager.serverURL + @"\github");
            });
            DiscordPict.Click += new EventHandler((object sender, EventArgs e) => {

                Process.Start("explorer", ModManager.serverURL + @"\discord");
            });
            StartButton.Click += new EventHandler((object sender, EventArgs e) => {

                ModWorker.startGame(true);
            });
            ServersMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                showMenuPanel();
                openForm(ServersForm);
            });
            NewsMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                openForm(NewsForm);
            });
            FaqMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                openForm(FaqForm);
            });
            SettingsMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                openForm(SettingsForm);
            });
            CreditsMenuButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                openForm(CreditsForm);
            });
        }

        public static void hideMenuPanels()
        {
            if (ModsCategoriesPanel.Visible == true)
                ModsCategoriesPanel.Visible = false;
            if (AccountPanel.Visible == true)
                AccountPanel.Visible = false;
        }

        public static void showMenuPanel(Panel subMenu = null)
        {
            if (subMenu == null || subMenu.Visible == false)
            {
                hideMenuPanels();
                if (subMenu != null)
                {
                    subMenu.Visible = true;
                }
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        public static Form activeForm = null;

        public static void openForm(Form form)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.BackColor = ThemeList.theme.AppBackgroundColor;
            AppPanel.Controls.Add(form);
            AppPanel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private static Button CreateSubMenuButton(string name)
        {
            Button SubMenuButton = new Button();
            SubMenuButton.BackColor = ThemeList.theme.MenuSubButtonsColor;
            SubMenuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            SubMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            SubMenuButton.FlatAppearance.BorderSize = 0;
            SubMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SubMenuButton.Font = new System.Drawing.Font(ThemeList.theme.MFont, ThemeList.theme.MSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            SubMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            SubMenuButton.Margin = new System.Windows.Forms.Padding(0);
            SubMenuButton.Name = "SubMenuButton";
            SubMenuButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            SubMenuButton.Size = new System.Drawing.Size(300, 40);
            SubMenuButton.Text = Translator.get(name);
            SubMenuButton.UseMnemonic = false;
            SubMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            SubMenuButton.UseVisualStyleBackColor = false;
            SubMenuButton.TabStop = false;

            return SubMenuButton;
        }

        public static void loadMods()
        {
            // SubMenus

            List<Category> cats = CategoryManager.categories;
            cats.Reverse();
            int size = 0;
            foreach (Category c in cats)
            {
                if (ModList.getModsByCategory(c.id).Count() > 0 || c.id == "local")
                {
                    size++;
                    Button b = CreateSubMenuButton(c.name);

                    Form f = new GenericPanel();
                    f.Name = c.id;
                    CategoryForms.Add(f);

                    b.Click += new EventHandler((object sender, EventArgs e) => {
                        openForm(f);
                    });

                    ModsCategoriesPanel.Controls.Add(b);
                }
                
            }
            
            ModsCategoriesPanel.Size = new Size(300, 40 * size);

            // Forms
            
            foreach (Form f in CategoryForms)
            {
                refreshModForm(f);
            }
            
        }

        public static Form getFormByCategoryId(string id)
        {
            return CategoryForms.Find(f => f.Name == id);
        }

        public static void refreshModForm(Form f)
        {
            f.Controls.Clear();

            Category cat = CategoryManager.getCategoryById(f.Name);

            List<Mod> mods = new List<Mod>() { };
            
            if (cat.id == "local")
            {
                mods.AddRange(ModList.localMods);
                int nextId = ModList.localMods.Count();
                mods.Add(new Mod("LocalMod" + nextId, "NewMod" + nextId, "local", "local", ServerConfig.get("gameVersion").value, new List<string>() { DependencyList.dependencies.Find(d => d.id.Contains("BepInEx")).id }, "", "", "0", "", new List<string>() { }));

            } else
            {
                mods = ModList.getModsByCategory(f.Name);
            }
            //mods.Reverse();

            Panel ContainerPanel = new Panel();
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.BackColor = Color.Transparent;
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.AutoScroll = true;
            f.Controls.Add(ContainerPanel);

            TableLayoutPanel ModPanel = new TableLayoutPanel();
            ModPanel.Name = "ModPanel";
            ModPanel.BackColor = Color.Transparent;
            ModPanel.Dock = DockStyle.Top;
            ContainerPanel.Controls.Add(ModPanel);

            if (cat.id == "local")
            {
                ModPanel.ColumnCount = 6;
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            } else
            {
                ModPanel.ColumnCount = 7;
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7F));
            }
            
            int size = mods.Count();
            float ratio = 0F;
            if (size != 0)
            {
                ratio = (float)(100 / size);
            }

            ModPanel.RowCount = size;
            if (cat.id == "local")
            {
                ModPanel.Size = new System.Drawing.Size(100, 100 * size);

            } else
            {

                ModPanel.Size = new System.Drawing.Size(100, 50 * size);
            }
            foreach (Mod m in mods)
            {
                ModPanel.RowStyles.Add(new RowStyle(SizeType.Percent, ratio));
            }

            int line = 0;
            foreach (Mod m in mods)
            {
                InstalledMod im = ConfigManager.getInstalledModById(m.id);
                
                if (m.type != "local") {
                    
                    if (m.id == "BetterCrewlink" && im == null)
                    {
                        object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);

                        if (o != null && System.IO.File.Exists(o.ToString() + @"\Better-CrewLink.exe"))
                        {
                            InstalledMod bcl = new InstalledMod(m.id, "", "");
                            ConfigManager.config.installedMods.Add(bcl);
                            ConfigManager.update();
                            im = ConfigManager.getInstalledModById(m.id);
                        }


                    }

                    
                    if (im == null)
                    {
                        PictureBox ModDownload = new PictureBox();
                        ModDownload.Cursor = System.Windows.Forms.Cursors.Hand;
                        ModDownload.Dock = DockStyle.Fill;
                        ModDownload.Image = global::ModManager5.Properties.Resources.download;
                        ModDownload.Margin = new System.Windows.Forms.Padding(0);
                        ModDownload.Name = "ModDownload";
                        ModDownload.Size = new System.Drawing.Size(60, 50);
                        ModDownload.Padding = new Padding(15, 10, 15, 10);
                        ModDownload.Margin = new Padding(10, 10, 10, 10);
                        ModDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        ModDownload.TabStop = false;
                        ModDownload.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModWorker.installAnyMod(m);
                        });

                        allocatedControls.Add(ModDownload);
                        
                        ModPanel.Controls.Add(ModDownload, 4, line);
                    }
                    else if (((m.type != "allInOne" || m.id == "Challenger" || m.id == "ChallengerBeta") && im.version != m.release.TagName) || (m.type != "allInOne" && im.gameVersion != m.gameVersion))
                    {
                        
                        PictureBox ModUpdate = new PictureBox();
                        ModUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
                        ModUpdate.Dock = DockStyle.Fill;
                        ModUpdate.Image = global::ModManager5.Properties.Resources.updateMod;
                        ModUpdate.Margin = new System.Windows.Forms.Padding(0);
                        ModUpdate.Name = "ModUpdate";
                        ModUpdate.Size = new System.Drawing.Size(60, 50);
                        ModUpdate.Padding = new Padding(15, 10, 15, 10);
                        ModUpdate.Margin = new Padding(10, 10, 10, 10);
                        ModUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        ModUpdate.TabStop = false;
                        ModUpdate.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModWorker.installAnyMod(m);
                        });
                        allocatedControls.Add(ModUpdate);

                        ModPanel.Controls.Add(ModUpdate, 4, line);
                        
                    }
                    else
                    {
                        
                        PictureBox ModPlay = new PictureBox();
                        ModPlay.Cursor = System.Windows.Forms.Cursors.Hand;
                        ModPlay.Dock = DockStyle.Fill;
                        ModPlay.Image = global::ModManager5.Properties.Resources.play;
                        ModPlay.Margin = new System.Windows.Forms.Padding(0);
                        ModPlay.Name = "ModPlay";
                        ModPlay.Size = new System.Drawing.Size(60, 50);
                        ModPlay.Padding = new Padding(15, 10, 15, 10);
                        ModPlay.Margin = new Padding(10, 10, 10, 10);
                        ModPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        ModPlay.TabStop = false;
                        ModPlay.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModWorker.startMod(m);
                        });
                        allocatedControls.Add(ModPlay);
                        ModPanel.Controls.Add(ModPlay, 4, line);
                        
                    }
                    
                    
                    PictureBox ModUninstall = new PictureBox();
                    ModUninstall.Dock = DockStyle.Fill;
                    ModUninstall.Margin = new System.Windows.Forms.Padding(0);
                    ModUninstall.Name = "ModUninstall";
                    ModUninstall.Size = new System.Drawing.Size(60, 50);
                    ModUninstall.Padding = new Padding(15, 10, 15, 10);
                    ModUninstall.Margin = new Padding(10, 10, 10, 10);
                    ModUninstall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    ModUninstall.TabStop = false;

                    allocatedControls.Add(ModUninstall);

                    ModPanel.Controls.Add(ModUninstall, 5, line);

                    if (im != null && m.id != "BetterCrewlink")
                    {
                        ModUninstall.Click += new EventHandler((object sender, EventArgs e) => {
                            if (MessageBox.Show(Translator.get("Are you sure you want to remove this mod ?"), Translator.get("Remove mod"), MessageBoxButtons.YesNo) == DialogResult.Yes) // TODO
                            {
                                ModWorker.UninstallMod(m);
                            }
                        });
                        ModUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
                        ModUninstall.Image = global::ModManager5.Properties.Resources.remove;
                    }

                    PictureBox ModSave = new PictureBox();
                    ModSave.Cursor = System.Windows.Forms.Cursors.Hand;
                    ModSave.Dock = DockStyle.Fill;
                    ModSave.Image = global::ModManager5.Properties.Resources.export;
                    ModSave.Margin = new System.Windows.Forms.Padding(0);
                    ModSave.Name = "ModSave";
                    ModSave.Size = new System.Drawing.Size(60, 50);
                    ModSave.Padding = new Padding(15, 10, 15, 10);
                    ModSave.Margin = new Padding(10, 10, 10, 10);
                    ModSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    ModSave.TabStop = false;
                    ModSave.Click += new EventHandler((object sender, EventArgs e) => {
                        ModList.createShortcut(m);
                    });
                    allocatedControls.Add(ModSave);
                    ModPanel.Controls.Add(ModSave, 6, line);

                    System.Windows.Forms.LinkLabel ModGithub = new System.Windows.Forms.LinkLabel();
                    ModGithub.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModGithub.LinkColor = System.Drawing.SystemColors.Control;
                    ModGithub.ForeColor = System.Drawing.SystemColors.Control;
                    ModGithub.Name = "ModGithub=" + m.id;
                    ModGithub.TextAlign = ContentAlignment.MiddleLeft;
                    ModGithub.TabStop = false;
                    ModGithub.Dock = DockStyle.Left;
                    ModGithub.Padding = new Padding(12, 0, 0, 0);
                    ModGithub.Size = new System.Drawing.Size(700, 50);
                    allocatedControls.Add(ModGithub);
                    if (m.githubLink == "1")
                    {
                        ModGithub.Text = "https://github.com/" + m.author + "/" + m.github;
                    }
                    else
                    {
                        ModGithub.Text = m.github;
                    }
                    ModGithub.Click += new EventHandler((object sender, EventArgs e) => {
                        LinkLabel clickedLink = ((LinkLabel)sender);
                        string link = clickedLink.Text;
                        Process.Start("explorer", link);
                    });
                    ModPanel.Controls.Add(ModGithub, 3, line);

                    System.Windows.Forms.Label ModVersion = new System.Windows.Forms.Label();
                    ModVersion.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModVersion.BackColor = Color.Transparent;
                    ModVersion.ForeColor = SystemColors.Control;
                    ModVersion.TextAlign = ContentAlignment.MiddleLeft;
                    ModVersion.Dock = DockStyle.Left;
                    ModVersion.Name = "ModVersion=" + m.id;
                    ModVersion.Padding = new Padding(12, 0, 0, 0);
                    ModVersion.Size = new System.Drawing.Size(150, 50);
                    ModVersion.TabStop = false;
                    allocatedControls.Add(ModVersion);
                    if (m.githubLink == "1")
                    {
                        ModVersion.Text = m.release.TagName;
                    }
                    else
                    {
                        ModVersion.Text = "";
                    }
                    ModPanel.Controls.Add(ModVersion, 2, line);

                    System.Windows.Forms.LinkLabel ModAuthor = new System.Windows.Forms.LinkLabel();
                    ModAuthor.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModAuthor.LinkColor = SystemColors.Control;
                    ModAuthor.ForeColor = SystemColors.Control;
                    ModAuthor.TextAlign = ContentAlignment.MiddleLeft;
                    ModAuthor.Dock = DockStyle.Left;
                    ModAuthor.Name = "ModAuthor=" + m.id;
                    ModAuthor.Padding = new Padding(12, 0, 0, 0);
                    ModAuthor.Size = new System.Drawing.Size(250, 50);
                    ModAuthor.Text = m.author;
                    ModAuthor.TabStop = false;
                    allocatedControls.Add(ModAuthor);

                    if (m.githubLink == "1")
                    {
                        ModAuthor.Click += new EventHandler((object sender, EventArgs e) => {
                            LinkLabel clickedLink = ((LinkLabel)sender);
                            string link = clickedLink.Text;
                            Process.Start("explorer", "https://github.com/" + link);
                        });
                    }
                    else
                    {
                        ModAuthor.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
                    }

                    ModPanel.Controls.Add(ModAuthor, 1, line);

                    System.Windows.Forms.Label ModTitle = new System.Windows.Forms.Label();

                    ModTitle.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModTitle.BackColor = Color.Transparent;
                    ModTitle.ForeColor = SystemColors.Control;
                    ModTitle.TextAlign = ContentAlignment.MiddleLeft;
                    ModTitle.Dock = DockStyle.Left;
                    ModTitle.Name = "ModTitle";
                    ModTitle.Padding = new Padding(12, 0, 0, 0);
                    ModTitle.Size = new System.Drawing.Size(250, 50);
                    ModTitle.Text = (m.type == "allInOne" || m.gameVersion == ServerConfig.get("gameVersion").value) ? m.name : m.name + "*";
                    ModTitle.TabStop = false;
                    ModPanel.Controls.Add(ModTitle, 0, line);
                    allocatedControls.Add(ModTitle);

                } else
                {
                    Boolean last = line == mods.Count() - 1;
                    PictureBox ModRemovedPic = new PictureBox();
                    PictureBox ModValidPic = new PictureBox();
                    PictureBox ModStartPic = new PictureBox();

                    MMButton FileButton = new MMButton("rounded");
                    FileButton.AutoSize = true;
                    FileButton.Margin = new System.Windows.Forms.Padding(10, 20, 10, 10);
                    FileButton.Size = new Size(0, 80);
                    FileButton.Dock = DockStyle.Top;

                    if (last)
                    {
                        // Change path for new local mod
                        FileButton.Text = Translator.get("No file selected");
                        FileButton.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            OpenFileDialog folderBrowser = new OpenFileDialog();
                            folderBrowser.ValidateNames = false;
                            folderBrowser.CheckFileExists = false;
                            folderBrowser.CheckPathExists = true;
                            folderBrowser.Filter = Translator.get("ZIP mod file") + "|*.zip";
                            // Always default to Folder Selection.
                            folderBrowser.FileName = "*.zip";

                            if (folderBrowser.ShowDialog() == DialogResult.OK)
                            {
                                FileButton.Text = folderBrowser.FileName;
                            }
                        });
                    }
                    else
                    {
                        // Change path for existing local mod
                        FileButton.Text = Translator.get("Change file");
                        FileButton.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            OpenFileDialog folderBrowser = new OpenFileDialog();
                            folderBrowser.ValidateNames = false;
                            folderBrowser.CheckFileExists = false;
                            folderBrowser.CheckPathExists = true;
                            folderBrowser.Filter = Translator.get("ZIP mod file") + "|*.zip";
                            // Always default to Folder Selection.
                            folderBrowser.FileName = "*.zip";

                            if (folderBrowser.ShowDialog() == DialogResult.OK)
                            {
                                FileButton.Text = folderBrowser.FileName;
                                ModValidPic.Show();
                            }
                        });

                    }


                    ModPanel.Controls.Add(FileButton, 2, line);

                    MMComboBox ModVersion = new MMComboBox();
                    ModVersion.Margin = new Padding(12, 25, 0, 25);
                    ModVersion.Dock = DockStyle.Left;

                    foreach (InstalledVanilla vanilla in ConfigManager.config.installedVanilla)
                    {
                        ModVersion.Items.Add(vanilla.version);
                    }

                    if (ModVersion.Items.Contains(m.gameVersion))
                    {
                        ModVersion.SelectedItem = m.gameVersion;
                    }

                    if (!last)
                    {
                        ModVersion.SelectionChangeCommitted += new EventHandler((object sender, EventArgs e) => {
                            ModValidPic.Show();
                        });
                    }


                    ModPanel.Controls.Add(ModVersion, 1, line);

                    MMTextbox ModTitle = new MMTextbox();
                    ModTitle.BackColor = ThemeList.theme.TextColor;
                    ModTitle.ForeColor = ThemeList.theme.AppBackgroundColor;
                    ModTitle.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ModTitle.Dock = DockStyle.Left;
                    ModTitle.Name = m.id;
                    ModTitle.Margin = new Padding(12, 25, 10, 15);
                    ModTitle.Size = new System.Drawing.Size(250, 50);
                    ModTitle.Text = (m.gameVersion == ServerConfig.get("gameVersion").value) ? m.name : m.name + "*";
                    ModTitle.TabStop = false;

                    if (!last)
                    {
                        ModTitle.TextChanged += new EventHandler((object sender, EventArgs e) => {
                            ModValidPic.Show();
                        });
                    }

                    ModPanel.Controls.Add(ModTitle, 0, line);

                    ModRemovedPic.Name = "ModRemovedPic=" + m.id;
                    ModRemovedPic.BackColor = ThemeList.theme.AppBackgroundColor;
                    ModRemovedPic.ForeColor = ThemeList.theme.TextColor;
                    ModRemovedPic.Dock = DockStyle.Top;
                    ModRemovedPic.Size = new Size(0, 50);
                    ModRemovedPic.Margin = new Padding(0, 15, 0, 25);
                    ModRemovedPic.Cursor = Cursors.Hand;
                    ModRemovedPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    ModRemovedPic.TabStop = false;
                    if (last)
                    {
                        // Add a local mod
                        ModRemovedPic.Image = global::ModManager5.Properties.Resources.plus;
                        ModRemovedPic.Click += new EventHandler((object sender, EventArgs e) => {
                            if (FileButton.Text != "" && FileButton.Text != Translator.get("No file selected"))
                            {
                                ModWorker.startTransaction();
                                StatusLabel.Text = Translator.get("Adding local mod...");
                                string newPath = ModManager.appDataPath + @"\localMods\" + ModTitle.Text;
                                Directory.CreateDirectory(newPath);
                                string tempPath = ModManager.tempPath + @"\ModZip";
                                Utils.DirectoryDelete(tempPath);
                                Directory.CreateDirectory(tempPath);
                                ZipFile.ExtractToDirectory(FileButton.Text, tempPath);
                                tempPath = ModWorker.getBepInExInsideRec(tempPath);
                                Utils.DirectoryCopy(tempPath, newPath, true);

                                Mod newLocalMod = new Mod(ModTitle.Name, ModTitle.Text, "local", "local", ModVersion.Text, new List<string>() { }, "", @"localMods\"+ModTitle.Text, "0", "", new List<string>() { }) ;
                                
                                ModList.localMods.Add(newLocalMod);

                                ModList.updateLocalMods();
                                openForm(EmptyForm);
                                ModManagerUI.refreshModForm(f);
                                openForm(f);
                                StatusLabel.Text = Translator.get("Local mod added");
                                ModWorker.endTransaction();
                            }
                        });
                    } else
                    {
                        // Remove a local mod
                        ModRemovedPic.Image = global::ModManager5.Properties.Resources.remove;
                        ModRemovedPic.Click += new EventHandler((object sender, EventArgs e) => {
                            ModWorker.startTransaction();
                            StatusLabel.Text = Translator.get("Removing local mod...");
                            string picName = ((PictureBox)sender).Name;
                            string modId = picName.Substring(picName.IndexOf("=") + 1);
                            Mod m = ModList.getLocalModById(modId);

                            string path = m.github.Replace(@"localMods\", ModManager.appDataPath + @"\localMods\");
                            Utils.DirectoryDelete(path);

                            ModList.localMods.Remove(m);
                            ModList.updateLocalMods();
                            openForm(EmptyForm);
                            ModManagerUI.refreshModForm(f);
                            openForm(f);
                            StatusLabel.Text = "Local mod removed";
                            ModWorker.endTransaction();
                        });
                    }
                    allocatedControls.Add(ModRemovedPic);
                    ModPanel.Controls.Add(ModRemovedPic, 5, line);

                    if (!last)
                    {
                        ModStartPic.Image = global::ModManager5.Properties.Resources.play;
                        ModStartPic.Name = "ModStartPic=" + m.id;
                        ModStartPic.BackColor = ThemeList.theme.AppBackgroundColor;
                        ModStartPic.ForeColor = ThemeList.theme.TextColor;
                        ModStartPic.Dock = DockStyle.Top;
                        ModStartPic.Size = new Size(0, 50);
                        ModStartPic.Margin = new Padding(0, 15, 0, 25);
                        ModStartPic.Cursor = Cursors.Hand;
                        ModStartPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        ModStartPic.TabStop = false;

                        ModStartPic.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModWorker.startMod(m);
                        });

                        ModPanel.Controls.Add(ModStartPic, 3, line);

                        ModValidPic.Image = global::ModManager5.Properties.Resources.valid;
                        ModValidPic.Name = "ModValidPic=" + m.id;
                        ModValidPic.BackColor = ThemeList.theme.AppBackgroundColor;
                        ModValidPic.ForeColor = ThemeList.theme.TextColor;
                        ModValidPic.Dock = DockStyle.Top;
                        ModValidPic.Size = new Size(0, 50);
                        ModValidPic.Margin = new Padding(0, 15, 0, 25);
                        ModValidPic.Cursor = Cursors.Hand;
                        ModValidPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        ModValidPic.TabStop = false;
                        ModValidPic.Hide();

                        ModValidPic.Click += new EventHandler((object sender, EventArgs e) => {
                            // Valid changes for a local mod
                            StatusLabel.Text = Translator.get("Editing local mod...");
                            ModWorker.startTransaction();
                            string picName = ((PictureBox)sender).Name;
                            string modId = picName.Substring(picName.IndexOf("=") + 1);
                            Mod m = ModList.getLocalModById(modId);

                            if (m.name != ModTitle.Text)
                            {
                                Utils.DirectoryCopy(ModManager.appDataPath + @"\localMods\" + m.name, ModManager.appDataPath + @"\localMods\" + ModTitle.Text, true);
                                Utils.DirectoryDelete(ModManager.appDataPath + @"\localMods\" + m.name);
                                m.name = ModTitle.Text;
                                m.github = @"localMods\" + m.name;
                            }

                            if (m.gameVersion != ModVersion.Text)
                            {
                                m.gameVersion = ModVersion.Text;
                            }

                            if (FileButton.Text != "" && FileButton.Text != Translator.get("Change file"))
                            {
                                string newPath = ModManager.appDataPath + @"\localMods\" + m.name;
                                Directory.CreateDirectory(newPath);
                                string tempPath = ModManager.tempPath + @"\ModZip";
                                Utils.DirectoryDelete(tempPath);
                                Directory.CreateDirectory(tempPath);
                                ZipFile.ExtractToDirectory(FileButton.Text, tempPath);
                                tempPath = ModWorker.getBepInExInsideRec(tempPath);
                                Utils.DirectoryCopy(tempPath, newPath, true);

                                m.github = @"localMods\" + m.name;
                            }

                            ModList.updateLocalMods();
                            ModValidPic.Hide();
                            StatusLabel.Text = Translator.get("Local mod edited");
                            ModWorker.endTransaction();
                        });

                        allocatedControls.Add(ModStartPic);
                        allocatedControls.Add(ModValidPic);

                        ModPanel.Controls.Add(ModValidPic, 4, line);
                    }
                }

                line++;
            }

            if (cat.id == "local")
            {
                f.Controls.Add(Visuals.LocalModsOverlay());
            } else
            {
                f.Controls.Add(Visuals.ModsOverlay());
            }

            f.Controls.Add(Visuals.LabelTitle(Translator.get(cat.name)));
        }

        public static void loadAccount()
        {
            AccountPanel.Controls.Clear();
            
            // SubMenu

            if (MatuxAPI.logged)
            {


                int panelSize = 80;

                Button b2 = CreateSubMenuButton("Logout");

                b2.Click += new EventHandler((object sender, EventArgs e) => {
                    MatuxAPI.logout();
                    loadAccount();
                    openForm(LoginForm);
                });
                AccountPanel.Controls.Add(b2);

                if (MatuxAPI.isTranslator() && MatuxAPI.currentLg != "EN")
                {
                    MyTranslationsForm = new GenericPanel();

                    Button b4 = CreateSubMenuButton("Translations");

                    b4.Click += new EventHandler((object sender, EventArgs e) => {
                        openForm(MyTranslationsForm);
                    });
                    AccountPanel.Controls.Add(b4);
                    panelSize = panelSize + 40;

                    loadMyTranslationsForm(MyTranslationsForm);
                }

                if (MatuxAPI.isModder())
                {
                    MyModsForm = new GenericPanel();

                    Button b = CreateSubMenuButton("My Mods");

                    b.Click += new EventHandler((object sender, EventArgs e) => {
                        openForm(MyModsForm);
                    });
                    AccountPanel.Controls.Add(b);
                    panelSize = panelSize + 40;

                    loadMyModsForm(MyModsForm);
                }

                AccountPanel.Size = new Size(300, panelSize);

                MyAccountForm = new GenericPanel();

                Button b1 = CreateSubMenuButton("My Account");

                loadAccountForm(MyAccountForm);

                b1.Click += new EventHandler((object sender, EventArgs e) => {
                    openForm(MyAccountForm);
                });
                AccountPanel.Controls.Add(b1);

            } else
            {
                AccountPanel.Size = new Size(300, 40);

                LoginForm = new GenericPanel();

                // Login

                Button b = CreateSubMenuButton("Login");

                b.Click += new EventHandler((object sender, EventArgs e) => {
                    openForm(LoginForm);
                });
                AccountPanel.Controls.Add(b);

                loadLoginForm(LoginForm);
            }
        }

        private static void loadAccountForm(Form f)
        {
            Panel AccountContainerPanel = Visuals.createPanel();
            f.Controls.Add(AccountContainerPanel);

            TableLayoutPanel AccountPanel = Visuals.createLayoutPanelV(0, 600, DockStyle.Top, new int[] { 20, 10, 10, 10, 10, 10, 10, 20 });

            AccountContainerPanel.Controls.Add(AccountPanel);


            f.Controls.Add(Visuals.LabelTitle(Translator.get("Welcome to Matux.fr")));

            PictureBox MatuxLogoPict = new PictureBox();
            MatuxLogoPict.Image = global::ModManager5.Properties.Resources.matux;
            MatuxLogoPict.Dock = DockStyle.Top;
            MatuxLogoPict.Margin = new System.Windows.Forms.Padding(0);
            MatuxLogoPict.Name = "MatuxLogoPict";
            MatuxLogoPict.Size = new Size(100, 100);
            MatuxLogoPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MatuxLogoPict.TabStop = false;
            AccountPanel.Controls.Add(MatuxLogoPict, 0, 0);

            MMLabel DescriptionLabel = new MMLabel();
            DescriptionLabel.Dock = DockStyle.Top;
            DescriptionLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DescriptionLabel.Size = new Size(0, 100);
            DescriptionLabel.ForeColor = ThemeList.theme.TextColor;
            DescriptionLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            DescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            DescriptionLabel.TabStop = false;
            DescriptionLabel.Text = Translator.get("You are logged as LOGIN").Replace("LOGIN", MatuxAPI.token.Substring(0, MatuxAPI.token.IndexOf("&")));
            AccountPanel.Controls.Add(DescriptionLabel, 0, 1);

            MMLabel OnlineLabel = new MMLabel();
            OnlineLabel.Dock = DockStyle.Top;
            OnlineLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OnlineLabel.Size = new Size(0, 100);
            OnlineLabel.ForeColor = ThemeList.theme.TextColor;
            OnlineLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            OnlineLabel.TextAlign = ContentAlignment.MiddleCenter;
            OnlineLabel.TabStop = false;
            OnlineLabel.Text = Translator.get("Click here to access your online panel");
            OnlineLabel.Click += new EventHandler((object sender, EventArgs e) => {
                int index = MatuxAPI.token.IndexOf("&");
                if (index != -1)
                    Process.Start(new ProcessStartInfo("explorer.exe", "\"" + ModManager.panelURL + @"?t1=" + MatuxAPI.token.Substring(0, index) + "&t2=" + MatuxAPI.token.Substring(index+1) + "\""));
            });
            AccountPanel.Controls.Add(OnlineLabel, 0, 2);
        }

        private static void loadLoginForm(Form f)
        {
            Panel LoginContainerPanel = Visuals.createPanel();
            f.Controls.Add(LoginContainerPanel);

            TableLayoutPanel LoginPanel = Visuals.createLayoutPanelV(0, 600, DockStyle.Top, new int[] { 20, 10, 10, 10, 10, 10, 10, 20 });

            LoginContainerPanel.Controls.Add(LoginPanel);

            MMLabel LoginErrorLabel = new MMLabel();

            f.Controls.Add(Visuals.LabelTitle(Translator.get("Login to Matux.fr")));

            PictureBox MatuxLogoPict = new PictureBox();
            MatuxLogoPict.Image = global::ModManager5.Properties.Resources.matux;
            MatuxLogoPict.Dock = DockStyle.Top;
            MatuxLogoPict.Margin = new System.Windows.Forms.Padding(0);
            MatuxLogoPict.Name = "MatuxLogoPict";
            MatuxLogoPict.Size = new Size(100, 100);
            MatuxLogoPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            MatuxLogoPict.TabStop = false;
            LoginPanel.Controls.Add(MatuxLogoPict, 0, 0);

            LoginPseudoText = new MMTextbox();
            LoginPanel.Controls.Add(Visuals.centeredTextbox(Translator.get("Pseudo"), LoginPseudoText), 0, 1);

            LoginPasswordText = new MMTextbox();
            LoginPasswordText.PasswordChar = '*';
            LoginPanel.Controls.Add(Visuals.centeredTextbox(Translator.get("Password"), LoginPasswordText), 0, 2);

            MMButton LoginLoginButton = new MMButton("rounded");
            LoginPanel.Controls.Add(Visuals.centeredButton(Translator.get("Login"), LoginLoginButton), 0, 3);


            LoginLoginButton.Click += new EventHandler((object sender, EventArgs e) => {
                if (LoginPseudoText.Text == "" || LoginPasswordText.Text == "")
                {
                    LoginErrorLabel.Visible = true;
                    LoginErrorLabel.Text = Translator.get("Wrong login and/or password, please try again");
                }
                else
                {
                    Boolean worked = MatuxAPI.Login(LoginPseudoText.Text, LoginPasswordText.Text);
                    if (worked)
                    {
                        loadAccount();
                        LoginErrorLabel.Visible = false;
                        openForm(MyAccountForm);
                    }
                    else
                    {
                        LoginErrorLabel.Visible = true;
                        LoginErrorLabel.Text = Translator.get("Wrong login and/or password, please try again");
                    }
                }
            });

            MMButton RegisterLoginButton = new MMButton("rounded");
            LoginPanel.Controls.Add(Visuals.centeredButton(Translator.get("Register"), RegisterLoginButton), 0, 4) ;

            RegisterLoginButton.Click += new EventHandler((object sender, EventArgs e) => {
                if (LoginPseudoText.Text == "" || LoginPasswordText.Text == "")
                {
                    LoginErrorLabel.Visible = true;
                    LoginErrorLabel.Text = Translator.get("Wrong login and/or password, please try again");
                } else
                {
                    Boolean worked = MatuxAPI.Register(LoginPseudoText.Text, LoginPasswordText.Text);
                    if (worked)
                    {
                        loadAccount();
                        LoginErrorLabel.Visible = false;
                        openForm(EmptyForm);
                    }
                    else
                    {
                        LoginErrorLabel.Visible = true;
                        LoginErrorLabel.Text = Translator.get("Account already exists, please choose another one or login");
                    }
                }
            });

            MMLabel RecoverLabel = new MMLabel();
            RecoverLabel.Dock = DockStyle.Top;
            RecoverLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RecoverLabel.Size = new Size(0, 100);
            RecoverLabel.ForeColor = ThemeList.theme.TextColor;
            RecoverLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            RecoverLabel.TextAlign = ContentAlignment.MiddleCenter;
            RecoverLabel.TabStop = false;
            RecoverLabel.Text = "\n" + Translator.get("Password forgotten? Click here!");
            RecoverLabel.Click += new EventHandler((object sender, EventArgs e) => {
                Process.Start("explorer", ModManager.panelURL + @"forgot");
            });
            LoginPanel.Controls.Add(RecoverLabel, 0, 5);

            MMLabel DisclamerLabel = new MMLabel();
            DisclamerLabel.Dock = DockStyle.Top;
            DisclamerLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DisclamerLabel.Size = new Size(0, 100);
            DisclamerLabel.ForeColor = ThemeList.theme.TextColor;
            DisclamerLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            DisclamerLabel.TextAlign = ContentAlignment.MiddleCenter;
            DisclamerLabel.TabStop = false;
            DisclamerLabel.Text = "\n"+Translator.get("Login and password are encrypted and will be only used to log you to matux.fr") + "\n\n" + Translator.get("Not registered yet ? Just register by clicking the button below !");
            LoginPanel.Controls.Add(DisclamerLabel, 0, 6);

            LoginErrorLabel.Dock = DockStyle.Top;
            LoginErrorLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LoginErrorLabel.Size = new Size(0, 100);
            LoginErrorLabel.ForeColor = Color.Red;
            LoginErrorLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            LoginErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
            LoginErrorLabel.TabStop = false;
            LoginErrorLabel.Visible = false;
            LoginPanel.Controls.Add(LoginErrorLabel, 0, 7);
        }

        public static void loadNews()
        {
            NewsForm = new GenericPanel();
            NewsForm.Name = "News";
            
            News n = NewsList.getCurrent();

            Panel NewsContainerPanel = Visuals.createPanel();
            NewsForm.Controls.Add(NewsContainerPanel);

            TableLayoutPanel NewsPanel = Visuals.createLayoutPanel(600);
            NewsContainerPanel.Controls.Add(NewsPanel);

            Label NewsContent = Visuals.LabelContent(n.content, ContentAlignment.TopLeft, DockStyle.Top);
            NewsContent.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            NewsPanel.Controls.Add(NewsContent, 0, 0);

            PictureBox LastNewsPict = new PictureBox();
            PictureBox NextNewsPict = new PictureBox();

            NewsForm.Controls.Add(Visuals.ScrollHeader(n.name, NextNewsPict, LastNewsPict));

            if (NewsList.current < NewsList.getMax())
            {
                NextNewsPict.Visible = true;
                NextNewsPict.Cursor = Cursors.Hand;
                NextNewsPict.Click += new EventHandler((object sender, EventArgs e) => {
                    NewsList.current = NewsList.current + 1;
                    loadNews();
                    openForm(NewsForm);
                });
            }

            if (NewsList.current > 0)
            {
                LastNewsPict.Visible = true;
                LastNewsPict.Cursor = Cursors.Hand;
                LastNewsPict.Click += new EventHandler((object sender, EventArgs e) => {
                    NewsList.current = NewsList.current - 1;
                    loadNews();
                    openForm(NewsForm);
                });
            }

            Label NewsDateLabel = Visuals.LabelContent(n.date, ContentAlignment.MiddleRight, DockStyle.Top);
            NewsDateLabel.Dock = DockStyle.Bottom;
            NewsForm.Controls.Add(NewsDateLabel);

            NewsForm.Controls.Add(Visuals.LabelTitle(Translator.get("News")));
        }

        public static void loadFaq()
        {
            FaqForm = new GenericPanel();
            FaqForm.Name = "Faq";

            Faq n = FaqList.getCurrent();

            Panel FaqContainerPanel = Visuals.createPanel();
            FaqForm.Controls.Add(FaqContainerPanel);

            TableLayoutPanel FaqPanel = Visuals.createLayoutPanel(600);
            FaqContainerPanel.Controls.Add(FaqPanel);

            Label FaqContentLabel = Visuals.LabelContent(n.answer, ContentAlignment.TopLeft, DockStyle.Top);
            FaqContentLabel.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            FaqPanel.Controls.Add(FaqContentLabel, 0, 0);


            PictureBox LastFaqPict = new PictureBox();
            PictureBox NextFaqPict = new PictureBox();

            FaqForm.Controls.Add(Visuals.ScrollHeader(n.question, NextFaqPict, LastFaqPict));

            if (FaqList.current < FaqList.getMax())
            {
                NextFaqPict.Visible = true;
                NextFaqPict.Cursor = Cursors.Hand;
                NextFaqPict.Click += new EventHandler((object sender, EventArgs e) => {
                    FaqList.current = FaqList.current + 1;
                    loadFaq();
                    openForm(FaqForm);
                });
            }

            if (FaqList.current > 0)
            {
                LastFaqPict.Visible = true;
                LastFaqPict.Cursor = Cursors.Hand;
                LastFaqPict.Click += new EventHandler((object sender, EventArgs e) => {
                    FaqList.current = FaqList.current - 1;
                    loadFaq();
                    openForm(FaqForm);
                });
            }

            FaqForm.Controls.Add(Visuals.LabelTitle(Translator.get("Frequently Asked Questions")));
        }

        public static void loadServers()
        {
            ServersForm = new GenericPanel();
            ServersForm.Name = "Servers";

            List<Server> servers = new List<Server>();
            servers.AddRange(ServerManager.serverList.Regions);
            servers.Add(new Server("DnsRegionInfo, Assembly-CSharp", "127.0.0.1", "127.0.0.1", 22023, Translator.get("New Server"), 1003));
            //servers.Reverse();

            int max = servers.Count();
            int i = 0;

            //bindWIP(ServersForm);

            Panel ServersContainerPanel = Visuals.createPanel();
            ServersForm.Controls.Add(ServersContainerPanel);

            TableLayoutPanel ServersPanel = new TableLayoutPanel();
            ServersPanel.Size = new Size(0, 50 * max);
            ServersPanel.Dock = DockStyle.Top;

            ServersPanel.ColumnCount = 5;
            ServersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ServersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            ServersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            ServersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            ServersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            ServersPanel.RowCount = max;
            int row = 0;
            while (row < max)
            {
                ServersPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / max ));
                row++;
            }

            ServersContainerPanel.Controls.Add(ServersPanel);

            MMButton ResetButton = new MMButton("rounded");
            ResetButton.Dock = DockStyle.Bottom;
            TableLayoutPanel t = Visuals.centeredButton(Translator.get("Reset to default"), ResetButton);
            t.Dock = DockStyle.Bottom;
            ServersForm.Controls.Add(t);

            ResetButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                ModWorker.startTransaction();
                ServerManager.reset();
                ModManagerUI.loadServers();
                openForm(ServersForm);
                ModWorker.endTransaction();
            });

            

            //TableLayoutPanel panel = Visuals.createLayoutPanelH(0, 50, DockStyle.Top, new int[] { 25, 35, 20, 10, 10 });
            
            foreach (Server s in servers)
            {
                TextBox ServerName = new TextBox();
                TextBox ServerIP = new TextBox();
                TextBox ServerPort = new TextBox();
                PictureBox ServerValidPic = new PictureBox();
                ServerValidPic.Name = "ServerValidPic=" + i;
                PictureBox ServerRemovePic = new PictureBox();
                ServerRemovePic.Name = "ServerRemovePic=" + i;
                Visuals.ServerLine(ServersPanel, i, s, ServerName, ServerIP, ServerPort, ServerValidPic, ServerRemovePic, (i < 3), (i + 1 == max));

                if (i + 1 != max)
                {
                    ServerName.TextChanged += new EventHandler((object sender, EventArgs e) =>
                    {
                        ServerValidPic.Visible = true;
                    });

                    ServerIP.TextChanged += new EventHandler((object sender, EventArgs e) =>
                    {
                        ServerValidPic.Visible = true;
                    });

                    ServerPort.TextChanged += new EventHandler((object sender, EventArgs e) =>
                    {
                        Regex portRegex = new Regex(@"^\d+$");
                        MatchCollection result = portRegex.Matches(ServerPort.Text);
                        if (result.Count() == 0)
                            return;

                        ServerValidPic.Visible = true;
                    });

                    ServerValidPic.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        // Check if Ip valid
                        Regex ipReg = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                        MatchCollection result = ipReg.Matches(ServerIP.Text);
                        if (result.Count() == 0)
                            return;

                        ModWorker.startTransaction();

                        string picName = ServerValidPic.Name;
                        int serverId = int.Parse(picName.Substring(picName.IndexOf("=") + 1));

                        ServerManager.serverList.Regions[serverId].name = ServerName.Text;
                        ServerManager.serverList.Regions[serverId].DefaultIp = result[0].Value;
                        ServerManager.serverList.Regions[serverId].Fqdn = result[0].Value;
                        ServerManager.serverList.Regions[serverId].port = int.Parse(ServerPort.Text);
                        ServerManager.update();
                        ModManagerUI.loadServers();
                        openForm(ServersForm);
                        ModWorker.endTransaction();
                    });

                    ServerRemovePic.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModWorker.startTransaction();
                        string picName = ServerRemovePic.Name;
                        int serverId = int.Parse(picName.Substring(picName.IndexOf("=") + 1));

                        ServerManager.serverList.Regions.RemoveAt(serverId);
                        ServerManager.update();
                        ModManagerUI.loadServers();
                        openForm(ServersForm);
                        ModWorker.endTransaction();
                    });

                } else
                {
                    ServerRemovePic.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModWorker.startTransaction();
                        // Check if Ip valid
                        Regex ipReg = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                        MatchCollection result = ipReg.Matches(ServerIP.Text);
                        if (result.Count() == 0)
                            return;

                        Server newServ = new Server("DnsRegionInfo, Assembly - CSharp", result[0].Value, result[0].Value, int.Parse(ServerPort.Text), ServerName.Text, 1003);
                        ServerManager.serverList.Regions.Add(newServ);
                        ServerManager.update();
                        ModManagerUI.loadServers();
                        openForm(ServersForm);
                        ModWorker.endTransaction();
                    });
                }
                i++;
            }

            ServersForm.Controls.Add(Visuals.ServersOverlay());

            ServersForm.Controls.Add(Visuals.LabelTitle(Translator.get("Servers")));
        }

        private static void loadMyStatsForm(Form f)
        {
            MyStatsForm = new GenericPanel();
            MyStatsForm.Name = "MyStats";

            bindWIP(MyStatsForm);

            MyStatsForm.Controls.Add(Visuals.LabelTitle("My Stats"));
        }

        private static void loadMyModsForm(Form f)
        {
            MyModsForm = new GenericPanel();
            MyModsForm.Name = "MyMods";

            bindWIP(MyModsForm);

            MyModsForm.Controls.Add(Visuals.LabelTitle("My Mods"));
        }

        private static void loadMyTranslationsForm(Form f)
        {
            MyTranslationsForm = new GenericPanel();
            MyTranslationsForm.Name = "MyTranslations";

            List<Translation> translations = new List<Translation>();
            translations.AddRange(MatuxAPI.getTranslationsForLg(MatuxAPI.currentLg));
            //servers.Reverse();

            int max = translations.Count();
            int i = 0;

            //bindWIP(ServersForm);

            Panel TranslationsContainerPanel = Visuals.createPanel();
            MyTranslationsForm.Controls.Add(TranslationsContainerPanel);

            TableLayoutPanel TranslationsPanel = new TableLayoutPanel();
            TranslationsPanel.Size = new Size(0, 100 * max);
            TranslationsPanel.Dock = DockStyle.Top;

            TranslationsPanel.ColumnCount = 3;
            TranslationsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            TranslationsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            TranslationsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            TranslationsPanel.RowCount = max;
            int row = 0;
            while (row < max)
            {
                TranslationsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / max));
                row++;
            }

            TranslationsContainerPanel.Controls.Add(TranslationsPanel);


            foreach (Translation tr in translations)
            {
                MMLabel TranslationLabel = new MMLabel();
                TextBox TranslationTextbox = new TextBox();
                PictureBox TranslationValidPic = new PictureBox();
                Visuals.TranslationLine(TranslationsPanel, i, tr, TranslationLabel, TranslationTextbox, TranslationValidPic);

                TranslationTextbox.TextChanged += new EventHandler((object sender, EventArgs e) =>
                {
                    TranslationValidPic.Visible = true;
                });

                TranslationValidPic.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    MatuxAPI.updateTranslation(MatuxAPI.currentLg, tr.original, TranslationTextbox.Text);
                    TranslationValidPic.Visible = false;
                });

                i++;

            }

            MyTranslationsForm.Controls.Add(Visuals.TranslationsOverlay());

            MyTranslationsForm.Controls.Add(Visuals.LabelTitle(Translator.get("Translations")));
        }
        public static void loadSettings()
        {
            SettingsForm = new GenericPanel();
            SettingsForm.Name = "Settings";

            // Reset
            MMButton ResetButton = new MMButton("rounded");
            ResetButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                if (MessageBox.Show(Translator.get("Mod Manager needs to restart to process this change. Do you want to continue ?"), Translator.get("Reset Mod Manager"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.startTransaction();

                    Utils.DirectoryDelete(ModManager.appDataPath);
                    string path = ModManager.appPath + "ModManager5.exe";
                    Process.Start(path, "force " + activeForm.Name);
                    Environment.Exit(0);
                }
            });

            SettingsForm.Controls.Add(Visuals.SettingsButton(ResetButton, Translator.get("Reset")));

            // Send log
            MMButton LogButton = new MMButton("rounded");
            LogButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                string argument = "/select, \"" + ModManager.appDataPath + @"\logs.txt" + "\"";

                Process.Start("explorer.exe", argument);
            });

            SettingsForm.Controls.Add(Visuals.SettingsButton(LogButton, Translator.get("Log File")));

            // Language
            ComboBox LanguageComboBox = new MMComboBox();
            LanguageComboBox.SelectionChangeCommitted += new EventHandler(async (object sender, EventArgs e) => {
                ComboBox control = (ComboBox) sender;
                string lg = (string) control.SelectedItem;
                if (MessageBox.Show(Translator.get("Mod Manager needs to restart to process this change. Do you want to continue ?"), Translator.get("Change Language"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.startTransaction();

                    ConfigManager.globalConfig.lg = Translator.getCodeFromName(lg);
                    ConfigManager.updateGlobalConfig();
                    string path = ModManager.appPath + "ModManager5.exe";
                    Process.Start(path, "force");
                    Environment.Exit(0);
                } else
                {
                    control.SelectedItem = ConfigManager.globalConfig.lg;
                }
            });

            List<string> lgs = new List<string>() { };
            foreach(Language l in Translator.languages)
            {
                lgs.Add(l.name);
            }
            SettingsForm.Controls.Add(Visuals.SettingsCombobox(LanguageComboBox, Translator.get("Language"), lgs, Translator.getNameFromCode(ConfigManager.globalConfig.lg)));

            // Theme
            ComboBox ThemeComboBox = new MMComboBox();
            ThemeComboBox.SelectionChangeCommitted += new EventHandler((object sender, EventArgs e) => {
                ComboBox control = (ComboBox)sender;
                string theme = (string)control.SelectedItem;
                if (MessageBox.Show(Translator.get("Mod Manager needs to restart to process this change. Do you want to continue ?"), Translator.get("Change Theme"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.startTransaction();

                    ConfigManager.globalConfig.theme = theme;
                    ConfigManager.updateGlobalConfig();
                    string path = ModManager.appPath + "ModManager5.exe";
                    Process.Start(path, "force");
                    Environment.Exit(0);
                }
                else
                {
                    control.SelectedItem = ThemeList.theme.name;
                }
            });

            List<string> themes = new List<string>() { };
            foreach (Theme theme in ThemeList.availableThemes)
            {
                themes.Add(theme.name);
            }
            
            SettingsForm.Controls.Add(Visuals.SettingsCombobox(ThemeComboBox, Translator.get("Theme"), themes, ThemeList.theme.name));


            SettingsForm.Controls.Add(Visuals.LabelTitle(Translator.get("Settings")));
        }

        public static void loadCredits()
        {
            CreditsForm = new GenericPanel();
            CreditsForm.Name = "Credits";

            MMLabel CreditsContentLabel = new MMLabel();
            CreditsContentLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CreditsContentLabel.BackColor = Color.Transparent;
            CreditsContentLabel.ForeColor = SystemColors.Control;
            CreditsContentLabel.TextAlign = ContentAlignment.TopLeft;
            CreditsContentLabel.Dock = DockStyle.Top;
            CreditsContentLabel.Name = "CreditsContentLabel";
            CreditsContentLabel.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            CreditsContentLabel.UseMnemonic = false;
            CreditsContentLabel.Size = new System.Drawing.Size(250, 150);
            CreditsContentLabel.Text = Translator.get(ServerConfig.get("credits").value);
            CreditsForm.Controls.Add(CreditsContentLabel);

            CreditsForm.Controls.Add(Visuals.LabelTitle(Translator.get("Credits")));
        }

        public static void loadEmpty()
        {
            EmptyForm = new GenericPanel();
            EmptyForm.Name = "Empty";
        }

        public static void bindWIP(Form f)
        {
            MMLabel PageWIPContent = new MMLabel();
            PageWIPContent.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PageWIPContent.BackColor = Color.Transparent;
            PageWIPContent.ForeColor = SystemColors.Control;
            PageWIPContent.TextAlign = ContentAlignment.MiddleCenter;
            PageWIPContent.Dock = DockStyle.Top;
            PageWIPContent.Name = "PageWIPContent";
            PageWIPContent.Padding = new Padding(0, 25, 0, 25);
            PageWIPContent.Size = new System.Drawing.Size(250, 150);
            PageWIPContent.Text = "This page is still under construction and will be available in a future update.\nThanks for your patience !";
            f.Controls.Add(PageWIPContent);
        }
    }
}