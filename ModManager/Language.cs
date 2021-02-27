using System.Collections.Generic;
using System;
using System.IO;

namespace ModManager
{
    internal class Language
    {
        public string id;

        public string name;

        public List<string> translations;

        public Language(string id, string name)
        {
            this.id = id;
            this.name = name;
            this.translations = new List<string>();
            string fullPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\files\\translations\\" + id + ".txt";
            FileInfo f = new FileInfo(fullPath);
            if (f.Exists)
            {
                foreach (string line in File.ReadLines(fullPath))
                {
                    this.translations.Add(line.ToString());
                }
            }
        }

        public string get(int id)
        {
            if (id >= this.translations.Count)
            {
                return null;
            }
            return this.translations[id];
        }

    }
}