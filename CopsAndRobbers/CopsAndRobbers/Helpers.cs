﻿namespace CopsAndRobbers
{
    public class Helpers
    {
        public static int Random(int i, int j)
        {
            Random rnd = new Random();
            int x = rnd.Next(i, j);
            return x;
        }
        public static void CountAllPersons(List<Person> persons, List<Person> prisoners, List<Person> poorGuys, int citizenAmount, int thiefAmount, int policeAmount)
        {

            int hasBeenRobbed = 0;
            int amountOfPoorGuys = poorGuys.Count;
            int policeCount = 0;
            int hasArrested = 0;
            int thiefInJail = prisoners.Count;
            int thiefOutSize = thiefAmount - thiefInJail;

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
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Citizens: {citizenAmount} varav {hasBeenRobbed} har blivit rånade och {amountOfPoorGuys} är i fattighuset.");
            Console.WriteLine($"Thieves: {thiefOutSize} är ute och {thiefInJail} sitter fängslade i Alcatraz.");
            Console.WriteLine($"Polices: {policeAmount} varav {hasArrested} har skickat in tjuvar till Alcatraz.");
        }
        public static string[] NameGenerator()
        {
            string[] allNames =
            {
                "John Cena",
                "Anders Bagge",
                "Pernilla Wahlgren",
                "The Rock",
                "Zlatan Ibrahimovic",
                "Greta Thunberg",
                "Mr Bean",
                "Billy Öhman",
                "Magdalena Andersson",
                "Glenn Hysén",
                "Homer Simpson",
                "Luke Skywalker",
                "Frodo Baggins",
                "Tony Stark" 
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
