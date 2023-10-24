namespace CopsAndRobbers
{
    public class Prison
    {
        public List<Prison> Prisoners = new List<Prison>();

        public string Name { get; set; }

        public int[] PrisonPlacement { get; set; }

        public int[] PrisonDirection { get; set; }

        public int TimeInPrison { get; set; }

        public Prison(string name, int[] prisonPlacement, int[] prisonDirection, int timeInPrison)
        {
            Name = name;
            PrisonPlacement = prisonPlacement;
            PrisonDirection = prisonDirection;
            TimeInPrison = timeInPrison;

        }
        public List<Person> OutOfJail(List<Prison> prisoners, List<Person> persons, int[,] mapSize)
        {
            List<Prison> prisonersToRemove = new List<Prison>();

            if(prisoners.Count > 0)
            {
                foreach (Prison prisoner in prisoners)
                {
                    if (prisoner.TimeInPrison <= 0)
                    {
                        persons.Add(new Thief(prisoner.Name, Helpers.GenerateRandomPlacement(mapSize), prisoner.PrisonDirection, Item.EmptyList(), false));
                        prisonersToRemove.Add(prisoner);
                        int x = 0;
                    }
                    else
                    {
                        prisoner.TimeInPrison--;
                        int x = 0;
                    }
                }
                foreach( Prison prisonerToRemove in prisonersToRemove)
                {
                    prisoners.Remove(prisonerToRemove);
                }
            }
            return persons;
        }
    }
}
