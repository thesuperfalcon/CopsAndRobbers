namespace CopsAndRobbers
{
    public class Prison
    {
        public (List<Person>, List<Person>) OutOfJail(List<Person> prisoners, List<Person> persons, Person prisoner, int[,] mapSize)
        {
            if (prisoner is Thief)
            {
                Thief thief = (Thief)prisoner;
                if (thief.TimeInJail <= 0)
                {
                    thief.Placement = Helpers.GenerateRandomPlacement(mapSize);
                    thief.Arrested = false;
                    thief.Loot = Item.EmptyList();
                    persons.Add(thief);
                    prisoners.Remove(thief);
                }
                else
                {
                    thief.TimeInJail--;
                }
            }
            return (prisoners, persons);
        }
    }
}
