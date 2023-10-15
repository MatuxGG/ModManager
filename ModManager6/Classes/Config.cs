using ModManager6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class Config
    {
        public string ModManagerVersion;
        public List<InstalledMod> installedMods;
        public List<InstalledVanilla> installedVanilla;
        public string amongUsPath;
        public List<string> favoriteMods;
        public bool miniEnabled;
        public List<string> availableAmongUsPaths;
        public string supportId;
        public string theme;
        public string lg;
        public List<string> sources;
        public List<ModState> modStates;

        public Config(string modManagerVersion = null, List<InstalledMod> installedMods = null, List<InstalledVanilla> installedVanilla = null, string amongUsPath = "", List<string> faroriteMods = null, bool miniEnabled = true, List<string> availableAmongUsPaths = null, string supportId = null, string lg = null, string theme = null , List<string> sources = null, List<ModState> modStates = null)
        {
            try
            {
                this.ModManagerVersion = modManagerVersion != null ? modManagerVersion : ModManager.visibleVersion;
                this.installedMods = installedMods != null ? installedMods : new List<InstalledMod>() { };
                this.installedVanilla = installedVanilla != null ? installedVanilla : new List<InstalledVanilla>() { };
                this.amongUsPath = amongUsPath;
                this.favoriteMods = faroriteMods != null ? favoriteMods : new List<string>() { };
                this.miniEnabled = miniEnabled;
                this.availableAmongUsPaths = availableAmongUsPaths != null ? availableAmongUsPaths : new List<string>() { };
                this.supportId = supportId;
                if (this.supportId == null)
                {
                    Random random = new Random();
                    this.supportId = new string(Enumerable.Repeat(ModManager.supportIdChars, 10)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                }
                this.lg = lg;
                this.theme = theme;
                this.sources = sources != null ? sources : new List<string>() { ModManager.apiURL + "/mm" };
                this.modStates = modStates != null ? modStates : new List<ModState>() { };
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}