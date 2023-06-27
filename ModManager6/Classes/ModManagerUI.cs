using ModManager6.Forms;
using ModManager6.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using System.Security.Policy;
using System.Text.RegularExpressions;
using TextBox = System.Windows.Forms.TextBox;
using ComboBox = System.Windows.Forms.ComboBox;
using static System.Windows.Forms.LinkLabel;
using ExCSS;
using Color = System.Drawing.Color;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace ModManager6.Classes
{
    public static class ModManagerUI
    {
        public static Form activeForm = null;

        public static Panel MenuPanel;
        public static PictureBox LogoPict;
        public static Panel BottomRightPanel;
        public static Panel ModsPanel;
        public static Panel BottomLeftPanel;
        public static Panel IconsMenuPanel;
        public static PictureBox RoadmapPict;
        public static PictureBox GithubPict;
        public static PictureBox DiscordPict;
        public static PictureBox AccountPict;
        public static PictureBox NewsPict;
        public static PictureBox FaqPict;
        public static Label VersionLabel;
        public static Panel AppPanel;
        public static Label LoadingLabel;
        public static Panel CreditsPanel;
        public static Panel SettingsPanel;
        public static Panel ServersPanel;
        public static Label StatusLabel;
        public static Panel ModsCategoriesPanel;
        public static MMButton StartButton;
        public static Panel StartPanel;

        public static List<Form> CategoryForms;
        public static Form ServersForm;
        public static Form SettingsForm;
        public static Form CreditsForm;
        public static Form EmptyForm;
        public static Form OptionsForm;

        public static void load(ModManager modManager)
        {

            Graphics graphics = modManager.CreateGraphics();
            float ratio = 4 / (4 + ((graphics.DpiX - 96) / 24));

            ThemeList.theme.TitleSize = (int)(ratio * ThemeList.theme.TitleSize);
            ThemeList.theme.SubTitleSize = (int)(ratio * ThemeList.theme.SubTitleSize);
            ThemeList.theme.XLSize = (int)(ratio * ThemeList.theme.XLSize);
            ThemeList.theme.MSize = (int)(ratio * ThemeList.theme.MSize);

            MenuPanel = new Panel();
            ModsCategoriesPanel = new Panel();
            BottomLeftPanel = new Panel();
            IconsMenuPanel = new Panel();
            VersionLabel = new MMLabel();
            LogoPict = new PictureBox();
            BottomRightPanel = new Panel();
            AppPanel = new Panel();
            LoadingLabel = new MMLabel();
            StatusLabel = new MMLabel();
            StartButton = new MMButton("rounded");
            StartPanel = new Panel();

            CategoryForms = new List<Form>() { };

            modManager.BackColor = ThemeList.theme.AppBackgroundColor;

            ServersPanel = ModManagerComponents.MenuPanel("ServersPanel", "Servers", global::ModManager6.Properties.Resources.servers);
            SettingsPanel = ModManagerComponents.MenuPanel("SettingsPanel", "Settings", global::ModManager6.Properties.Resources.settings);
            CreditsPanel = ModManagerComponents.MenuPanel("CreditsPanel", "Credits", global::ModManager6.Properties.Resources.credits);
            ModsPanel = ModManagerComponents.MenuPanel("ModsPanel", "Mods", global::ModManager6.Properties.Resources.mods);

            // 
            // MenuPanel
            // 
            MenuPanel.AutoScroll = true;
            MenuPanel.BackColor = ThemeList.theme.MenuBackgroundColor;
            MenuPanel.Controls.Add(CreditsPanel);
            MenuPanel.Controls.Add(SettingsPanel);
            MenuPanel.Controls.Add(ServersPanel);
            MenuPanel.Controls.Add(ModsCategoriesPanel);
            MenuPanel.Controls.Add(BottomLeftPanel);
            MenuPanel.Controls.Add(ModsPanel);
            MenuPanel.Controls.Add(LogoPict);
            MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            MenuPanel.Location = new System.Drawing.Point(0, 0);
            MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new System.Drawing.Size(300, 1041);

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
            //BottomLeftPanel.Controls.Add(IconsMenuPanel2);
            BottomLeftPanel.Controls.Add(IconsMenuPanel);
            BottomLeftPanel.Controls.Add(VersionLabel);
            BottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            BottomLeftPanel.Location = new System.Drawing.Point(0, 941);
            BottomLeftPanel.Name = "BottomLeftPanel";
            BottomLeftPanel.Size = new System.Drawing.Size(300, 200);

            RoadmapPict = ModManagerComponents.BottomLeftPict(global::ModManager6.Properties.Resources.roadmap);
            GithubPict = ModManagerComponents.BottomLeftPict(global::ModManager6.Properties.Resources.github);
            DiscordPict = ModManagerComponents.BottomLeftPict(global::ModManager6.Properties.Resources.discord);
            AccountPict = ModManagerComponents.BottomLeftPict(global::ModManager6.Properties.Resources.account);
            NewsPict = ModManagerComponents.BottomLeftPict(global::ModManager6.Properties.Resources.news);
            FaqPict = ModManagerComponents.BottomLeftPict(global::ModManager6.Properties.Resources.faq);

            // 
            // IconsMenuPanel
            // 
            IconsMenuPanel.BackColor = ThemeList.theme.MenuButtonsColor;
            IconsMenuPanel.Controls.Add(RoadmapPict);
            IconsMenuPanel.Controls.Add(GithubPict);
            IconsMenuPanel.Controls.Add(DiscordPict);
            IconsMenuPanel.Controls.Add(FaqPict);
            IconsMenuPanel.Controls.Add(NewsPict);
            IconsMenuPanel.Controls.Add(AccountPict);
            IconsMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            IconsMenuPanel.Location = new System.Drawing.Point(0, 30);
            IconsMenuPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            IconsMenuPanel.Name = "IconsMenuPanel";
            IconsMenuPanel.Size = new System.Drawing.Size(300, 60);
            IconsMenuPanel.Padding = new Padding(30, 15, 30, 15);



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
            VersionLabel.Text = "Mod Manager Version " + (ModManager.version.Major == 5 ? ModManager.visibleVersion : "6 Beta");
            VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // LogoPict
            // 
            LogoPict.Dock = System.Windows.Forms.DockStyle.Top;
            LogoPict.Image = global::ModManager6.Properties.Resources.modmanager_logo;
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
            loadEmpty();
            loadMods();
            loadServers();
            loadSettings();
            loadCredits();
        }

        public static void reloadMods()
        {
            if (activeForm == null) return;
            string fName = activeForm.Name;
            CategoryForms.Clear();
            ModsCategoriesPanel.Controls.Clear();
            loadMods();
            Form f = CategoryForms.Find(f => f.Name == fName);
            if (f != null)
            {
                openForm(f);
            }
            else
            {
                openForm(CategoryForms.Last());
            }
            if (!ModManager.silent)
                ContextMenu.load();
        }

        public static void InitForm()
        {
            if (CategoryForms.Count() > 0)
            {
                showMenuPanel(ModsCategoriesPanel);
                openForm(CategoryForms.Last());
            }
            else
            {
                openForm(EmptyForm);
            }
        }


        public static void InitListeners()
        {
            foreach (Control c in ModsPanel.Controls)
            {
                c.Click += new EventHandler((object sender, EventArgs e) => {
                    showMenuPanel(ModsCategoriesPanel);
                });
            }

            foreach (Control c in ServersPanel.Controls)
            {
                c.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    showMenuPanel();
                    openForm(ServersForm);
                });
            }

            foreach (Control c in CreditsPanel.Controls)
            {
                c.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    showMenuPanel();
                    openForm(CreditsForm);
                });
            }

            foreach (Control c in SettingsPanel.Controls)
            {
                c.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    showMenuPanel();
                    openForm(SettingsForm);
                });
            }

            FaqPict.Click += new EventHandler((object sender, EventArgs e) =>
            {
                Process.Start("explorer", ModManager.serverURL + @"\faq");
            });
            NewsPict.Click += new EventHandler((object sender, EventArgs e) =>
            {
                Process.Start("explorer", ModManager.serverURL + @"\news");
            });
            AccountPict.Click += new EventHandler((object sender, EventArgs e) =>
            {
                Process.Start("explorer", ModManager.serverURL + @"\login");
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

                ModWorker.startGame();
            });

        }

        public static void hideMenuPanels()
        {
            if (ModsCategoriesPanel.Visible == true)
                ModsCategoriesPanel.Visible = false;
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

            List<Category> oriCats = ModList.getAllCategories();
            List<Category> cats = new List<Category>() { };
            cats.AddRange(oriCats);
            cats.Reverse();
            int size = 0;
            foreach (Category c in cats)
            {
                if (ModList.getModsByCategoryId(c.id).Count() > 0)
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

            //if (ConfigManager.getFavoriteMods() != null)
            //{
            //    size++;
            //    Button b = CreateSubMenuButton(Translator.get("Favorites"));
            //    Form f = new GenericPanel();
            //    f.Name = "Favorites";
            //    CategoryForms.Add(f);
            //    b.Click += new EventHandler((object sender, EventArgs e) => {
            //        openForm(f);
            //    });
            //    ModsCategoriesPanel.Controls.Add(b);
            //} TODO

            ModsCategoriesPanel.Size = new Size(300, 40 * size);

            // Forms

            foreach (Form f in CategoryForms)
            {
                refreshModForm(f);
            }

        }

        public static void addOptions(TableLayoutPanel SubModPanel, Mod m, ModVersion v, PictureBox download, PictureBox play, PictureBox unins)
        {
            SubModPanel.Controls.Clear();
            // Refresh buttons if no option
            if (ConfigManager.isInstalled(m, v, ConfigManager.getActiveOptions(m.id, v.version)))
            {
                download.Visible = false;
                play.Visible = true;
                unins.Visible = true;
            }
            else
            {
                download.Visible = true;
                play.Visible = false;
                unins.Visible = false;
            }
            // Refresh options panel
            foreach (ModOption option in v.options)
            {
                Mod modOption = ModList.getModById(option.modOption);
                if (modOption == null)
                {
                    Log.debug(option.modOption);
                    Log.debug(ModList.modSources[0].mods.Count().ToString());
                }
                ModVersion versionOption = modOption.versions.Find(ver => ver.version == option.version);

                TableLayoutPanel SubModLinePanel = new TableLayoutPanel();
                SubModLinePanel.Name = "SubModLinePanel";
                SubModLinePanel.BackColor = Color.Transparent;
                SubModLinePanel.Dock = DockStyle.Top;
                SubModPanel.Controls.Add(SubModLinePanel);

                SubModLinePanel.ColumnCount = 5;
                SubModLinePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Checkbox
                SubModLinePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Name
                SubModLinePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Author
                SubModLinePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F)); // Version
                SubModLinePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F)); // Discord
                SubModLinePanel.RowCount = 1;
                SubModLinePanel.Size = new System.Drawing.Size(100, 50);
                SubModLinePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

                LinkLabel ModName = ModManagerComponents.ModLinkLabel("ModName", modOption.name);
                SubModLinePanel.Controls.Add(ModName, 1, 0);
                ModName.Click += new EventHandler((object sender, EventArgs e) => {
                    Process.Start("explorer", modOption.getLink());
                });

                LinkLabel ModAuthor = ModManagerComponents.ModLinkLabel("ModAuthor", modOption.author);
                SubModLinePanel.Controls.Add(ModAuthor, 2, 0);

                if (modOption.githubLink)
                {
                    ModAuthor.Click += new EventHandler((object sender, EventArgs e) => {
                        Process.Start("explorer", modOption.getAuthorLink());
                    });
                }
                else
                {
                    ModAuthor.LinkBehavior = LinkBehavior.NeverUnderline;
                }

                LinkLabel ModVersion = ModManagerComponents.ModLinkLabel("ModVersion", versionOption.release.TagName);
                SubModLinePanel.Controls.Add(ModVersion, 3, 0);
                ModVersion.Click += new EventHandler((object sender, EventArgs e) => {
                    Process.Start("explorer", modOption.getReleaseLink(versionOption));
                });

                PictureBox ModDiscord = ModManagerComponents.ModPic("ModDiscord", global::ModManager6.Properties.Resources.discord);
                ModDiscord.Click += new EventHandler((object sender, EventArgs e) => {
                    string link = modOption.social;
                    Process.Start("explorer", link);
                });
                SubModLinePanel.Controls.Add(ModDiscord, 4, 0);

                CheckBox ModBox = new CheckBox();
                SubModLinePanel.Controls.Add(ModBox, 0, 0);
                ModBox.Anchor = AnchorStyles.Right;
                ModBox.AutoSize = true;

                // Init boxes and add them to verification for isInstalled
                if (ConfigManager.isActiveOption(m.id, v.version, option))
                {
                    ModBox.Checked = true;
                } else
                {
                    ModBox.Checked = false;
                }
                updateOptions(m, v, option, ModBox, download, play, unins);

                // Check / Uncheck handler
                ModBox.Click += new EventHandler((object sender, EventArgs e) => {
                    CheckBox cb = (CheckBox)sender;
                    updateOptions(m, v, option, cb, download, play, unins);
                });
            }
        }

        private static void updateOptions(Mod m, ModVersion v, ModOption option, CheckBox cb, PictureBox download, PictureBox play, PictureBox unins)
        {
            if (cb.Checked)
            {
                ConfigManager.addActiveOption(m.id, v.version, option);
            }
            else
            {
                ConfigManager.removeActiveOption(m.id, v.version, option);
            }

            if (ConfigManager.isInstalled(m, v, ConfigManager.getActiveOptions(m.id, v.version)))
            {
                download.Visible = false;
                play.Visible = true;
                unins.Visible = true;
            }
            else
            {
                download.Visible = true;
                play.Visible = false;
                unins.Visible = false;
            }
        }

        public static void refreshModForm(Form f)
        {
            f.Controls.Clear();

            Category cat = ModList.getCategoryById(f.Name);

            List<Mod> mods = new List<Mod>() { };

            if (cat.id == "Favorites")
            {
                //mods = ConfigManager.getFavoriteMods();
            }
            else
            {
                mods = ModList.getModsByCategoryId(f.Name);
            }

            Panel ContainerPanel = new Panel();
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.BackColor = Color.Transparent;
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.AutoScroll = true;
            f.Controls.Add(ContainerPanel);

            foreach (Mod m in mods)
            {
                int nbVersions = m.versions.Count();
                //Log.debug(m.id + " / " + nbVersions.ToString());

                TableLayoutPanel SubModPanel = new TableLayoutPanel();
                SubModPanel.Name = "SubModPanel";
                SubModPanel.BackColor = Color.Transparent;
                SubModPanel.Dock = DockStyle.Top;
                ContainerPanel.Controls.Add(SubModPanel);

                SubModPanel.ColumnCount = 1;
                SubModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                SubModPanel.RowCount = nbVersions;
                SubModPanel.Size = new System.Drawing.Size(100, 50 * nbVersions + 20);
                SubModPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

                TableLayoutPanel ModPanel = new TableLayoutPanel();
                ModPanel.Name = "ModPanel";
                ModPanel.BackColor = ThemeList.theme.AppOverlayColor;
                ModPanel.Dock = DockStyle.Top;
                ContainerPanel.Controls.Add(ModPanel);

                ModPanel.ColumnCount = 8;
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Flags
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Name
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Author
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F)); // Version
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // Game Version
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Discord
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Download / Start
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Uninstall
                ModPanel.RowCount = 1;
                ModPanel.Size = new System.Drawing.Size(100, 50);
                ModPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

                if (m.social != null && m.social != "")
                {
                    PictureBox ModDiscord = ModManagerComponents.ModPic("ModDiscord", global::ModManager6.Properties.Resources.discord);
                    ModDiscord.Click += new EventHandler((object sender, EventArgs e) => {
                        string link = m.social;
                        Process.Start("explorer", link);
                    });
                    ModPanel.Controls.Add(ModDiscord, 5, 0);
                }

                Label ModGameVersion = ModManagerComponents.ModLabel("ModGameVersion", m.versions.First().gameVersion);
                ModPanel.Controls.Add(ModGameVersion, 4, 0);

                LinkLabel ModAuthor = ModManagerComponents.ModLinkLabel("ModAuthor", m.author);
                ModPanel.Controls.Add(ModAuthor, 2, 0);

                if (m.githubLink)
                {
                    ModAuthor.Click += new EventHandler((object sender, EventArgs e) => {
                        Process.Start("explorer", m.getAuthorLink());
                    });
                }
                else
                {
                    ModAuthor.LinkBehavior = LinkBehavior.NeverUnderline;
                }

                LinkLabel ModTitle = ModManagerComponents.ModLinkLabel("ModTitle", m.name);
                ModPanel.Controls.Add(ModTitle, 1, 0);
                ModTitle.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    string link = m.getLink();
                    Process.Start("explorer", link);
                });

                Bitmap lgMap;
                switch (m.countries)
                {
                    case "fr":
                        lgMap = global::ModManager6.Properties.Resources.fr;
                        break;
                    case "es":
                        lgMap = global::ModManager6.Properties.Resources.es;
                        break;
                    case "cn":
                        lgMap = global::ModManager6.Properties.Resources.cn;
                        break;
                    case "jp":
                        lgMap = global::ModManager6.Properties.Resources.jp;
                        break;
                    default:
                        lgMap = global::ModManager6.Properties.Resources.en;
                        break;
                }

                PictureBox ModLg = ModManagerComponents.ModPic("ModLg", lgMap);
                ModLg.Cursor = Cursors.Default;
                ModPanel.Controls.Add(ModLg, 0, 0);

                MMComboBox VersionCombobox = new MMComboBox();
                PictureBox ModDownload = ModManagerComponents.ModPic("ModDownload", global::ModManager6.Properties.Resources.download);
                PictureBox ModPlay = ModManagerComponents.ModPic("ModPlay", global::ModManager6.Properties.Resources.play);
                PictureBox ModUnins = ModManagerComponents.ModPic("ModPlay", global::ModManager6.Properties.Resources.delete);

                VersionCombobox.SelectionChangeCommitted += new EventHandler(async (object sender, EventArgs e) =>
                {
                    ComboBox control = (ComboBox)sender;
                    string version = (string)control.SelectedItem;
                    ModVersion curVersion = m.versions.Find(v => v.version == version);
                    ModGameVersion.Text = curVersion.gameVersion;
                    ConfigManager.setActiveVersion(m.id, curVersion.version);
                    addOptions(SubModPanel, m, curVersion, ModDownload, ModPlay, ModUnins);
                });

                List<string> versions = new List<string>() { };
                int i = 0; int foundIndex = -1;
                string savedVersion = ConfigManager.getActiveVersion(m.id);
                foreach (ModVersion v in m.versions)
                {
                    VersionCombobox.Items.Add(v.version);
                    if (v.version == savedVersion)
                    {
                        foundIndex = i;
                    }
                    i++;
                }
                VersionCombobox.SelectedIndex = foundIndex != -1 ? foundIndex : 0; 
                ModPanel.Controls.Add(VersionCombobox, 3, 0);

                ModDownload.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    string selected = VersionCombobox.SelectedItem.ToString();
                    List<ModOption> options = ConfigManager.getActiveOptions(m.id, selected);
                    if (options == null) options = new List<ModOption>() { };
                    List<string> modOptionStrings = options.Select(modOption => modOption.modOption).ToList();
                    ModVersion v =  m.versions.Find(v => v.version == selected);
                    ModWorker.installAnyMod(m, v, modOptionStrings);
                });
                ModDownload.Visible = false;
                ModPanel.Controls.Add(ModDownload, 6, 0);

                ModPlay.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    //
                });
                ModPlay.Visible = false;
                ModPanel.Controls.Add(ModPlay, 6, 0);

                ModUnins.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    //
                });
                ModUnins.Visible = false;
                ModPanel.Controls.Add(ModUnins, 7, 0);

                if (m.type == "mod")
                {
                    string activeVersion = ConfigManager.getActiveVersion(m.id);
                    if (activeVersion == null)
                    {
                        activeVersion = m.versions.First().version;
                    }
                    ModVersion activeVersionObj = m.versions.Find(v => v.version == activeVersion);
                    addOptions(SubModPanel, m, activeVersionObj, ModDownload, ModPlay, ModUnins);
                }
            }

            f.Controls.Add(ModManagerComponents.ModsOverlay());

            f.Controls.Add(ModManagerComponents.LabelTitle(Translator.get(cat.name)));
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

            Panel ServersContainerPanel = ModManagerComponents.createPanel();
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
                ServersPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / max));
                row++;
            }

            ServersContainerPanel.Controls.Add(ServersPanel);

            MMButton ResetButton = new MMButton("rounded");
            ResetButton.Dock = DockStyle.Bottom;
            TableLayoutPanel t = ModManagerComponents.centeredButton(Translator.get("Reset to default"), ResetButton);
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
                ModManagerComponents.ServerLine(ServersPanel, i, s, ServerName, ServerIP, ServerPort, ServerValidPic, ServerRemovePic, (i < 3), (i + 1 == max));

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

                }
                else
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

            ServersForm.Controls.Add(ModManagerComponents.ServersOverlay());

            ServersForm.Controls.Add(ModManagerComponents.LabelTitle(Translator.get("Servers")));
        }

        public static void loadSettings()
        {
            SettingsForm = new GenericPanel();
            SettingsForm.Name = "Settings";

            // Reset
            MMButton ResetButton = new MMButton("trans");
            ResetButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                if (MessageBox.Show(Translator.get("Mod Manager needs to restart to process this change. Do you want to continue ?"), Translator.get("Reset Mod Manager"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.startTransaction();

                    FileSystem.DirectoryDelete(ModManager.appDataPath);
                    string path = ModManager.appPath + "ModManager6.exe";
                    Process.Start(path, "force " + activeForm.Name);
                    Environment.Exit(0);
                }
            });

            SettingsForm.Controls.Add(ModManagerComponents.SettingsButton(ResetButton, Translator.get("Reset")));

            // Support Id
            MMButton SupportIdButton = new MMButton("trans");
            SupportIdButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                Clipboard.SetText(ConfigManager.config.supportId);
            });

            SettingsForm.Controls.Add(ModManagerComponents.SettingsButton(SupportIdButton, Translator.get("Copy Support Id")));

            // Send log
            MMButton LogButton = new MMButton("trans");
            LogButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                string argument = "/select, \"" + ModManager.appDataPath + @"\logs.txt" + "\"";

                Process.Start("explorer.exe", argument);
            });

            SettingsForm.Controls.Add(ModManagerComponents.SettingsButton(LogButton, Translator.get("Log File")));

            // Minimise in taskbar
            MMButton MinimisationButton = new MMButton("trans");
            MinimisationButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                MMButton c = (MMButton)sender;
                if (c.Text == Translator.get("Enabled"))
                {
                    ConfigManager.config.miniEnabled = false;
                    c.Text = Translator.get("Disabled");
                }
                else
                {
                    ConfigManager.config.miniEnabled = true;
                    c.Text = Translator.get("Enabled");
                }
                ConfigManager.update();
            });
            SettingsForm.Controls.Add(ModManagerComponents.SettingsButton(MinimisationButton, Translator.get("Minimise in taskbar")));
            if (ConfigManager.config.miniEnabled)
            {
                MinimisationButton.Text = Translator.get("Enabled");
            }
            else
            {
                MinimisationButton.Text = Translator.get("Disabled");
            }

            // Language
            MMComboBox LanguageComboBox = new MMComboBox();
            LanguageComboBox.SelectionChangeCommitted += new EventHandler(async (object sender, EventArgs e) => {
                ComboBox control = (ComboBox)sender;
                string lg = (string)control.SelectedItem;
                if (MessageBox.Show(Translator.get("Mod Manager needs to restart to process this change. Do you want to continue ?"), Translator.get("Change Language"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.startTransaction();

                    ConfigManager.config.lg = Translator.getCodeFromName(lg);
                    ConfigManager.update();
                    string path = ModManager.appPath + "ModManager6.exe";
                    Process.Start(path, "force");
                    Environment.Exit(0);
                }
                else
                {
                    control.SelectedItem = ConfigManager.config.lg;
                }
            });

            List<string> lgs = new List<string>() { };
            foreach (Language l in Translator.languages)
            {
                lgs.Add(l.name);
            }
            SettingsForm.Controls.Add(ModManagerComponents.SettingsCombobox(LanguageComboBox, Translator.get("Language"), lgs, Translator.getNameFromCode(ConfigManager.config.lg)));
            LanguageComboBox.Width = LanguageComboBox.getAutoWidth();

            // Theme
            MMComboBox ThemeComboBox = new MMComboBox();
            ThemeComboBox.SelectionChangeCommitted += new EventHandler((object sender, EventArgs e) => {
                ComboBox control = (ComboBox)sender;
                string theme = (string)control.SelectedItem;
                if (MessageBox.Show(Translator.get("Mod Manager needs to restart to process this change. Do you want to continue ?"), Translator.get("Change Theme"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.startTransaction();

                    ConfigManager.config.theme = theme;
                    ConfigManager.update();
                    string path = ModManager.appPath + "ModManager6.exe";
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

            SettingsForm.Controls.Add(ModManagerComponents.SettingsCombobox(ThemeComboBox, Translator.get("Theme"), themes, ThemeList.theme.name));
            ThemeComboBox.Width = ThemeComboBox.getAutoWidth();

            SettingsForm.Controls.Add(ModManagerComponents.LabelTitle(Translator.get("Settings")));
        }

        public static void loadCredits()
        {
            CreditsForm = new GenericPanel();
            CreditsForm.Name = "Credits";

            MMLabel CreditsContentLabel = new MMLabel();
            CreditsContentLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CreditsContentLabel.BackColor = Color.Transparent;
            CreditsContentLabel.ForeColor = SystemColors.Control;
            CreditsContentLabel.TextAlign = ContentAlignment.MiddleCenter;
            CreditsContentLabel.Dock = DockStyle.Top;
            CreditsContentLabel.Name = "CreditsContentLabel";
            CreditsContentLabel.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            CreditsContentLabel.UseMnemonic = false;
            CreditsContentLabel.Size = new System.Drawing.Size(250, 150);
            string creditsText = Translator.get("creditsContent").Replace("\\n", "\n");
            CreditsContentLabel.Text = creditsText;
            CreditsForm.Controls.Add(CreditsContentLabel);

            CreditsForm.Controls.Add(ModManagerComponents.LabelTitle(Translator.get("Credits")));
        }

        public static Form getFormByCategoryId(string id)
        {
            return CategoryForms.Find(f => f.Name == id);
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
