using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class Dependency
    {
        public string id;
        public string name;
        public string isAvailable;

        public Dependency(string id, string name, string isAvailable)
        {
            this.id = id;
            this.name = name;
            this.isAvailable = isAvailable;
        }
    }
}
