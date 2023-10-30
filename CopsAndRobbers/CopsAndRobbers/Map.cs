namespace CopsAndRobbers
{
    internal class Map
    {
        public void DrawMap(int[,] map, int[,] prisonSize, int[,] poorHouseSize, List<Person> persons)
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
                    foreach (Person person in persons)
                    {
                        if (person is Thief)
                        {
                            Thief thief = (Thief)person;
                            if (thief.Arrested)
                            {
                                if (row == thief.Placement[0] && col == thief.Placement[1])
                                {
                                    Console.Write("T");
                                    isPersonInPrison = true;
                                }
                            }
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
            Console.WriteLine();
            int poorHouseHeight = poorHouseSize.GetLength(0);
            int poorHouseWidth = poorHouseSize.GetLength(1);

            for(int row = 0; row <= prisonHeight; row++)
            {
                for(int col = 0; col <= prisonWidth; col++)
                {
                    bool isPersonInPoorHouse = false;
                    foreach(Person person in persons)
                    {
                        if(person is Citizen)
                        {
                            Citizen citizen = (Citizen)person;
                            if(citizen.IsPoor)
                            {
                                if(row == citizen.Placement[0] && col == citizen.Placement[1])
                                {
                                    Console.Write("C");
                                    isPersonInPoorHouse = true;
                                }
                            }
                        }
                    }
                    if(!isPersonInPoorHouse)
                    {
                        if (row == 0 || col == 0 || row == poorHouseHeight || col == poorHouseWidth)
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


