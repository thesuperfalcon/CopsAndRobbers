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
            int speed = 1;
            int height = mapSize.GetLength(0);
            int width = mapSize.GetLength(1);
            for (int row = 0; row < width; row++)
            {
                for(int col = 0; col < height; col++)
                {
                    if (placement[0] <= 0) //if direction[0] == -1 && direction[1] == 0
                    {
                        placement[0] = width - 1;
                    }
                    if (placement[0] >= width)
                    {
                        placement[0] = 1;
                    }
                    if (placement[1] <= 0)
                    {
                        placement[1] = height - 1;
                    }
                    if (placement[1] >= height)
                    {
                        placement[1] = 1;
                    }
                }
            }
            int num = Helpers.Random(0, 160);
            if (num <= 20)
            {
                placement[0]+=speed;
            }
            else if (num > 20 && num <= 40)
            {
                placement[0]-=speed;
            }
            else if (num > 40 && num <= 60)
            {
                placement[1]+=speed;
            }
            else if( num > 60 && num <= 80)
            {
                placement[1]-=speed;
            }
            else if (num > 80 && num <= 100)
            {
                placement[0]-=speed;
                placement[1]-=speed;
            }
            else if (num > 100 && num <= 120)
            {
                placement[0]+=speed;
                placement[1]+=speed;
            }
            else if (num > 120 && num <= 140)
            {
                placement[0] += speed;
                placement[1] -= speed;
            }
            else if (num > 140 && num <= 160)
            {
                placement[0] -= speed;
                placement[1] += speed;
            }
            return placement;
        }
    }
}
