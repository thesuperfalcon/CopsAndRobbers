using System.Text;

namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movement movement = new Movement();

            int[,] mapSize = new int[100, 25];
            int[] placement = new int[2];

            List<Person> person = new List<Person>();

            List<string> inventory = new List<string>();

            Citizen citizen1 = new Citizen(new int[2] {50, 15} , new int[2] { 1, 1 }, inventory);

            Map map = new Map(mapSize);

            while (true)
            {
                
                Console.SetCursorPosition(110, 10);
                Console.WriteLine($"{citizen1.Placement[0]} {citizen1.Placement[1]}");
                map.DrawMap(mapSize, citizen1.Placement);
                Thread.Sleep(100);
                int[] newPlacement = Movement.Move(citizen1.Placement, mapSize);
                newPlacement = placement;
                Console.Clear();
            }
            
        }
    }
}