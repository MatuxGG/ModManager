using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class ConfigLine
    {
        public string id;
        public string value;

        public ConfigLine(string id, string value)
        {
            this.id = id;
            this.value = value;
        }
    }
}
