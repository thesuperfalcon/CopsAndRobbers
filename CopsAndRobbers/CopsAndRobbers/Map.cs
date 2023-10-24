namespace CopsAndRobbers
{
    internal class Map
    {
        public void DrawMap(int[,] map, int[,] prisonSize, List<Person> persons, List<Prison> prisoners)
        {
            Console.Clear();

            int height = map.GetLength(0);
            int width = map.GetLength(1);

            for (int row = 0; row <= height; row++)
            {
                for (int col = 0; col <= width; col++)
                {
                    bool isPersonHere = false;
                    foreach (Person person in persons)
                    {
                        if (row == person.Placement[0] && col == person.Placement[1])
                        {
                            Console.Write((person is Citizen) ? "C" : (person is Thief) ? "T" : (person is Police) ? "P" : " ");
                            isPersonHere = true;
                            break;
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
            Console.WriteLine();
            int prisonHeight = prisonSize.GetLength(0);
            int prisonWidth = prisonSize.GetLength(1);

            for (int row = 0; row <= prisonHeight; row++)
            {
                for (int col = 0; col <= prisonWidth; col++)
                {
                    bool isPersonInPrison = false;
                    foreach(Prison prisoner in prisoners)
                    {
                        if(row == prisoner.PrisonPlacement[0] && col == prisoner.PrisonPlacement[1])
                        {
                            Console.Write("T");
                            isPersonInPrison = true;
                        }
                    }
                    if (!isPersonInPrison)
                    {
                        if (row == 0 || col == 0 || row == prisonHeight || col == prisonWidth)
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


