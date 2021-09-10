using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }

        public string type { get; set; }

        public Category(string id, string name, string type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }
    }
}
