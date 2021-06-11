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

        public string image;

        public string downloadLink;

        public string type;

        public bool installer;

        public string author;

        public string repository;

        public string appFile;

        public Tool(string name, string image, string downloadLink, string type, bool installer, string author, string repository, string appFile)
        {
            this.name = name;
            this.image = image;
            this.downloadLink = downloadLink;
            this.type = type;
            this.installer = installer;
            this.repository = repository;
            this.appFile = appFile;
        }
    }
}
