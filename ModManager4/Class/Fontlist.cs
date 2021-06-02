using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Fontlist
    {
        public float sizeS;
        public float sizeM;
        public float sizeL;
        public float sizeXL;

        public Fontlist(int height)
        {
            sizeS = 18 - (int)((1600 - height) / 100);
            sizeM = 20 - (int)((1600 - height) / 100);
            sizeL = 22 - (int)((1600 - height) / 100);
            sizeXL = 28 - (int)((1600 - height) / 50);
        }
    }
}
