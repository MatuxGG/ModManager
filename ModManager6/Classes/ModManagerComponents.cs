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
    }
}
