using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class InstalledVanilla
    {
        public string version;

        public InstalledVanilla(string version)
        {
           this.version = version;
        }
        public InstalledVanilla()
        {
            this.version = "";
        }
    }
}
