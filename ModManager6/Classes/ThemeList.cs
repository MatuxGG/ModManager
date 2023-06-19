using ModManager6.Classes;
using ModManager6;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public static class ThemeList
    {
        public static Theme theme;
        public static List<Theme> availableThemes;

        public static void load()
        {
            availableThemes = new List<Theme>() { };

            string path = ModManager.appDataPath + @"\themes";

            addDefaultTheme(new Theme("Dark", "Arial", "Arial", "Arial", "Arial", 36, 20, 14, 12,
                Color.FromArgb(17, 7, 30), Color.FromArgb(17, 7, 21), Color.FromArgb(44, 57, 55), Color.FromArgb(24, 22, 36),
                Color.FromArgb(33, 31, 46), Color.FromArgb(28, 26, 37), Color.FromArgb(19, 16, 29), Color.White, Color.FromArgb(17, 7, 21)));

            addDefaultTheme(new Theme("Light", "Arial", "Arial", "Arial", "Arial", 36, 20, 14, 12,
                 Color.FromArgb(220, 192, 255), Color.FromArgb(177, 116, 255), Color.FromArgb(151, 67, 255), Color.FromArgb(132, 115, 255),
                 Color.FromArgb(162, 149, 255), Color.FromArgb(111, 91, 255), Color.FromArgb(31, 0, 255), Color.White, Color.FromArgb(177, 116, 255)));

            addDefaultTheme(new Theme("Discord", "Sansation Regular", "Sansation Regular", "Sansation Regular", "Sansation Regular", 36, 20, 14, 12,
                Color.FromArgb(47, 49, 54), Color.FromArgb(47, 49, 54), Color.FromArgb(57, 60, 67), Color.FromArgb(64, 68, 75),
                Color.FromArgb(54, 57, 63), Color.FromArgb(32, 34, 37), Color.FromArgb(41, 43, 47), Color.FromArgb(136, 140, 144), Color.FromArgb(47, 49, 54)));

            addDefaultTheme(new Theme("Pink", "Sansation Regular", "Sansation Regular", "Sansation Regular", "Sansation Regular", 36, 20, 14, 12,
                Color.FromArgb(255, 204, 223), Color.FromArgb(195, 121, 148), Color.FromArgb(255, 164, 197), Color.FromArgb(255, 204, 223),
                Color.FromArgb(240, 154, 179), Color.FromArgb(195, 121, 148), Color.FromArgb(195, 121, 148), Color.White, Color.FromArgb(240, 154, 179)));

            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles();

            foreach (FileInfo f in files)
            {
                string json = System.IO.File.ReadAllText(f.FullName);
                Theme t = Newtonsoft.Json.JsonConvert.DeserializeObject<Theme>(json);
                availableThemes.Add(t);
            }

            theme = availableThemes.Find(t => t.name == ConfigManager.config.theme);
            if (theme == null)
            {
                theme = availableThemes.Find(t => t.name == "Dark");
                ConfigManager.config.theme = "Dark";
                ConfigManager.update();
            }
        }

        private static void addDefaultTheme(Theme t)
        {
            string path = ModManager.appDataPath + @"\themes\" + t.name + ".txt";

            if (File.Exists(path))
            {
                FileSystem.FileDelete(path);
            }

            string json = JsonConvert.SerializeObject(t);
            File.WriteAllText(path, json);
        }

        public static void useTheme(string name)
        {
            theme = availableThemes.Find(t => t.name == name);
        }
    }
}