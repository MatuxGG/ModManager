using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Pagelist
    {
        public ModManager modManager;

        public List<Page> pages;
        public Pagelist(ModManager modManager)
        {
            this.modManager = modManager;
            this.pages = new List<Page>();
        }
        public void load()
        {
            this.pages.Add(new Page("ModSelection", new string[] { "Header", "HeaderPub", "ModSelection", "Footer" }));
            this.pages.Add(new Page("PathSelection", new string[] { "Header", "HeaderPub", "BackToMods", "PathSelection", "Footer" }));
            this.pages.Add(new Page("FirstPathSelection", new string[] { "HeaderPub", "PathSelection" }));
            this.pages.Add(new Page("Settings", new string[] { "Header", "HeaderPub", "BackToMods", "Settings", "Footer" }));
            this.pages.Add(new Page("News", new string[] { "Header", "HeaderPub", "BackToMods", "News", "Footer" }));
            this.pages.Add(new Page("AfterUninstallMods", new string[] { "Header", "HeaderPub", "AfterUninstallMods", "Footer" }));
            this.pages.Add(new Page("BeforeUpdateMods", new string[] { "HeaderPub", "BeforeUpdateMods" }));
            this.pages.Add(new Page("BeforeApplyCode", new string[] { "HeaderPub", "BeforeApplyCode" }));
            this.pages.Add(new Page("LocalAdd", new string[] { "Header", "HeaderPub", "BackToMods", "LocalAdd", "Footer" }));
            this.pages.Add(new Page("LocalEdit", new string[] { "Header", "HeaderPub", "BackToMods", "LocalEdit", "Footer" }));
            this.pages.Add(new Page("Info", new string[] { "Header", "HeaderPub", "BackToMods", "Info", "Footer" }));
            this.pages.Add(new Page("UnsavedChanges", new string[] { "Header", "HeaderPub", "BackToMods", "UnsavedChanges", "Footer" }));
            this.pages.Add(new Page("Servers", new string[] { "Header", "HeaderPub", "BackToMods", "Servers", "Footer" }));

            this.pages.Add(new Page("Disabled", new string[] { "HeaderPub", "Disabled" }));
        }

        public void clear()
        {
            this.pages.Clear();
        }

        public void renderPage(string name)
        {
            foreach (Page p in this.pages)
            {
                if (p.name == name)
                {
                    this.modManager.componentlist.renderComponents(p.components);
                } else
                {
                    
                }
            }
        }

        public string toString()
        {
            string ret = "Page list :\n";

            foreach (Page p in this.pages)
            {
                ret = ret + "- Page " + p.name + "\n";
            }
            return ret;
        }
    }
}
