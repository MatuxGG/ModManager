using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class AccountStat
    {
        public string role;
        public string action;
        public string value;

        public AccountStat(string role, string action, string value)
        {
            this.role = role;
            this.action = action;
            this.value = value;
        }

        public AccountStat()
        {
            this.role = "";
            this.action = "";
            this.value = "";
        }
    }
}
