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
            sizeS = 10F;
            sizeM = 12F;
            sizeL = 14F;
            sizeXL = 20F;
            if (height == 900)
            {
                sizeS = 12F;
                sizeM = 14F;
                sizeL = 16F;
                sizeXL = 22F;
            }
            else if (height == 1050)
            {
                sizeS = 14F;
                sizeM = 16F;
                sizeL = 18F;
                sizeXL = 24F;
            }
            else if (height == 1200)
            {
                sizeS = 16F;
                sizeM = 18F;
                sizeL = 20F;
                sizeXL = 26F;
            }
            else if (height == 1600)
            {
                sizeS = 18F;
                sizeM = 20F;
                sizeL = 22F;
                sizeXL = 28F;
            }
        }
    }
}
