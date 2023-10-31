namespace CopsAndRobbers
{
    internal class MovementV2
    {
        public static int[] Movement(Person person, int[,] size)
        {
            int speed = 1;
            int mapHeight = size.GetLength(0);
            int mapWidth = size.GetLength(1);

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
    }
}
