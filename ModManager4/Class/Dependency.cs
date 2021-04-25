using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Dependency
    {
        public string name { get; set; }
    
        public Dependency(string name)
        {
            this.name = name;
        }
    }
}
