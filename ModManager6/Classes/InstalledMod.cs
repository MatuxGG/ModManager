using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class InstalledMod
    {
        public string id;
        public string version;

        public InstalledMod(string id = "", string version = "")
        {
            this.id = id;
            this.version = version;
        }
    }
}