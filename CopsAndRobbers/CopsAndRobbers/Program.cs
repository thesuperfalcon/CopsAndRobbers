namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int citizenAmount = 10;
            int thiefAmount = 5;
            int policeAmount = 5;

            List<string> updates = new List<string>();

            string[] names = Helpers.NameGenerator();

            Movement movement = new Movement();

            Report report = new Report();

            int[,] mapSize = new int[25, 100];

            int height = mapSize.GetLength(0);
            int width = mapSize.GetLength(1);

            int[] placement = new int[2];

            Map map = new Map();

            List<Person> persons = new List<Person>();

            List<Item> belongings = new List<Item>();

            List<Item> loot = new List<Item>();

            List<Item> confiscated = new List<Item>();

            belongings.AddRange(Item.AllTypesOfObjects());

            for (int i = 1; i <= citizenAmount; i++)
            {
                persons.Add(new Citizen(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), belongings = Item.AllTypesOfObjects(), false));
            }

            for (int i = 1; i <= thiefAmount; i++)
            {
                persons.Add(new Thief(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), loot = Item.EmptyList(), false));
            }

            for (int i = 1; i <= policeAmount; i++)
            {
                persons.Add(new Police(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), confiscated = Item.EmptyList(), false));
            }

            int citizenCount = 0;
            int thiefCount = 0;
            int policeCount = 0;

            foreach (Person person in persons)
            {
                if (person is Citizen)
                {
                    citizenCount++;
                }
                else if (person is Thief)
                {
                    thiefCount++;
                }
                else if (person is Police)
                {
                    policeCount++;
                }
            }

            while (true)
            {
                Console.CursorVisible = false;

                foreach (Person person in persons)
                {
                    int[] newPlacement = Movement.Move(person, mapSize);
                    person.Placement = newPlacement;
                }

                map.DrawMap(mapSize, persons);
                //report.ReportAndUpdates(person);
                //Console.WriteLine();
                //Helpers.CountAllPersons(persons, citizenAmount, thiefAmount, policeAmount);
                //NewsFeed.WriteNewsFeed(updates);
                //Console.WriteLine();
                //Meeting.HandleMeeting(persons, updates);
                //Console.ReadKey();

                Thread.Sleep(200);
                Console.Clear();
            }
        }
    }
}