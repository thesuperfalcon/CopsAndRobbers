using System.Text;

namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movement movement = new Movement();

            Report report = new Report();

            int[,] mapSize = new int[100, 25];

            int[] placement = new int[2];

            Map map = new Map(mapSize);

            List<Person> persons = new List<Person>();

            List<Item> belongings = new List<Item>();

            belongings = Item.AllTypesOfObjects();

            List<Item> loot = new List<Item>();

            List<Item> confiscated = new List<Item>();

            for(int i = 0; i <= 0; i++)
            {
                persons.Add(new Citizen(new int[2] { 1, 1 }, new int[2] { 1, 1 }, belongings));
                persons.Add(new Citizen(new int[2] { 6, 3 }, new int[2] { 1, 1 }, belongings));
            }

            for (int i = 0; i <= 0; i++)
            {
                persons.Add(new Thief(new int[2] { 1, 1 }, new int[2] { 1, 1 }, loot, true));
                persons.Add(new Thief(new int[2] { 5, 3 }, new int[2] { 1, 1 }, loot, true));
               
            }

            //for(int i = 0; i <= 10; i++)
            //{
            //    persons.Add(new Citizen(new int[2] { Helpers.Random(1, 99), Helpers.Random(1, 24) }, new int[2] { 1, 1 }, belongings));
            //}

            //for(int i = 0; i <= 5; i++)
            //{
            //    persons.Add(new Thief(new int[2] { Helpers.Random(1, 99), Helpers.Random(1, 24) }, new int[2] { 1, 1 }, loot, true));
            //}

            //for (int i = 0; i <= 5; i++)
            //{
            //    persons.Add(new Police(new int[2] { Helpers.Random(1, 99), Helpers.Random(1, 24) }, new int[2] { 1, 1 }, confiscated, true));
            //}

            while (true)
            {
                Console.CursorVisible = false;

                Meeting.HandleMeeting(persons, mapSize);

                foreach (Person person in persons)
                {
                    //map.DrawMap(mapSize, person.Placement, person);
                    report.ReportAndUpdates(person);
                    //Meeting.HandleMeeting(persons, mapSize);
                    //int[] newPlacement = Movement.Move(person.Placement, mapSize);
                    //newPlacement = placement;
                }
                int x = 0;
                Console.ReadLine();
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}