namespace CopsAndRobbers
{
    public class Movement
    {
        public static int[] Move(Person person, int[,] mapSize, int[,] prisonSize, int[,]poorHouseSize)
        {
            int speed = 1;
            int mapHeight = mapSize.GetLength(0);
            int mapWidth = mapSize.GetLength(1);

            int prisonHeight = prisonSize.GetLength(0);
            int prisonWidth = prisonSize.GetLength(1);

            int poorHeight = poorHouseSize.GetLength(0);
            int poorWidth = poorHouseSize.GetUpperBound(0);

            person.Placement[0] += speed * person.Direction[0];
            person.Placement[1] += speed * person.Direction[1];

            if (person is Police)
            {
                if (person.Placement[0] <= 0)
                {
                    person.Placement[0] = mapHeight - 1;
                }
                else if (person.Placement[0] >= mapHeight - 1)
                {
                    person.Placement[0] = 1;
                }
                else if (person.Placement[1] <= 0)
                {
                    person.Placement[1] = mapWidth - 1;
                }
                else if (person.Placement[1] >= mapWidth - 1)
                {
                    person.Placement[1] = 1;
                }
            }

            if (person is Thief)
            {
                Thief thief = (Thief)person;
                if (!thief.Arrested)
                {
                    if (person.Placement[0] <= 0)
                    {
                        person.Placement[0] = mapHeight - 1;
                    }
                    else if (person.Placement[0] >= mapHeight - 1)
                    {
                        person.Placement[0] = 1;
                    }
                    else if (person.Placement[1] <= 0)
                    {
                        person.Placement[1] = mapWidth - 1;
                    }
                    else if (person.Placement[1] >= mapWidth - 1)
                    {
                        person.Placement[1] = 1;
                    }
                }
                else
                {
                    if (person.Placement[0] <= 0)
                    {
                        person.Placement[0] = prisonHeight - 1;
                    }
                    else if (person.Placement[0] >= prisonHeight - 1)
                    {
                        person.Placement[0] = 1;
                    }
                    else if (person.Placement[1] <= 0)
                    {
                        person.Placement[1] = prisonWidth - 1;
                    }
                    else if (person.Placement[1] >= prisonWidth - 1)
                    {
                        person.Placement[1] = 1;
                    }
                }
            }
            if (person is Citizen)
            {
                Citizen citizen = (Citizen)person;
                if (!citizen.IsPoor)
                {
                    if (person.Placement[0] <= 0)
                    {
                        person.Placement[0] = mapHeight - 1;
                    }
                    else if (person.Placement[0] >= mapHeight - 1)
                    {
                        person.Placement[0] = 1;
                    }
                    else if (person.Placement[1] <= 0)
                    {
                        person.Placement[1] = mapWidth - 1;
                    }
                    else if (person.Placement[1] >= mapWidth - 1)
                    {
                        person.Placement[1] = 1;
                    }
                }
                else
                {
                    if (person.Placement[0] <= 0)
                    {
                        person.Placement[0] = poorHeight - 1;
                    }
                    else if (person.Placement[0] >= poorHeight - 1)
                    {
                        person.Placement[0] = 1;
                    }
                    else if (person.Placement[1] <= 0)
                    {
                        person.Placement[1] = poorWidth - 1;
                    }
                    else if (person.Placement[1] >= poorWidth - 1)
                    {
                        person.Placement[1] = 1;
                    }
                }
            }
            return person.Placement;
        }
    }
}
