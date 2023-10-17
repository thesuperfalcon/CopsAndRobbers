using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Movement
    {
        public static int[] Move(int[]placement, int [,]mapSize)
        {
            int height = mapSize.GetLength(0);
            int width = mapSize.GetLength(1);
            for (int row = 0; row < height; row++)
            {
                for(int col = 0; col < width; col++)
                {
                    if (placement[0] == 1 || placement[0] == 99)
                    {
                        placement[0] = (placement[0] + height) % height;
                    }
                }
            }
           // placement[0] = (placement[0] + height) % height;
            placement[1] = (placement[1] + width) % width;
            int x = 0;

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.KeyChar)
            {
                case 'w':
                    placement[1]--; break;
                case 's':
                    placement[1]++; break;
                case 'a':
                    placement[0]--; break;
                case 'd':
                    placement[0]++; break;
            }
            

            //int num = Helpers.Random(1, 100);
            //if (num <= 20)
            //{
            //    placement[0]++;
            //}
            //else if (num > 20 && num <= 40)
            //{
            //    placement[0]--;
            //}
            //else if(num > 40 && num <= 60)
            //{
            //    placement[1]++;
            //}
            //else
            //{
            //    placement[1]--;
            //}
            //{
            //    case num < 20:
            //        placement[0]++; break;
            //    case 2:
            //        placement[0]--; break;
            //    case 3:
            //        placement[1]--; break;
            //    case 4:
            //        placement[1]--; break;
            //}
            return placement;
        }
    }
}
