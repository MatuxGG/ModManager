using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Page
    {
        public string name;

        public string[] components;
        public Page(string name, string[] components)
        {
            this.name = name;
            this.components = components;
        }
    }
}
