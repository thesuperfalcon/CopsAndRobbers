using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    internal class Helpers
    {
        public static int Random(int i, int j)
        {
            Random rnd = new Random();
            int x = rnd.Next(i, j);
            return x;
        }
        public List<string> Inventory(List<string>inventory)
        {
            List<string> item = new List<string>();

            item.Add("Klocka");
            item.Add("Nycklar");
            item.Add("Telefon");
            item.Add("Pengar");
            item.Add("Pass");

            if(inventory == null)
            {
                switch(Random(1,5))
                {
                    case 1: inventory.Add("Klocka"); break;
                    case 2: inventory.Add("Nycklar"); break;
                    case 3: inventory.Add("Telefon"); break;
                    case 4: inventory.Add("Pengar"); break;
                    case 5: inventory.Add("Pass"); break;
                }
            }
            return inventory;
        }
    }
}
