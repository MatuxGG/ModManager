using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Server
    {
        public string type;

        public string Fqdn;

        public string DefaultIp;

        public int port;

        public string name;

        public int TranslateName;

        public Server(string type, string Fqdn, string DefaultIp, int port, string name, int TranslateName)
        {
            this.type = type;
            this.Fqdn = Fqdn;
            this.DefaultIp = DefaultIp;
            this.port = port;
            this.name = name;
            this.TranslateName = TranslateName;
        }

        public Server()
        {
            this.type = "DnsRegionInfo, Assembly-CSharp";
            this.Fqdn = "";
            this.DefaultIp = "";
            this.port = 22023;
            this.name = "";
            this.TranslateName = 1103;
        }
    }
}
