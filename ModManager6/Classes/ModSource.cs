using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class ModSource
    {
        public string name;
        public bool enabled;
        public List<Mod> mods;

        public ModSource(string name = "", bool enabled = true, List<Mod> mods = null) {
            this.name = name;
            this.enabled = enabled;
            this.mods = mods != null ? mods : new List<Mod>() { };
        }
    }
}
