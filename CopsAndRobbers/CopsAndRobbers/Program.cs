using System;

namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int citizenAmount = 12;
            int thiefAmount = 10;
            int policeAmount = 7;

            List<string> updates = new List<string>();

            string[] names = Helpers.NameGenerator();

            MovementV2 movementV2 = new MovementV2();

            Helpers helper = new Helpers();

            Report report = new Report();

            int[,] mapSize = new int[25, 100];

            int[,] prisonSize = new int[10, 10];

            int[,] poorHouseSize = new int[10, 35];

            int height = mapSize.GetLength(0);
            int width = mapSize.GetLength(1);

            int[] placement = new int[2];

            Prison prison = new Prison();

            DrawMap drawMap = new DrawMap();

            List<Person> persons = new List<Person>();

            List<Person> prisoners = new List<Person>();

            List<Person> poorGuys = new List<Person>();

            List<Item> belongings = new List<Item>();

            List<Item> loot = new List<Item>();

            List<Item> confiscated = new List<Item>();

            belongings.AddRange(Item.AllTypesOfObjects());

            for (int i = 1; i <= citizenAmount; i++)
            {
                persons.Add(new Citizen(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), belongings = Item.AllTypesOfObjects(), false, false));
            }

            for (int i = 1; i <= thiefAmount; i++)
            {
                persons.Add(new Thief(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), loot = Item.EmptyList(), false, 0));
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

                    int[] newPlacement = MovementV2.Movement(person, mapSize);
                    person.Placement = newPlacement;
                }
                foreach(Person prisoner in prisoners)
                {
                    int[] newPlacement = MovementV2.Movement(prisoner, prisonSize);
                    prisoner.Placement = newPlacement;
                }
                foreach (Person poorGuy in poorGuys)
                {
                    int[] newPlacement = MovementV2.Movement(poorGuy, poorHouseSize);
                    poorGuy.Placement = newPlacement;
                }


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
                        case 'c':
                            persons.Add(new Citizen(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), belongings = Item.AllTypesOfObjects(), false, false));
                            citizenAmount++;
                            break;
                        case 't':
                            persons.Add(new Thief(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), loot = Item.EmptyList(), false, 0));
                            thiefAmount++;
                            break;
                        case 'p':
                            persons.Add(new Police(names[Helpers.Random(0, names.Length)], Helpers.GenerateRandomPlacement(mapSize), Helpers.GenerateRandomDirection(), confiscated = Item.EmptyList(), false));
                            policeAmount++;
                            break;
                    }
                }
                if (showMap == true)
                {
                    drawMap.DrawMapV2(mapSize, persons, "City");
                    drawMap.DrawMapV2(prisonSize, prisoners, "Jail");
                    drawMap.DrawMapV2(poorHouseSize, poorGuys, "Poor-house");
                    Helpers.CountAllPersons(persons, prisoners, poorGuys, citizenAmount, thiefAmount, policeAmount);
                    NewsFeed.WriteNewsFeed(updates);
                    (prisoners, poorGuys, persons) = Meeting.HandleMeeting(persons, prisoners, poorGuys, updates, prisonSize, poorHouseSize, mapSize);
                    if (prisoners.Count > 0)
                    {
                        foreach (Person prisoner in prisoners.ToList())
                        {
                            (prisoners, persons) = prison.OutOfJail(prisoners, persons, prisoner, mapSize);
                        }
                    }
                }
                else
                {
                    report.ReportAndUpdates(persons, prisoners, poorGuys);
                    Helpers.CountAllPersons(persons, prisoners, poorGuys, citizenAmount, thiefAmount, policeAmount);
                    NewsFeed.WriteNewsFeed(updates);
                    (prisoners, poorGuys, persons) = Meeting.HandleMeeting(persons, prisoners, poorGuys, updates, prisonSize, poorHouseSize, mapSize);
                    if (prisoners.Count > 0)
                    {
                        foreach (Person prisoner in prisoners.ToList())
                        {
                            (prisoners, persons) = prison.OutOfJail(prisoners, persons, prisoner, mapSize);
                        }
                    }
                }
                Thread.Sleep(50);
                Console.Clear();
            }
        }
    }
}