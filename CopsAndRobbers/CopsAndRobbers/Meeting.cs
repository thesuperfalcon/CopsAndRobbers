namespace CopsAndRobbers
{
    public class Meeting
    {
        public static void HandleMeeting(List<Person> persons, int[,] mapSize)
        {
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        for (int x = i; x < matrix.GetLength(0); x++)
            //        {
            //            for (int y = (x == i ? j + 1 : 0); y < matrix.GetLength(1); y++)
            //            {
            //                if (matrix[i, j] == matrix[x, y])
            //                { }
            for (int i = 0; i < persons.Count; i++)
            {
                for (int j = i + 1; j < persons.Count; j++)
                {
                    Person person1 = persons[i];
                    Person person2 = persons[j];

                    if (person1.Placement[0] == person2.Placement[0] && person1.Placement[1] == person2.Placement[1])
                    {
                        if (person1 is Thief && person2 is Citizen)
                        {
                            //Console.WriteLine("Tjuv möter medborgare");
                            Thief thief1 = (Thief)person1;
                            Citizen citizen1 = (Citizen)person2;

                            int randomIndex = Helpers.Random(0, citizen1.Belongings.Count);
                            Item stoleItem = citizen1.Belongings[randomIndex];

                            thief1.Loot.Add(stoleItem);

                            citizen1.Belongings.RemoveAt(randomIndex);
                        }
                        else if (person1 is Citizen && person2 is Thief)
                        {
                            Citizen citizen1 = (Citizen)person1;
                            Thief thief1 = (Thief)person2;

                            int randomIndex = Helpers.Random(0, citizen1.Belongings.Count);
                            Item stoleItem = citizen1.Belongings[randomIndex];

                            thief1.Loot.Add(stoleItem);

                            citizen1.Belongings.RemoveAt(randomIndex);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
