using Microsoft.Win32;
using ModManager5.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public static Form NewsForm;
        public static Form FaqForm;
        public static Form SettingsForm;
        public static Form CreditsForm;

        public static TextBox LoginPseudoText;
        public static TextBox LoginPasswordText;

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
            ModsCategoriesPanel = new Panel();
            BottomLeftPanel = new Panel();
            IconsMenuPanel = new Panel();
            RoadmapPict = new PictureBox();
            GithubPict = new PictureBox();
            DiscordPict = new PictureBox();
            VersionLabel = new Label();
            ModsMenuButton = new Button();
            LogoPict = new PictureBox();
            BottomRightPanel = new Panel();
            AppPanel = new Panel();
            LoadingLabel = new Label();
            StatusLabel = new Label();
            StartButton = new MMButton();
            StartPanel = new Panel();

            CategoryForms = new List<Form>() { };

            // 
            // MenuPanel
            // 
            MenuPanel.AutoScroll = true;
            MenuPanel.BackColor = ThemeList.theme.MenuBackgroundColor;
            MenuPanel.Controls.Add(CreditsMenuButton);
            MenuPanel.Controls.Add(SettingsMenuButton);
            MenuPanel.Controls.Add(FaqMenuButton);
            MenuPanel.Controls.Add(NewsMenuButton);
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
            CreditsMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            CreditsMenuButton.Location = new System.Drawing.Point(0, 455);
            CreditsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            CreditsMenuButton.Name = "CreditsMenuButton";
            CreditsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            CreditsMenuButton.Size = new System.Drawing.Size(300, 50);
            CreditsMenuButton.Text = "Credits";
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
            SettingsMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            SettingsMenuButton.Location = new System.Drawing.Point(0, 405);
            SettingsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            SettingsMenuButton.Name = "SettingsMenuButton";
            SettingsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            SettingsMenuButton.Size = new System.Drawing.Size(300, 50);
            SettingsMenuButton.Text = "Settings";
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
            FaqMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            FaqMenuButton.Location = new System.Drawing.Point(0, 355);
            FaqMenuButton.Margin = new System.Windows.Forms.Padding(0);
            FaqMenuButton.Name = "FaqMenuButton";
            FaqMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            FaqMenuButton.Size = new System.Drawing.Size(300, 50);
            FaqMenuButton.Text = "FAQ";
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
            NewsMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            NewsMenuButton.Location = new System.Drawing.Point(0, 305);
            NewsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            NewsMenuButton.Name = "NewsMenuButton";
            NewsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            NewsMenuButton.Size = new System.Drawing.Size(300, 50);
            NewsMenuButton.Text = "News";
            NewsMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            NewsMenuButton.UseVisualStyleBackColor = false;
            NewsMenuButton.TabStop = false;
            

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
            AccountMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            AccountMenuButton.Location = new System.Drawing.Point(0, 255);
            AccountMenuButton.Margin = new System.Windows.Forms.Padding(0);
            AccountMenuButton.Name = "AccountMenuButton";
            AccountMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            AccountMenuButton.Size = new System.Drawing.Size(300, 50);
            AccountMenuButton.Text = "Account";
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
            VersionLabel.ForeColor = System.Drawing.SystemColors.Control;
            VersionLabel.Location = new System.Drawing.Point(0, 60);
            VersionLabel.Margin = new System.Windows.Forms.Padding(0);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            VersionLabel.Size = new System.Drawing.Size(300, 40);
            VersionLabel.Text = "Mod Manager Version " + ModManager.visibleVersion;
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
            ModsMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            ModsMenuButton.Location = new System.Drawing.Point(0, 115);
            ModsMenuButton.Margin = new System.Windows.Forms.Padding(0);
            ModsMenuButton.Name = "ModsMenuButton";
            ModsMenuButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            ModsMenuButton.Size = new System.Drawing.Size(300, 50);
            ModsMenuButton.Text = "Mods";
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
            BottomRightPanel.ForeColor = System.Drawing.SystemColors.Control;
            BottomRightPanel.Location = new System.Drawing.Point(300, 941);
            BottomRightPanel.Margin = new System.Windows.Forms.Padding(0);
            BottomRightPanel.Name = "BottomRightPanel";
            BottomRightPanel.Size = new System.Drawing.Size(1604, 100);
            
            // 
            // AppPanel
            // 
            AppPanel.BackColor = ThemeList.theme.AppBackgroundColor;
            AppPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            AppPanel.ForeColor = System.Drawing.SystemColors.Control;
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
            LoadingLabel.Text = "Loading Mod Manager, please wait...";
            AppPanel.Controls.Add(LoadingLabel);

            // 
            // StartButton
            // 

            StartPanel.Controls.Add(StartButton);
            StartPanel.Dock = DockStyle.Right;
            StartPanel.ForeColor = System.Drawing.SystemColors.Control;
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
            StartButton.Text = "Start Vanilla Among Us";
            StartButton.TabStop = false;

            // 
            // StatusLabel
            // 
            StatusLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StatusLabel.Dock = DockStyle.Left;
            StatusLabel.Size = new Size(700, 30);
            StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            StatusLabel.Padding = new Padding(10, 30, 10, 30);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Text = "Loading...";
            StatusLabel.TabStop = false;


            modManager.Controls.Add(AppPanel);
            modManager.Controls.Add(BottomRightPanel);
            modManager.Controls.Add(MenuPanel);
        }

        public static void InitUI()
        {
            loadMods();
            loadAccount();
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

                ModWorker.startVanilla();
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
            SubMenuButton.Text = name;
            SubMenuButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            SubMenuButton.UseVisualStyleBackColor = false;
            SubMenuButton.TabStop = false;

            return SubMenuButton;
        }

        private static Label createTitle(string title)
        {
            Label PageTitle = new Label();
            PageTitle.Font = new System.Drawing.Font(ThemeList.theme.TitleFont, ThemeList.theme.TitleSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            PageTitle.BackColor = Color.Transparent;
            PageTitle.ForeColor = SystemColors.Control;
            PageTitle.TextAlign = ContentAlignment.MiddleCenter;
            PageTitle.Dock = DockStyle.Top;
            PageTitle.Name = "PageTitle";
            PageTitle.Padding = new Padding(0, 25, 0, 25);
            PageTitle.Size = new System.Drawing.Size(250, 150);
            PageTitle.Text = title;
            return PageTitle;
        }

        private static Panel createPanel()
        {
            Panel ContainerPanel = new Panel();
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.AutoScroll = true;
            return ContainerPanel;
        }

        private static TableLayoutPanel createLayoutPanel(int height)
        {
            return createLayoutPanelV(height, new int[] { 100 });
        }

        private static TableLayoutPanel createLayoutPanelV(int height, int[] rows)
        {
            TableLayoutPanel Panel = new TableLayoutPanel();
            Panel.Size = new Size(0, height);
            Panel.Dock = DockStyle.Top;

            Panel.ColumnCount = 1;
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Panel.RowCount = rows.Count();
            foreach(int row in rows)
            {
                Panel.RowStyles.Add(new RowStyle(SizeType.Percent, row));
            }
            return Panel;
        }

        private static TableLayoutPanel createLayoutPanelH(int width, int[] columns)
        {
            TableLayoutPanel Panel = new TableLayoutPanel();
            Panel.Size = new Size(width, 0);
            Panel.Dock = DockStyle.Left;

            Panel.ColumnCount = columns.Count();
            foreach (int column in columns)
            {
                Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, column));
            }
            Panel.RowCount = 1;
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            return Panel;
        }

        public static void loadMods()
        {
            // SubMenus

            List<Category> cats = CategoryManager.categories;
            cats.Reverse();
            int size = 0;
            foreach (Category c in cats)
            {
                if (ModList.getModsByCategory(c.id).Count() > 0)
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
            List<Mod> mods = ModList.getModsByCategory(f.Name);
            mods.Reverse();

            Panel ContainerPanel = new Panel();
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.AutoScroll = true;
            f.Controls.Add(ContainerPanel);

            TableLayoutPanel ModPanel = new TableLayoutPanel();
            ModPanel.Name = "ModPanel";
            ModPanel.Dock = DockStyle.Top;
            ContainerPanel.Controls.Add(ModPanel);

            ModPanel.ColumnCount = 5;
            ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            int size = mods.Count();
            float ratio = 0F;
            if (size != 0)
            {
                ratio = (float)(100 / size);
            }

            ModPanel.RowCount = size;
            ModPanel.Size = new System.Drawing.Size(100, 50 * size);
            foreach (Mod m in mods)
            {
                ModPanel.RowStyles.Add(new RowStyle(SizeType.Percent, ratio));
            }

            int line = 0;
            foreach (Mod m in mods)
            {
                InstalledMod im = ConfigManager.getInstalledModById(m.id);
                
                TableLayoutPanel ModButtonsPanel = new TableLayoutPanel();
                ModButtonsPanel.Name = "ModPanel";
                ModButtonsPanel.Dock = DockStyle.Fill;
                ModPanel.Controls.Add(ModButtonsPanel, 4, line);

                ModButtonsPanel.ColumnCount = 3;
                ModButtonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                ModButtonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                ModButtonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
                ModButtonsPanel.RowCount = 1;
                ModButtonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

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
                    ModDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    ModDownload.TabStop = false;
                    ModDownload.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModWorker.installAnyMod(m);
                    });
                    ModButtonsPanel.Controls.Add(ModDownload, 0, 0);
                }
                else if (((m.type != "allInOne" || m.id == "Challenger") && im.version != m.release.TagName) || (m.type != "allInOne" && im.gameVersion != m.gameVersion))
                {
                    PictureBox ModUpdate = new PictureBox();
                    ModUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
                    ModUpdate.Dock = DockStyle.Fill;
                    ModUpdate.Image = global::ModManager5.Properties.Resources.updateMod;
                    ModUpdate.Margin = new System.Windows.Forms.Padding(0);
                    ModUpdate.Name = "ModUpdate";
                    ModUpdate.Size = new System.Drawing.Size(60, 50);
                    ModUpdate.Padding = new Padding(15, 10, 15, 10);
                    ModUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    ModUpdate.TabStop = false;
                    ModUpdate.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModWorker.installAnyMod(m);
                    });

                    ModButtonsPanel.Controls.Add(ModUpdate, 0, 0);
                } else
                {
                    PictureBox ModPlay = new PictureBox();
                    ModPlay.Cursor = System.Windows.Forms.Cursors.Hand;
                    ModPlay.Dock = DockStyle.Fill;
                    ModPlay.Image = global::ModManager5.Properties.Resources.play;
                    ModPlay.Margin = new System.Windows.Forms.Padding(0);
                    ModPlay.Name = "ModPlay";
                    ModPlay.Size = new System.Drawing.Size(60, 50);
                    ModPlay.Padding = new Padding(15, 10, 15, 10);
                    ModPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    ModPlay.TabStop = false;
                    ModPlay.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModWorker.startMod(m);
                    });
                    ModButtonsPanel.Controls.Add(ModPlay, 0, 0);
                }

                PictureBox ModUninstall = new PictureBox();
                ModUninstall.Dock = DockStyle.Fill;
                ModUninstall.Margin = new System.Windows.Forms.Padding(0);
                ModUninstall.Name = "ModUninstall";
                ModUninstall.Size = new System.Drawing.Size(60, 50);
                ModUninstall.Padding = new Padding(15, 10, 15, 10);
                ModUninstall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                ModUninstall.TabStop = false;

                ModButtonsPanel.Controls.Add(ModUninstall, 1, 0);

                if (im != null && m.id != "BetterCrewlink")
                {
                    ModUninstall.Click += new EventHandler((object sender, EventArgs e) => {
                        ModWorker.UninstallMod(m);
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
                ModSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                ModSave.TabStop = false;
                ModSave.Click += new EventHandler((object sender, EventArgs e) => {
                    ModList.createShortcut(m);
                });
                ModButtonsPanel.Controls.Add(ModSave, 2, 0);
                
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
                ModTitle.Text = m.name;
                ModTitle.TabStop = false;
                ModPanel.Controls.Add(ModTitle, 0, line);
                
                line++;
            }

            TableLayoutPanel ModTitlePanel = new TableLayoutPanel();
            ModTitlePanel.Dock = DockStyle.Top;
            ModTitlePanel.BackColor = ThemeList.theme.AppOverlayColor;
            f.Controls.Add(ModTitlePanel);

            ModTitlePanel.ColumnCount = 5;
            ModTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            ModTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            ModTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            ModTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ModTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            ModTitlePanel.RowCount = 1;
            ModTitlePanel.Size = new System.Drawing.Size(100, 50);
            ModTitlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            

            System.Windows.Forms.Label ModTitleGithub = new System.Windows.Forms.Label();
            ModTitleGithub.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleGithub.BackColor = Color.Transparent;
            ModTitleGithub.ForeColor = SystemColors.Control;
            ModTitleGithub.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleGithub.Dock = DockStyle.Left;
            ModTitleGithub.Name = "ModTitleGithub";
            ModTitleGithub.Padding = new Padding(12, 0, 0, 0);
            ModTitleGithub.Size = new System.Drawing.Size(700, 50);
            ModTitleGithub.Text = "More information";
            ModTitlePanel.Controls.Add(ModTitleGithub, 3, 0);

            System.Windows.Forms.Label ModTitleVersion = new System.Windows.Forms.Label();
            ModTitleVersion.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleVersion.BackColor = Color.Transparent;
            ModTitleVersion.ForeColor = SystemColors.Control;
            ModTitleVersion.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleVersion.Dock = DockStyle.Left;
            ModTitleVersion.Name = "ModTitleVersion";
            ModTitleVersion.Padding = new Padding(12, 0, 0, 0);
            ModTitleVersion.Size = new System.Drawing.Size(150, 50);
            ModTitleVersion.Text = "Version";
            ModTitlePanel.Controls.Add(ModTitleVersion, 2, 0);

            System.Windows.Forms.Label ModTitleAuthor = new System.Windows.Forms.Label();
            ModTitleAuthor.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleAuthor.BackColor = Color.Transparent;
            ModTitleAuthor.ForeColor = SystemColors.Control;
            ModTitleAuthor.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleAuthor.Dock = DockStyle.Left;
            ModTitleAuthor.Name = "ModTitleAuthor";
            ModTitleAuthor.Padding = new Padding(12, 0, 0, 0);
            ModTitleAuthor.Size = new System.Drawing.Size(250, 50);
            ModTitleAuthor.Text = "Author";
            ModTitlePanel.Controls.Add(ModTitleAuthor, 1, 0);

            System.Windows.Forms.Label ModTitleTitle = new System.Windows.Forms.Label();
            ModTitleTitle.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleTitle.BackColor = Color.Transparent;
            ModTitleTitle.ForeColor = SystemColors.Control;
            ModTitleTitle.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleTitle.Dock = DockStyle.Left;
            ModTitleTitle.Name = "ModTitleTitle";
            ModTitleTitle.Padding = new Padding(12, 0, 0, 0);
            ModTitleTitle.Size = new System.Drawing.Size(250, 50);
            ModTitleTitle.Text = "Name";
            ModTitlePanel.Controls.Add(ModTitleTitle, 0, 0);

            f.Controls.Add(createTitle(cat.name));
        }

        public static void loadAccount()
        {
            AccountPanel.Controls.Clear();
            
            // SubMenu

            if (MatuxAPI.logged)
            {
                int panelSize = 40;

                MyModsForm = new GenericPanel();

                Button b2 = CreateSubMenuButton("Logout");

                b2.Click += new EventHandler((object sender, EventArgs e) => {
                    MatuxAPI.logout();
                    loadAccount();
                });
                AccountPanel.Controls.Add(b2);

                if (MatuxAPI.myStats.Count() > 0)
                {
                    MyStatsForm = new GenericPanel();

                    Button b3 = CreateSubMenuButton("My Stats");

                    b3.Click += new EventHandler((object sender, EventArgs e) => {
                        openForm(MyStatsForm);
                    });
                    AccountPanel.Controls.Add(b3);
                    panelSize = panelSize + 40;
                }

                if (MatuxAPI.myMods.Count() > 0)
                {
                    Button b = CreateSubMenuButton("My Mods");

                    b.Click += new EventHandler((object sender, EventArgs e) => {
                        openForm(MyModsForm);
                    });
                    AccountPanel.Controls.Add(b);
                    panelSize = panelSize + 40;
                }
                AccountPanel.Size = new Size(300, panelSize);

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

                Panel LoginContainerPanel = createPanel();
                LoginForm.Controls.Add(LoginContainerPanel);

                TableLayoutPanel LoginPanel = createLayoutPanelV(600, new int[] { 20, 10, 10, 10, 10, 20, 20 }) ;
                
                LoginContainerPanel.Controls.Add(LoginPanel);

                Label LoginErrorLabel = new Label();

                LoginForm.Controls.Add(createTitle("Login to Matux.fr"));

                PictureBox MatuxLogoPict = new PictureBox();
                MatuxLogoPict.Image = global::ModManager5.Properties.Resources.matux;
                MatuxLogoPict.Dock = DockStyle.Top;
                MatuxLogoPict.Margin = new System.Windows.Forms.Padding(0);
                MatuxLogoPict.Name = "MatuxLogoPict";
                MatuxLogoPict.Size = new Size(100, 100);
                MatuxLogoPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                MatuxLogoPict.TabStop = false;
                LoginPanel.Controls.Add(MatuxLogoPict, 0, 0);

                LoginPseudoText = new TextBox();
                LoginPseudoText.Dock = DockStyle.Top;
                LoginPseudoText.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                LoginPseudoText.Size = new Size(0, 50);
                LoginPseudoText.ForeColor = ThemeList.theme.TextColor;
                LoginPseudoText.BackColor = ThemeList.theme.AppBackgroundColor;
                LoginPseudoText.TextAlign = HorizontalAlignment.Center;
                LoginPseudoText.PlaceholderText = "Pseudo";
                LoginPseudoText.TabStop = false;
                LoginPanel.Controls.Add(LoginPseudoText, 0, 1);

                LoginPasswordText = new TextBox();
                LoginPasswordText.Dock = DockStyle.Top;
                LoginPasswordText.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                LoginPasswordText.Size = new Size(0, 50);
                LoginPasswordText.ForeColor = ThemeList.theme.TextColor;
                LoginPasswordText.BackColor = ThemeList.theme.AppBackgroundColor;
                LoginPasswordText.TextAlign = HorizontalAlignment.Center;
                LoginPasswordText.PlaceholderText = "Password";
                LoginPasswordText.TabStop = false;
                LoginPanel.Controls.Add(LoginPasswordText, 0, 2);

                MMButton LoginLoginButton = new MMButton();
                LoginLoginButton.Text = "Login";
                LoginLoginButton.BackColor = ThemeList.theme.ButtonsColor;
                LoginLoginButton.Size = new Size(300, 60);
                LoginLoginButton.Dock = DockStyle.Top;
                LoginLoginButton.TabStop = false;
                LoginPanel.Controls.Add(LoginLoginButton, 0, 3);

                LoginLoginButton.Click += new EventHandler((object sender, EventArgs e) => {
                    if (LoginPseudoText.Text == "" || LoginPasswordText.Text == "")
                    {
                        LoginErrorLabel.Visible = true;
                        LoginErrorLabel.Text = "Wrong login and/or password, please try again";
                    } else
                    {
                        Boolean worked = MatuxAPI.Login(LoginPseudoText.Text, LoginPasswordText.Text);
                        if (worked)
                        {
                            loadAccount();
                            LoginErrorLabel.Visible = false;
                            openForm(MyModsForm);
                        }
                        else
                        {
                            LoginErrorLabel.Visible = true;
                            LoginErrorLabel.Text = "Wrong login and/or password, please try again";
                        }
                    }
                });

                MMButton RegisterLoginButton = new MMButton();
                RegisterLoginButton.Size = new Size(300, 60);
                RegisterLoginButton.BackColor = ThemeList.theme.ButtonsColor;
                RegisterLoginButton.Text = "Register";
                RegisterLoginButton.Dock = DockStyle.Top;
                RegisterLoginButton.TabStop = false;
                LoginPanel.Controls.Add(RegisterLoginButton, 0, 4);

                RegisterLoginButton.Click += new EventHandler((object sender, EventArgs e) => {
                    Boolean worked = MatuxAPI.Register(LoginPseudoText.Text, LoginPasswordText.Text);
                    if (worked)
                    {
                        loadAccount();
                        LoginErrorLabel.Visible = false;
                        openForm(MyModsForm);
                    }
                    else
                    {
                        LoginErrorLabel.Visible = true;
                        LoginErrorLabel.Text = "Account already exists, please choose another one or login";
                    }
                });

                Label DisclamerLabel = new Label();
                DisclamerLabel.Dock = DockStyle.Top;
                DisclamerLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                DisclamerLabel.Size = new Size(0, 100);
                DisclamerLabel.ForeColor = ThemeList.theme.TextColor;
                DisclamerLabel.BackColor = ThemeList.theme.AppBackgroundColor;
                DisclamerLabel.TextAlign = ContentAlignment.MiddleCenter;
                DisclamerLabel.TabStop = false;
                DisclamerLabel.Text = "\nLogin and password are encrypted and will be only used to log you to matux.fr\n\nNot registered yet ? Just register by clicking the button below !";
                LoginPanel.Controls.Add(DisclamerLabel, 0, 5);

                LoginErrorLabel.Dock = DockStyle.Top;
                LoginErrorLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                LoginErrorLabel.Size = new Size(0, 100);
                LoginErrorLabel.ForeColor = Color.Red;
                LoginErrorLabel.BackColor = ThemeList.theme.AppBackgroundColor;
                LoginErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
                LoginErrorLabel.TabStop = false;
                LoginErrorLabel.Visible = false;
                LoginPanel.Controls.Add(LoginErrorLabel, 0, 6);
            }
        }

        public static void loadNews()
        {
            NewsForm = new GenericPanel();
            NewsForm.Name = "News";
            
            News n = NewsList.getCurrent();

            Panel NewsContainerPanel = createPanel();
            NewsForm.Controls.Add(NewsContainerPanel);

            TableLayoutPanel NewsPanel = createLayoutPanel(600);
            NewsContainerPanel.Controls.Add(NewsPanel);

            Label NewsContentLabel = new Label();
            NewsContentLabel.Dock = DockStyle.Top;
            NewsContentLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //NewsContentLabel.Size = new Size(0, 100);
            NewsContentLabel.AutoSize = true;
            NewsContentLabel.ForeColor = ThemeList.theme.TextColor;
            NewsContentLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            NewsContentLabel.TextAlign = ContentAlignment.TopLeft;
            NewsContentLabel.TabStop = false;
            NewsContentLabel.Text = n.content;
            NewsPanel.Controls.Add(NewsContentLabel, 0, 0);

            TableLayoutPanel NewsHeaderPanel = createLayoutPanelH(100, new int[] { 20, 60, 20 });
            NewsHeaderPanel.Dock = DockStyle.Top;
            NewsForm.Controls.Add(NewsHeaderPanel);

            Label NewsTitleLabel = new Label();
            NewsTitleLabel.Dock = DockStyle.Fill;
            NewsTitleLabel.Font = new Font(ThemeList.theme.SubTitleFont, ThemeList.theme.SubTitleSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NewsTitleLabel.Size = new Size(0, 100);
            NewsTitleLabel.ForeColor = ThemeList.theme.TextColor;
            NewsTitleLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            NewsTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            NewsTitleLabel.TabStop = false;
            NewsTitleLabel.Text = n.name;
            NewsTitleLabel.Padding = new Padding(0, 25, 0, 25);
            NewsHeaderPanel.Controls.Add(NewsTitleLabel, 1, 0);

            PictureBox NextNewsPict = new PictureBox();
            NextNewsPict.Image = global::ModManager5.Properties.Resources.next;
            NextNewsPict.Dock = DockStyle.Top;
            NextNewsPict.Name = "NextNewsPict";
            NextNewsPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            NextNewsPict.TabStop = false;
            NextNewsPict.Margin = new Padding(25, 25, 25, 25);
            NextNewsPict.Visible = false;
            NewsHeaderPanel.Controls.Add(NextNewsPict, 2, 0);

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

            PictureBox LastNewsPict = new PictureBox();
            LastNewsPict.Image = global::ModManager5.Properties.Resources.back;
            LastNewsPict.Dock = DockStyle.Top;
            LastNewsPict.Name = "LastNewsPict";
            LastNewsPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LastNewsPict.TabStop = false;
            LastNewsPict.Margin = new Padding(25, 25, 25, 25);
            LastNewsPict.Visible = false;
            NewsHeaderPanel.Controls.Add(LastNewsPict, 0, 0);

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

            Label NewsDateLabel = new Label();
            NewsDateLabel.Dock = DockStyle.Bottom;
            NewsDateLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NewsDateLabel.Size = new Size(0, 100);
            NewsDateLabel.ForeColor = ThemeList.theme.TextColor;
            NewsDateLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            NewsDateLabel.TextAlign = ContentAlignment.MiddleRight;
            NewsDateLabel.TabStop = false;
            NewsDateLabel.Text = n.date;
            NewsForm.Controls.Add(NewsDateLabel);

            NewsForm.Controls.Add(createTitle("News"));
        }

        public static void loadFaq()
        {
            FaqForm = new GenericPanel();
            FaqForm.Name = "Faq";

            Faq n = FaqList.getCurrent();

            Panel FaqContainerPanel = createPanel();
            FaqForm.Controls.Add(FaqContainerPanel);

            TableLayoutPanel FaqPanel = createLayoutPanel(600);
            FaqContainerPanel.Controls.Add(FaqPanel);

            Label FaqContentLabel = new Label();
            FaqContentLabel.Dock = DockStyle.Top;
            FaqContentLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            FaqContentLabel.AutoSize = true;
            FaqContentLabel.ForeColor = ThemeList.theme.TextColor;
            FaqContentLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            FaqContentLabel.TextAlign = ContentAlignment.TopLeft;
            FaqContentLabel.TabStop = false;
            FaqContentLabel.Text = n.answer;
            FaqPanel.Controls.Add(FaqContentLabel, 0, 0);

            TableLayoutPanel FaqHeaderPanel = new TableLayoutPanel();
            FaqHeaderPanel.Dock = DockStyle.Top;
            FaqForm.Controls.Add(FaqHeaderPanel);

            FaqHeaderPanel.ColumnCount = 3;
            FaqHeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            FaqHeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            FaqHeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            FaqHeaderPanel.RowCount = 1;
            FaqHeaderPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));

            Panel FaqTitleContainerPanel = createPanel();
            FaqHeaderPanel.Controls.Add(FaqTitleContainerPanel, 1, 0);

            TableLayoutPanel FaqTitlePanel = createLayoutPanel(100);
            FaqTitleContainerPanel.Controls.Add(FaqTitlePanel);

            Label FaqTitleLabel = new Label();
            FaqTitleLabel.Dock = DockStyle.Fill;
            FaqTitleLabel.Font = new Font(ThemeList.theme.SubTitleFont, ThemeList.theme.SubTitleSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            FaqTitleLabel.Size = new Size(300, 100);
            FaqTitleLabel.ForeColor = ThemeList.theme.TextColor;
            FaqTitleLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            FaqTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            FaqTitleLabel.TabStop = false;
            FaqTitleLabel.Text = n.question;
            FaqTitlePanel.Controls.Add(FaqTitleLabel);

            PictureBox NextFaqPict = new PictureBox();
            NextFaqPict.Image = global::ModManager5.Properties.Resources.next;
            NextFaqPict.Dock = DockStyle.Top;
            NextFaqPict.Name = "NextFaqPict";
            NextFaqPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            NextFaqPict.TabStop = false;
            NextFaqPict.Margin = new Padding(0, 25, 0, 25);
            NextFaqPict.Visible = false;
            FaqHeaderPanel.Controls.Add(NextFaqPict, 2, 0);

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

            PictureBox LastFaqPict = new PictureBox();
            LastFaqPict.Image = global::ModManager5.Properties.Resources.back;
            LastFaqPict.Dock = DockStyle.Top;
            LastFaqPict.Name = "LastNewsPict";
            LastFaqPict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LastFaqPict.TabStop = false;
            LastFaqPict.Margin = new Padding(0, 25, 0, 25);
            LastFaqPict.Visible = false;
            FaqHeaderPanel.Controls.Add(LastFaqPict, 0, 0);

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

            FaqForm.Controls.Add(createTitle("Frequently Asked Questions"));
        }

        public static void loadSettings()
        {
            SettingsForm = new GenericPanel();
            SettingsForm.Name = "Settings";

            SettingsForm.Controls.Add(createTitle("Settings"));

            Panel SettingsContainerPanel = createPanel();
            SettingsForm.Controls.Add(SettingsContainerPanel);

            TableLayoutPanel SettingsPanel = createLayoutPanel(600);
            SettingsPanel.BackColor = Color.Red;
            SettingsContainerPanel.Controls.Add(SettingsPanel);

            TableLayoutPanel LanguagePanel = createLayoutPanelH(100, new int[] { 40, 60 });
            SettingsPanel.Controls.Add(LanguagePanel, 0, 0);

            Label LanguageLabel = new Label();
            LanguageLabel.Dock = DockStyle.Top;
            LanguageLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LanguageLabel.Text = "Language";
            LanguageLabel.TabStop = false;
            LanguagePanel.Controls.Add(LanguageLabel, 0, 0);

            ComboBox LanguageComboBox = new ComboBox();
            LanguageComboBox.Dock = DockStyle.Top;
            LanguageComboBox.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LanguageComboBox.Name = "LanguageComboBox";
            LanguageComboBox.TabStop = false;
            LanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            LanguageComboBox.Items.AddRange(new string[] { "English", "Français" });

            LanguagePanel.Controls.Add(LanguageComboBox, 1, 0);

            TableLayoutPanel ThemePanel = createLayoutPanelH(100, new int[] { 40, 60 });
            SettingsPanel.Controls.Add(ThemePanel, 0, 0);

            Label ThemeLabel = new Label();
            ThemeLabel.Dock = DockStyle.Top;
            ThemeLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ThemeLabel.Text = "Theme";
            ThemeLabel.TabStop = false;
            ThemePanel.Controls.Add(ThemeLabel, 0, 0);

            ComboBox ThemeComboBox = new ComboBox();
            ThemeComboBox.Dock = DockStyle.Top;
            ThemeComboBox.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ThemeComboBox.Name = "ThemeComboBox";
            ThemeComboBox.TabStop = false;
            ThemeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            ThemeComboBox.Items.AddRange(new string[] { "Dark", "Light" });

            ThemePanel.Controls.Add(ThemeComboBox, 1, 0);

        }

        public static void loadCredits()
        {
            CreditsForm = new GenericPanel();
            CreditsForm.Name = "Credits";

            CreditsForm.Controls.Add(createTitle("Credits"));

            Panel CreditsContainerPanel = createPanel();
            CreditsForm.Controls.Add(CreditsContainerPanel);

            TableLayoutPanel CreditsPanel = createLayoutPanel(600);
            CreditsContainerPanel.Controls.Add(CreditsPanel);

            Label CreditsContentLabel = new Label();
            CreditsContentLabel.Dock = DockStyle.Top;
            CreditsContentLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CreditsContentLabel.AutoSize = true;
            CreditsContentLabel.ForeColor = ThemeList.theme.TextColor;
            CreditsContentLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            CreditsContentLabel.TextAlign = ContentAlignment.TopLeft;
            CreditsContentLabel.TabStop = false;
            CreditsContentLabel.Text = ServerConfig.get("credits").value;
            CreditsPanel.Controls.Add(CreditsContentLabel, 0, 0);
        }
    }
}
