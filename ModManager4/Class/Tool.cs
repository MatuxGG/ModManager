using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Tool
    {
        public string name;

        public string path;

        public string image;

        public string downloadLink;

        public Tool(string name, string path, string image, string downloadLink)
        {
            this.name = name;
            this.path = path;
            this.image = image;
            this.downloadLink = downloadLink;
        }
    }
}
