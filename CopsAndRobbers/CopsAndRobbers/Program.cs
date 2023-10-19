using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

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

            List<Item> loot = new List<Item>();

            List<Item> confiscated = new List<Item>();

            belongings.AddRange(Item.AllTypesOfObjects());

            for (int i = 1; i <= 10; i++)
            {
                persons.Add(new Citizen(new int[2] { Helpers.Random(1, 99), Helpers.Random(1, 24) }, new int[2] { 1, 1 }, belongings = Item.AllTypesOfObjects()));
            }

            for (int i = 1; i <= 5; i++)
            {
                persons.Add(new Thief(new int[2] { Helpers.Random(1, 99), Helpers.Random(1, 24) }, new int[2] { 1, 1 }, loot = Item.EmptyList(), true));
            }

            for (int i = 1; i <= 5; i++)
            {
                persons.Add(new Police(new int[2] { Helpers.Random(1, 99), Helpers.Random(1, 24) }, new int[2] { 1, 1 }, confiscated = Item.EmptyList(), true));
            }

            int citizenCount = 0;
            int thiefCount = 0;
            int policeCount = 0;


            foreach(Person person in persons)
            {
                if (person is Citizen)
                {
                    citizenCount++;
                }
                else if(person is Thief)
                {
                    thiefCount++;
                }
                else if(person is Police)
                {
                    policeCount++;
                }
            }

            while (true)
            {
                Console.CursorVisible = false;

                int x = 0;

                foreach (Person person in persons)
                {
                    //map.DrawMap(mapSize, person.Placement, person);
                    report.ReportAndUpdates(person);
                    int[] newPlacement = Movement.Move(person.Placement, mapSize);
                    newPlacement = placement;
                }

                Console.WriteLine();
                CountAllPersons(persons);
                Console.WriteLine();
                Meeting.HandleMeeting(persons, mapSize);

                Thread.Sleep(100);
                Console.Clear();
            }
        }
        public static void CountAllPersons(List<Person> persons)
        {

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
            Console.WriteLine($"Citizens: {citizenCount}");
            Console.WriteLine($"Thieves: {thiefCount}");
            Console.WriteLine($"Polices: {policeCount}");
        }
    }
}