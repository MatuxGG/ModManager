using ExCSS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class Category
    {
        [JsonProperty(PropertyName = "sId")]
        public string id;
        public string name;
        public int weight;

        public Category(string id = "", string name = "", int weight = 0)
        {
            try
            {
                this.id = id;
                this.name = name;
                this.weight = weight;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
    }
}
