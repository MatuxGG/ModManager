using ExCSS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class Server
    {
        [JsonProperty(PropertyName = "$type")]
        public string type;

        public string Fqdn;

        public string DefaultIp;

        public int port;

        public string name;

        public int TranslateName;

        public Server(string type, string Fqdn, string DefaultIp, int port, string name, int TranslateName)
        {
            try
            {
                this.type = type;
                this.Fqdn = Fqdn;
                this.DefaultIp = DefaultIp;
                this.port = port;
                this.name = name;
                this.TranslateName = TranslateName;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public Server()
        {
            try
            {

                this.type = "DnsRegionInfo, Assembly-CSharp";
                this.Fqdn = "";
                this.DefaultIp = "";
                this.port = 22023;
                this.name = "";
                this.TranslateName = 1103;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}
