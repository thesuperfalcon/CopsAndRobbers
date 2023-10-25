namespace CopsAndRobbers
{
    public class Prison
    {
        public List<Person> OutOfJail(List<Person> persons, int[,] mapSize)
        {
            foreach (Person person in persons) 
            {
                if (person is Thief)
                {

                    Thief thief = (Thief)person;
                    if (thief.TimeInJail <= 0)
                    {
                        thief.Placement = Helpers.GenerateRandomPlacement(mapSize);
                        thief.Arrested = false;
                    }
                    else
                    {
                        thief.TimeInJail--;
                    }
                }
            }
            return persons;
        }
    }
}
