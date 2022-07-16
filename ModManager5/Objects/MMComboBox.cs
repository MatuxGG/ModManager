using ModManager5.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Objects
{
    public class MMComboBox : ComboBox
    {
        public MMComboBox()
        {
            this.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BackColor = ThemeList.theme.AppOverlayColor;
            this.ForeColor = ThemeList.theme.TextColor;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.FlatStyle = FlatStyle.Flat;
            this.DrawItem += new DrawItemEventHandler((object sender, DrawItemEventArgs e) => {
                int index = e.Index >= 0 ? e.Index : 0;
                SolidBrush brush = new SolidBrush(ThemeList.theme.TextColor);
                e.DrawBackground();
                e.Graphics.DrawString(((ComboBox)sender).Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            });
            this.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);

            this.DrawItem += new DrawItemEventHandler((object sender, DrawItemEventArgs e) =>
            {
                    ComboBox box = ((ComboBox)sender);
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(ThemeList.theme.SelectionColor), e.Bounds);
                    }

                    else { e.Graphics.FillRectangle(new SolidBrush(box.BackColor), e.Bounds); }

                    e.Graphics.DrawString(box.Items[e.Index].ToString(),
                         e.Font, new SolidBrush(box.ForeColor),
                         new Point(e.Bounds.X, e.Bounds.Y));
                    e.DrawFocusRectangle();

            });
        }

        public int getAutoWidth()
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in this.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), this.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            double supMaxWidth = (double)(maxWidth + 25);
            return (int) (25 * Math.Ceiling(supMaxWidth / 25));
        }

    }
}
