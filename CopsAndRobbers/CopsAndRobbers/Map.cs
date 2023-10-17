using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Map
    {
        public int[,] MapSize {  get; set; }

        public Map(int[,]mapSize)
        {
            MapSize = mapSize;
        }
        public void DrawMap(int[,]mapSize, int[]placement)
        {
            int height = MapSize.GetLength(0);
            int width = MapSize.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(i, 0);
                Border();
                Console.SetCursorPosition(i, width);
                Border();
            }

            for(int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(0, i);
                Border();
                Console.SetCursorPosition(height, i);
                Border();
            }

            for(int row = 0; row < height; row++)
            {
                for(int col = 0; col < width; col++)
                {
                    if(row == placement[0] && col == placement[1])
                    {
                        Console.SetCursorPosition(placement[0], placement[1]);
                        Console.Write("C");
                    }
                }
            }
        }
        public void Border()
        {
            Console.Write("X");
        }
    }
}
