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
        public string Name { get; set; }
        public int[] Placement { get; set; }
        public int[] Direction { get; set; }
        public Person(string name, int[] placement, int[] direction)
        {
            Name = name;
            Placement = placement;
            Direction = direction;
        }
    }
    public class Citizen : Person 
    {
        public bool HasBeenRobbed { get; set; }
        public bool IsPoor { get; set; }
        public List<Item> Belongings { get; set; }
        public Citizen(string name, int[]placement, int[] direction, List<Item> belongings, bool hasBeenRobbed, bool isPoor) : base(name, placement, direction)
        {
            Belongings = belongings;
            HasBeenRobbed = hasBeenRobbed;
            IsPoor = isPoor;
        }
    }
    public class Thief : Person
    {
        public bool Arrested { get; set; }
        public List<Item> Loot { get; set; }
        public int TimeInJail { get; set; }
        public Thief(string name, int[] placement, int[] direction, List<Item>loot, bool arrested, int timeInJail) : base(name, placement, direction)
        {
            Loot = loot;
            Arrested = arrested;
            TimeInJail = timeInJail;
        }
    }
    public class Police : Person
    {
        public bool Arrest { get; set; }
        public List<Item> Confiscated { get; set; }
        public Police(string name, int[] placement, int[] direction, List<Item> confiscated, bool arrest) : base(name, placement, direction)
        {
            Confiscated = confiscated;
            Arrest = arrest;
        }
    }
    public class Prisoner : Person
    {
        public int TimeInJail { get; set; }

        public Prisoner(string name, int[] placement, int[] direction, int timeInJail) : base(name, placement, direction) 
        {
            TimeInJail = timeInJail;
        }
    }
}
