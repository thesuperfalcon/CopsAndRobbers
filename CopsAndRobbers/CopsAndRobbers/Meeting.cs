using System.Formats.Asn1;

namespace CopsAndRobbers
{
    public class Meeting
    {
        public static void HandleMeeting(List<Person> persons, int[,] mapSize)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                for (int j = i + 1; j < persons.Count; j++)
                {
                    Person person1 = persons[i];
                    Person person2 = persons[j];

                    if (person1 is Thief && person2 is Citizen)
                    {
                        Thief thief = (Thief)person1;
                        Citizen citizen = (Citizen)person2;
                        if (thief.Placement[0] == citizen.Placement[0] && thief.Placement[1] == citizen.Placement[1])
                        {
                            
                            Console.WriteLine("Tjuv möter Citzen");

                            if (citizen.Belongings.Count > 0)
                            {
                                int randomIndex = Helpers.Random(0, citizen.Belongings.Count);
                                Item stolenItem = citizen.Belongings[randomIndex];

                                thief.Loot.Add(stolenItem);
                                citizen.Belongings.RemoveAt(randomIndex);

                                string result = $"Tjuven tog {stolenItem.Objects} från medborgare.";
                                Console.WriteLine(result);
                                StopTime();
                            }
                        }
                    }
                    else if(person1 is Citizen && person2 is Thief)
                    {
                        Thief thief = (Thief)person2;
                        Citizen citizen = (Citizen)person1;
                        if (thief.Placement[0] == citizen.Placement[0] && thief.Placement[1] == citizen.Placement[1])
                        {
                            Console.WriteLine("Tjuv möter Citzen");

                            if (citizen.Belongings.Count > 0)
                            {
                                int randomIndex = Helpers.Random(0, citizen.Belongings.Count);
                                Item stolenItem = citizen.Belongings[randomIndex];

                                thief.Loot.Add(stolenItem);
                                citizen.Belongings.RemoveAt(randomIndex);

                                string result = $"Tjuven tog {stolenItem.Objects} från medborgare.";
                                Console.WriteLine(result);
                                StopTime();
                            }
                        }
                    }
                    else if (person1 is Thief && person2 is Police)
                    {
                        Thief thief = (Thief)person1;
                        Police police = (Police)person2;
                        if (thief.Placement[0] == police.Placement[0] && thief.Placement[1] == police.Placement[1])
                        {
                            Console.WriteLine("Polis möter tjuv");

                            if (thief.Loot.Count > 0)
                            {
                                for (int x = 0; x < thief.Loot.Count; x++)
                                {
                                    Item pickItem = thief.Loot[x];
                                    police.Confiscated.Add(pickItem);
                                    thief.Loot.RemoveAt(x);
                                }
                                string result = $"Polisen tog ";
                                foreach(Item item in police.Confiscated)
                                {
                                    result += item.Objects + ", ";
                                }
                                result += "från tjuven";
                                Console.WriteLine(result);
                                persons.Remove(person1);
                                StopTime();
                            }
                        }
                    }
                    else if (person1 is Police && person2 is Thief)
                    {
                        Thief thief = (Thief)person2;
                        Police police = (Police)person1;
                        if (thief.Placement[0] == police.Placement[0] && thief.Placement[1] == police.Placement[1])
                        {
                            Console.WriteLine("Polis möter tjuv");
                            if (thief.Loot.Count > 0)
                            {
                                if (thief.Loot.Count > 0)
                                {
                                    for (int x = 0; x < thief.Loot.Count; x++)
                                    {
                                        Item pickItem = thief.Loot[x];
                                        police.Confiscated.Add(pickItem);
                                        thief.Loot.RemoveAt(x);
                                    }
                                    string result = $"Polisen tog ";
                                    foreach (Item item in police.Confiscated)
                                    {
                                        result += item.Objects + ", ";
                                    }
                                    result += "från tjuven";
                                    Console.WriteLine(result);
                                    persons.Remove(person2);
                                    StopTime();
                                }
                            }
                        }
                    }
                    else if (person1 is Citizen && person2 is Police)
                    {
                        Citizen citizen = (Citizen)person1;
                        Police police = (Police)person2;
                        if (citizen.Placement[0] == police.Placement[0] && citizen.Placement[1] == police.Placement[1])
                        {
                            Console.WriteLine("Polis möter medborgare");
                            StopTime();

                        }
                    }
                    else if (person1 is Police && person2 is Citizen)
                    {
                        Citizen citizen = (Citizen)person2;
                        Police police = (Police)person1;
                        if (citizen.Placement[0] == police.Placement[0] && citizen.Placement[1] == police.Placement[1])
                        {
                            Console.WriteLine("Polis möter medborgare");
                            StopTime();

                        }
                    }
                }
            }
        }
        public static void StopTime()
        {
            Thread.Sleep(2000);
        }
    }
}



