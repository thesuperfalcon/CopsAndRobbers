namespace CopsAndRobbers
{
    public class Movement
    {
        public static int[] Move(Person person, int[,] mapSize)
        {
            int speed = 1;
            int height = mapSize.GetLength(0);
            int width = mapSize.GetLength(1);

            person.Placement[0] += speed * person.Direction[0];
            person.Placement[1] += speed * person.Direction[1];

            if (person.Placement[0] <= 0)
            {
                person.Placement[0] = height - 1;
            }
            if (person.Placement[0] >= height - 1)
            {
                person.Placement[0] = 1;
            }
            if (person.Placement[1] <= 0)
            {
                person.Placement[1] = width - 1;
            }
            if (person.Placement[1] >= width - 1)
            {
                person.Placement[1] = 1;
            }

            return person.Placement;
        }
    }
}
