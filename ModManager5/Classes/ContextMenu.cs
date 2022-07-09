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
            Utils.log("Init START", "ContextMenu");
            modManager = modmanager;
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = global::ModManager5.Properties.Resources.modmanager;
            notifyIcon.Text = "Mod Manager";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += mouseEvent;
            modManager.Resize += new EventHandler(onResize);
            Application.ApplicationExit += new EventHandler(exit);
            Utils.log("Init END", "ContextMenu");
        }

        public static void load()
        {
            Utils.log("Load START", "ContextMenu");
            notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            if (ServerConfig.get("enabled").value == "true")
            {
                notifyIcon.ContextMenuStrip.Items.Add("Mod Manager", null, open);

                notifyIcon.ContextMenuStrip.Items.Add("-");

                List<InstalledMod> im = ConfigManager.config.installedMods;
                
                notifyIcon.ContextMenuStrip.Items.Add("Vanilla Among Us", null, startGame);

                Utils.log("Loading " + im.Count() + " mods", "ContextMenu");
                foreach (InstalledMod i in im)
                {
                    Mod m = ModList.getModById(i.id);
                    if (m != null)
                    {
                        notifyIcon.ContextMenuStrip.Items.Add(m.name, null, new EventHandler((object sender, EventArgs e) => {
                            Process.Start("explorer", ModManager.appDataPath + @"\mods\" + m.id + @"\Among Us.exe");
                        }));
                    }
                    
                }
                
                notifyIcon.ContextMenuStrip.Items.Add("-");

                notifyIcon.ContextMenuStrip.Items.Add("Settings", null, settings);
            }

            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, exit);
            Utils.log("Load END", "ContextMenu");
        }
        private static void mouseEvent(object Sender, MouseEventArgs e)
        {
            Utils.log("Click START", "ContextMenu");
            if (e.Button != MouseButtons.Right)
            {
                Utils.log("Click YES", "ContextMenu");
                if (modManager.WindowState == FormWindowState.Minimized)
                {
                    Utils.log("Maximize window", "ContextMenu");
                    modManager.WindowState = FormWindowState.Normal;
                }
            }
            Utils.log("Load END", "ContextMenu");
        }

        public static void onResize(object sender, EventArgs e)
        {
            if (ConfigManager.config.miniEnabled)
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
            
        }

        private static void open(object sender, EventArgs e)
        {
            Utils.log("Open START", "ContextMenu");
            if (modManager.WindowState == FormWindowState.Minimized)
                modManager.WindowState = FormWindowState.Normal;

            modManager.Activate();
            Utils.log("Open END", "ContextMenu");
        }

        private static void startGame(object sender, EventArgs e)
        {
            Utils.log("Start Game START", "ContextMenu");
            ModWorker.startGame();
            Utils.log("Start Game END", "ContextMenu");
        }

        private static void settings(object sender, EventArgs e)
        {
            Utils.log("Settings START", "ContextMenu");
            ModManagerUI.openForm(ModManagerUI.SettingsForm);
            if (modManager.WindowState == FormWindowState.Minimized)
                modManager.WindowState = FormWindowState.Normal;
            modManager.Activate();
            Utils.log("Start Game END", "ContextMenu");
        }

        private static void exit(object sender, EventArgs e)
        {
            Utils.log("Exit", "ContextMenu");
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}
