using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Tooltips
    {
        public ModManager modManager;

        public ToolTip toolTip;

        public Tooltips (ModManager modManager) {
            this.modManager = modManager;
            this.toolTip = new ToolTip();
        }

        private static readonly Dictionary<string, string> tips = new Dictionary<string, string> {
            { "CodeTextbox", "Share this code with others to make them install same mods\nOr enter a code here to install their mods" },
            { "ValidCodePic", "Click here to install mods from a code you entered" },
            { "ExportCodePic", "Click here to create a shortcut on your desktop with currently installed mods" },
            { "UpdateModsPic", "Click here install selected mods and uninstall unselected ones" },
            { "RemoveModsPic", "At any moment, you can click here to remove all mods and go back to vanilla Among Us" },
            { "AddLocalPic", "Click here to add a mod to Mod Manager from your computer" },
            { "BetterCrewlinkPic", "Click here to open (or install) Better Crewlink" },
            { "ServersPic", "Click here to manage available servers available in Among Us\n(By default, Europe, North America & Asia)" },
            { "AnnouncePic", "Click here to see latest news about Mod Manager" },
            { "InfoPic", "Click here to see credits & Frequently Asked Questions" },
            { "PlayGameLabel", "Click here to see start Among Us" },
            { "SettingsPic", "Click here to edit Mod Manager's settings" },
            { "AmongUsDirSwitchButton", "Click here to change the Among Us path used by Mod Manager" },
            { "OpenAmongUs", "Click here to open the folder with Among Us used by Mod Manager" },
            { "RemoveLocalButton", "Click here to remove all local mods stored in Mod Manager at once" },
            { "OpenLogsButton", "Click here to open Mod Manager's logs folder\nIt contains useful information that can be used to solve an issue" },
            { "EnableCacheCheckbox", "Click here to enable/disable Mod Manager's cache" },
            { "ResolutionComboBox", "Click here to change the resolution of Mod Manager's window" },
            { "MatuxRoadmapLabel", "Click here to open Mod Manager's roadmap\nYou can track incomming features or known bugs here" },
            { "MMDiscordLabel", "Click here to join Mod Manager's discord server" },
            { "MatuxGithubLabel", "Click here to open Mod Manager's github repository" },
            { "MethodComboBox", "Click here to change the method used to start Among Us" },

        }; 

        public void show(object sender, EventArgs e)
        {
            Control c = (Control)sender;

            string s = tips[c.Name];

            Point locationOnForm = c.FindForm().PointToClient(c.Parent.PointToScreen(c.Location));

            this.toolTip.Show(s, this.modManager, locationOnForm, 5000);
        }

        public void hide(object sender, EventArgs e)
        {
            this.toolTip.Hide(this.modManager);
        }
    }
}
