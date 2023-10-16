using ModManager6.Classes;
using ModManager6.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Forms
{
    public partial class AlertBox : Form
    {
        public AlertBox()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private AlertBox.enmAction action;
        private int x, y;

        private void alertBoxTimer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    alertBoxTimer.Interval = 5000;
                    action = enmAction.close;
                    break;
                case AlertBox.enmAction.start:
                    this.alertBoxTimer.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = AlertBox.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    alertBoxTimer.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void AlertBoxLabel_Click(object sender, EventArgs e)
        {
            alertBoxTimer.Interval = 1;
            this.Opacity -= 0.1;

            this.Left -= 3;
            if (base.Opacity == 0.0)
            {
                base.Close();
            }
        }

        public void showAlert(string msg, bool success = true) // , enmType type
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                AlertBox frm = (AlertBox)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            if (success)
            {
                AlertBoxLabel.BackColor = ThemeList.theme.AppBackgroundColor;
            } else
            {
                AlertBoxLabel.BackColor = Color.DarkRed;
            }

            //switch (type)
            //{
            //    case enmType.Success:
            //        this.AlertBoxPict.Image = Resources.valid;
            //        this.BackColor = Color.SeaGreen;
            //        break;
            //    case enmType.Error:
            //        this.AlertBoxPict.Image = Resources.cross;
            //        this.BackColor = Color.DarkRed;
            //        break;
            //    case enmType.Info:
            //        this.AlertBoxPict.Image = Resources.info;
            //        this.BackColor = Color.RoyalBlue;
            //        break;
            //    case enmType.Warning:
            //        this.AlertBoxPict.Image = Resources.warn;
            //        this.BackColor = Color.DarkOrange;
            //        break;
            //}

            this.AlertBoxLabel.Text = msg;
            this.AlertBoxLabel.Font = new System.Drawing.Font(ThemeList.theme.XLFont, ThemeList.theme.XLSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.Show();
            this.action = enmAction.start;
            this.alertBoxTimer.Interval = 1;
            this.alertBoxTimer.Start();
            this.Activate();
        }
    }
}
