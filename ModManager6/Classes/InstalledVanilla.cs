using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class InstalledVanilla
    {
        public string version;

        public InstalledVanilla(string version = "")
        {
            try
            {
                this.version = version;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}