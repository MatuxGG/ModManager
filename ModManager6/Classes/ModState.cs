using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class ModState
    {
        public string modId { get; set; } // Current selected mod
        public string version { get; set; } // Current selected version
        public List<ModOption> options { get; set; } // Current selected options

        public ModState(string modId, string version, List<ModOption> options)
        {
            this.modId = modId;
            this.version = version;
            this.options = options;
        }
    }
}
