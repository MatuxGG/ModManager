using System.Collections.Generic;

using System.Windows.Forms;

namespace ModManager
{
    internal class Page
    {
        public string name;

        public List<Control> controls;

        public Page(string name)
        {
            this.name = name;
            this.controls = new List<Control>();
        }

        public void addControl(Control c)
        {
            this.controls.Add(c);
        }

        public void show(bool isNewMod)
        {
            foreach (Control c in this.controls)
            {
                if (c.Name == "UpdateFilesLabel" || c.Name == "UpdateFilesButton")
                {
                    if (isNewMod)
                    {
                        c.Show();
                    } else
                    {
                        c.Hide();
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
                c.Hide();
            }
        }
    }
}