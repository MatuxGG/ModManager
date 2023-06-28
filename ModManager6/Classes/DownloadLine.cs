using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class DownloadLine
    {
        public string source { get; set; }
        public string target { get; set; }

        public long size { get; set; }
        public DownloadLine(string source, string target)
        {
            this.source = source;
            this.target = target;
        }

    }
}
