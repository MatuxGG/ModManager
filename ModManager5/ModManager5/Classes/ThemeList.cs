using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public static class ThemeList
    {
        public static Theme theme;
        public static List<Theme> availableThemes;

        public static void load()
        {
            availableThemes = new List<Theme>() { };

            string path = ModManager.appDataPath + @"\themes";

            if (!File.Exists(path + @"\dark.txt"))
            {
                Theme dark = new Theme() { };
                dark.name = "dark";

                dark.TitleFont = "Arial";
                dark.SubTitleFont = "Arial";
                dark.XLFont = "Arial";
                dark.MFont = "Arial";

                dark.TitleSize = 36;
                dark.SubTitleSize = 20;
                dark.XLSize = 14;
                dark.MSize = 12;

                dark.MenuBackgroundColor = Color.FromArgb(17, 7, 30);
                dark.MenuButtonsColor = Color.FromArgb(17, 7, 21);
                dark.MenuSubButtonsColor = Color.FromArgb(44, 57, 55);
                dark.StatusBarColor = Color.FromArgb(24, 22, 36);
                dark.AppBackgroundColor = Color.FromArgb(33, 31, 46);
                dark.AppOverlayColor = Color.FromArgb(28, 26, 37);
                dark.ButtonsColor = Color.FromArgb(19, 16, 29);
                dark.TextColor = Color.White;

                string json = JsonConvert.SerializeObject(dark);
                File.WriteAllText(path + @"\dark.txt", json);
            }

            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles();

            foreach(FileInfo f in files)
            {
                if (f.Name != "theme.conf")
                {
                    string json = System.IO.File.ReadAllText(f.FullName);
                    Theme t = Newtonsoft.Json.JsonConvert.DeserializeObject<Theme>(json);
                    availableThemes.Add(t);
                }
            }

            string confPath = path + @"\theme.conf";

            if (!File.Exists(confPath))
            {
                File.WriteAllText(confPath, "dark");
                theme = availableThemes.Find(t => t.name == "dark");
            } else
            {
                string name = File.ReadAllText(confPath);
                theme = availableThemes.Find(t => t.name == name);
                if (theme == null)
                {
                    File.WriteAllText(confPath, "dark");
                    theme = availableThemes.Find(t => t.name == "dark");
                }
            }

        }

        public static void useTheme(string name)
        {
            theme = availableThemes.Find(t => t.name == name);
        }
    }
}
