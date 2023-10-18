using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //public static List<Item> Inventory(List<Item>inventory, Person person)
        //{
        //    Item item1 = new Item("Apple-Watch", 1);
        //    Item item2 = new Item("Keys", 1);
        //    Item item3 = new Item("Iphone 15", 1);
        //    Item item4 = new Item("Cash", 1);
        //    Item item5 = new Item("Pass", 1);

        //    if(person is Citizen)
        //    {
        //        inventory.Add(item1);
        //        inventory.Add(item2);
        //        inventory.Add(item3);
        //        inventory.Add(item4);
        //        inventory.Add(item5);
        //    }
            //if (inventory == null)
            //{
            //    switch(Random(1,5))
            //    {
        //    //        case 1: inventory.Add(item1); break;
        //    //        case 2: inventory.Add(item2); break;
        //    //        case 3: inventory.Add(item3); break;
        //    //        case 4: inventory.Add(item4); break;
        //    //        case 5: inventory.Add(item5); break;
        //    //    }
        //    //}
        //    return inventory;
        //}
    }
}
