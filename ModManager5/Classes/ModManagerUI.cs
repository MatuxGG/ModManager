using Microsoft.Win32;
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

        public static TextBox LoginPseudoText;
        public static TextBox LoginPasswordText;
        public static List<Control> allocatedControls;

        public static void load(ModManager modManager)
        {
            Utils.log("Load START", "ModManagerUI");
            Graphics graphics = modManager.CreateGraphics();
            float ratio = 4 / (4 + ((graphics.DpiX - 96) / 24));

            ThemeList.theme.TitleSize = (int) (ratio * ThemeList.theme.TitleSize);
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
            allocatedControls = new List<Control>() { };

            modManager.BackColor = ThemeList.theme.AppBackgroundColor;

            ServersPanel = Visuals.MenuPanel("ServersPanel", "Servers", global::ModManager5.Properties.Resources.servers);
            SettingsPanel = Visuals.MenuPanel("SettingsPanel", "Settings", global::ModManager5.Properties.Resources.settings);
            CreditsPanel = Visuals.MenuPanel("CreditsPanel", "Credits", global::ModManager5.Properties.Resources.credits);
            ModsPanel = Visuals.MenuPanel("ModsPanel", "Mods", global::ModManager5.Properties.Resources.mods);

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

            RoadmapPict = Visuals.BottomLeftPict(global::ModManager5.Properties.Resources.roadmap);
            GithubPict = Visuals.BottomLeftPict(global::ModManager5.Properties.Resources.github);
            DiscordPict = Visuals.BottomLeftPict(global::ModManager5.Properties.Resources.discord);
            AccountPict = Visuals.BottomLeftPict(global::ModManager5.Properties.Resources.account);
            NewsPict = Visuals.BottomLeftPict(global::ModManager5.Properties.Resources.news);
            FaqPict = Visuals.BottomLeftPict(global::ModManager5.Properties.Resources.faq);

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
            VersionLabel.Text = "Mod Manager Version " + (ModManager.version.Major == 5 ? ModManager.visibleVersion : "5 Beta");
            VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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
            Utils.log("Load END", "ModManagerUI");
        }

        public static void InitUI()
        {
            Utils.log("InitUI START", "ModManagerUI");
            foreach (Control c in allocatedControls)
            {
                c.Dispose();
            }
            allocatedControls.Clear();
            //loadLocalMods();
            loadEmpty();
            loadMods();
            loadServers();
            loadSettings();
            loadCredits();
            Utils.log("InitUI END", "ModManagerUI");
        }

        public static void reloadMods()
        {
            string fName = activeForm.Name;
            CategoryForms.Clear();
            ModsCategoriesPanel.Controls.Clear();
            loadMods();
            Form f = CategoryForms.Find(f => f.Name == fName);
            if (f != null)
            {
                openForm(f);
            } else
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
            } else
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
            Utils.log("Load mods START", "ModManagerUI");
            // SubMenus

            List<Category> oriCats = CategoryManager.categories;
            List<Category> cats = new List<Category>() { };
            cats.AddRange(oriCats);
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

            if (ConfigManager.getFavoriteMods() != null)
            {
                size++;
                Button b = CreateSubMenuButton(Translator.get("Favorites"));
                Form f = new GenericPanel();
                f.Name = "Favorites";
                CategoryForms.Add(f);
                b.Click += new EventHandler((object sender, EventArgs e) => {
                    openForm(f);
                });
                ModsCategoriesPanel.Controls.Add(b);
            }

            ModsCategoriesPanel.Size = new Size(300, 40 * size);

            // Forms
            
            foreach (Form f in CategoryForms)
            {
                refreshModForm(f);
            }

            Utils.log("Load mods END", "ModManagerUI");
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
                TableLayoutPanel InfoPanel = Visuals.InfoLabel(Translator.get("In your ZIP file, you need to include") + "\n" +
                Translator.get("ⓘ BepInEx folder, mono folder, doorstop_config.ini & winhttp.dll ⓘ")
                );
                f.Controls.Add(InfoPanel);
                mods.AddRange(ModList.localMods);
                int nextId = ModList.localMods.Count();
                mods.Add(new Mod("LocalMod" + nextId, Translator.get("NewMod") + nextId, "local", "local", ServerConfig.get("gameVersion").value, new List<string>() { ModList.mods.Find(d => d.id.Contains("BepInEx")).id }, "", "", "0", "", "", "", "", "", new List<string>() { }));
            } else if (cat.id == "Favorites")
            {
                mods = ConfigManager.getFavoriteMods();
            } else
            {
                mods = ModList.getModsByCategory(f.Name);
            }

            if (ConfigManager.config.launcher != "Steam" && f.Name != "local")
            {
                TableLayoutPanel AlertPanel = Visuals.AlertLabel(Translator.get("⚠ You are not using Among Us from Steam. As a consequence, some mods may not be available. ⚠") + "\n" +
                Translator.get("If you're using Among Us from Steam, please change launcher in Settings.")
                );
                f.Controls.Add(AlertPanel);
            }

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
                ModPanel.ColumnCount = 9;
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                ModPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
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
                    
                    if (m.id == "BetterCrewlink")
                    {
                        if (ConfigManager.isBetterCrewlinkInstalled())
                        {
                            ConfigManager.config.installedMods.RemoveAll(im => im.id == m.id);
                            InstalledMod bcl = new InstalledMod(m.id, "", "", new List<string>() { });
                            ConfigManager.config.installedMods.Add(bcl);
                            ConfigManager.update();
                            im = ConfigManager.getInstalledModById(m.id);
                        } else if (ConfigManager.getInstalledModById(m.id) != null)
                        {
                            ConfigManager.config.installedMods.RemoveAll(im => im.id == m.id);
                            ConfigManager.update();
                            im = ConfigManager.getInstalledModById(m.id);
                        }
                    }

                    if (im == null)
                    {
                        PictureBox ModDownload = Visuals.ModPic("ModDownload", global::ModManager5.Properties.Resources.download);
                        ModDownload.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModWorker.installAnyMod(m);
                        });
                        allocatedControls.Add(ModDownload);
                        ModPanel.Controls.Add(ModDownload, 3, line);
                    }
                    else if (((m.type != "allInOne" || m.id == "Challenger" || m.id == "ChallengerBeta") && im.version != m.release.TagName) || (m.type != "allInOne" && im.gameVersion != m.gameVersion))
                    {
                        PictureBox ModUpdate = Visuals.ModPic("ModUpdate", global::ModManager5.Properties.Resources.update);
                        ModUpdate.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModWorker.installAnyMod(m);
                        });
                        allocatedControls.Add(ModUpdate);
                        ModPanel.Controls.Add(ModUpdate, 3, line);
                    }
                    else
                    {
                        PictureBox ModPlay = Visuals.ModPic("ModPlay", global::ModManager5.Properties.Resources.play);
                        ModPlay.Click += new EventHandler((object sender, EventArgs e) =>
                        {
                            ModWorker.startMod(m);
                        });
                        allocatedControls.Add(ModPlay);
                        ModPanel.Controls.Add(ModPlay, 3, line);
                    }
                    
                    PictureBox ModUninstall = Visuals.ModPic("ModUninstall", global::ModManager5.Properties.Resources.delete);
                    allocatedControls.Add(ModUninstall);
                    ModPanel.Controls.Add(ModUninstall, 4, line);

                    if (im != null)
                    {
                        ModUninstall.Click += new EventHandler((object sender, EventArgs e) => {
                            if (MessageBox.Show(Translator.get("Are you sure you want to remove this mod ?"), Translator.get("Remove mod"), MessageBoxButtons.YesNo) == DialogResult.Yes) // TODO
                            {
                                ModWorker.UninstallMod(m);
                            }
                        });
                        ModUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
                    } else
                    {
                        ModUninstall.Cursor = System.Windows.Forms.Cursors.Default;
                        ModUninstall.Image = null;
                    }

                    PictureBox ModFavorite = Visuals.ModPic("ModFavorite", global::ModManager5.Properties.Resources.favorite);
                    if (ConfigManager.isFavoriteMod(m.id))
                    {
                        ModFavorite.Image = global::ModManager5.Properties.Resources.favoriteFilled;
                        ModFavorite.Click += new EventHandler((object sender, EventArgs e) => {
                            ConfigManager.removeFavoriteMod(m.id);
                            ConfigManager.update();
                            reloadMods();
                        });
                    } else
                    {
                        ModFavorite.Click += new EventHandler((object sender, EventArgs e) => {
                            ConfigManager.addFavoriteMod(m.id);
                            ConfigManager.update();
                            reloadMods();
                        });
                    }
                    
                    allocatedControls.Add(ModFavorite);
                    ModPanel.Controls.Add(ModFavorite, 8, line);

                    PictureBox ModSave = Visuals.ModPic("ModSave", global::ModManager5.Properties.Resources.shortcut);
                    ModSave.Click += new EventHandler((object sender, EventArgs e) => {
                        ModList.createShortcut(m);
                    });
                    allocatedControls.Add(ModSave);
                    ModPanel.Controls.Add(ModSave, 7, line);

                    if (m.social != null && m.social != "")
                    {
                        PictureBox ModDiscord = Visuals.ModPic("ModDiscord", global::ModManager5.Properties.Resources.discord);
                        allocatedControls.Add(ModDiscord);
                        ModDiscord.Click += new EventHandler((object sender, EventArgs e) => {
                            string link = m.social;
                            Process.Start("explorer", link);
                        });
                        ModPanel.Controls.Add(ModDiscord, 6, line);
                    }
                    PictureBox ModEdit = Visuals.ModPic("ModEdit", global::ModManager5.Properties.Resources.edit);
                    allocatedControls.Add(ModEdit);
                    ModPanel.Controls.Add(ModEdit, 5, line);
                    if (m.options.Count() == 0 || im == null)
                    {
                        ModEdit.Image = null;
                        ModEdit.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                    else
                    {
                        ModEdit.Click += new EventHandler((object sender, EventArgs e) => {
                            openOptionsForm(m);
                        });
                    }
                    Label ModVersion = Visuals.ModLabel("ModVersion", m.githubLink == "1" ? m.release.TagName : "");
                    allocatedControls.Add(ModVersion);
                    ModPanel.Controls.Add(ModVersion, 2, line);

                    LinkLabel ModAuthor = Visuals.ModLinkLabel("ModAuthor", m.author);
                    allocatedControls.Add(ModAuthor);
                    ModPanel.Controls.Add(ModAuthor, 1, line);

                    if (m.githubLink == "1")
                    {
                        ModAuthor.Click += new EventHandler((object sender, EventArgs e) => {
                            Process.Start("explorer", m.getAuthorLink());
                        });
                    }
                    else
                    {
                        ModAuthor.LinkBehavior = LinkBehavior.NeverUnderline;
                    }

                    LinkLabel ModTitle = Visuals.ModLinkLabel("ModTitle", m.name);
                    ModPanel.Controls.Add(ModTitle, 0, line);
                    allocatedControls.Add(ModTitle);
                    ModTitle.Click += new EventHandler((object sender, EventArgs e) => {
                        string link = m.getLink();
                        Process.Start("explorer", link);
                    });

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
                    if (!ModVersion.Items.Contains(ServerConfig.get("gameVersion").value))
                    {
                        ModVersion.Items.Add(ServerConfig.get("gameVersion").value);
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
                        ModRemovedPic.Image = global::ModManager5.Properties.Resources.add;
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
                                string vanillaDestPath = ModManager.appDataPath + @"\vanilla\" + ModVersion.Text;
                                ZipFile.ExtractToDirectory(FileButton.Text, tempPath);
                                tempPath = ModWorker.getBepInExInsideRec(tempPath);
                                Utils.DirectoryCopy(vanillaDestPath, newPath, true);
                                Utils.DirectoryCopy(tempPath, newPath, true);

                                Mod newLocalMod = new Mod(ModTitle.Name, ModTitle.Text, "local", "local", ModVersion.Text, new List<string>() { }, "", @"localMods\"+ModTitle.Text, "0", "", "", "", "") ;
                                
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
                        ModRemovedPic.Image = global::ModManager5.Properties.Resources.delete;
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
        public static void openOptionsForm(Mod m)
        {
            InstalledMod im = ConfigManager.getInstalledModById(m.id);

            OptionsForm = new Form();
            OptionsForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            OptionsForm.MaximizeBox = false;
            OptionsForm.Size = new Size(800, 40 + 50 * m.options.Count());
            OptionsForm.StartPosition = FormStartPosition.CenterScreen;
            OptionsForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            OptionsForm.BackColor = ThemeList.theme.AppBackgroundColor;
            OptionsForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            OptionsForm.ForeColor = ThemeList.theme.TextColor;
            OptionsForm.Icon = global::ModManager5.Properties.Resources.modmanager;
            OptionsForm.Name = "OptionsForm";
            OptionsForm.Text = m.name + " options";

            Panel ContainerOptionsPanel = new Panel();
            ContainerOptionsPanel.Name = "ContainerOptionsPanel";
            ContainerOptionsPanel.BackColor = Color.Transparent;
            ContainerOptionsPanel.Dock = DockStyle.Fill;
            ContainerOptionsPanel.AutoScroll = false;
            OptionsForm.Controls.Add(ContainerOptionsPanel);

            TableLayoutPanel ModOptionsPanel = new TableLayoutPanel();
            ModOptionsPanel.Name = "ModOptionsPanel";
            ModOptionsPanel.BackColor = Color.Transparent;
            ModOptionsPanel.Dock = DockStyle.Top;
            ContainerOptionsPanel.Controls.Add(ModOptionsPanel);

            foreach (string optionName in m.options)
            {
                Mod option = ModList.getModById(optionName);
                MMButton OptionButton = new MMButton("trans");
                OptionsForm.Controls.Add(Visuals.OptionsLine(OptionButton, optionName));

                OptionButton.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    MMButton c = (MMButton)sender;
                    if (c.Text == Translator.get("Enabled"))
                    {
                        im.options.Remove(optionName);
                        ConfigManager.update();
                        c.Text = Translator.get("Disabled");
                    } else if (c.Text == Translator.get("Disabled"))
                    {
                        im.options.Add(optionName);
                        ConfigManager.update();
                        c.Text = Translator.get("Enabled");
                    }
                });

                if (im.hasOption(optionName))
                {
                    OptionButton.Text = Translator.get("Enabled");
                } else if (ConfigManager.getInstalledModById(optionName) != null)
                {
                    OptionButton.Text = Translator.get("Disabled");
                } else
                {
                    OptionButton.Text = Translator.get("Not installed");
                }
            }

            OptionsForm.ShowDialog();
        }
        public static void loadServers()
        {
            Utils.log("Load servers START", "ModManagerUI");
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

            Utils.log("Load mods END", "ModManagerUI");
        }

        public static void loadSettings()
        {
            Utils.log("Load settings START", "ModManagerUI");
            SettingsForm = new GenericPanel();
            SettingsForm.Name = "Settings";

            // Reset
            MMButton ResetButton = new MMButton("trans");
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
            MMButton LogButton = new MMButton("trans");
            LogButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                string argument = "/select, \"" + ModManager.appDataPath + @"\logs.txt" + "\"";

                Process.Start("explorer.exe", argument);
            });

            SettingsForm.Controls.Add(Visuals.SettingsButton(LogButton, Translator.get("Log File")));

            // Minimise in taskbar
            MMButton MinimisationButton = new MMButton("trans");
            MinimisationButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                MMButton c = (MMButton)sender;
                if (c.Text == Translator.get("Enabled"))
                {
                    ConfigManager.config.miniEnabled = false;
                    c.Text = Translator.get("Disabled");
                } else
                {
                    ConfigManager.config.miniEnabled = true;
                    c.Text = Translator.get("Enabled");
                }
                ConfigManager.update();
            });
            SettingsForm.Controls.Add(Visuals.SettingsButton(MinimisationButton, Translator.get("Minimise in taskbar")));
            if (ConfigManager.config.miniEnabled)
            {
                MinimisationButton.Text = Translator.get("Enabled");
            }
            else
            {
                MinimisationButton.Text = Translator.get("Disabled");
            }

            // Among Us Path add
            MMButton PathButton = new MMButton("trans");
            PathButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                if (MessageBox.Show(Translator.get("Be careful! All mods will be uninstalled! Please, don't change this option if you don't know what you're doing. Do you want to continue?"), Translator.get("Change Among Us path"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string amongUspath = ConfigManager.selectFolderWorker();

                    if (amongUspath != null)
                    {
                        ModWorker.removeAllMods();
                        ConfigManager.addAvailableAmongUsPath(amongUspath);
                        ConfigManager.config.launcher = "Other";
                        ConfigManager.config.amongUsPath = amongUspath;
                        ConfigManager.update();
                        SettingsForm.Controls.Clear();
                        loadSettings();
                        openForm(SettingsForm);
                    }
                }
            });

            SettingsForm.Controls.Add(Visuals.SettingsButton(PathButton, Translator.get("Search Among Us path")));

            // Among Us Path
            MMComboBox PathComboBox = new MMComboBox();
            PathComboBox.SelectionChangeCommitted += new EventHandler(async (object sender, EventArgs e) => {
                ComboBox control = (ComboBox)sender;
                string path = (string)control.SelectedItem;

                if (MessageBox.Show(Translator.get("Be careful! All mods will be uninstalled! Please, don't change this option if you don't know what you're doing. Do you want to continue?"), Translator.get("Change Among Us path"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.removeAllMods();
                    ConfigManager.config.amongUsPath = path;
                    ConfigManager.update();
                    Form f = activeForm;
                    ModManagerUI.reloadMods();
                    openForm(f);
                }
                else
                {
                    control.SelectedItem = ConfigManager.config.amongUsPath;
                }
            });

            List<string> paths = new List<string>() { };

            paths.AddRange(ConfigManager.config.availableAmongUsPaths);

            SettingsForm.Controls.Add(Visuals.SettingsCombobox(PathComboBox, Translator.get("Among Us Path"), paths, ConfigManager.config.amongUsPath));
            PathComboBox.Width = PathComboBox.getAutoWidth();

            // Launcher
            MMComboBox LauncherComboBox = new MMComboBox();
            LauncherComboBox.SelectionChangeCommitted += new EventHandler(async (object sender, EventArgs e) => {
                ComboBox control = (ComboBox)sender;
                string launcher = (string)control.SelectedItem;

                if (MessageBox.Show(Translator.get("Be careful! All mods will be uninstalled! Please, don't change this option if you don't know what you're doing. Do you want to continue?"), Translator.get("Change Launcher"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ModWorker.removeAllMods();
                    ConfigManager.config.launcher = launcher;
                    ConfigManager.update();
                    Form f = activeForm;
                    ModManagerUI.reloadMods();
                    openForm(f);
                }
                else
                {
                    control.SelectedItem = ConfigManager.config.launcher;
                }
            });

            List<string> launchers = new List<string>() { };

            launchers.Add("Steam");
            launchers.Add("EGS");
            launchers.Add("Other");

            SettingsForm.Controls.Add(Visuals.SettingsCombobox(LauncherComboBox, Translator.get("Launcher"), launchers, ConfigManager.config.launcher));
            LauncherComboBox.Width = LauncherComboBox.getAutoWidth();

            // Language
            MMComboBox LanguageComboBox = new MMComboBox();
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
            LanguageComboBox.Width = LanguageComboBox.getAutoWidth();

            // Theme
            MMComboBox ThemeComboBox = new MMComboBox();
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
            ThemeComboBox.Width = ThemeComboBox.getAutoWidth();

            SettingsForm.Controls.Add(Visuals.LabelTitle(Translator.get("Settings")));

            Utils.log("Load settings END", "ModManagerUI");
        }

        public static void loadCredits()
        {
            Utils.log("Load credits START", "ModManagerUI");
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

            CreditsForm.Controls.Add(Visuals.LabelTitle(Translator.get("Credits")));

            Utils.log("Load credits END", "ModManagerUI");
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
