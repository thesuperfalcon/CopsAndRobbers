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
        public List<string> Inventory { get; set; }

        public Person(int[] placement, int[] direction, List<string> inventory)
        {
            Placement = placement;
            Direction = direction;
            Inventory = inventory;
        }
    }
    public class Citizen : Person 
    {
        public Citizen(int[]placement, int[]direction, List<string>inventory) : base(placement, direction, inventory)
        {
            
        }
    }
    public class Thief : Person
    {
        public bool Steal { get; set; }
        public Thief(int[] placement, int[] direction, List<string> inventory, bool steal) : base(placement, direction, inventory)
        {
            Steal = steal;
        }
    }
    public class Police : Person
    {
        public bool Arrest { get; set; }
        public Police(int[] placement, int[] direction, List<string> inventory, bool arrest) : base(placement, direction, inventory)
        {
            Arrest = arrest;
        }
    }
}
