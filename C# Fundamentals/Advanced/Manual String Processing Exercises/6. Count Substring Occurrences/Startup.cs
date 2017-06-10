using System;

namespace _6.Count_Substring_Occurrences
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine().ToLower();

            var startIndex = text.IndexOf(pattern);
            var counter = 0;

            while (true)
            {
                int found = text.IndexOf(pattern, startIndex);

                if (found >= 0)
                {
                    counter++;
                    startIndex = found + 1;
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine(counter);
        }
    }
}
