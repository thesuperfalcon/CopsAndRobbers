using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    public class Person
    {

        public int[] Placement { get; set; }
        public int[] Direction { get; set; }
        public Person(int[] placement, int[] direction)
        {
            Placement = placement;
            Direction = direction;
        }
    }
    public class Citizen : Person 
    {
        List<Item> Belongings { get; set; }
        public Citizen(int[]placement, int[]direction, List<Item>belongings) : base(placement, direction)
        {
            Belongings = belongings;
        }
        //public static List<Item> Inventory(List<Item>belongings)
        //{
        //    Item item1 = new Item("Apple-Watch", 1);
        //    Item item2 = new Item("Keys", 1);
        //    Item item3 = new Item("Iphone 15", 1);
        //    Item item4 = new Item("Cash", 1);
        //    Item item5 = new Item("Nicotine-Product", 1);

        //    belongings.Add(item1);
        //    belongings.Add(item2);
        //    belongings.Add(item3);
        //    belongings.Add(item4);
        //    belongings.Add(item5);

        //    return belongings;
        //}
    }
    public class Thief : Person
    {
        public List<Item> Loot { get; set; }
        public bool Steal { get; set; }
        public Thief(int[] placement, int[] direction, List<Item>loot, bool steal) : base(placement, direction)
        {
            Steal = steal;
            Loot = loot;
        }
    }
    public class Police : Person
    {
        public List<Item> Confiscated { get; set; }
        public bool Arrest { get; set; }
        public Police(int[] placement, int[] direction, List<Item> confiscated, bool arrest) : base(placement, direction)
        {
            Arrest = arrest;
            Confiscated = confiscated;
        }
    }
}
