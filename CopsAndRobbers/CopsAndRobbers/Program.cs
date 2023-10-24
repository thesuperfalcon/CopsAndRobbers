namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int citizenAmount = 20;
            int thiefAmount = 10;
            int policeAmount = 10;

            List<string> updates = new List<string>();

            string[] names = Helpers.NameGenerator();

            Movement movement = new Movement();

            Helpers helper = new Helpers();

            Report report = new Report();

            int[,] mapSize = new int[25, 100];

            int[,] prisonSize = new int[10, 10];   

            int height = mapSize.GetLength(0);
            int width = mapSize.GetLength(1);

            int[] placement = new int[2];

            Prison prison = new Prison("", new int[] { 0, 0 }, new int[] {0,0}, 0);

            Map map = new Map();

            List<Prison> prisoners = new List<Prison>();

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

            bool showMap = true;

            while (true)
            {
                Console.CursorVisible = false;

                foreach (Person person in persons)
                {
                    int[] newPlacement = Movement.Move(person, mapSize);
                    person.Placement = newPlacement;
                }
                foreach(Prison prisoner in prisoners)
                {
                    int[] newPlacement = Movement.MoveInPrison(prisoner, prisonSize);
                    prisoner.PrisonPlacement = newPlacement;
                }

                //prison.OutOfJail(prisoners, persons, mapSize);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();


                    switch (key.KeyChar)
                    {
                        case 'm':
                            showMap = true;
                            continue;
                        case 'r':
                            showMap = false;
                            continue;
                    }
                }
                if(showMap == true)
                {
                    map.DrawMap(mapSize, prisonSize, persons, prisoners);
                    Helpers.CountAllPersons(persons, prisoners, citizenAmount, thiefAmount, policeAmount);
                    NewsFeed.WriteNewsFeed(updates);
                    Meeting.HandleMeeting(persons, updates, prisoners, prisonSize);
                    prison.OutOfJail(prisoners, persons, mapSize);
                }
                else
                {
                    foreach (Person person in persons)
                    {
                        report.ReportAndUpdates(person);
                    }
                    Helpers.CountAllPersons(persons, prisoners, citizenAmount, thiefAmount, policeAmount);
                    NewsFeed.WriteNewsFeed(updates);
                    Meeting.HandleMeeting(persons, updates, prisoners, prisonSize);
                    prison.OutOfJail(prisoners, persons, mapSize);
                }
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}