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
using Microsoft.VisualBasic;
using static System.Windows.Forms.Design.AxImporter;

namespace ModManager6.Classes
{
    public static class ModManagerUI
    {
        public static GenericPanel activeForm = null;
        
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
        public static Panel AddModPanel;
        public static Panel SourcesPanel;
        public static Label StatusLabel;
        public static Panel ModsCategoriesPanel;
        public static MMButton StartButton;
        public static Panel StartPanel;

        public static List<GenericPanel> CategoryForms;
        public static GenericPanel ServersForm;
        public static GenericPanel SourcesForm;
        public static GenericPanel AddModForm;
        public static GenericPanel SettingsForm;
        public static GenericPanel CreditsForm;
        public static GenericPanel EmptyForm;
        public static GenericPanel OptionsForm;
        public static string lastVersion;
        public static ModManager thisModManager;
        public static Feedback FeedbackForm;

        public static void load(ModManager modManager)
        {
            try
            {

                Graphics graphics = modManager.CreateGraphics();
                float ratio = 4 / (4 + ((graphics.DpiX - 96) / 24));

                thisModManager = modManager;

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
                FeedbackForm = new Feedback();

                CategoryForms = new List<GenericPanel>() { };

                modManager.BackColor = ThemeList.theme.AppBackgroundColor;

                AddModPanel = ModManagerComponents.MenuPanel("AddModPanel", "Add Mod", global::ModManager6.Properties.Resources.add);
                SourcesPanel = ModManagerComponents.MenuPanel("SourcesPanel", "Sources", global::ModManager6.Properties.Resources.list);
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
                MenuPanel.Controls.Add(SourcesPanel);
                MenuPanel.Controls.Add(AddModPanel);
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
                StatusLabel.Size = new Size(600, 30);
                StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
                StatusLabel.Padding = new Padding(10, 10, 10, 10);
                StatusLabel.Name = "StatusLabel";
                StatusLabel.Text = Translator.get("Loading...");
                StatusLabel.TabStop = false;

                modManager.Controls.Add(AppPanel);
                modManager.Controls.Add(BottomRightPanel);
                modManager.Controls.Add(MenuPanel);
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void loadMini(ModManager modManager)
        {
            try
            {
                Graphics graphics = modManager.CreateGraphics();
                float ratio = 4 / (4 + ((graphics.DpiX - 96) / 24));

                thisModManager = modManager;

                ThemeList.theme.TitleSize = (int)(ratio * ThemeList.theme.TitleSize);
                ThemeList.theme.SubTitleSize = (int)(ratio * ThemeList.theme.SubTitleSize);
                ThemeList.theme.XLSize = (int)(ratio * ThemeList.theme.XLSize);
                ThemeList.theme.MSize = (int)(ratio * ThemeList.theme.MSize);

                StatusLabel = new MMLabel();

                CategoryForms = new List<GenericPanel>() { };

                modManager.BackColor = ThemeList.theme.AppBackgroundColor;
                FeedbackForm = new Feedback();

                // 
                // StatusLabel
                // 
                StatusLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                StatusLabel.Dock = DockStyle.Left;
                StatusLabel.Size = new Size(500, 30);
                StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
                StatusLabel.Padding = new Padding(10, 10, 10, 10);
                StatusLabel.Name = "StatusLabel";
                StatusLabel.ForeColor = ThemeList.theme.TextColor;
                StatusLabel.Text = Translator.get("Loading...");
                StatusLabel.TabStop = false;

                modManager.Controls.Add(StatusLabel);
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
            
        }

        public static void InitUI()
        {
            loadEmpty();
            loadMods();
            loadServers();
            loadAddMod();
            loadSources();
            loadSettings();
            loadCredits();
        }

        public static void reloadMods()
        {
            try
            {
                if (activeForm == null) return;
                string fName = activeForm.Name;
                foreach (GenericPanel gp in CategoryForms)
                {
                    gp.Dispose();
                }
                CategoryForms.Clear();
                foreach (Control c in ModsCategoriesPanel.Controls)
                {
                    c.Dispose();
                }
                ModsCategoriesPanel.Controls.Clear();
                loadMods();
                GenericPanel f = CategoryForms.Find(f => f.Name == fName);
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void InitForm()
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }


        public static void InitListeners()
        {
            try
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

                foreach (Control c in AddModPanel.Controls)
                {
                    c.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        showMenuPanel();
                        openForm(AddModForm);
                    });
                }

                foreach (Control c in SourcesPanel.Controls)
                {
                    c.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        showMenuPanel();
                        openForm(SourcesForm);
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void hideMenuPanels()
        {
            try
            {
                if (ModsCategoriesPanel.Visible == true)
                    ModsCategoriesPanel.Hide();

            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void showMenuPanel(Panel subMenu = null)
        {
            try
            {
                if (subMenu == null || subMenu.Visible == false)
                {
                    hideMenuPanels();
                    if (subMenu != null)
                    {
                        subMenu.Show();
                    }
                }
                else
                {
                    subMenu.Hide();
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }


        public static void openForm(GenericPanel form)
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        private static Button CreateSubMenuButton(string name)
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static void loadMods()
        {
            try
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

                        GenericPanel f = new GenericPanel();
                        f.Name = c.id;
                        CategoryForms.Add(f);

                        b.Click += new EventHandler((object sender, EventArgs e) => {
                            openForm(f);
                        });

                        ModsCategoriesPanel.Controls.Add(b);
                    }
                }

                if (ConfigManager.getFavoriteMods() != null)
                {
                    size++;
                    Button b = CreateSubMenuButton(Translator.get("Favorites"));
                    GenericPanel f = new GenericPanel();
                    f.Name = "Favorites";
                    CategoryForms.Add(f);
                    b.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        openForm(f);
                    });
                    ModsCategoriesPanel.Controls.Add(b);
                }

                ModsCategoriesPanel.Size = new Size(300, 40 * size);

                // Forms

                foreach (GenericPanel f in CategoryForms)
                {
                    refreshModForm(f);
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }

        }

        public static void addOptions(TableLayoutPanel SubModPanel, Mod m, ModVersion v, PictureBox download, PictureBox play, PictureBox unins,
            PictureBox arrowBot, PictureBox arrowTop)
        {
            try
            {

                SubModPanel.Hide();
                SubModPanel.Controls.Clear();

                bool needUpdate = ConfigManager.needUpdate(m, v.gameVersion, v.version);

                if (needUpdate)
                {
                    download.Image = global::ModManager6.Properties.Resources.update;
                }
                else
                {
                    download.Image = global::ModManager6.Properties.Resources.download;
                }

                // Refresh buttons if no option
                if (ConfigManager.isInstalled(m, v, ConfigManager.getActiveOptions(m.id, v.gameVersion)) && needUpdate == false)
                {
                    download.Hide();
                    play.Show();
                    unins.Show();
                }
                else
                {
                    download.Show();
                    play.Hide();
                    unins.Hide();
                }
                List<ModOption> mos = ModList.getModOptions(m, v);
                int nbOptions = mos.Count();

                updateArrows(arrowBot, arrowTop, m, v, SubModPanel);

                SubModPanel.Size = new Size(100, nbOptions > 0 ? nbOptions * 50 + 10 : 0);
                // Refresh options panel
                foreach (ModOption option in mos)
                {
                    Mod modOption = ModList.getModById(option.modOption);
                    ModVersion versionOption = modOption.versions.Find(ver => ver.gameVersion == option.gameVersion);

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
                    ModDiscord.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        string link = modOption.social;
                        Process.Start("explorer", link);
                    });
                    ModDiscord.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModDiscord.Image = global::ModManager6.Properties.Resources.discordHover;
                    });
                    ModDiscord.MouseLeave += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModDiscord.Image = global::ModManager6.Properties.Resources.discord;
                    });
                    SubModLinePanel.Controls.Add(ModDiscord, 4, 0);

                    CheckBox ModBox = new CheckBox();
                    SubModLinePanel.Controls.Add(ModBox, 0, 0);
                    ModBox.Anchor = AnchorStyles.Right;
                    ModBox.AutoSize = true;

                    // Init boxes and add them to verification for isInstalled
                    if (ConfigManager.isActiveOption(m.id, v.gameVersion, option))
                    {
                        ModBox.Checked = true;
                    }
                    else
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        //public static void addOptionsBox(FlowLayoutPanel SubModPanel, Mod m, ModVersion v, PictureBox download, PictureBox play, PictureBox unins)
        //{
        //    SubModPanel.Controls.Clear();
        //    // Refresh buttons if no option
        //    if (ConfigManager.isInstalled(m, v, ConfigManager.getActiveOptions(m.id, v.gameVersion)))
        //    {
        //        download.Hide();
        //        play.Show();
        //        unins.Show();
        //    }
        //    else
        //    {
        //        download.Show();
        //        play.Hide();
        //        unins.Hide();
        //    }
        //    List<ModOption> mos = ModList.getModOptions(m, v);
        //    int nbOptions = mos.Count();
        //    // Refresh options panel
        //    foreach (ModOption option in mos)
        //    {
        //        Mod modOption = ModList.getModById(option.modOption);
        //        ModVersion versionOption = modOption.versions.Find(ver => ver.gameVersion == option.gameVersion);

        //        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        //        flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight; // flex-row
        //        flowLayoutPanel.WrapContents = false; // flex-wrap
        //        flowLayoutPanel.Margin = new Padding(10);
        //        flowLayoutPanel.AutoSize = true;
        //        SubModPanel.Controls.Add(flowLayoutPanel);

        //        CheckBox ModBox = new CheckBox();
        //        ModBox.Anchor = AnchorStyles.Left;
        //        flowLayoutPanel.Controls.Add(ModBox);
        //        ModBox.Anchor = AnchorStyles.Right;
        //        ModBox.AutoSize = true;

        //        LinkLabel ModName = ModManagerComponents.ModLinkLabel("ModName", modOption.name);
        //        ModName.Anchor = AnchorStyles.Right;
        //        flowLayoutPanel.Controls.Add(ModName);
        //        ModName.Click += new EventHandler((object sender, EventArgs e) => {
        //            Process.Start("explorer", modOption.getLink());
        //        });

        //        // Init boxes and add them to verification for isInstalled
        //        if (ConfigManager.isActiveOption(m.id, v.gameVersion, option))
        //        {
        //            ModBox.Checked = true;
        //        }
        //        else
        //        {
        //            ModBox.Checked = false;
        //        }
        //        updateOptions(m, v, option, ModBox, download, play, unins);

        //        // Check / Uncheck handler
        //        ModBox.Click += new EventHandler((object sender, EventArgs e) => {
        //            CheckBox cb = (CheckBox)sender;
        //            updateOptions(m, v, option, cb, download, play, unins);
        //        });
        //    }
        //}

        private static void updateOptions(Mod m, ModVersion v, ModOption option, CheckBox cb, PictureBox download, PictureBox play, PictureBox unins)
        {
            try
            {

                if (cb.Checked)
                {
                    ConfigManager.addActiveOption(m.id, v.gameVersion, option);
                }
                else
                {
                    ConfigManager.removeActiveOption(m.id, v.gameVersion, option);
                }

                bool needUpdate = ConfigManager.needUpdate(m, v.gameVersion, v.version);

                if (needUpdate)
                {
                    download.Image = global::ModManager6.Properties.Resources.update;
                }
                else
                {
                    download.Image = global::ModManager6.Properties.Resources.download;
                }

                if (ConfigManager.isInstalled(m, v, ConfigManager.getActiveOptions(m.id, v.gameVersion)) && !needUpdate)
                {
                    download.Hide();
                    play.Show();
                    unins.Show();
                }
                else
                {
                    download.Show();
                    play.Hide();
                    unins.Hide();
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void updateArrows(PictureBox bot, PictureBox top, Mod m, ModVersion v, TableLayoutPanel panel)
        {
            try
            {

                List<ModOption> mos = ModList.getModOptions(m, v);
                int nbOptions = mos.Count();

                if (nbOptions > 0)
                {
                    List<ModOption> activeOptions = ConfigManager.getActiveOptions(m.id, v.gameVersion);
                    bool hasActiveOptions = activeOptions != null && activeOptions.Count > 0;

                    if (hasActiveOptions)
                    {
                        bot.Hide();
                        top.Show();
                        panel.Show();
                        foreach (Control c in panel.Controls)
                        {
                            c.Show();
                        }
                    }
                    else
                    {
                        top.Hide();
                        bot.Show();
                        panel.Hide();
                    }
                }
                else
                {
                    top.Hide();
                    bot.Hide();
                    panel.Hide();
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void refreshModForm(GenericPanel f)
        {
            try
            {
                f.Controls.Clear();

                Category cat = ModList.getCategoryById(f.Name);

                List<Mod> mods = new List<Mod>() { };

                if (cat.id == "Favorites")
                {
                    mods = ConfigManager.getFavoriteMods();
                }
                else
                {
                    mods = ModList.getModsByCategoryId(f.Name);
                }

                bool isInLineView = true;
                int maxOptions = 0;

                Panel ContainerPanel = new Panel();
                f.SetDoubleBuffer(ContainerPanel, true);
                ContainerPanel.Name = "ContainerPanel";
                ContainerPanel.BackColor = Color.Transparent;
                ContainerPanel.Dock = DockStyle.Fill;
                ContainerPanel.AutoScroll = true;
                f.Controls.Add(ContainerPanel);
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                f.SetDoubleBuffer(flowLayoutPanel, true);

                if (!isInLineView)
                {
                    mods.Reverse();
                    flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight; // flex-row
                    flowLayoutPanel.WrapContents = true; // flex-wrap
                    flowLayoutPanel.Dock = DockStyle.Fill;
                    flowLayoutPanel.Margin = new Padding(10);
                    flowLayoutPanel.AutoSize = true;
                    ContainerPanel.Controls.Add(flowLayoutPanel);
                    foreach (Mod m in mods)
                    {
                        foreach (ModVersion mv in m.versions)
                        {
                            List<ModOption> mos = ModList.getModOptions(m, mv);
                            if (mos.Count() > maxOptions)
                            {
                                maxOptions = mos.Count();
                            }
                        }
                    }
                }

                foreach (Mod m in mods)
                {
                    int nbVersions = m.versions.Count();

                    PictureBox ModDiscord = ModManagerComponents.ModPic("ModDiscord", global::ModManager6.Properties.Resources.discord);
                    ModDiscord.Click += new EventHandler((object sender, EventArgs e) => {
                        string link = m.social;
                        Process.Start("explorer", link);
                    });
                    ModDiscord.MouseEnter += new EventHandler((object sender, EventArgs e) => {
                        ModDiscord.Image = global::ModManager6.Properties.Resources.discordHover;
                    });
                    ModDiscord.MouseLeave += new EventHandler((object sender, EventArgs e) => {
                        ModDiscord.Image = global::ModManager6.Properties.Resources.discord;
                    });

                    Label ModGameVersion;

                    if (m.type == "mod")
                    {
                        ModGameVersion = ModManagerComponents.ModLabel("ModGameVersion", m.versions.FirstOrDefault().gameVersion);
                    }
                    else
                    {
                        ModGameVersion = ModManagerComponents.ModLabel("ModGameVersion", "-");
                        ModGameVersion.Hide();
                    }

                    // Flag
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

                    LinkLabel ModAuthor = ModManagerComponents.ModLinkLabel("ModAuthor", m.author);

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
                    ModTitle.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        string link = m.getLink();
                        Process.Start("explorer", link);
                    });

                    MMComboBox VersionCombobox = new MMComboBox();
                    PictureBox ModDownload = ModManagerComponents.ModPic("ModDownload", global::ModManager6.Properties.Resources.download);
                    PictureBox ModPlay = ModManagerComponents.ModPic("ModPlay", global::ModManager6.Properties.Resources.play);
                    PictureBox ModUnins = ModManagerComponents.ModPic("ModPlay", global::ModManager6.Properties.Resources.delete);

                    if (m.type == "mod")
                    {
                        List<string> versions = new List<string>() { };
                        int i = 0; int foundIndex = -1;
                        string savedVersion = ConfigManager.getActiveGameVersion(m.id);
                        foreach (ModVersion v in m.versions)
                        {
                            VersionCombobox.Items.Add(v.version);
                            if (v.gameVersion == savedVersion)
                            {
                                foundIndex = i;
                            }
                            i++;
                        }
                        VersionCombobox.SelectedIndex = foundIndex != -1 ? foundIndex : 0;
                    }
                    else
                    {
                        VersionCombobox.Items.Add("-");
                        VersionCombobox.SelectedIndex = 0;
                        VersionCombobox.Hide();
                    }

                    ModDownload.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (m.type == "mod" || m.type == "")
                        {
                            string selected = VersionCombobox.SelectedItem.ToString();
                            ModVersion v = m.versions.Find(v => v.version == selected);
                            List<ModOption> options = ConfigManager.getActiveOptions(m.id, v.gameVersion);
                            if (options == null) options = new List<ModOption>() { };
                            List<string> modOptionStrings = options.Select(modOption => modOption.modOption).ToList();
                            ModWorker.installAnyMod(m, v, modOptionStrings);
                        }
                        else if (m.type == "allInOne")
                        {
                            ModWorker.installAnyMod(m, null, null);
                        }
                    });

                    ModDownload.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        string selected = VersionCombobox.SelectedItem.ToString();
                        ModVersion v = m.versions.Find(v => v.version == selected);
                        bool isDownload = v == null || !ConfigManager.needUpdate(m, v.gameVersion, v.version);
                        if (isDownload)
                        {
                            ModDownload.Image = global::ModManager6.Properties.Resources.downloadHover;
                        } else
                        {
                            ModDownload.Image = global::ModManager6.Properties.Resources.updateHover;
                        }
                    });
                    ModDownload.MouseLeave += new EventHandler((object sender, EventArgs e) =>
                    {
                        string selected = VersionCombobox.SelectedItem.ToString();
                        ModVersion v = m.versions.Find(v => v.version == selected);
                        bool isDownload = v == null || !ConfigManager.needUpdate(m, v.gameVersion, v.version);
                        if (isDownload)
                        {
                            ModDownload.Image = global::ModManager6.Properties.Resources.download;
                        } else
                        {
                            ModDownload.Image = global::ModManager6.Properties.Resources.update;
                        }
                    });
                    ModDownload.Hide();

                    ModPlay.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (m.type == "mod")
                        {
                            string selected = VersionCombobox.SelectedItem.ToString();
                            ModVersion v = m.versions.Find(v => v.version == selected);
                            List<ModOption> options = ConfigManager.getActiveOptions(m.id, v.gameVersion);
                            if (options == null) options = new List<ModOption>() { };
                            List<string> modOptionStrings = options.Select(modOption => modOption.modOption).ToList();
                            ModWorker.startMod(m, v, modOptionStrings);
                        }
                        else if (m.type == "allInOne")
                        {
                            ModWorker.startMod(m, null, null);
                        }
                    });
                    ModPlay.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModPlay.Image = global::ModManager6.Properties.Resources.playHover;
                    });
                    ModPlay.MouseLeave += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModPlay.Image = global::ModManager6.Properties.Resources.play;
                    });
                    ModPlay.Hide();

                    ModUnins.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        if (m.type == "mod")
                        {
                            string selected = VersionCombobox.SelectedItem.ToString();
                            ModVersion v = m.versions.Find(v => v.version == selected);
                            ModWorker.uninsMod(m, v);
                        }
                        else if (m.type == "allInOne")
                        {
                            ModWorker.uninsMod(m, null);
                        }
                    });
                    ModUnins.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModUnins.Image = global::ModManager6.Properties.Resources.deleteHover;
                    });
                    ModUnins.MouseLeave += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModUnins.Image = global::ModManager6.Properties.Resources.delete;
                    });
                    ModUnins.Hide();

                    PictureBox ModFavorite = ModManagerComponents.ModPic("ModFavorite", global::ModManager6.Properties.Resources.favorite);
                    if (ConfigManager.isFavoriteMod(m.id))
                    {
                        ModFavorite.Image = global::ModManager6.Properties.Resources.favoriteFilled;
                        ModFavorite.Click += new EventHandler((object sender, EventArgs e) => {
                            ConfigManager.removeFavoriteMod(m.id);
                            ConfigManager.update();
                            reloadMods();
                        });
                    }
                    else
                    {
                        ModFavorite.Click += new EventHandler((object sender, EventArgs e) => {
                            ConfigManager.addFavoriteMod(m.id);
                            ConfigManager.update();
                            reloadMods();
                        });
                        ModFavorite.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModFavorite.Image = global::ModManager6.Properties.Resources.favoriteFilled;
                        });
                        ModFavorite.MouseLeave += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModFavorite.Image = global::ModManager6.Properties.Resources.favorite;
                        });
                    }

                    PictureBox ModSave = ModManagerComponents.ModPic("ModSave", global::ModManager6.Properties.Resources.shortcut);
                    ModSave.Click += new EventHandler((object sender, EventArgs e) => {
                        string selected = VersionCombobox.SelectedItem.ToString();
                        ModVersion v = m.versions.Find(v => v.version == selected);
                        List<ModOption> options = ConfigManager.getActiveOptions(m.id, v.gameVersion);
                        if (options == null) options = new List<ModOption>() { };
                        List<string> modOptionStrings = options.Select(modOption => modOption.modOption).ToList();
                        ModList.createShortcut(m, v, modOptionStrings);
                    });
                    ModSave.MouseEnter += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModSave.Image = global::ModManager6.Properties.Resources.shortcutHover;
                    });
                    ModSave.MouseLeave += new EventHandler((object sender, EventArgs e) =>
                    {
                        ModSave.Image = global::ModManager6.Properties.Resources.shortcut;
                    });

                    PictureBox ModArrowTop = ModManagerComponents.ModPic("ModArrowTop", global::ModManager6.Properties.Resources.top);
                    PictureBox ModArrowBottom = ModManagerComponents.ModPic("ModArrow", global::ModManager6.Properties.Resources.bottom);

                    ModArrowTop.Hide();
                    ModArrowBottom.Hide();

                    if (isInLineView)
                    {
                        TableLayoutPanel SubModPanel = new TableLayoutPanel();
                        f.SetDoubleBuffer(SubModPanel, true);
                        SubModPanel.Name = "SubModPanel";
                        SubModPanel.BackColor = Color.Transparent;
                        SubModPanel.Dock = DockStyle.Top;
                        ContainerPanel.Controls.Add(SubModPanel);

                        SubModPanel.ColumnCount = 1;
                        SubModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                        SubModPanel.RowCount = nbVersions;
                        SubModPanel.Size = new Size(100, 0);
                        //                SubModPanel.Size = new System.Drawing.Size(100, 50 * nbVersions + 20);
                        SubModPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

                        TableLayoutPanel ModPanel = new TableLayoutPanel();
                        ModPanel.Name = "ModPanel";
                        ModPanel.BackColor = ThemeList.theme.AppOverlayColor;
                        ModPanel.Dock = DockStyle.Top;
                        ContainerPanel.Controls.Add(ModPanel);

                        ModPanel.ColumnCount = 11;
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Flags
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Name
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Author
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F)); // Version
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // Game Version
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Favorite
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Shortcut
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Discord
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Download / Start
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Uninstall
                        ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Arrows
                        ModPanel.RowCount = 1;
                        ModPanel.Size = new System.Drawing.Size(100, 50);
                        ModPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

                        if (m.social != null && m.social != "")
                        {
                            ModPanel.Controls.Add(ModDiscord, 7, 0);
                        }

                        ModPanel.Controls.Add(ModGameVersion, 4, 0);

                        ModPanel.Controls.Add(ModAuthor, 2, 0);

                        ModPanel.Controls.Add(ModTitle, 1, 0);

                        ModPanel.Controls.Add(ModLg, 0, 0);

                        ModPanel.Controls.Add(ModFavorite, 5, 0);

                        ModPanel.Controls.Add(ModSave, 6, 0);

                        ModPanel.Controls.Add(ModArrowBottom, 10, 0);

                        ModPanel.Controls.Add(ModArrowTop, 10, 0);

                        VersionCombobox.SelectionChangeCommitted += new EventHandler(async (object sender, EventArgs e) =>
                        {
                            ComboBox control = (ComboBox)sender;
                            string version = (string)control.SelectedItem;
                            ModVersion curVersion = m.versions.Find(v => v.version == version);
                            if (m.type == "mod") ModGameVersion.Text = curVersion.gameVersion;
                            ConfigManager.setActiveGameVersion(m.id, curVersion.gameVersion);
                            addOptions(SubModPanel, m, curVersion, ModDownload, ModPlay, ModUnins, ModArrowBottom, ModArrowTop);

                        });

                        ModPanel.Controls.Add(VersionCombobox, 3, 0);

                        ModPanel.Controls.Add(ModDownload, 8, 0);

                        ModPanel.Controls.Add(ModPlay, 8, 0);

                        ModPanel.Controls.Add(ModUnins, 9, 0);

                        if (m.type == "mod")
                        {
                            string activeVersion = ConfigManager.getActiveGameVersion(m.id);
                            if (activeVersion == null)
                            {
                                activeVersion = m.versions.FirstOrDefault().gameVersion;
                            }
                            ModVersion activeVersionObj = m.versions.Find(v => v.gameVersion == activeVersion);
                            string version = (string)VersionCombobox.SelectedItem;

                            addOptions(SubModPanel, m, activeVersionObj, ModDownload, ModPlay, ModUnins, ModArrowBottom, ModArrowTop);

                            ModArrowTop.Click += new EventHandler((object sender, EventArgs e) =>
                            {
                                ModArrowTop.Hide();
                                ModArrowBottom.Show();
                                SubModPanel.Hide();
                            });

                            ModArrowBottom.Click += new EventHandler((object sender, EventArgs e) =>
                            {
                                ModArrowBottom.Hide();
                                ModArrowTop.Show();
                                SubModPanel.Show();
                                foreach (Control c in SubModPanel.Controls)
                                {
                                    c.Show();
                                }
                            });
                        }
                        else if (m.type == "allInOne")
                        {
                            if (ConfigManager.isAllInOneInstalled(m))
                            {
                                ModDownload.Hide();
                                ModPlay.Show();
                                ModUnins.Show();
                            }
                            else
                            {
                                ModDownload.Show();
                                ModPlay.Hide();
                                ModUnins.Hide();
                            }
                        }

                    }
                    else
                    {
                        FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
                        flowLayoutPanel2.FlowDirection = FlowDirection.TopDown; // flex-row
                        flowLayoutPanel2.WrapContents = false; // flex-wrap
                        flowLayoutPanel2.BackColor = ThemeList.theme.AppOverlayColor;
                        flowLayoutPanel2.Margin = new Padding(10);
                        flowLayoutPanel2.AutoSize = true;
                        flowLayoutPanel.Controls.Add(flowLayoutPanel2);

                        // Line 1

                        FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel();
                        flowLayoutPanel3.FlowDirection = FlowDirection.LeftToRight; // flex-row
                        flowLayoutPanel3.WrapContents = false; // flex-wrap
                        flowLayoutPanel3.Margin = new Padding(10);
                        flowLayoutPanel3.AutoSize = true;
                        flowLayoutPanel2.Controls.Add(flowLayoutPanel3);

                        // Line 1 - Left

                        FlowLayoutPanel flowLayoutPanel4 = new FlowLayoutPanel();
                        flowLayoutPanel4.FlowDirection = FlowDirection.TopDown; // flex-row
                        flowLayoutPanel4.WrapContents = false; // flex-wrap
                        flowLayoutPanel4.Margin = new Padding(2);
                        flowLayoutPanel4.AutoSize = true;
                        flowLayoutPanel3.Controls.Add(flowLayoutPanel4);

                        flowLayoutPanel4.Controls.Add(ModTitle);
                        flowLayoutPanel4.Controls.Add(ModAuthor);
                        flowLayoutPanel4.Controls.Add(ModGameVersion);

                        FlowLayoutPanel flowLayoutPanel7 = new FlowLayoutPanel();

                        VersionCombobox.SelectionChangeCommitted += new EventHandler(async (object sender, EventArgs e) =>
                        {
                            ComboBox control = (ComboBox)sender;
                            string version = (string)control.SelectedItem;
                            ModVersion curVersion = m.versions.Find(v => v.version == version);
                            if (m.type == "mod") ModGameVersion.Text = curVersion.gameVersion;
                            ConfigManager.setActiveGameVersion(m.id, curVersion.gameVersion);
                            //addOptionsBox(flowLayoutPanel7, m, curVersion, ModDownload, ModPlay, ModUnins);
                        });
                        flowLayoutPanel4.Controls.Add(VersionCombobox);

                        // Line 1 - Right

                        flowLayoutPanel3.Controls.Add(ModLg);
                        ModLg.Anchor = AnchorStyles.Right;
                        ModLg.Dock = DockStyle.Top;

                        // Line 2

                        FlowLayoutPanel flowLayoutPanel5 = new FlowLayoutPanel();
                        flowLayoutPanel5.FlowDirection = FlowDirection.LeftToRight; // flex-row
                        flowLayoutPanel5.WrapContents = true; // flex-wrap
                        flowLayoutPanel5.Margin = new Padding(10);
                        flowLayoutPanel5.AutoSize = true;
                        flowLayoutPanel2.Controls.Add(flowLayoutPanel5);

                        flowLayoutPanel5.Controls.Add(ModDownload);
                        flowLayoutPanel5.Controls.Add(ModPlay);
                        flowLayoutPanel5.Controls.Add(ModUnins);
                        ModDownload.Anchor = AnchorStyles.Left;
                        ModPlay.Anchor = AnchorStyles.Left;
                        ModUnins.Anchor = AnchorStyles.Left;

                        if (m.social != null && m.social != "")
                        {
                            flowLayoutPanel5.Controls.Add(ModDiscord);
                        }
                        ModDiscord.Anchor = AnchorStyles.Right;

                        // Line 3

                        flowLayoutPanel7.FlowDirection = FlowDirection.TopDown; // flex-row
                        flowLayoutPanel7.WrapContents = false; // flex-wrap
                        flowLayoutPanel7.Margin = new Padding(10);
                        flowLayoutPanel7.Anchor = AnchorStyles.Left;
                        flowLayoutPanel7.Size = new Size(0, 50 * maxOptions);
                        //flowLayoutPanel7.AutoSize = true;
                        flowLayoutPanel2.Controls.Add(flowLayoutPanel7);

                        if (m.type == "mod")
                        {
                            string activeVersion = ConfigManager.getActiveGameVersion(m.id);
                            if (activeVersion == null)
                            {
                                activeVersion = m.versions.FirstOrDefault().version;
                            }
                            ModVersion activeVersionObj = m.versions.Find(v => v.gameVersion == activeVersion);
                            //addOptionsBox(flowLayoutPanel7, m, activeVersionObj, ModDownload, ModPlay, ModUnins);
                        }
                        else if (m.type == "allInOne")
                        {
                            if (ConfigManager.isAllInOneInstalled(m))
                            {
                                ModDownload.Hide();
                                ModPlay.Show();
                                ModUnins.Show();
                            }
                            else
                            {
                                ModDownload.Show();
                                ModPlay.Hide();
                                ModUnins.Hide();
                            }
                        }
                    }

                }

                if (isInLineView)
                    f.Controls.Add(ModManagerComponents.ModsOverlay());

                f.Controls.Add(ModManagerComponents.LabelTitle(Translator.get(cat.name)));
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void loadAddMod()
        {
            try
            {
                AddModForm = new GenericPanel();
                AddModForm.Name = "AddMod";

                AddModForm.Controls.Add(ModManagerComponents.LabelTitle(Translator.get("Add Mod")));

            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void loadSources()
        {
            try
            {
                SourcesForm = new GenericPanel();
                SourcesForm.Name = "Sources";

                //    List<ModSource> sources = new List<ModSource>();
                //    sources.AddRange(ModList.modSources);
                //    sources.Add(new ModSource("https://newsource.com"));

                //    int max = sources.Count();
                //    int i = 0;

                //    Panel SourcesContainerPanel = ModManagerComponents.createPanel();
                //    SourcesForm.Controls.Add(SourcesContainerPanel);

                //    TableLayoutPanel SourcesPanel = new TableLayoutPanel();
                //    SourcesPanel.Size = new Size(0, 50 * max);
                //    SourcesPanel.Dock = DockStyle.Top;

                //    SourcesPanel.ColumnCount = 5;
                //    SourcesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                //    SourcesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
                //    SourcesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                //    SourcesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                //    SourcesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

                //    SourcesPanel.RowCount = max;
                //    int row = 0;
                //    while (row < max)
                //    {
                //        SourcesPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / max));
                //        row++;
                //    }

                //    foreach (ModSource s in ModList.modSources)
                //    {
                //        TextBox SourceName = new TextBox();
                //        TextBox SourceURL = new TextBox();
                //        TextBox SourceMods = new TextBox();
                //        PictureBox SourceValidPic = new PictureBox();
                //        SourceValidPic.Name = "SourceValidPic=" + i;
                //        PictureBox SourceRemovePic = new PictureBox();
                //        SourceRemovePic.Name = "SourceRemovePic=" + i;
                //        ModManagerComponents.SourceLine(SourcesPanel, i, s, SourceName, SourceURL, SourceMods, SourceValidPic, SourceRemovePic, (i < 1), (i + 1 == max));

                //        if (i + 1 != max)
                //        {
                //            SourceName.TextChanged += new EventHandler((object sender, EventArgs e) =>
                //            {
                //                SourceValidPic.Show();
                //            });

                //            SourceMods.TextChanged += new EventHandler((object sender, EventArgs e) =>
                //            {
                //                SourceValidPic.Show();
                //            });

                //            SourceValidPic.Click += new EventHandler((object sender, EventArgs e) =>
                //            {
                //                ModWorker.startTransaction();

                //                //string picName = ServerValidPic.Name;
                //                //int serverId = int.Parse(picName.Substring(picName.IndexOf("=") + 1));

                //                //ServerManager.serverList.Regions[serverId].name = ServerName.Text;
                //                //ServerManager.serverList.Regions[serverId].DefaultIp = result[0].Value;
                //                //ServerManager.serverList.Regions[serverId].Fqdn = result[0].Value;
                //                //ServerManager.serverList.Regions[serverId].port = int.Parse(ServerPort.Text);
                //                //ServerManager.update();
                //                //ModManagerUI.loadServers();
                //                //openForm(ServersForm);
                //                //ModWorker.endTransaction();
                //            });

                //            SourceRemovePic.Click += new EventHandler((object sender, EventArgs e) =>
                //            {
                //                //ModWorker.startTransaction();
                //                //string picName = ServerRemovePic.Name;
                //                //int serverId = int.Parse(picName.Substring(picName.IndexOf("=") + 1));

                //                //ServerManager.serverList.Regions.RemoveAt(serverId);
                //                //ServerManager.update();
                //                //ModManagerUI.loadServers();
                //                //openForm(ServersForm);
                //                //ModWorker.endTransaction();
                //            });

                //        }
                //        else
                //        {
                //            SourceRemovePic.Click += new EventHandler((object sender, EventArgs e) =>
                //            {
                //                //ModWorker.startTransaction();
                //                //// Check if Ip valid

                //                //Server newServ = new Server("DnsRegionInfo, Assembly - CSharp", result[0].Value, result[0].Value, int.Parse(ServerPort.Text), ServerName.Text, 1003);
                //                //ServerManager.serverList.Regions.Add(newServ);
                //                //ServerManager.update();
                //                //ModManagerUI.loadServers();
                //                //openForm(ServersForm);
                //                //ModWorker.endTransaction();
                //            });
                //        }
                //        i++;
                //    }

                //    SourcesForm.Controls.Add(ModManagerComponents.ServersOverlay());

                //    SourcesForm.Controls.Add(ModManagerComponents.LabelTitle(Translator.get("Sources")));
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void loadServers()
        {
            try
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
                            ServerValidPic.Show();
                        });

                        ServerIP.TextChanged += new EventHandler((object sender, EventArgs e) =>
                        {
                            ServerValidPic.Show();
                        });

                        ServerPort.TextChanged += new EventHandler((object sender, EventArgs e) =>
                        {
                            Regex portRegex = new Regex(@"^\d+$");
                            MatchCollection result = portRegex.Matches(ServerPort.Text);
                            if (result.Count() == 0)
                                return;

                            ServerValidPic.Show();
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
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void loadSettings()
        {
            try
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

                // Change appData Location

                MMButton PathButton = new MMButton("trans");
                PathButton.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    if (ModWorker.isGameOpen()) return;

                    try
                    {
                        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                        folderBrowser.SelectedPath = ConfigManager.config.dataPath;

                        if (folderBrowser.ShowDialog() == DialogResult.OK)
                        {
                            ModWorker.startTransaction();
                            string folderPath = Path.GetFullPath(folderBrowser.SelectedPath);
                            Task.Run(() =>
                            {
                                FileSystem.DirectoryCreate(folderPath + @"\mod");
                                FileSystem.DirectoryCreate(folderPath + @"\mods");
                                FileSystem.DirectoryCreate(folderPath + @"\vanilla");
                                if (Directory.Exists(ConfigManager.config.dataPath + @"\mod"))
                                {
                                    FileSystem.DirectoryDelete(folderPath + @"\mod");
                                    Directory.Move(ConfigManager.config.dataPath + @"\mod", folderPath + @"\mod");
                                }
                                if (Directory.Exists(ConfigManager.config.dataPath + @"\mods"))
                                {
                                    FileSystem.DirectoryDelete(folderPath + @"\mods");
                                    Directory.Move(ConfigManager.config.dataPath + @"\mods", folderPath + @"\mods");
                                }
                                if (Directory.Exists(ConfigManager.config.dataPath + @"\vanilla"))
                                {
                                    FileSystem.DirectoryDelete(folderPath + @"\vanilla");
                                    Directory.Move(ConfigManager.config.dataPath + @"\vanilla", folderPath + @"\vanilla");
                                }
                                ConfigManager.config.dataPath = folderPath;
                                ConfigManager.update();
                            });
                            ModWorker.endTransaction();
                        }

                    }
                    catch (Exception ex)
                    {
                        Log.logExceptionToServ(ex);
                    }
                    
                });

                SettingsForm.Controls.Add(ModManagerComponents.SettingsButton(PathButton, Translator.get("Move Data")));

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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void loadCredits()
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static GenericPanel getFormByCategoryId(string id)
        {
            try
            {
                return CategoryForms.Find(f => f.Name == id);
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }


        public static void loadEmpty()
        {
            EmptyForm = new GenericPanel();
            EmptyForm.Name = "Empty";
        }

        public static void bindWIP(GenericPanel f)
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

        public static void Alert(string msg, bool success = true) // , AlertBox.enmType type
        {
            try
            {
                AlertBox frm = new AlertBox();
                frm.showAlert(msg, success);
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}
