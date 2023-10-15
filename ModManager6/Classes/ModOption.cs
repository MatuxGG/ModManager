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
        public string gameVersion { get; set; }

        public ModOption(string modOption = "", string gameVersion = "")
        {
            try
            {
                this.modOption = modOption;
                this.gameVersion = gameVersion;
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}
