using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class ServerConfigLine
    {
        public string id;
        public string value;

        public ServerConfigLine(string id, string value)
        {
            this.id = id;
            this.value = value;
        }
    }
}
