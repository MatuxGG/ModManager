using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using ModManager5.Classes;

namespace ModManager5.Objects
{
    public class MMButton : Button
    {
        private int borderSize = 0;
        private int borderRadius = 20;
        private Color borderColor = Color.LightCoral;
        private string style;

        public MMButton(string style)
        {
            this.style = style;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = Color.White;
            this.Padding = new Padding(10, 0, 10, 0);

            this.Font = new Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = ThemeList.theme.ButtonsColor;
            this.TextAlign = ContentAlignment.MiddleCenter;
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (this.style == "rounded")
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
                RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

                if (borderRadius > 2)
                {
                    using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                    using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius))
                    using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        this.Region = new Region(pathSurface);
                        pevent.Graphics.DrawPath(penSurface, pathSurface);
                        if (borderSize >= 1)
                        {
                            pevent.Graphics.DrawPath(penBorder, pathBorder);
                        }
                    }
                }
                else
                {
                    this.Region = new Region(rectSurface);
                    if (borderSize >= 1)
                    {
                        using (Pen penBorder = new Pen(borderColor, borderSize))
                        {
                            penBorder.Alignment = PenAlignment.Inset;
                            pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                        }
                    }

                }
            }
            
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}
