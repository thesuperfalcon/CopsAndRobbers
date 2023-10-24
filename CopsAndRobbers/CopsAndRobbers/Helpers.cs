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
        public static void CountAllPersons(List<Person> persons,List<Prison> prisoners, int citizenAmount, int thiefAmount, int policeAmount)
        {

            int hasBeenRobbed = 0;

            int thiefOutSize = thiefAmount;
            int thiefInJail = 0;

            int policeCount = 0;
            int hasArrested = 0;

            int prisonersInJail = 0;

            foreach(Prison prisoner in prisoners)
            {
                prisonersInJail++;
                thiefOutSize-=prisonersInJail;
                thiefInJail += prisonersInJail;
                int x = 0;
            }

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
            }
            Console.WriteLine();
            Console.WriteLine($"Citizens: {citizenAmount} varav {hasBeenRobbed} har blivit rånade.");
            Console.WriteLine($"Thieves: {thiefOutSize} är ute och {thiefInJail} sitter i finkan.");
            Console.WriteLine($"Polices: {policeAmount}");
        }
        public static string[] NameGenerator()
        {
            string[] allNames =
            {
                "Karin",
                "Anders",
                "Johan",
                "Eva",
                "Maria",
                "Mikael",
                "Anna",
                "Sara",
                "Erik",
                "Per",
                "Christina",
                "Lena",
                "Lars",
                "Emma",
                "Kerstin",
                "Karl",
                "Marie",
                "Peter"
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
