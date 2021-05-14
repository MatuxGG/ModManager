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

        public string type;

        public string installMethod;

        public string author;

        public string repository;

        public string installFile;

        public string appFile;

        public Tool(string name, string path, string image, string downloadLink, string type, string installMethod, string author, string repository, string installFile, string appFile)
        {
            this.name = name;
            this.path = path;
            this.image = image;
            this.downloadLink = downloadLink;
            this.type = type;
            this.installMethod = installMethod;
            this.repository = repository;
            this.installFile = installFile;
            this.appFile = appFile;
        }
    }
}
