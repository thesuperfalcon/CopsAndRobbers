namespace CopsAndRobbers
{
    public class Meeting
    {
        public static void HandleMeeting(List<Person> persons, List<string> updates, int[,] prisonSize, List<Person> prisoners)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                for (int j = i + 1; j < persons.Count; j++)
                {
                    Person person1 = persons[i];
                    Person person2 = persons[j];

                    if (person1.Placement[0] == person2.Placement[0] && person1.Placement[1] == person2.Placement[1])
                    {
                        HandleEncounter(person1, person2, persons, updates, prisonSize, prisoners);
                    }
                }
            }
        }

        public static void HandleEncounter(Person person1, Person person2, List<Person> persons, List<string> updates, int[,] prisonSize, List<Person> prisoners)
        {
            if (person1 is Thief && person2 is Citizen)
            {
                HandleThiefCitizenEncounter((Thief)person1, (Citizen)person2, updates);
            }
            else if (person1 is Citizen && person2 is Thief)
            {
                HandleThiefCitizenEncounter((Thief)person2, (Citizen)person1, updates);
            }
            else if (person1 is Police && person2 is Thief)
            {
                HandleThiefPoliceEncounter((Thief)person2, (Police)person1, persons, updates, prisonSize, prisoners);
            }
            else if (person1 is Thief && person2 is Police)
            {
                HandleThiefPoliceEncounter((Thief)person1, (Police)person2, persons, updates, prisonSize, prisoners);
            }
            else if (person1 is Citizen && person2 is Police)
            {
                HandleCitizenPolice((Police)person2, (Citizen)person1, updates);
            }
            else if (person1 is Police && person2 is Citizen)
            {
                HandleCitizenPolice((Police)person1, (Citizen)person2, updates);
            }

        }
        public static void HandleThiefCitizenEncounter(Thief thief, Citizen citizen, List<string> updates)
        {
            if (!citizen.HasBeenRobbed)
            {
                citizen.HasBeenRobbed = true;
            }
            if (citizen.Belongings.Count > 0)
            {
                int randomIndex = Helpers.Random(0, citizen.Belongings.Count);
                Item stolenItem = citizen.Belongings[randomIndex];

                thief.Loot.Add(stolenItem);
                citizen.Belongings.RemoveAt(randomIndex);

                string result = $"Tjuven {thief.Name} tog {stolenItem.Objects} från medborgaren {citizen.Name}.";
                updates.Add(result);
                StopTime(2000);
                int x = 0;
            }
        }
        public static void HandleThiefPoliceEncounter(Thief thief, Police police, List<Person> persons, List<string> updates, int[,] prisonSize, List<Person> prisoners)
        {
            if (thief.Loot.Count > 0)
            {
                if (!thief.Arrested)
                {
                    thief.Arrested = true;
                }
                int time = 0;
                for (int x = 0; x < thief.Loot.Count; x++)
                {
                    Item pickItem = thief.Loot[x];
                    police.Confiscated.Add(pickItem);
                    thief.Loot.RemoveAt(x);
                    time += 20;
                }
                string result = $"Polisen {police.Name} tog ";
                foreach (Item item in police.Confiscated)
                {
                    result += item.Objects + ", ";
                }
                result += $"från tjuven {thief.Name}.";
                prisoners.Add(new Prisoner(thief.Name, Helpers.GenerateRandomPlacement(prisonSize), thief.Direction, time));
                persons.Remove(thief);
                updates.Add(result);
                StopTime(2000);
                int y = 0;
            }
            else
            {
                string result = $"Polisen {police.Name} möter tjuven {thief.Name} men inget händer då tjuven inte har begått något brott ännu.";
            }
        }
        public static void HandleCitizenPolice(Police police, Citizen citizen, List<string> updates)
        {
            string result = $"Polisen {police.Name} möter medborgare {citizen.Name} och dem hälsar glatt på varandra";
            updates.Add(result);
            StopTime(2000);

        }
        public static void StopTime(int time)
        {
            Thread.Sleep(time);
        }
    }
}


