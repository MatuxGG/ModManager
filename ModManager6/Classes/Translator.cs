using ModManager6;
using Octokit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public static class Translator
    {
        public static List<Language> languages;

        public static async Task load()
        {
            string languagesURL = ModManager.apiURL + "/trans";
            string lg = "";
            try
            {
                lg = await Downloader.downloadString(languagesURL);
            }
            catch (Exception e)
            {
                Log.showError("Translator", e.Source, e.Message);
            }
            languages = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Language>>(lg);

            List<Task> tasks = new List<Task>() { };
            foreach (Language l in languages)
            {
                Task t = l.load();
                tasks.Add(t);
            }
            await Task.WhenAll(tasks);


            if (ConfigManager.config.lg == null)
            {
                setLg();
            }

        }

        public static void setLg()
        {
            try
            {
                CultureInfo ci = CultureInfo.InstalledUICulture;
                string curLg = ci.TwoLetterISOLanguageName.ToUpper();
                curLg = languages.Find(l => l.code == curLg) != null ? curLg : "EN";
                ConfigManager.config.lg = curLg;
                ConfigManager.update();
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static string get(string toTranslate)
        {
            try
            {
                List<Translation> current = languages.Find(l => l.code == ConfigManager.config.lg).translations;
                Translation tr = current.Find(t => t.original == toTranslate);
                if (tr != null)
                {
                    return tr.translation;
                }
                else
                {
                    return toTranslate;
                }
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }

        }

        public static string getNameFromCode(string code)
        {
            try
            {
                return languages.Find(l => l.code == code).name;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }

        public static string getCodeFromName(string name)
        {
            try
            {
                return languages.Find(l => l.name == name).code;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }
    }
}