using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class Translator
    {
        public static List<Language> languages;

        public static void load()
        {
            Utils.log("Load START", "Translator");
            string languagesURL = ModManager.apiURL + "/trans";
            string lg = "";
            try
            {
                using (var client = new WebClient())
                {
                    lg = client.DownloadString(languagesURL);
                }
            }
            catch (Exception e)
            {
                Utils.logE("Load connection FAIL", "Translator");
                Utils.logEx(e, "Translator");
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
            Utils.log(lg, "Translator");
            languages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Language>>(lg);

            Utils.log("Loading " + languages.Count() + " languages", "Translator");
            foreach (Language l in languages)
            {
                l.load();
            }

            if (ConfigManager.globalConfig.lg == "")
            {
                Utils.log("Choosing automatic language", "Translator");
                CultureInfo ci = CultureInfo.InstalledUICulture;
                string curLg = ci.TwoLetterISOLanguageName.ToUpper();
                curLg = languages.Find(l => l.code == curLg) != null ? curLg : "EN";
                Utils.log("New language: " + curLg, "Translator");
                ConfigManager.globalConfig.lg = curLg;
                ConfigManager.updateGlobalConfig();
            }

            Utils.log("Load END", "Translator");
        }

        public static string get(string toTranslate)
        {
            List<Translation> current = languages.Find(l => l.code == ConfigManager.globalConfig.lg).translations;
            Translation tr = current.Find(t => t.original == toTranslate);
            if (tr != null)
            {
                return tr.translation;
            } else
            {
                return toTranslate;
            }
            
        }

        public static string getNameFromCode(string code)
        {
            return languages.Find(l => l.code == code).name;
        }

        public static string getCodeFromName(string name)
        {
            return languages.Find(l => l.name == name).code;
        }
    }
}
