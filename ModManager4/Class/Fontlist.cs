using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager4.Class
{
    public class Fontlist
    {
        public float sizeXS;
        public float sizeS;
        public float sizeM;
        public float sizeL;
        public float sizeXL;

        public Fontlist(int height)
        {
            if (height >= 900)
            {
                sizeXS = 16 - (int)((1600 - height) / 100);
                sizeS = 18 - (int)((1600 - height) / 100);
                sizeM = 20 - (int)((1600 - height) / 100);
                sizeL = 22 - (int)((1600 - height) / 100);
                sizeXL = 36 - (int)((1600 - height) / 50);
            } else
            {
                sizeXS = 16 - (int)((1600 - height) / 80);
                sizeS = 18 - (int)((1600 - height) / 80);
                sizeM = 20 - (int)((1600 - height) / 80);
                sizeL = 22 - (int)((1600 - height) / 80);
                sizeXL = 36 - (int)((1600 - height) / 40);
            }
        }
    }
}
