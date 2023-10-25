namespace CopsAndRobbers
{
    public class Prison
    {
        public List<Person> OutOfJail(List<Person> prisoners, List<Person> persons, int[,] mapSize)
        {
            foreach (Person prisoner in prisoners)
            {
                Prisoner prisonerX = (Prisoner)prisoner;
                if (prisonerX.TimeInJail <= 0)
                {
                    persons.Add(new Thief(prisoner.Name, Helpers.GenerateRandomPlacement(mapSize), prisoner.Direction, Item.EmptyList(), false));
                    prisoners.Remove(prisoner);
                }
                else
                {
                    prisonerX.TimeInJail--;
                }
            }
            return persons;
        }
    }
}
