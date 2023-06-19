using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class Translation
    {
        public string original;
        public string translation;

        public Translation(string original, string translation)
        {
            this.original = original;
            this.translation = translation;
        }

        public Translation()
        {
            this.original = "";
            this.translation = "";
        }

    }
}