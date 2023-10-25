using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    public class Report
    {
        public void ReportAndUpdates(Person person)
        {
            string result = person is Citizen ? "C" : (person is Thief) ? "T" : "P";
            result += $" {person.Placement[0]} {person.Placement[1]} ";
            if(person is Citizen)
            {
                Citizen citizen = (Citizen)person;

                result += " Belongings: ";

                foreach(Item item in citizen.Belongings)
                {
                    result += item.Objects + ", ";
                }
            }
            if(person is Thief)
            {
                Thief thief = (Thief)person;

                result += " Stealed Goods: ";

                foreach(Item item in thief.Loot)
                {
                    result += item.Objects + ", ";
                }
                result += thief.Arrested ? "Arrested" : " ";
            }
            if(person is Police)
            {
                Police police = (Police)person;

                result += " Seized Goods: ";

                foreach(Item item in police.Confiscated)
                {
                    result += item.Objects + ", ";
                }
            }
            if(person is Prisoner)
            {
                Prisoner prisoner = (Prisoner)person;

                result += " Sitting in jail ";

                result += prisoner.TimeInJail;
            }
            Console.WriteLine(result);
        }
        public void ReportAndUpdatesPrisoner(Person prisoner)
        {
            Console.WriteLine();
            Prisoner prisonerX = (Prisoner)prisoner;
            string result = "T";
            result += $" {prisoner.Placement[0]} {prisoner.Placement[1]} ";
            result += "Arrested ";
            result += prisonerX.TimeInJail;
            Console.WriteLine(result);
        }
    }
}
