using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class MMCheckbox : CheckBox
    {
        public ModManager modManager;

        public MMCheckbox(ModManager modManager)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.modManager = modManager;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {

            double ratioX = (double)this.modManager.config.resolutionX / 1300.0;
            double ratioY = (double)this.modManager.config.resolutionY / 810.0;

            int width = (int)(15 * ratioX);
            int height = (int)(15 * ratioY);

            base.OnPaint(pevent);

            if (this.Checked)
            {
                Bitmap bmp = new Bitmap(global::ModManager4.Properties.Resources._checked, new Size(width, height));
                pevent.Graphics.Clear(Color.Black);
                pevent.Graphics.FillRectangle(new TextureBrush(bmp), new Rectangle(0, 0, width, height));
            }
            else
            {
                Bitmap bmp = new Bitmap(global::ModManager4.Properties.Resources._unchecked, new Size(width, height));
                pevent.Graphics.Clear(Color.Black);
                pevent.Graphics.FillRectangle(new TextureBrush(bmp), new Rectangle(0, 0, (int)(15 * ratioX), (int)(15 * ratioY)));
            }
        }
    }
}
