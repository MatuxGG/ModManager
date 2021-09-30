using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class News
    {
        public int id;
        public string name;
        public string content;
        public string date;

        public News (int id, string name, string content, string date)
        {
            this.id = id;
            this.name = name;
            this.content = content;
            this.date = date;
        }
    }
}
