using System.ComponentModel.Design;

namespace CopsAndRobbers
{
    public class Movement
    {
        public static int[] Move(Person person, int[,] mapSize)
        {
            int speed = 1;
            int mapHeight = mapSize.GetLength(0);
            int mapWidth = mapSize.GetLength(1);

            person.Placement[0] += speed * person.Direction[0];
            person.Placement[1] += speed * person.Direction[1];

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
            return person.Placement;
        }
        public static int[] MoveInPrison(Prison prisoner, int[,]prisonSize)
        {
            int speed = 1;
            int prisonHeight = prisonSize.GetLength(0);
            int prisonWidth = prisonSize.GetLength(1);

            prisoner.PrisonPlacement[0] += speed * prisoner.PrisonDirection[0];
            prisoner.PrisonPlacement[1] += speed * prisoner.PrisonDirection[1];

            if (prisoner.PrisonPlacement[0] <= 0)
            {
                prisoner.PrisonPlacement[0] = prisonHeight - 1;
            }
            else if (prisoner.PrisonPlacement[0] >= prisonHeight - 1)
            {
                prisoner.PrisonPlacement[0] = 1;
            }
            else if (prisoner.PrisonPlacement[1] <= 0)
            {
                prisoner.PrisonPlacement[1] = prisonWidth - 1;
            }
            else if (prisoner.PrisonPlacement[1] >= prisonWidth - 1)
            {
                prisoner.PrisonPlacement[1] = 1;
            }
            return prisoner.PrisonPlacement;
        }
    }
}
