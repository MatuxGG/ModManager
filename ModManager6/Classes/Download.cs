using Fizzler;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public class Download
    {
        public static ModManager thisModManager;
        public static Boolean finished;
        public static string thisSentence;
        public static int thisOffset;
        public static int thisPercent;

        public static void load(ModManager modManager)
        {
            thisModManager = modManager;
        }

        public static async Task<String> downloadString(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Log.logError("ModManager", "Http Error", response.StatusCode.ToString());
                }
            }
            return "";
        }

        public static async Task<bool> downloadPath(string url, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    File.Delete(path);
                    File.WriteAllText(path, result);
                    return true;
                }
                else
                {
                    Log.logError("ModManager", "Http Error", response.StatusCode.ToString());
                }
            }
            return false;
        }
    }
}
