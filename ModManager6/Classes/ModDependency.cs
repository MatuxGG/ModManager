using ExCSS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class ModDependency
    {
        [JsonProperty(PropertyName = "modDependency")]
        public string dependency { get; set; }
        [JsonProperty(PropertyName = "modVersion")]
        public string version { get; set; }

        public ModDependency(string dependency = "", string version = "")
        {
            try
            {
                this.dependency = dependency;
                this.version = version;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}
