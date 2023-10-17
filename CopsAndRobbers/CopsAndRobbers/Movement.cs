using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Movement
    {
        public static int[] Move(int[]placement)
        {
            
            switch(Helpers.Random(1,5))
            {
                case 1:
                    placement[0]++; break;
                case 2:
                    placement[0]--; break;
                case 3:
                    placement[1]--; break;
                case 4:
                    placement[1]--; break;
            }
            return placement;
        }
    }
}
