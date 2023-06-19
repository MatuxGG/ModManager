using ModManager6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public class Language
    {
        public string code;
        public string name;
        public List<Translation> translations;

        public Language(string code, string name)
        {
            this.code = code;
            this.name = name;
            this.translations = new List<Translation>() { };
        }

        public Language()
        {
            this.code = "";
            this.name = "";
            this.translations = new List<Translation>() { };
        }

        public async Task load()
        {
            string translationsURL = ModManager.apiURL + "/trans/" + this.code;
            string tr = "";
            try
            {
                tr = await Download.downloadString(translationsURL);
            }
            catch (Exception e)
            {
                Log.showError("Language", e.Source, e.Message);
            }
            translations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Translation>>(tr);
        }
    }
}