using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public static class ModList
    {
        public static List<ModSource> modSources;

        public static async Task load()
        {
            modSources = new List<ModSource>() { };
            List<Task> tasks = new List<Task>() { };
            foreach (string source in ConfigManager.config.sources)
            {
                tasks.Add(FetchSource(source));
            }
            await Task.WhenAll(tasks);
        }

        public static async Task FetchSource(string source)
        {
            string result = await Download.downloadString(source);
            ModSource modSource = Newtonsoft.Json.JsonConvert.DeserializeObject<ModSource>(result);
            modSources.Add(modSource);
        }

        public static async Task loadReleases()
        {
            List<Task> tasks = new List<Task>() { };
            foreach (ModSource source in modSources)
            {
                foreach (Mod m in source.mods)
                {
                    foreach (ModVersion version in m.versions)
                    {
                        tasks.Add(loadRelease(m, version));
                    }
                }
            }
            await Task.WhenAll(tasks);
        }

        public static async Task loadRelease(Mod m, ModVersion v)
        {
            try
            {
                v.release = await ModManager.githubClient.Repository.Release.Get(m.author, m.github, v.version);
            }
            catch (Exception e) 
            {
                Log.logError("ModList", e.Source, e.Message);
                m.versions.Remove(v);
            }
        }

        public static List<Mod> getAllMods()
        {
            List<Mod> mods = new List<Mod>() { };
            modSources.ForEach(s => mods.FindAll(m => m.type == "mod").ForEach(m => mods.Add(m)));
            return mods;
        }

        public static Mod getModById(string modId)
        {
            foreach (ModSource source in modSources)
            {
                Mod m = source.mods.Find(m => m.id == modId);
                if (m != null) return m;
            }
            return null;
        }

        public static List<Category> getAllCategories()
        {
            List<Category> categories = new List<Category>() { };
            foreach (ModSource source in modSources)
            {
                foreach (Mod mod in source.mods)
                {
                    if (mod.type == "mod" && categories.Find(c => c.id == mod.category.id) == null)
                    {
                        categories.Add(mod.category);
                    }
                }
            }
            categories.Sort((x, y) => x.weight.CompareTo(y.weight));
            return categories;
        }

        public static List<Mod> getModsByCategoryId(string categoryId)
        {
            List<Mod> mods = new List<Mod>() { };
            modSources.ForEach(s => s.mods.FindAll(m => m.type == "mod" && m.category.id == categoryId).ForEach(m => mods.Add(m)));
            return mods;
        }

        public static Category getCategoryById(string categoryId)
        {
            foreach (ModSource source in modSources)
            {
                foreach (Mod mod in source.mods)
                {
                    if (mod.category.id == categoryId)
                    {
                        return mod.category;
                    }
                }
            }
            return null;
        }
    }
}
