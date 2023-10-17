using System.Text;

namespace CopsAndRobbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movement movement = new Movement();

            int[,] mapSize = new int[100, 25];
            int[] placement = new int[2] {10,10};

            List<Person> person = new List<Person>();

            List<string> inventory = new List<string>();

            Citizen citizen1 = new Citizen(new int[2] , new int[2] { 1, 1 }, inventory);

            Map map = new Map(mapSize);

            while (true)
            {
                
                Console.SetCursorPosition(110, 10);
                Console.WriteLine($"{placement[0]} {placement[1]}");
                map.DrawMap(mapSize, placement);
                
                int[] newPlacement = Movement.Move(placement, mapSize);
                newPlacement = placement;
                
                
                Console.ReadKey();
                Console.Clear();
            }
            
        }
    }
}