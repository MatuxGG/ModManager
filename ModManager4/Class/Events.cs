using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

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

        public void openAuthorGithub(object sender, EventArgs e)
        {
            LinkLabel clickedLink = ((LinkLabel)sender);
            string modId = clickedLink.Name.Substring(clickedLink.Name.IndexOf("=") + 1);
            Mod m = this.modManager.modlist.getModById(modId);
            string link = "https://github.com/" + m.author;
            this.modManager.logs.log("Event : Open Author github at link " + link + "\n");
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
            Process.Start("explorer", this.modManager.serverURL + "/discord");
        }

        public void openMatuxGithub(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Open Mod Manager github\n");
            Process.Start("explorer", this.modManager.serverURL + "\\github");
        }

        public void openMatuxRoadmap(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Open Mod Manager Roadmap\n");
            Process.Start("explorer", this.modManager.serverURL + "\\roadmap");
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

        public void openServers(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page Servers\n");
            this.modManager.pagelist.renderPage("Servers");
        }

        public void enableCache(object sender, EventArgs e)
        {
            MMCheckbox checkbox = ((MMCheckbox)sender);
            if (checkbox.Checked)
            {
                this.modManager.logs.log("Event : Enable cache \n");
                this.modManager.config.enableCache = true;
            } else
            {
                this.modManager.logs.log("Event : Disable cache \n");
                this.modManager.config.enableCache = false;
            }
            this.modManager.config.update(this.modManager);
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

        public void openPolus(object sender, EventArgs e)
        {
            PictureBox pic = ((PictureBox)sender);
            RegistryKey polusKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 1653240", false);

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
            this.selectFolderWorker();
        }

        public void saveServer(object sender, EventArgs e)
        {
            string picName = ((PictureBox)sender).Name;
            int serverId = int.Parse(picName.Substring(picName.IndexOf("=") + 1));

            Panel ServersPanel = (Panel) this.modManager.componentlist.get("Servers").getControl("PagePanelServers").Controls["ServersPanel"];

            string name = ServersPanel.Controls["ServerName=" + serverId].Text;
            string ip = ServersPanel.Controls["ServerIP=" + serverId].Text;
            string port = ServersPanel.Controls["ServerPort=" + serverId].Text;

            Regex ipReg = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ipReg.Matches(ip);

            if (result.Count() == 0)
            {
                return;
            }

            this.modManager.serverlist.Regions[serverId].name = name;
            this.modManager.serverlist.Regions[serverId].DefaultIp = result[0].Value;
            this.modManager.serverlist.Regions[serverId].Fqdn = result[0].Value;
            this.modManager.serverlist.Regions[serverId].port = int.Parse(port);

            this.modManager.serverlist.update(this.modManager);
            ((PictureBox)sender).Hide();
        }

        public void showSaveServer(object sender, EventArgs e)
        {
            string controlName;
            if (sender is TextBox)
            {
                controlName = ((TextBox)sender).Name;
            } else if (sender is TextBox)
            {
                controlName = ((TextBox)sender).Name;
            } else
            {
                controlName = ((NumericUpDown)sender).Name;
            }
            int serverId = int.Parse(controlName.Substring(controlName.IndexOf("=") + 1));

            Panel ServersPanel = (Panel)this.modManager.componentlist.get("Servers").getControl("PagePanelServers").Controls["ServersPanel"];
            ServersPanel.Controls["ServerValidPic=" + serverId].Visible = true;
        }

        public void removeServer(object sender, EventArgs e)
        {
            string picName = ((PictureBox)sender).Name;
            int serverId = int.Parse(picName.Substring(picName.IndexOf("=") + 1));

            this.modManager.serverlist.removeRegion(serverId);
            this.modManager.serverlist.update(this.modManager);

            this.clearWithBlink();

            this.modManager.pagelist.renderPage("Servers");
        }

        public void resetServers(object sender, EventArgs e)
        {
            this.modManager.serverlist.reset(this.modManager);

            this.clearWithBlink();

            this.modManager.pagelist.renderPage("Servers");
        }

        public void clearWithBlink()
        {
            this.modManager.componentlist = new Componentlist(this.modManager);
            this.modManager.componentlist.load();
            this.modManager.modlist.setCode();
        }

        public void addServer(object sender, EventArgs e)
        {
            this.modManager.serverlist.add(this.modManager);

            Server newServ = new Server("DnsRegionInfo, Assembly-CSharp", "", "", 22023, "New Server", 1003);
            Panel ServersPanel = (Panel)this.modManager.componentlist.get("Servers").getControl("PagePanelServers").Controls["ServersPanel"];
            this.modManager.componentlist.addServer(newServ, this.modManager.serverlist.Regions.Count() - 1, ServersPanel);
        }

        public void selectFolderWorker()
        {
            this.modManager.logs.log("Event : Open popup to select Among Us folder\n");
            OpenFileDialog folderBrowser = new OpenFileDialog();
            if (this.modManager.config != null && this.modManager.config.amongUsPath != null)
            {
                folderBrowser.InitialDirectory = this.modManager.config.amongUsPath;
            }
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
                }
                this.modManager.config.amongUsPath = folderPath;
                this.modManager.config.update(this.modManager);
                this.modManager.pagelist.renderPage("ModSelection");
            }
        }

        public void checkBox(object sender, EventArgs e)
        {
            MMCheckbox clickedBox = ((MMCheckbox)sender);
            Mod m = this.modManager.modlist.getModById(clickedBox.Name);

            Category modCat = this.modManager.categorylist.getCategoryById(m.category);
            Boolean status = true;
            if (clickedBox.CheckState == CheckState.Unchecked || modCat.type == "any")
                //|| (modCat.type == "unique" && this.modManager.config.getInstalledModsWithoutAllInOne(this.modManager).Count + this.modManager.modlist.toInstall.Count - this.modManager.modlist.toUninstall.Count == 0)) Unique dropped for now
            {
                status = true;
            }
            else if (modCat.type == "one")
            {
                int inCat = 0;
                foreach (InstalledMod im in this.modManager.config.getInstalledModsForCategory(this.modManager, modCat))
                {
                    inCat++;
                    foreach (string toUninstall in this.modManager.modlist.toUninstall)
                    {
                        if (toUninstall == im.id)
                        {
                            inCat--;
                            break;
                        }
                    }
                }
                if (inCat > 0)
                {
                    status = false;
                }
                else
                {
                    Boolean toInstallCat = false;
                    foreach (string toInstall in this.modManager.modlist.toInstall)
                    {
                        if (this.modManager.modlist.getModById(toInstall).category == modCat.id)
                        {
                            toInstallCat = true;
                            break;
                        }
                    }
                    if (toInstallCat)
                    {
                        status = false;
                    }
                    else
                    {
                        status = true;
                    }
                }

            }
            else
            {
                status = false;
            }

            if (status)
            {
                if (clickedBox.CheckState == CheckState.Checked)
                {
                    if (this.modManager.modlist.toUninstall.Contains(m.id))
                    {
                        this.modManager.modlist.toUninstall.Remove(m.id);
                    }
                    else
                    {
                        this.modManager.modlist.toInstall.Add(m.id);
                    }
                }
                else
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
            } else
            {
                if (clickedBox.CheckState == CheckState.Checked)
                {
                    clickedBox.CheckState = CheckState.Unchecked;
                } else
                {
                    clickedBox.CheckState = CheckState.Checked;
                }
            }
        }

        public void changeResolution(object sender, EventArgs e)
        {
            ComboBox comboBox = ((ComboBox)sender);
            string selectedRes = comboBox.Text;
            int resX = int.Parse(selectedRes.Substring(0, selectedRes.IndexOf("x")));
            int resY = int.Parse(selectedRes.Substring(selectedRes.IndexOf("x") + 1));
            this.modManager.config.resolutionX = resX;
            this.modManager.config.resolutionY = resY;
            this.modManager.config.update(this.modManager);
            this.modManager.componentlist = new Componentlist(this.modManager);
            this.modManager.componentlist.load();
            this.modManager.modlist.setCode();
            this.modManager.Size = new Size(resX, resY + 30);
            this.modManager.centerToScreenPub();
            this.modManager.logs.log(this.modManager.componentlist.toString());
            this.modManager.pagelist.renderPage("Settings");
        }

        public void changeMethod(object sender, EventArgs e)
        {
            ComboBox comboBox = ((ComboBox)sender);
            string selectedRes = comboBox.Text;
            this.modManager.config.startMethod = selectedRes;
            this.modManager.config.update(this.modManager);
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
            this.modManager.modWorker.updateMods(false);
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

        public void exportCode(object sender, EventArgs e)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string title = "Mod Manager -";
            string arguments = "";
            foreach (InstalledMod mod in this.modManager.config.installedMods)
            {
                Mod m = this.modManager.modlist.getModById(mod.id);
                if (m.type == "mod")
                {
                    title = title + " " + m.name + " &";
                    arguments = arguments + m.id + " ";
                }
            }
            if (title.Substring(title.Length - 1, 1) == "&")
            {
                title = title.Substring(0, title.Length - 2);
                arguments = arguments.Substring(0, arguments.Length - 1);
            } else
            {
                title = title + " Among Us";
                arguments = "";
            }
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + "\\" + title + ".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Mod Manager Set of mods";
            shortcut.TargetPath = this.modManager.appPath + "\\ModManager4.exe";
            shortcut.Arguments = arguments;
            shortcut.Save();
            MessageBox.Show("A shortcut has been created on your desktop !", "Shortcut created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void localAdd(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Render page LocalAdd\n");
            this.modManager.pagelist.renderPage("LocalAdd");
        }

        public void addMod(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Add local mod\n");
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Filter = "ZIP mod file|*.zip|DLL mod file|*.dll";
            // Always default to Folder Selection.
            folderBrowser.FileName = "";

            Panel p = (Panel)this.modManager.componentlist.get("LocalAdd").getControl("PagePanelLocal");
            Label l = (Label)p.Controls["ModAddFileName"];

            if (l.Text != "")
            {
                folderBrowser.InitialDirectory = Path.GetDirectoryName(l.Text);
            }

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                l.Text = Path.GetFullPath(folderBrowser.FileName);
            }
            this.modManager.logs.log("- Added local mod successfully\n");
        }

        public void editMod(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Edit local mod\n");
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.Filter = "ZIP mod file|*.zip|DLL mod file|*.dll";
            // Always default to Folder Selection.
            folderBrowser.FileName = "";

            Panel p = (Panel)this.modManager.componentlist.get("LocalEdit").getControl("PagePanelLocalEdit");
            Label l = (Label)p.Controls["ModAddFileNameEdit"];

            if (l.Text != "")
            {
                folderBrowser.InitialDirectory = Path.GetDirectoryName(l.Text);
            }

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                l.Text = Path.GetFullPath(folderBrowser.FileName);
            }
            this.modManager.logs.log("Event : Edit local mod successfully\n");
        }

        public void validAddMod(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Valid add local mod\n");
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
                if (c is MMCheckbox)
                {
                    MMCheckbox cb = (MMCheckbox)c;
                    if (cb.CheckState == CheckState.Checked)
                    {
                        dependencies.Add(cb.Name);
                    }
                }
            }
            string newPath = this.modManager.appDataPath + "\\localMods\\" + Path.GetFileName(fileName);
            this.modManager.utils.FileCopy(fileName, newPath);
            List<Mod> localMods = this.modManager.modlist.getLocalMods();
            Mod newMod = new Mod("Localmod" + localMods.Count, name, "local", "localMod", this.modManager.serverConfig.gameVersion, dependencies, "You", newPath, new List<string>(){ }, new List<string>() { }, new List<string>() { });
            this.modManager.modlist.mods.Add(newMod);
            this.modManager.modlist.updateLocalMods();
            this.modManager.componentlist.refreshModSelection();
            this.modManager.pagelist.renderPage("ModSelection");

            this.modManager.logs.log("Event : Valid add local mod successfully\n");
        }

        public void validEditMod(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Valid edit local mod\n");
            Panel p = (Panel)this.modManager.componentlist.get("LocalEdit").getControl("PagePanelLocalEdit");
            string name = p.Controls["ModNameFieldEdit"].Text;
            string fileName = p.Controls["ModAddFileNameEdit"].Text;
            if (fileName == "No file selected" || name == "")
            {
                return;
            }

            System.Windows.Forms.Label LocalEditId = (System.Windows.Forms.Label)p.Controls["LocalEditId"];
            Mod m = this.modManager.modlist.getModById(LocalEditId.Text);

            List<string> dependencies = new List<string>();
            foreach (Control c in p.Controls)
            {
                if (c is MMCheckbox)
                {
                    MMCheckbox cb = (MMCheckbox)c;
                    if (cb.CheckState == CheckState.Checked)
                    {
                        dependencies.Add(cb.Name);
                    }
                }
            }


            string newPath = this.modManager.appDataPath + "\\localMods\\" + Path.GetFileName(fileName);
            this.modManager.utils.FileCopy(fileName, newPath);

            m.name = name;
            this.modManager.utils.FileDelete(m.github);
            m.dependencies = dependencies;
            m.github = newPath;

            this.modManager.modlist.updateLocalMods();
            this.modManager.componentlist.refreshModSelection();
            this.modManager.pagelist.renderPage("ModSelection");
            this.modManager.logs.log("Event : Valid edit local mod successfully\n");
        }

        public void editLocalMod(object sender, EventArgs e)
        {
            string edit = ((PictureBox)sender).Name;
            string modId = edit.Substring(edit.IndexOf("=") + 1);
            Mod m = this.modManager.modlist.getModById(modId);
            this.modManager.componentlist.loadEditModPage(m);
            this.modManager.pagelist.renderPage("LocalEdit");
        }

        public void removeLocalMod(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Remove local mod\n");
            string cross = ((PictureBox)sender).Name;
            string modId = cross.Substring(cross.IndexOf("=") + 1);
            Mod m = this.modManager.modlist.getModById(modId);
            this.modManager.modWorker.removeLocalMod(m);

            this.clearWithBlink();

            this.modManager.logs.log(this.modManager.componentlist.toString());
            this.modManager.pagelist.renderPage("ModSelection");

            this.modManager.logs.log("Event : Removed local mod successfully\n");

            //this.modManager.componentlist.refreshModSelection();
            //this.modManager.pagelist.renderPage("ModSelection");
        }

        public void removeLocalMods(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Remove local mods\n");
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
            this.modManager.logs.log("Event : Removed local mods successfully\n");
        }

        public void downloadAllInOne(object sender, EventArgs e)
        {
            string cross = ((PictureBox)sender).Name;
            string modId = cross.Substring(cross.IndexOf("=") + 1);
            Mod m = this.modManager.modlist.getModById(modId);
            this.modManager.logs.log("Event : Downloading All In One Mod " + m.name + "\n");

            if (m.id == "Skeld")
            {
                try
                {
                    Directory.CreateDirectory(this.modManager.appDataPath + "\\allInOneMods\\" + m.id);
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(this.modManager.serverURL + "/skeld", this.modManager.appDataPath + "\\allInOneMods\\" + m.id + "\\" + "Skeld.exe");
                    }
                }
                catch
                {
                    this.modManager.logs.log("Error : Disconnected during " + m.name + " install");
                    this.modManager.componentlist.events.exitMM();
                }
                InstalledMod newMod = new InstalledMod(m.id, "1.0", m.gameVersion, new List<string>() { });
                this.modManager.config.installedMods.Add(newMod);
                this.modManager.config.update(this.modManager);

                this.clearWithBlink();
                this.modManager.pagelist.renderPage("ModSelection");
            } else if (m.id == "Challenger")
            {
                Directory.CreateDirectory(this.modManager.appDataPath + "\\allInOneMods\\" + m.id);
                this.modManager.pagelist.renderPage("BeforeUpdateMods");
                this.modManager.modWorker.installChallenger();
            } else if (m.id == "BetterCrewlink")
            {
                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);

                if (o != null && System.IO.File.Exists(o.ToString() + "\\Better-CrewLink.exe"))
                {
                    Process.Start("explorer", o.ToString() + "\\Better-CrewLink.exe");
                }
                else
                {
                    string dlPath = this.modManager.tempPath + "\\Better-CrewLink-Setup.exe";
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile(this.modManager.serverURL + "\\bcl", dlPath);
                        }
                    }
                    catch
                    {
                        this.modManager.logs.log("Error : Disconnected during Better Crewlink install");
                        this.modManager.componentlist.events.exitMM();
                    }
                    this.modManager.logs.debug(dlPath);
                    Process.Start("explorer.exe", dlPath);

                    Boolean installed = false;
                    while (!installed)
                    {
                        o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                        if (o != null && System.IO.File.Exists(o.ToString() + "\\Better-CrewLink.exe"))
                        {
                            installed = true;
                        }
                    }
                    this.clearWithBlink();
                    this.modManager.pagelist.renderPage("ModSelection");
                }
            }
            else if (m.id == "Polusgg")
            {
                RegistryKey polusKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 1653240", false);
                if (polusKey != null)
                {
                    Process.Start("explorer", "steam://rungameid/1653240");
                } else
                {
                    Process.Start("explorer", "https://store.steampowered.com/app/1653240/Polusgg/");
                }
            }

            this.modManager.logs.log("Event : Downloaded All In One Mod " + m.name + " successfully\n");

        }

        public void startAllInOne(object sender, EventArgs e)
        {
            string cross = ((PictureBox)sender).Name;
            string modId = cross.Substring(cross.IndexOf("=") + 1);
            Mod m = this.modManager.modlist.getModById(modId);
            this.modManager.logs.log("Event : Starting All In One Mod " + m.name + "\n");

            if (m.id == "Skeld")
            {
                Process.Start("explorer", this.modManager.appDataPath + "\\allInOneMods\\" + m.id + "\\" + "Skeld.exe");
            }
            else if (m.id == "Challenger")
            {
                Process.Start("explorer", this.modManager.appDataPath + "\\allInOneMods\\" + m.id + "\\" + "Among Us.exe");
            }
            else if (m.id == "BetterCrewlink")
            {
                object o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);

                if (o != null && System.IO.File.Exists(o.ToString() + "\\Better-CrewLink.exe"))
                {
                    Process.Start("explorer", o.ToString() + "\\Better-CrewLink.exe");
                }
                else
                {
                    string dlPath = this.modManager.tempPath + "\\Better-CrewLink-Setup.exe";
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile(this.modManager.serverURL + "\\bcl", dlPath);
                        }
                    }
                    catch
                    {
                        this.modManager.logs.log("Error : Disconnected during Better Crewlink install");
                        this.modManager.componentlist.events.exitMM();
                    }
                    this.modManager.logs.debug(dlPath);
                    Process.Start("explorer.exe", dlPath);

                    Boolean installed = false;
                    while (!installed)
                    {
                        o = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\03ceac78-9166-585d-b33a-90982f435933", "InstallLocation", null);
                        if (o != null && System.IO.File.Exists(o.ToString() + "\\Better-CrewLink.exe"))
                        {
                            installed = true;
                        }
                    }
                    this.clearWithBlink();
                    this.modManager.pagelist.renderPage("ModSelection");
                }
            }
            else if (m.id == "Polusgg")
            {
                RegistryKey polusKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 1653240", false);
                if (polusKey != null)
                {
                    Process.Start("explorer", "steam://rungameid/1653240");

                }
            }

            this.modManager.logs.log("Event : Started All In One Mod " + m.name + " successfully\n");
        }

        public void rollCategory(object sender, EventArgs e)
        {
            string cross = ((Control)sender).Name;
            string categoryName = cross.Substring(cross.IndexOf("=") + 1);
            if (this.modManager.config.hiddenCategories.Contains(categoryName))
            {
                this.modManager.config.hiddenCategories.Remove(categoryName);
            } else
            {
                this.modManager.config.hiddenCategories.Add(categoryName);
            }
            this.modManager.config.update(this.modManager);

            this.clearWithBlink();

            this.modManager.pagelist.renderPage("ModSelection");

        }
        public void sortMods(object sender, EventArgs e)
        {
            string cross = ((Control)sender).Name;
            string sortType = cross.Substring(cross.IndexOf("=") + 1);
            if (this.modManager.config.sortType == sortType)
            {
                if (this.modManager.config.sortOrder == "A")
                {
                    this.modManager.config.sortOrder = "D";
                } else
                {
                    this.modManager.config.sortOrder = "A";
                }
            } else
            {
                this.modManager.config.sortType = sortType;
                this.modManager.config.sortOrder = "A";
            }

            this.clearWithBlink();

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
            this.modManager.modWorker.updateMods(true);
        }

        public void startAnyway(object sender, EventArgs e)
        {
            this.modManager.logs.log("Event : Don't Save and Start\n");
            this.startGame();
            this.modManager.pagelist.renderPage("ModSelection");
        }

        public void startGame()
        {
            Boolean worked = false;
            this.modManager.logs.log("Event : Start Game\n");
            if (this.modManager.config.startMethod == "Direct Link")
            {
                string path = this.modManager.config.amongUsPath + "\\Among Us.exe";
                if (System.IO.File.Exists(path))
                {
                    Process.Start("explorer", path);
                    worked = true;
                } else
                {
                    worked = false;
                }
            } else if (this.modManager.config.startMethod == "Steam")
            {
                Process.Start("explorer", "steam://rungameid/945360");
                worked = true;
            } else if (this.modManager.config.startMethod == "Epic Games Store")
            {
                Process.Start("explorer", "com.epicgames.launcher://apps/33956bcb55d4452d8c47e16b94e294bd%3A729a86a5146640a2ace9e8c595414c56%3A963137e4c29d4c79a81323b8fab03a40?action=launch&silent=true");
                worked = true;
            }
            if (worked == false)
            {
                MessageBox.Show("Apparently, Mod Manager was not able to start Among Us.\n" +
                    "\n" +
                    "Please, make sure you're using the correct Start Method.\n" +
                    "Start Method can be changed in Mod Manager's settings !", "Among Us didn't start", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
