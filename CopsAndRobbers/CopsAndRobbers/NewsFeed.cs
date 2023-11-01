using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace CopsAndRobbers
{
    public class NewsFeed
    {
        public static void WriteNewsFeed(List<string> updates)
        {
            Console.WriteLine();
            Console.WriteLine("News-Feed:");

            Queue <string> newsFeedStack = new Queue<string>();

            int number = 1;
            foreach(string item in updates)
            {
                newsFeedStack.Enqueue(number + ": " + item);
                number++;
            }
            while(newsFeedStack.Count > 5)
            {
                newsFeedStack.Dequeue();
            }
            foreach(string item in newsFeedStack.Reverse())
            {
                Console.WriteLine(item);
            }
        }
    }
}
