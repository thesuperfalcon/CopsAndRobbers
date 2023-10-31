using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class DrawMap
    {
        public void DrawMapV2(int[,]size, List<Person> persons)
        {
            int height = size.GetLength(0);
            int width = size.GetLength(1);

            for (int row = 0; row <= height; row++)
            {
                for (int col = 0; col <= width; col++)
                {
                    bool isPersonHere = false;
                    foreach (Person person in persons)
                    {
                        if (row == person.Placement[0] && col == person.Placement[1])
                        {
                            if(person is Citizen)
                            {
                                Console.Write("C");
                                // console.foregroundcolor = consolecolor.green
                                isPersonHere = true;
                                break;
                            }
                            else if (person is Police)
                            {
                                Console.Write("P");
                                // console.foregroundcolor = consolecolor.blue
                                isPersonHere = true;
                                break;
                            }
                            else if (person is Thief)
                            {
                                Console.Write("T");
                                // console.foregroundcolor = consolecolor.red
                                isPersonHere = true;
                                break;
                            }
                        }
                    }
                    if (!isPersonHere)
                    {
                        if (row == 0 || col == 0 || row == height || col == width)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
