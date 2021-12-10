using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class ContextMenu
    {
        public static NotifyIcon notifyIcon;
        private static ModManager modManager;

        public static void init(ModManager modmanager)
        {
            modManager = modmanager;
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = global::ModManager5.Properties.Resources.modmanager;
            notifyIcon.Text = "Mod Manager";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += mouseEvent;
            modManager.Resize += new EventHandler(onResize);
            Application.ApplicationExit += new EventHandler(exit);
        }

        public static void load()
        {
            notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            if (ServerConfig.get("enabled").value == "true")
            {
                notifyIcon.ContextMenuStrip.Items.Add("Mod Manager", null, open);

                notifyIcon.ContextMenuStrip.Items.Add("-");

                List<InstalledMod> im = ConfigManager.config.installedMods;
                
                notifyIcon.ContextMenuStrip.Items.Add("Vanilla Among Us", null, startVanilla);

                foreach (InstalledMod i in im)
                {
                    Mod m = ModList.getModById(i.id);
                    notifyIcon.ContextMenuStrip.Items.Add(m.name, null, new EventHandler((object sender, EventArgs e) => {
                        Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Among Us.exe");
                    }));
                }
                
                notifyIcon.ContextMenuStrip.Items.Add("-");

                notifyIcon.ContextMenuStrip.Items.Add("Settings", null, settings);
            }

            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, exit);
        }
        private static void mouseEvent(object Sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                if (modManager.WindowState == FormWindowState.Minimized)
                {
                    modManager.WindowState = FormWindowState.Normal;
                }
            }
        }

        public static void onResize(object sender, EventArgs e)
        {
            if (modManager.WindowState == FormWindowState.Minimized)
            {
                modManager.ShowInTaskbar = false;
            }
            else if (modManager.WindowState == FormWindowState.Normal)
            {
                modManager.ShowInTaskbar = true;
            }
        }

        private static void open(object sender, EventArgs e)
        {
            if (modManager.WindowState == FormWindowState.Minimized)
                modManager.WindowState = FormWindowState.Normal;

            modManager.Activate();
        }

        private static void startVanilla(object sender, EventArgs e)
        {
            ModWorker.startVanilla();
        }

        private static void settings(object sender, EventArgs e)
        {
            ModManagerUI.openForm(ModManagerUI.SettingsForm);
            if (modManager.WindowState == FormWindowState.Minimized)
                modManager.WindowState = FormWindowState.Normal;
            modManager.Activate();
        }

        private static void exit(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}
