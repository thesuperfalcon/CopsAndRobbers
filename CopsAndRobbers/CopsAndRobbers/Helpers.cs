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
        public static void CountAllPersons(List<Person> persons, int citizenAmount, int thiefAmount, int policeAmount)
        {

            int hasBeenRobbed = 0;

            int thiefOutSize = thiefAmount;
            int thiefInJail = 0;

            int policeCount = 0;
            int hasArrested = 0;

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
                else if (person is Thief)
                {
                    Thief thief = (Thief)person;
                    if(thief.Arrested)
                    {
                        thiefOutSize--;
                        thiefInJail++;
                    }
                }
                else if (person is Police)
                {
                    policeCount++;
                    Police police = (Police)person;
                    if(police.Arrest)
                    {
                        hasArrested++;
                        police.Arrest = false;
                    }
                }
            }
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
    }
}
