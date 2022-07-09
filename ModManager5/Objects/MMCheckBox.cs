using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Objects
{
    public class MMCheckBox : CheckBox
    {
        public MMCheckBox()
        {
            this.ForeColor = Color.Red;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);

            pevent.Graphics.Clear(BackColor);

            using (SolidBrush brush = new SolidBrush(ForeColor))
                pevent.Graphics.DrawString(Text, Font, brush, 27, 4);

            Point pt = new Point(4, 4);
            Rectangle rect = new Rectangle(pt, new Size(16, 16));

            pevent.Graphics.FillRectangle(Brushes.Beige, rect);

            if (Checked)
            {
                using (SolidBrush brush = new SolidBrush(Color.Red))
                using (Font wing = new Font("Wingdings", 12f))
                    pevent.Graphics.DrawString("ü", wing, brush, 1, 2);
            }
            pevent.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect);

            Rectangle fRect = ClientRectangle;

            if (Focused)
            {
                fRect.Inflate(-1, -1);
                using (Pen pen = new Pen(Brushes.Gray) { DashStyle = DashStyle.Dot })
                    pevent.Graphics.DrawRectangle(pen, fRect);
            }
        }
    }
}
