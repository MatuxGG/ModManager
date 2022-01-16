using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public class Account
    {
        public string login;
        public string admin;
        public string modder;
        public string translator;

        public Account(string login, string admin, string modder, string translator)
        {
            this.login = login;
            this.admin = admin;
            this.modder = modder;
            this.translator = translator;
        }

        public Account()
        {
            this.login = null;
            this.admin = "0";
            this.modder = "0";
            this.translator = "0";
        }
    }
}
