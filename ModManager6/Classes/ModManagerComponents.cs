using ModManager6.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public class ModManagerComponents
    {
        public static Label LabelTitle(string title)
        {
            MMLabel LabelTitle = new MMLabel();
            LabelTitle.Font = new System.Drawing.Font(ThemeList.theme.TitleFont, ThemeList.theme.TitleSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LabelTitle.BackColor = ThemeList.theme.AppBackgroundColor;
            LabelTitle.ForeColor = Color.Transparent;
            LabelTitle.TextAlign = ContentAlignment.MiddleCenter;
            LabelTitle.Dock = DockStyle.Top;
            LabelTitle.Padding = new Padding(0, 25, 0, 25);
            LabelTitle.Size = new Size(0, 150);
            LabelTitle.Text = title;
            return LabelTitle;
        }

        public static Label LabelSubTitle(string title)
        {
            MMLabel LabelSubTitle = new MMLabel();
            LabelSubTitle.Dock = DockStyle.Top;
            LabelSubTitle.Font = new Font(ThemeList.theme.SubTitleFont, ThemeList.theme.SubTitleSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LabelSubTitle.Size = new Size(0, 100);
            LabelSubTitle.ForeColor = ThemeList.theme.TextColor;
            LabelSubTitle.BackColor = Color.Transparent;
            LabelSubTitle.TextAlign = ContentAlignment.MiddleCenter;
            LabelSubTitle.TabStop = false;
            LabelSubTitle.Text = title;
            return LabelSubTitle;
        }

        public static TableLayoutPanel AlertLabel(string message)
        {
            TableLayoutPanel LayoutPanel = ModManagerComponents.createLayoutPanelH(0, 100, DockStyle.Bottom, new int[] { 100 });

            Label AlertLabel = ModManagerComponents.LabelContent(message, ContentAlignment.MiddleCenter, DockStyle.Bottom);
            AlertLabel.BackColor = Color.FromArgb(143, 113, 3);
            AlertLabel.Padding = new Padding(5, 5, 5, 5);

            LayoutPanel.Controls.Add(AlertLabel, 0, 0);
            return LayoutPanel;
        }

        public static TableLayoutPanel InfoLabel(string message)
        {
            TableLayoutPanel LayoutPanel = ModManagerComponents.createLayoutPanelH(0, 100, DockStyle.Bottom, new int[] { 100 });

            Label AlertLabel = ModManagerComponents.LabelContent(message, ContentAlignment.MiddleCenter, DockStyle.Bottom);
            AlertLabel.BackColor = ThemeList.theme.AppOverlayColor;
            AlertLabel.Padding = new Padding(5, 5, 5, 5);

            LayoutPanel.Controls.Add(AlertLabel, 0, 0);
            return LayoutPanel;
        }

        public static Label LabelContent(string title, ContentAlignment align, DockStyle dockstyle)
        {
            MMLabel ContentLabel = new MMLabel();
            ContentLabel.Dock = dockstyle;
            ContentLabel.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ContentLabel.AutoSize = true;
            ContentLabel.ForeColor = ThemeList.theme.TextColor;
            ContentLabel.BackColor = Color.Transparent;
            ContentLabel.TextAlign = align;
            ContentLabel.TabStop = false;
            ContentLabel.Text = title;
            return ContentLabel;
        }

        public static TableLayoutPanel OptionsLine(Button OptionButton, string title)
        {
            TableLayoutPanel t = ModManagerComponents.createLayoutPanelH(0, 50, DockStyle.Top, new int[] { 30, 70 });

            t.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            t.BackColor = ThemeList.theme.AppOverlayColor;

            Label label = ModManagerComponents.LabelContent(title, ContentAlignment.MiddleLeft, DockStyle.Fill);
            label.Text = title;
            t.Controls.Add(label, 1, 0);

            OptionButton.AutoSize = true;
            OptionButton.Dock = DockStyle.Fill;
            t.Controls.Add(OptionButton, 0, 0);

            return t;
        }

        public static TableLayoutPanel centeredTextbox(string title, TextBox textbox)
        {
            TableLayoutPanel LayoutPanel = ModManagerComponents.createLayoutPanelH(0, 100, DockStyle.Fill, new int[] { 20, 60, 20 });

            textbox.Text = "";
            textbox.Dock = DockStyle.Top;
            textbox.Size = new Size(0, 100);
            textbox.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textbox.BackColor = ThemeList.theme.TextColor;
            textbox.ForeColor = ThemeList.theme.AppBackgroundColor;
            textbox.TextAlign = HorizontalAlignment.Center;
            textbox.PlaceholderText = title;
            //textbox.TabStop = false;
            LayoutPanel.Controls.Add(textbox, 1, 0);

            return LayoutPanel;
        }

        public static TableLayoutPanel centeredButton(string title, Button button)
        {
            TableLayoutPanel LayoutPanel = ModManagerComponents.createLayoutPanelH(0, 100, DockStyle.Top, new int[] { 20, 60, 20 });

            button.Text = title;
            button.Size = new Size(0, 50);
            button.Dock = DockStyle.Top;
            LayoutPanel.Controls.Add(button, 1, 0);

            return LayoutPanel;
        }

        public static Panel ScrollHeader(string title, PictureBox left, PictureBox right)
        {
            TableLayoutPanel HeaderPanel = new TableLayoutPanel();
            HeaderPanel.BackColor = ThemeList.theme.AppOverlayColor;
            HeaderPanel.Dock = DockStyle.Top;

            HeaderPanel.ColumnCount = 3;
            HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            HeaderPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            HeaderPanel.RowCount = 1;
            HeaderPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));

            Panel TitleContainerPanel = createPanel();
            HeaderPanel.Controls.Add(TitleContainerPanel, 1, 0);

            TableLayoutPanel TitlePanel = createLayoutPanel(100);
            TitleContainerPanel.Controls.Add(TitlePanel);

            TitlePanel.Controls.Add(ModManagerComponents.LabelSubTitle(title));

            left.Image = global::ModManager6.Properties.Resources.right;
            left.Dock = DockStyle.Top;
            left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            left.TabStop = false;
            left.Margin = new Padding(0, 25, 0, 25);
            left.Hide();
            HeaderPanel.Controls.Add(left, 2, 0);

            right.Image = global::ModManager6.Properties.Resources.left;
            right.Dock = DockStyle.Top;
            right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            right.TabStop = false;
            right.Margin = new Padding(0, 25, 0, 25);
            right.Hide();
            HeaderPanel.Controls.Add(right, 0, 0);

            return HeaderPanel;
        }

        // Panels

        public static Panel createPanel()
        {
            Panel ContainerPanel = new Panel();
            ContainerPanel.Dock = DockStyle.Fill;
            ContainerPanel.AutoScroll = true;
            return ContainerPanel;
        }

        public static TableLayoutPanel createLayoutPanel(int height)
        {
            return createLayoutPanelV(0, height, DockStyle.Top, new int[] { 100 });
        }

        public static TableLayoutPanel createLayoutPanelV(int width, int height, DockStyle dockStyle, int[] rows)
        {
            TableLayoutPanel Panel = new TableLayoutPanel();
            Panel.Size = new Size(width, height);
            Panel.Dock = dockStyle;

            Panel.ColumnCount = 1;
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Panel.RowCount = rows.Count();
            foreach (int row in rows)
            {
                Panel.RowStyles.Add(new RowStyle(SizeType.Percent, row));
            }
            return Panel;
        }

        public static TableLayoutPanel createLayoutPanelH(int width, int height, DockStyle dockStyle, int[] columns)
        {
            TableLayoutPanel Panel = new TableLayoutPanel();
            Panel.Size = new Size(width, height);
            Panel.Dock = dockStyle;

            Panel.ColumnCount = columns.Count();
            foreach (int column in columns)
            {
                Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, column));
            }
            Panel.RowCount = 1;
            Panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            return Panel;
        }

        public static TableLayoutPanel SettingsCombobox(ComboBox combobox, string title, List<string> options, string defaut)
        {
            TableLayoutPanel t = ModManagerComponents.createLayoutPanelH(0, 50, DockStyle.Top, new int[] { 30, 70 });

            t.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            t.BackColor = ThemeList.theme.AppOverlayColor;

            Label label = ModManagerComponents.LabelContent(title, ContentAlignment.MiddleLeft, DockStyle.Fill);
            t.Controls.Add(label, 0, 0);

            combobox.Dock = DockStyle.Left;

            foreach (string option in options)
            {
                combobox.Items.Add(option);
            }
            combobox.SelectedItem = defaut;

            t.Controls.Add(combobox, 1, 0);

            return t;
        }

        public static TableLayoutPanel SettingsButton(Button button, string title)
        {
            TableLayoutPanel t = ModManagerComponents.createLayoutPanelH(0, 50, DockStyle.Top, new int[] { 30, 70 });

            t.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            t.BackColor = ThemeList.theme.AppOverlayColor;

            Label label = ModManagerComponents.LabelContent(title, ContentAlignment.MiddleLeft, DockStyle.Fill);
            t.Controls.Add(label, 0, 0);

            button.Text = title;
            button.AutoSize = true;
            button.Dock = DockStyle.Fill;
            button.TextAlign = ContentAlignment.MiddleLeft;


            t.Controls.Add(button, 1, 0);

            return t;
        }

        public static TableLayoutPanel SettingsCheckbox(CheckBox checkbox, string title)
        {
            TableLayoutPanel t = ModManagerComponents.createLayoutPanelH(0, 50, DockStyle.Top, new int[] { 30, 70 });

            t.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            t.BackColor = ThemeList.theme.AppOverlayColor;

            Label label = ModManagerComponents.LabelContent(title, ContentAlignment.MiddleLeft, DockStyle.Fill);
            t.Controls.Add(label, 0, 0);

            checkbox.Dock = DockStyle.Left;

            t.Controls.Add(checkbox, 1, 0);

            return t;
        }

        public static void ServerLine(TableLayoutPanel panel, int y, Server server, TextBox ServerName, TextBox ServerIP, TextBox ServerPort, PictureBox ServerValidPic, PictureBox ServerRemovePic, bool official, bool last)
        {
            ServerName.Text = server.name;
            ServerName.Dock = DockStyle.Bottom;
            ServerName.Size = new Size(0, 100);
            ServerName.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerName.BackColor = ThemeList.theme.AppBackgroundColor;
            ServerName.ForeColor = ThemeList.theme.TextColor;
            ServerName.TextAlign = HorizontalAlignment.Left;
            ServerName.Margin = new System.Windows.Forms.Padding(20, 10, 0, 0);
            ServerName.BorderStyle = BorderStyle.None;
            if (official)
                ServerName.Enabled = false;
            panel.Controls.Add(ServerName, 0, y);

            ServerIP.Text = server.DefaultIp;
            ServerIP.Dock = DockStyle.Bottom;
            ServerIP.Size = new Size(0, 100);
            ServerIP.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerIP.BackColor = ThemeList.theme.AppBackgroundColor;
            ServerIP.ForeColor = ThemeList.theme.TextColor;
            ServerIP.TextAlign = HorizontalAlignment.Left;
            ServerIP.Margin = new System.Windows.Forms.Padding(20, 10, 0, 0);
            ServerIP.BorderStyle = BorderStyle.None;
            if (official)
                ServerIP.Enabled = false;
            panel.Controls.Add(ServerIP, 1, y);

            ServerPort.Dock = DockStyle.Bottom;
            ServerPort.Size = new Size(0, 100);
            ServerPort.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerPort.BackColor = ThemeList.theme.AppBackgroundColor;
            ServerPort.ForeColor = ThemeList.theme.TextColor;
            ServerPort.TextAlign = HorizontalAlignment.Left;
            ServerPort.Margin = new System.Windows.Forms.Padding(20, 10, 0, 0);
            ServerPort.Text = server.port.ToString();
            ServerPort.BorderStyle = BorderStyle.None;
            if (official)
                ServerPort.Enabled = false;
            panel.Controls.Add(ServerPort, 2, y);

            ServerValidPic.Image = global::ModManager6.Properties.Resources.valid;
            ServerValidPic.BackColor = ThemeList.theme.AppBackgroundColor;
            ServerValidPic.ForeColor = ThemeList.theme.TextColor;
            ServerValidPic.Dock = DockStyle.Top;
            ServerValidPic.Size = new Size(0, 80);
            ServerValidPic.Margin = new Padding(10, 10, 10, 10);
            ServerValidPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ServerValidPic.TabStop = false;
            ServerValidPic.Hide();
            if (official)
            {
                ServerValidPic.Enabled = false;
            }
            else
            {
                ServerValidPic.Cursor = Cursors.Hand;
            }
            panel.Controls.Add(ServerValidPic, 3, y);

            if (last)
            {
                ServerRemovePic.Image = global::ModManager6.Properties.Resources.add;
            }
            else
            {
                ServerRemovePic.Image = global::ModManager6.Properties.Resources.delete;
            }
            ServerRemovePic.BackColor = ThemeList.theme.AppBackgroundColor;
            ServerRemovePic.ForeColor = ThemeList.theme.TextColor;
            ServerRemovePic.Dock = DockStyle.Top;
            ServerRemovePic.Size = new Size(0, 80);
            ServerRemovePic.Margin = new Padding(10, 10, 10, 10);
            ServerRemovePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ServerRemovePic.TabStop = false;
            if (official)
            {
                ServerRemovePic.Enabled = false;
                ServerRemovePic.Hide();
            }
            else
            {
                ServerRemovePic.Cursor = Cursors.Hand;
            }
            panel.Controls.Add(ServerRemovePic, 4, y);

        }

        public static void TranslationLine(TableLayoutPanel panel, int y, Translation t, Label ori, TextBox tr, PictureBox valid)
        {
            ori.Text = t.original;
            ori.Dock = DockStyle.Bottom;
            ori.Size = new Size(0, 100);
            ori.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ori.BackColor = ThemeList.theme.AppBackgroundColor;
            ori.ForeColor = ThemeList.theme.TextColor;
            ori.Margin = new System.Windows.Forms.Padding(20, 10, 0, 0);
            ori.BorderStyle = BorderStyle.None;
            panel.Controls.Add(ori, 0, y);

            tr.Text = t.translation;
            tr.Dock = DockStyle.Bottom;
            tr.Size = new Size(0, 100);
            tr.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tr.BackColor = ThemeList.theme.TextColor;
            tr.Multiline = true;
            tr.Margin = new Padding(20, 10, 0, 10);
            tr.ForeColor = ThemeList.theme.AppBackgroundColor;
            tr.TextAlign = HorizontalAlignment.Left;
            panel.Controls.Add(tr, 1, y);

            valid.Image = global::ModManager6.Properties.Resources.valid;
            valid.BackColor = ThemeList.theme.AppBackgroundColor;
            valid.ForeColor = ThemeList.theme.TextColor;
            valid.Dock = DockStyle.Bottom;
            valid.Size = new Size(0, 80);
            valid.Margin = new Padding(10, 10, 10, 10);
            valid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            valid.TabStop = false;
            valid.Hide();
            valid.Cursor = Cursors.Hand;
            panel.Controls.Add(valid, 3, y);
        }

        public static TableLayoutPanel ModsOverlay()
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.BackColor = Color.FromArgb(21, 23, 36);

            panel.ColumnCount = 10;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Flags
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Name
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Author
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F)); // Version
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F)); // Game Version
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Favorites
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Discord
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Download / Start
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Uninstall
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F)); // Arrows

            panel.RowCount = 1;
            panel.Size = new System.Drawing.Size(100, 50);
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            System.Windows.Forms.Label ModTitleGameVersion = new System.Windows.Forms.Label();
            ModTitleGameVersion.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleGameVersion.BackColor = Color.Transparent;
            ModTitleGameVersion.ForeColor = SystemColors.Control;
            ModTitleGameVersion.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleGameVersion.Dock = DockStyle.Left;
            ModTitleGameVersion.Name = "ModTitleGameVersion";
            ModTitleGameVersion.Padding = new Padding(12, 0, 0, 0);
            ModTitleGameVersion.Size = new System.Drawing.Size(150, 50);
            ModTitleGameVersion.Text = Translator.get("Game Version");
            panel.Controls.Add(ModTitleGameVersion, 4, 0);

            System.Windows.Forms.Label ModTitleVersion = new System.Windows.Forms.Label();
            ModTitleVersion.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleVersion.BackColor = Color.Transparent;
            ModTitleVersion.ForeColor = SystemColors.Control;
            ModTitleVersion.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleVersion.Dock = DockStyle.Left;
            ModTitleVersion.Name = "ModTitleVersion";
            ModTitleVersion.Padding = new Padding(12, 0, 0, 0);
            ModTitleVersion.Size = new System.Drawing.Size(150, 50);
            ModTitleVersion.Text = Translator.get("Version");
            panel.Controls.Add(ModTitleVersion, 3, 0);

            System.Windows.Forms.Label ModTitleAuthor = new System.Windows.Forms.Label();
            ModTitleAuthor.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleAuthor.BackColor = Color.Transparent;
            ModTitleAuthor.ForeColor = SystemColors.Control;
            ModTitleAuthor.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleAuthor.Dock = DockStyle.Left;
            ModTitleAuthor.Name = "ModTitleAuthor";
            ModTitleAuthor.Padding = new Padding(12, 0, 0, 0);
            ModTitleAuthor.Size = new System.Drawing.Size(250, 50);
            ModTitleAuthor.Text = Translator.get("Author");
            panel.Controls.Add(ModTitleAuthor, 2, 0);

            System.Windows.Forms.Label ModTitleTitle = new System.Windows.Forms.Label();
            ModTitleTitle.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ModTitleTitle.BackColor = Color.Transparent;
            ModTitleTitle.ForeColor = SystemColors.Control;
            ModTitleTitle.TextAlign = ContentAlignment.MiddleLeft;
            ModTitleTitle.Dock = DockStyle.Left;
            ModTitleTitle.Name = "ModTitleTitle";
            ModTitleTitle.Padding = new Padding(12, 0, 0, 0);
            ModTitleTitle.Size = new System.Drawing.Size(250, 50);
            ModTitleTitle.Text = Translator.get("Name");
            panel.Controls.Add(ModTitleTitle, 1, 0);

            return panel;
        }

        public static TableLayoutPanel TranslationsOverlay()
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.BackColor = ThemeList.theme.AppOverlayColor;

            panel.ColumnCount = 3;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            panel.RowCount = 1;
            panel.Size = new System.Drawing.Size(100, 50);
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));


            System.Windows.Forms.Label TranslationOri = new System.Windows.Forms.Label();
            TranslationOri.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TranslationOri.BackColor = Color.Transparent;
            TranslationOri.ForeColor = SystemColors.Control;
            TranslationOri.TextAlign = ContentAlignment.MiddleLeft;
            TranslationOri.Dock = DockStyle.Left;
            TranslationOri.Name = "TranslationOri";
            TranslationOri.Padding = new Padding(12, 0, 0, 0);
            TranslationOri.AutoSize = true;
            TranslationOri.Text = Translator.get("Original Text");
            panel.Controls.Add(TranslationOri, 0, 0);

            System.Windows.Forms.Label TranslationNew = new System.Windows.Forms.Label();
            TranslationNew.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TranslationNew.BackColor = Color.Transparent;
            TranslationNew.ForeColor = SystemColors.Control;
            TranslationNew.TextAlign = ContentAlignment.MiddleLeft;
            TranslationNew.Dock = DockStyle.Left;
            TranslationNew.Name = "TranslationNew";
            TranslationNew.Padding = new Padding(12, 0, 0, 0);
            TranslationNew.AutoSize = true;
            TranslationNew.Text = Translator.get("Translated Text");
            panel.Controls.Add(TranslationNew, 1, 0);

            return panel;
        }

        public static TableLayoutPanel ServersOverlay()
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.BackColor = ThemeList.theme.AppOverlayColor;

            panel.ColumnCount = 5;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            panel.RowCount = 1;
            panel.Size = new System.Drawing.Size(100, 50);
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            System.Windows.Forms.Label ServerPort = new System.Windows.Forms.Label();
            ServerPort.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerPort.BackColor = Color.Transparent;
            ServerPort.ForeColor = SystemColors.Control;
            ServerPort.TextAlign = ContentAlignment.MiddleLeft;
            ServerPort.Dock = DockStyle.Left;
            ServerPort.Name = "ServerPort";
            ServerPort.Size = new System.Drawing.Size(150, 50);
            ServerPort.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            ServerPort.Text = Translator.get("Port");
            panel.Controls.Add(ServerPort, 2, 0);

            System.Windows.Forms.Label ServerIP = new System.Windows.Forms.Label();
            ServerIP.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerIP.BackColor = Color.Transparent;
            ServerIP.ForeColor = SystemColors.Control;
            ServerIP.TextAlign = ContentAlignment.MiddleLeft;
            ServerIP.Dock = DockStyle.Left;
            ServerIP.Name = "ServerIP";
            ServerIP.Size = new System.Drawing.Size(250, 50);
            ServerIP.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            ServerIP.Text = Translator.get("IP");
            panel.Controls.Add(ServerIP, 1, 0);

            System.Windows.Forms.Label ServerName = new System.Windows.Forms.Label();
            ServerName.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ServerName.BackColor = Color.Transparent;
            ServerName.ForeColor = SystemColors.Control;
            ServerName.TextAlign = ContentAlignment.MiddleLeft;
            ServerName.Dock = DockStyle.Left;
            ServerName.Name = "ServerName";
            ServerName.Size = new System.Drawing.Size(250, 50);
            ServerName.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            ServerName.Text = Translator.get("Name");
            panel.Controls.Add(ServerName, 0, 0);

            return panel;
        }

        public static PictureBox BottomLeftPict(Image img)
        {
            PictureBox pb = new PictureBox();
            pb.Cursor = System.Windows.Forms.Cursors.Hand;
            pb.Dock = System.Windows.Forms.DockStyle.Left;
            pb.Image = img;
            pb.Location = new System.Drawing.Point(163, 0);
            pb.Margin = new System.Windows.Forms.Padding(0);
            pb.Size = new System.Drawing.Size(40, 30);
            pb.Padding = new Padding(5, 0, 5, 0);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.TabStop = false;

            return pb;
        }

        public static PictureBox ModPic(string name, Bitmap img)
        {
            PictureBox Picture = new PictureBox();
            Picture.Cursor = System.Windows.Forms.Cursors.Hand;
            Picture.Dock = DockStyle.Fill;
            Picture.Image = img;
            Picture.Margin = new System.Windows.Forms.Padding(0);
            Picture.Name = name;
            Picture.Size = new System.Drawing.Size(60, 50);
            Picture.Padding = new Padding(15, 10, 15, 10);
            Picture.Margin = new Padding(10, 10, 10, 10);
            Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Picture.TabStop = false;

            return Picture;
        }
        public static Label ModLabel(string name, string text)
        {
            Label Label = new System.Windows.Forms.Label();
            Label.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label.BackColor = Color.Transparent;
            Label.ForeColor = SystemColors.Control;
            Label.TextAlign = ContentAlignment.MiddleLeft;
            Label.Dock = DockStyle.Left;
            Label.Name = name;
            Label.Text = text;
            Label.Padding = new Padding(12, 0, 0, 0);
            Label.Size = new System.Drawing.Size(150, 50);
            Label.TabStop = false;

            return Label;
        }

        public static LinkLabel ModLinkLabel(string name, string text)
        {
            LinkLabel LinkLabel = new LinkLabel();
            LinkLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LinkLabel.LinkColor = SystemColors.Control;
            LinkLabel.ForeColor = SystemColors.Control;
            LinkLabel.TextAlign = ContentAlignment.MiddleLeft;
            LinkLabel.Dock = DockStyle.Left;
            LinkLabel.Name = name;
            LinkLabel.Padding = new Padding(12, 0, 0, 0);
            LinkLabel.Size = new System.Drawing.Size(250, 50);
            LinkLabel.Text = text;
            LinkLabel.TabStop = false;

            return LinkLabel;
        }

        public static Panel MenuPanel(string name, string text, Image img)
        {
            Panel p = new Panel();
            p.BackColor = ThemeList.theme.MenuButtonsColor;
            p.Dock = System.Windows.Forms.DockStyle.Top;
            p.Margin = new System.Windows.Forms.Padding(0);
            p.Name = name;
            p.Cursor = System.Windows.Forms.Cursors.Hand;
            p.Size = new System.Drawing.Size(300, 50);

            PictureBox pb = new PictureBox();
            pb.Cursor = System.Windows.Forms.Cursors.Hand;
            pb.Dock = System.Windows.Forms.DockStyle.Left;
            pb.Image = img;
            pb.Location = new System.Drawing.Point(163, 0);
            pb.Margin = new System.Windows.Forms.Padding(0);
            pb.Size = new System.Drawing.Size(50, 50);
            pb.Padding = new Padding(10);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.TabStop = false;

            Button b = new Button();
            b.BackColor = ThemeList.theme.MenuButtonsColor;
            b.Cursor = System.Windows.Forms.Cursors.Hand;
            b.Dock = System.Windows.Forms.DockStyle.Left;
            b.FlatAppearance.BorderSize = 0;
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            b.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            b.ForeColor = ThemeList.theme.TextColor;
            b.Location = new System.Drawing.Point(0, 405);
            b.Margin = new System.Windows.Forms.Padding(0);
            b.Name = "SettingsMenuButton";
            b.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            b.Size = new System.Drawing.Size(250, 50);
            b.Text = Translator.get(text);
            b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            b.UseVisualStyleBackColor = false;
            b.TabStop = false;


            p.Controls.Add(b);
            p.Controls.Add(pb);

            return p;
        }
    }
}
