using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class ModOption
    {
        public string modOption { get; set; }
        public string version { get; set; }

        public ModOption(string modOption = "", string version = "")
        {
            this.modOption = modOption;
            this.version = version;
        }
    }
}
