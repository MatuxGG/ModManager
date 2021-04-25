﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Events
    {
        public ModManager modManager;

        public Events(ModManager modManager)
        {
            this.modManager = modManager;
        }

        public void openGithub(object sender, EventArgs e)
        {
            LinkLabel clickedLink = ((LinkLabel)sender);
            string link = clickedLink.Text;
            this.modManager.logs.log("Event : Open github at link " + link + "\n");
            Process.Start("explorer", link);
        }

        public void openAnnounce(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page News\n");
            this.modManager.pagelist.renderPage("News");
        }
        public void openSettings(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page Settings\n");
            this.modManager.pagelist.renderPage("Settings");
        }

        public void openMods(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page ModSelection\n");
            this.modManager.pagelist.renderPage("ModSelection");
        }
        public void openMMDiscord(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Open Mod Manager discord\n");
            Process.Start("explorer", "https://discord.gg/yBNgKuGjNw");
        }

        public void openMatuxGithub(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Open Mod Manager github\n");
            Process.Start("explorer", "https://github.com/MatuxGG/ModManager");
        }

        public void openPathSelection(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page PathSelection\n");
            this.modManager.pagelist.renderPage("PathSelection");
        }

        public void openAmongUsDirectory(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Open Among Us folder\n");
            Process.Start("explorer.exe", this.modManager.config.amongUsPath);
        }

        public void openInfo(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page Info\n");
            this.modManager.pagelist.renderPage("Info");
        }

        public void openTools(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page Tools\n");
            this.modManager.pagelist.renderPage("ModTools");
        }

        public void openTool(object sender, EventArgs e)
        {
            string toolFieldName = ((PictureBox)sender).Name;
            string toolName = toolFieldName.Substring(toolFieldName.IndexOf("=") + 1);
            Tool t = this.modManager.toollist.getToolByName(toolName);
            if (t.path == "")
            {
                if (MessageBox.Show("Please select a path for " + t.name, "Select tool path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    OpenFileDialog folderBrowser = new OpenFileDialog();
                    folderBrowser.ValidateNames = false;
                    folderBrowser.CheckFileExists = false;
                    folderBrowser.CheckPathExists = true;
                    folderBrowser.Filter = "Any|*";
                    // Always default to Folder Selection.
                    folderBrowser.FileName = "";
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        t.path = folderBrowser.FileName;
                        this.modManager.toollist.update();
                    }
                }
            } else
            {
                Process.Start("explorer", t.path);
            }
        }

        public void downloadTool(object sender, EventArgs e)
        {
            string toolFieldName = ((LinkLabel)sender).Name;
            string toolName = toolFieldName.Substring(toolFieldName.IndexOf("=") + 1);
            Tool t = this.modManager.toollist.getToolByName(toolName);
            Process.Start("explorer", t.downloadLink);
        }

        public void openLogs(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Open Mod Manager logs folder\n");
            if (MessageBox.Show("Please, don't touch anything in this folder !\n\n" +
                "This option should only be used to create a support ticket.\n\n" +
                "Do you still want to open it ?", "Open logs folder", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string path = this.modManager.appDataPath;
                Process.Start("explorer.exe", path);
            }
        }

        public void exitMM()
        {
            MessageBox.Show("Mod Manager's server is unreacheable.\n" +
                "\n" +
                "There are many possible reasons for this :\n" +
                "- You are disconnected from internet\n" +
                "- Your antivirus blocks Mod Manager\n" +
                "- Mod Manager server is down. Check its status on matux.fr\n" +
                "\n" +
                "If this problem persists, please send a ticket on Mod Manager's discord.", "Server unreacheable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        public void selectFolder(object sender, EventArgs e) {
            this.modManager.logs.log("Event : Open popup to select Among Us folder\n");
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Filter = "Among Us file|Among Us.exe";
            // Always default to Folder Selection.
            folderBrowser.FileName = "Among Us.exe";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                this.modManager.logs.log("- Folder selected : " + folderPath + "\n");
                if (this.modManager.config == null)
                {
                    this.modManager.config = new Config();
                    this.modManager.config.setPath(this.modManager.serverURL);
                }
                this.modManager.config.amongUsPath = folderPath;
                this.modManager.config.update();
                this.modManager.pagelist.renderPage("ModSelection");
            }
        }

        public void checkBox(object sender, EventArgs e)
        {
            CheckBox clickedBox = ((CheckBox)sender);
            Mod m = this.modManager.modlist.getModById(clickedBox.Name);
            if (clickedBox.CheckState == CheckState.Checked)
            {
                if (this.modManager.modlist.toUninstall.Contains(m.id))
                {
                    this.modManager.modlist.toUninstall.Remove(m.id);
                } else
                {
                    this.modManager.modlist.toInstall.Add(m.id);
                }
            } else
            {
                if (this.modManager.modlist.toInstall.Contains(m.id))
                {
                    this.modManager.modlist.toInstall.Remove(m.id);
                }
                else
                {
                    this.modManager.modlist.toUninstall.Add(m.id);
                }
            }
        }

        public void uninstallMods(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Uninstall all mods\n");

            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                this.modManager.logs.log("- Among Us running\n");
                if (MessageBox.Show("Can't uninstall mods while Among Us is running", "Can't uninstall mods", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    return;
                }
            }

            this.modManager.modWorker.uninstallMods();
            this.modManager.modlist.resetChanged();
            this.modManager.modlist.setCode();
            this.modManager.pagelist.renderPage("AfterUninstallMods");
            this.modManager.componentlist.refreshModSelection();
            this.modManager.logs.log("- Uninstall all mods completed\n");
        }

        public void updateMods(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Update mods\n");

            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                this.modManager.logs.log("- Among Us running\n");
                if (MessageBox.Show("Can't update mods while Among Us is running", "Can't update mods", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    return;
                }
            }

            this.modManager.pagelist.renderPage("BeforeUpdateMods");
            this.modManager.modWorker.updateMods();
            this.modManager.logs.log("- Update mods completed\n");
        }

        public void validCode(object sender, EventArgs e)
        {
            TextBox codeTextbox = (TextBox)this.modManager.componentlist.get("Footer").getControl("CodeTextbox");
            string code = codeTextbox.Text;
            this.modManager.logs.log("Event : Install mods from code " + code + "\n");

            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                this.modManager.logs.log("- Among Us running\n");
                if (MessageBox.Show("Can't update mods while Among Us is running", "Can't update mods", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    return;
                }
            }

            this.modManager.pagelist.renderPage("BeforeApplyCode");
            this.modManager.modWorker.installFromCode(code);
            this.modManager.logs.log("- Install mods from code completed\n");
        }

        public void localAdd(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page LocalAdd\n");
            this.modManager.pagelist.renderPage("LocalAdd");
        }

        public void addMod(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Filter = "ZIP mod file|*.zip|DLL mod file|*.dll";
            // Always default to Folder Selection.
            folderBrowser.FileName = "";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                Panel p = (Panel)this.modManager.componentlist.get("LocalAdd").getControl("PagePanelLocal");
                Label l = (Label)p.Controls["ModAddFileName"];
                l.Text = Path.GetFullPath(folderBrowser.FileName);
            }
        }

        public void validAddMod(object sender, EventArgs e)
        {
            Panel p = (Panel)this.modManager.componentlist.get("LocalAdd").getControl("PagePanelLocal");
            string name = p.Controls["ModNameField"].Text;
            string fileName = p.Controls["ModAddFileName"].Text;
            if (fileName == "No file selected" || name == "")
            {
                return;
            }
            List<string> dependencies = new List<string>();
            foreach (Control c in p.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.CheckState == CheckState.Checked)
                    {
                        dependencies.Add(cb.Name);
                    }
                }
            }
            string newPath = this.modManager.appDataPath + "\\localMods\\" + Path.GetFileName(fileName);
            this.modManager.utils.FileCopy(fileName, newPath);
            List<Mod> localMods = this.modManager.modlist.getLocalMods();
            Mod newMod = new Mod("Localmod"+localMods.Count, name, "Local mods", "localMod", this.modManager.serverConfig.gameVersion, dependencies, "You", newPath);
            this.modManager.modlist.mods.Add(newMod);
            this.modManager.modlist.updateLocalMods();
            this.modManager.componentlist.refreshModSelection();
            this.modManager.pagelist.renderPage("ModSelection");
        }

        //Temporary disabled
        public void removeLocalMod(object sender, EventArgs e)
        {
            string cross = ((Label)sender).Name;
            string modId = cross.Substring(cross.IndexOf("=") + 1);
            Mod m = this.modManager.modlist.getModById(modId);
            this.modManager.modWorker.removeLocalMod(m);
            this.modManager.componentlist.refreshModSelection();
            this.modManager.pagelist.renderPage("ModSelection");
        }

        public void removeLocalMods(object sender, EventArgs e)
        {
            if (MessageBox.Show("This option will remove and uninstall all current local mods from Mod Manager.\n\nDo you really want to do that ?", "Remove local mods", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }
            foreach (Mod m in this.modManager.modlist.getLocalMods())
            {
                this.modManager.modWorker.removeLocalMod(m);
            }
            this.modManager.componentlist.refreshModSelection();
            this.modManager.pagelist.renderPage("ModSelection");
        }

        public void launchGame(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Start Among Us\n");
            if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
            {
                this.modManager.logs.log("- Already running\n");
                if (MessageBox.Show("Among Us is already running or is starting.\nDo you want to start another instance of Among Us ?", "Among Us already running", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    this.modManager.logs.log("- Cancelled\n");
                    return;
                } else
                {
                    this.modManager.logs.log("- Forced\n");
                }
            }

            if (this.modManager.modlist.toInstall.Count != 0 || this.modManager.modlist.toUninstall.Count != 0) 
            {
                this.modManager.logs.log("- Render page Unsaved Changes\n");
                this.modManager.pagelist.renderPage("UnsavedChanges");
            } else
            {
                this.modManager.logs.log("- Start\n");
                this.startGame();
            }
        }

        public void saveAndStart(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Save and Start\n");
            this.modManager.pagelist.renderPage("BeforeUpdateMods");
            this.modManager.modWorker.updateMods();
            this.startGame();
        }

        public void startAnyway(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Don't Save and Start\n");
            this.startGame();
            this.modManager.pagelist.renderPage("ModSelection");
        }

        public void startGame()
        {
            this.modManager.logs.log("Event : Start Game\n");
            Process.Start("explorer", this.modManager.config.amongUsPath + "\\Among Us.exe");
        }
    }
}
