using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Component
    {
        public string name;

        public List<Control> controls;

        public Component(string name)
        {
            this.name = name;
            this.controls = new List<Control>();
        }

        public void addControl(Control c)
        {
            this.controls.Add(c);
        }

        public void show()
        {
            foreach (Control c in this.controls)
            {
                if (c is Panel)
                {
                    c.Show();
                    foreach (Control subC in c.Controls)
                    {
                        subC.Show();
                    } 
                } else
                {
                    c.Show();
                }
            }
        }

        public Control getControl(string name)
        {
            foreach (Control c in this.controls)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }
            return null;
        }

        public void hide()
        {
            foreach (Control c in this.controls)
            {
                if (c is Panel)
                {
                    c.Hide();
                    foreach (Control subC in c.Controls)
                    {
                        subC.Hide();
                    }
                }
                else
                {
                    c.Hide();
                }
            }
        }

        public void removeControls()
        {
            this.controls = new List<Control>();
        }
    }
}
