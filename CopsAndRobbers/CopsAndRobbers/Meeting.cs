namespace CopsAndRobbers
{
    public class Meeting
    {
        public static (List<Person>,List<Person>,List<Person>) HandleMeeting(List<Person> persons, List<Person> prisoners, List<Person> poorGuys,List<string> updates, int[,] prisonSize, int[,]poorHouseSize, int[,]mapSize)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                for (int j = i + 1; j < persons.Count; j++)
                {
                    Person person1 = persons[i];
                    Person person2 = persons[j];

                    if (person1.Placement[0] == person2.Placement[0] && person1.Placement[1] == person2.Placement[1])
                    {
                        (prisoners, poorGuys, persons) = HandleEncounter(person1, person2, persons, prisoners, poorGuys, updates, prisonSize, poorHouseSize, mapSize);
                        person1.Direction = Helpers.GenerateRandomDirection();
                        person2.Direction = Helpers.GenerateRandomDirection();
                    }
                }
            }
            StopTime();
            return (prisoners, poorGuys, persons);
        }
        private static (List<Person>,List<Person>,List<Person>) HandleEncounter(Person person1, Person person2, List<Person> persons, List<Person> prisoners, List<Person> poorGuys, List<string> updates, int[,] prisonSize, int[,]poorHouseSize, int[,]mapSize)
        {
            if (person1 is Thief && person2 is Citizen)
            {
                HandleThiefCitizenEncounter((Thief)person1, (Citizen)person2, updates, mapSize);
            }
            else if (person1 is Citizen && person2 is Thief)
            {
                HandleThiefCitizenEncounter((Thief)person2, (Citizen)person1, updates, mapSize);
            }
            else if (person1 is Police && person2 is Thief)
            {
                (prisoners, persons) = HandleThiefPoliceEncounter((Thief)person2, (Police)person1, persons, prisoners, updates, prisonSize, mapSize);
            }
            else if (person1 is Thief && person2 is Police)
            {
                (prisoners, persons) = HandleThiefPoliceEncounter((Thief)person1, (Police)person2, persons, prisoners, updates, prisonSize, mapSize);
            }
            else if (person1 is Citizen && person2 is Police)
            {
                (poorGuys, persons) = HandleCitizenPolice((Police)person2, (Citizen)person1, persons, poorGuys, updates, poorHouseSize, mapSize);
            }
            else if (person1 is Police && person2 is Citizen)
            {

                (poorGuys, persons) = HandleCitizenPolice((Police)person1, (Citizen)person2, persons, poorGuys, updates, poorHouseSize, mapSize);
            }
            return (prisoners, poorGuys, persons);
        }
        private static void HandleThiefCitizenEncounter(Thief thief, Citizen citizen, List<string> updates, int[,]mapSize)
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
                citizen.Direction = MovementV2.Movement(citizen, mapSize);
                thief.Direction = MovementV2.Movement(thief, mapSize);
                updates.Add(result);
            }
            StopTime();
        }
        private static (List<Person>,List<Person>) HandleThiefPoliceEncounter(Thief thief, Police police, List<Person> persons, List<Person> prisoners, List<string> updates, int[,] prisonSize, int[,]mapSize)
        {
            string result = string.Empty;
            if (thief.Loot.Count > 0)
            {
                if (!thief.Arrested)
                {
                    thief.Arrested = true;
                    police.Arrest = true;
                }
                thief.TimeInJail += 40;
                for (int x = 0; x < thief.Loot.Count; x++)
                {
                    Item pickItem = thief.Loot[x];
                    police.Confiscated.Add(pickItem);
                    thief.Loot.RemoveAt(x);
                    thief.TimeInJail += 30;
                }
                result = $"Polisen {police.Name} tog ";
                foreach (Item item in police.Confiscated)
                {
                    result += item.Objects + ", ";
                }
                result += $"från tjuven {thief.Name}.";
                thief.Placement = Helpers.GenerateRandomPlacement(prisonSize);
                prisoners.Add(thief);
                persons.Remove(thief);
            }
            else
            {
                result = $"Polisen {police.Name} möter tjuven {thief.Name} men inget händer då tjuven inte har begått något brott ännu.";
                thief.Direction = MovementV2.Movement(thief, mapSize);
            }
            police.Direction = MovementV2.Movement(police, mapSize);
            updates.Add(result);
            return (prisoners, persons);
            StopTime();
        }
        private static (List<Person>,List<Person>) HandleCitizenPolice(Police police, Citizen citizen, List<Person> persons, List<Person> poorGuys,List<string> updates, int[,] poorHouseSize, int[,]mapSize)
        {
            string result = string.Empty;
            if (citizen.Belongings.Count == 0)
            {
                citizen.IsPoor = true;
                result = $"Polisen {police.Name} arresterar medborgaren {citizen.Name} då den är fattig";
                citizen.Placement = Helpers.GenerateRandomPlacement(poorHouseSize);
                poorGuys.Add(citizen);
                persons.Remove(citizen);
            }
            else
            {
                result = $"Polisen {police.Name} möter medborgare {citizen.Name} och dem hälsar glatt på varandra";
                citizen.Direction = MovementV2.Movement(citizen, mapSize);
            }
            police.Direction = MovementV2.Movement(police, mapSize);
            updates.Add(result);
            return (poorGuys, persons);
            StopTime();
        }
        private static void StopTime()
        {
            Thread.Sleep(2000);
        }
    }
}


