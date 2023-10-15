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
        public string gameVersion { get; set; } // Current selected version
        public List<ModOption> options { get; set; } // Current selected options

        public ModState(string modId, string gameVersion, List<ModOption> options)
        {
            try
            {
                this.modId = modId;
                this.gameVersion = gameVersion;
                this.options = options;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}
