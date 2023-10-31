using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    public class Report
    {
        public void ReportAndUpdates(List<Person> persons, List<Person> prisoners, List<Person> poorGuys)
        {
            foreach(Person person in persons)
            {
                if(person is Citizen)
                {
                    PrintPerson(person);
                }
            }
            foreach(Person poorGuy in poorGuys)
            {
                PrintPoorGuy(poorGuy);
            }
            foreach(Person person in persons)
            {
                if(person is Thief)
                {
                    PrintPerson(person);
                }
            }
            foreach(Person prisoner in prisoners)
            {
                PrintPrisoner(prisoner);
            }
            foreach(Person person in persons)
            {
                if(person is Police) 
                {
                    PrintPerson(person);
                }
            }
        }
        private void PrintPerson(Person person)
        {
            string result = string.Empty;
            if (person is Citizen)
            {
                result += "C";
            }
            else if (person is Thief)
            {
                result += "T";
            }
            else if (person is Police)
            {
                result += "P";
            }
            result += $" {person.Placement[0]} {person.Placement[1]} ";
            if (person is Citizen)
            {
                Citizen citizen = (Citizen)person;

                result += " Belongings: ";

                foreach (Item item in citizen.Belongings)
                {
                    result += item.Objects + ", ";
                }
            }
            if (person is Thief)
            {
                Thief thief = (Thief)person;

                result += " Stolen Goods: ";

                foreach (Item item in thief.Loot)
                {
                    result += item.Objects + ", ";
                }
                result += thief.Arrested ? "Arrested" : " ";
            }
            if (person is Police)
            {
                Police police = (Police)person;

                result += " Seized Goods: ";

                foreach (Item item in police.Confiscated)
                {
                    result += item.Objects + ", ";
                }
            }
            Console.WriteLine(result);
        }
        private void PrintPrisoner(Person prisoner)
        {
            Thief thief = (Thief)prisoner;
            string result = "T";
            result += $" Arrested for: {thief.TimeInJail} minutes";
            Console.WriteLine(result);
        }   
        private void PrintPoorGuy(Person poorGuy)
        {
            string result = "C is poor :(";
            Console.WriteLine(result);
        }
    }
}
