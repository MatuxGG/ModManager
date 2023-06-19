using ModManager6.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModManager6.Classes
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
            VersionLabel.Text = "Mod Manager Version " + (ModManager.version.Major == 5 ? ModManager.visibleVersion : "5 Beta");
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
    }
}
