namespace CopsAndRobbers
{
    public class Helpers
    {
        public static int Random(int i, int j)
        {
            Random rnd = new Random();
            int x = rnd.Next(i, j);
            return x;
        }
        public static void CountAllPersons(List<Person> persons, List<Person> prisoners, int citizenAmount, int thiefAmount, int policeAmount)
        {

            int hasBeenRobbed = 0;

            int thiefOutSize = thiefAmount;

            int policeCount = 0;
            int hasArrested = 0;

            int prisonersInJail = 0;


            foreach (Person person in persons)
            {
                if (person is Citizen)
                {
                    Citizen citizen = (Citizen)person;
                    if (citizen.HasBeenRobbed)
                    {
                        hasBeenRobbed++;
                    }
                }
                
                else if (person is Police)
                {
                    policeCount++;
                    Police police = (Police)person;
                    if (police.Arrest)
                    {
                        hasArrested++;
                        police.Arrest = false;
                    }
                }
                else if (person is Thief)
                {
                    thiefOutSize++;
                }
            }
            foreach(Person prisoner in prisoners)
            {
                prisonersInJail++;
            }
            Console.WriteLine();
            Console.WriteLine($"Citizens: {citizenAmount} varav {hasBeenRobbed} har blivit rånade.");
            Console.WriteLine($"Thieves: {thiefOutSize} är ute och {prisonersInJail} sitter fängslade i Alcatraz.");
            Console.WriteLine($"Polices: {policeAmount}");
        }
        public static string[] NameGenerator()
        {
            string[] allNames =
            {
                "John Cena",
                "Anders Bagge",
                "Mikael Engström",
                "The Rock",
                "Snoop Dogg",
                "Zlatan",
                "Greta Thunberg",
                "Mr Bean",
                "Billy Öhman",
                "Akon",
                /*"Christina",
                "Lena",
                "Lars",
                "Emma",
                "Kerstin",
                "Karl",
                "Marie",
                "Peter" */
            };
            return allNames;
        }
        public static int[] GenerateRandomDirection()
        {
            int number1, number2;

            do
            {
                number1 = Random(-1, 2);
                number2 = Random(-1, 2);
            } while (number1 == 0 && number2 == 0);

            return new int[] { number1, number2 };
        }
        public static int[] GenerateRandomPlacement(int[,] mapSize)
        {
            int number1, number2;

            number1 = Random(1, mapSize.GetLength(0));
            number2 = Random(1, mapSize.GetLength(1));

            return new int[] { number1, number2 };
        }
    }
}
