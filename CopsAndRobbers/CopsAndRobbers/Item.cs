using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    public class Item
    {
        public string Objects { get; set; }

        public Item(string objects)
        {
            Objects = objects;
        }
        public static List<Item> AllTypesOfObjects()
        {
            List<Item> items = new List<Item>();

            Item item1 = new Item("Rolex Daytona");
            Item item2 = new Item("Tesla Keys");
            Item item3 = new Item("Iphone 15");
            Item item4 = new Item("American Express Platinum Card");
            Item item5 = new Item("General Snus");

            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);

            return items;
        }
        public static List<Item> EmptyList()
        {
            List<Item> items = new List<Item> ();

            return items;
        }
    }
}
