using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Fontlist(ModManager modManager, int height)
        {
            float ratio;
            Graphics graphics = modManager.CreateGraphics();
            ratio = 4 / (4 + ((graphics.DpiX - 96)/24));

            if (height >= 900)
            {
                sizeXS = (int) (ratio * (16 - (int)((1600 - height) / 100)));
                sizeS = (int) (ratio * (18 - (int)((1600 - height) / 100)));
                sizeM = (int) (ratio * (20 - (int)((1600 - height) / 100)));
                sizeL = (int) (ratio * (22 - (int)((1600 - height) / 100)));
                sizeXL = (int) (ratio * (36 - (int)((1600 - height) / 50)));
            } else
            {
                sizeXS = (int) (ratio * (16 - (int)((1600 - height) / 80)));
                sizeS = (int) (ratio * (18 - (int)((1600 - height) / 80)));
                sizeM = (int) (ratio * (20 - (int)((1600 - height) / 80)));
                sizeL = (int) (ratio * (22 - (int)((1600 - height) / 80)));
                sizeXL = (int) (ratio * (36 - (int)((1600 - height) / 40)));
            }
        }
    }
}
