using ModManager6.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Objects
{
    public class MMListBox : ListBox
    {
        public MMListBox()
        {
            this.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectionMode = SelectionMode.MultiExtended;
            this.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);

            this.DrawMode = DrawMode.OwnerDrawVariable;
            this.BackColor = ThemeList.theme.AppOverlayColor;
            this.ForeColor = ThemeList.theme.TextColor;
            this.MeasureItem += new MeasureItemEventHandler((object sender, MeasureItemEventArgs e) =>
            {
                ListBox listBox = (ListBox)sender;
                e.ItemHeight = listBox.Font.Height;
            });
            this.DrawItem += new DrawItemEventHandler((object sender, DrawItemEventArgs e) =>
            {
                if (e.Index < 0) return;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    e = new DrawItemEventArgs(e.Graphics,
                                              e.Font,
                                              e.Bounds,
                                              e.Index,
                                              e.State ^ DrawItemState.Selected,
                                              ThemeList.theme.TextColor,
                                              ThemeList.theme.SelectionColor);//Choose the color
                
                // Draw the background of the ListBox control for each item.
                e.DrawBackground();
                // Draw the current item text
                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
                // If the ListBox has focus, draw a focus rectangle around the selected item.
                e.DrawFocusRectangle();
            });
        }
    }
}
