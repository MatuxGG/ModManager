using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class Dependency
    {
        [JsonProperty(PropertyName = "sId")]
        public string id;
        public string name;
        public string file;

        public Dependency(string id, string name, string file)
        {
            this.id = id;
            this.name = name;
            this.file = file;
        }
    }
}
