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
                List<Item> belongings = new List<Item>();
                Item item1 = new Item("Apple-Watch");
                Item item2 = new Item("Keys");
                Item item3 = new Item("Iphone 15");
                Item item4 = new Item("Cash");
                Item item5 = new Item("Nicotine-Product");

                belongings.Add(item1);
                belongings.Add(item2);
                belongings.Add(item3);
                belongings.Add(item4);
                belongings.Add(item5);
                foreach(Item belonging in belongings)
                {
                    result += belonging.Objects + ", ";
                }
                result += belongings.Count;
            }
            Console.WriteLine(result);
        }
    }
}
