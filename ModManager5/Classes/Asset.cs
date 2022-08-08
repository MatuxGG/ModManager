using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager5.Classes
{
    public static class Asset
    {
        public static void equals(object a, object b)
        {
            if (a.Equals(b) == false)
            {
                Utils.logE("Assert error: Not equals (" + a.ToString() + " & " + b.ToString() + ")", "Assert");
            }
        }

        public static void exist(object a)
        {
            if (a == null)
            {
                Utils.logE("Assert error: Null (" + a.ToString() + ")", "Assert");
            }
        }

        public static void notEmpty(List<Object> a)
        {
            if (a == null || a.Count() == 0)
            {
                Utils.logE("Assert error: Empty (" + (a != null ? a.ToString() : "null") + ")", "Assert");
            }
        }

        public static void notHere(string text)
        {
            if (text == null)
            {
                Utils.logE("Assert error: Not here (" + text + ")", "Assert");
            }
        }


    }
}
