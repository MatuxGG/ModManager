    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class Category
    {
        public string id;
        public string name;
        public string type;

        public Category(string id, string name, string type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }
    }
}
