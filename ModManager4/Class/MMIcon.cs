using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class MMIcon
    {
        public ModManager modManager;

        public NotifyIcon notifyIcon;

        public MMIcon(ModManager modManager)
        {
            this.modManager = modManager;
            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.Icon = global::ModManager4.Properties.Resources.modmanager;
            this.notifyIcon.Text = "Mod Manager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += this.mouseEvent;
            this.modManager.Resize += new EventHandler(this.onResize);
            this.load();
        }

        public void load()
        {
            this.notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            if (this.modManager.serverConfig.get("enabled").value == "true")
            {
                this.notifyIcon.ContextMenuStrip.Items.Add("Open Mod Manager", null, this.open);

                this.notifyIcon.ContextMenuStrip.Items.Add("-");

                List<InstalledMod> im = this.modManager.config.getInstalledModsWithoutAllInOne(this.modManager);

                if (im.Count() > 0)
                {
                    this.notifyIcon.ContextMenuStrip.Items.Add("Start Vanilla Among Us", null, this.startVanilla);

                    string text = "Start Modded Among Us (";
                    foreach (InstalledMod i in im)
                    {
                        Mod m = this.modManager.modlist.getModById(i.id);
                        text = text + m.name + ", ";
                    }
                    text = text.Substring(0, text.Length - 2);
                    text = text + ")";
                    this.notifyIcon.ContextMenuStrip.Items.Add(text, null, this.start);
                }
                else
                {
                    this.notifyIcon.ContextMenuStrip.Items.Add("Start Vanilla Among Us", null, this.start);
                }

                this.notifyIcon.ContextMenuStrip.Items.Add("-");

                object objBcl = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                if (this.modManager.config.containsMod("BetterCrewlink") || (objBcl != null && System.IO.File.Exists(objBcl.ToString() + "\\Better-CrewLink.exe")))
                {
                    this.notifyIcon.ContextMenuStrip.Items.Add("Start Better Crewlink", null, this.startBetterCrewlink);
                }
                else
                {
                    this.notifyIcon.ContextMenuStrip.Items.Add("Install Better Crewlink", null, this.installBetterCrewlink);
                }

                if (this.modManager.config.containsMod("Challenger"))
                {
                    if (this.modManager.config.getInstalledModById("Challenger").version != this.modManager.modlist.challengerMod.TagName)
                    {
                        this.notifyIcon.ContextMenuStrip.Items.Add("Update Challenger", null, this.updateChallenger);
                    }
                    else
                    {
                        this.notifyIcon.ContextMenuStrip.Items.Add("Start Challenger", null, this.startChallenger);
                    }
                }
                else
                {
                    this.notifyIcon.ContextMenuStrip.Items.Add("Install Challenger", null, this.updateChallenger);
                }

                if (this.modManager.config.containsMod("Skeld"))
                {
                    this.notifyIcon.ContextMenuStrip.Items.Add("Start Skeld.net", null, this.startSkeld);
                }
                else
                {
                    this.notifyIcon.ContextMenuStrip.Items.Add("Install Skeld.net", null, this.installSkeld);
                }

                this.notifyIcon.ContextMenuStrip.Items.Add("-");

                this.notifyIcon.ContextMenuStrip.Items.Add("Settings", null, this.settings);
            }
            
            this.notifyIcon.ContextMenuStrip.Items.Add("Exit", null, this.exit);
        }

        public void onResize(object sender, EventArgs e)
        {
            if (this.modManager.WindowState == FormWindowState.Minimized)
            {
                this.modManager.ShowInTaskbar = false;
            } else if (this.modManager.WindowState == FormWindowState.Normal)
            {
                this.modManager.ShowInTaskbar = true;
            }
        }

        private void mouseEvent(object Sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                if (this.modManager.WindowState == FormWindowState.Minimized)
                {
                    this.modManager.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void open(object sender, EventArgs e)
        {
            if (this.modManager.WindowState == FormWindowState.Minimized)
                this.modManager.WindowState = FormWindowState.Normal;

        }

        private void start(object sender, EventArgs e)
        {
            this.modManager.componentlist.events.startGame();
        }

        private void startVanilla(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                this.modManager.logs.log("- Among Us running\n");
                if (MessageBox.Show("Can't switch to Vanilla Among Us while Among Us is running", "Can't uninstall mods", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    return;
                }
            }

            this.modManager.modWorker.uninstallMods();
            this.modManager.modlist.resetChanged();
            this.modManager.modlist.setCode();
            this.modManager.componentlist.refreshModSelection();
            this.modManager.pagelist.renderPage("ModSelection");
            this.modManager.logs.log("- Uninstall all mods completed\n");
            this.modManager.componentlist.events.startGame();
        }

        private void startChallenger(object sender, EventArgs e)
        {
            Mod m = this.modManager.modlist.getAvailableModById("Challenger");
            this.modManager.componentlist.events.startAllInOneMod(m);
        }

        private void updateChallenger(object sender, EventArgs e)
        {
            if (this.modManager.WindowState == FormWindowState.Minimized)
                this.modManager.WindowState = FormWindowState.Normal;

            this.modManager.Activate();

            Mod m = this.modManager.modlist.getAvailableModById("Challenger");
            this.modManager.componentlist.events.downloadAllInOneMod(m);
        }

        private void startBetterCrewlink(object sender, EventArgs e)
        {
            Mod m = this.modManager.modlist.getAvailableModById("BetterCrewlink");
            this.modManager.componentlist.events.startAllInOneMod(m);
        }

        private void installBetterCrewlink(object sender, EventArgs e)
        {
            Mod m = this.modManager.modlist.getAvailableModById("BetterCrewlink");
            this.modManager.componentlist.events.downloadAllInOneMod(m);
        }

        private void startSkeld(object sender, EventArgs e)
        {
            Mod m = this.modManager.modlist.getAvailableModById("Skeld");
            this.modManager.componentlist.events.startAllInOneMod(m);
        }

        private void installSkeld(object sender, EventArgs e)
        {
            Mod m = this.modManager.modlist.getAvailableModById("Skeld");
            this.modManager.componentlist.events.downloadAllInOneMod(m);
        }

        private void settings(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page Settings\n");
            this.modManager.pagelist.renderPage("Settings");
            this.modManager.Activate();
        }

        private void exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
