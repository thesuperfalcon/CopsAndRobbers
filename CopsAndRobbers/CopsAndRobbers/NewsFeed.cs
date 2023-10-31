using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopsAndRobbers
{
    public class NewsFeed
    {
        public void WriteNewsFeed(List<string> updates)
        {
            Console.WriteLine();
            Console.WriteLine("Newsfeed: ");
            if (updates.Count >= 6)
            {
                updates.RemoveAt(6);
            }
            int number = 1;
            foreach (string update in updates)
            {
                Console.WriteLine(number + ": " + update);
                number++;
            }
        }
    }
}
