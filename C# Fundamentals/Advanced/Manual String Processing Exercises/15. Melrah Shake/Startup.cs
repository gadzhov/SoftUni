using System;

namespace _15.Melrah_Shake
{
    class Startup
    {
        static void Main(string[] args)
        {
            var test = Console.ReadLine();
            var key = Console.ReadLine();

            while (true)
            {
                //find match
                var lastindex = test.LastIndexOf(key);
                var firstindex = test.IndexOf(key);

                //shake it or not
                if (firstindex != -1 && lastindex != -1 && firstindex != lastindex
                    && key.Length > 0)
                {
                    Console.WriteLine("Shaked it.");
                    test = test.Remove(firstindex, key.Length);
                    lastindex = test.LastIndexOf(key);
                    test = test.Remove(lastindex, key.Length);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(test);
                    break;
                }
                //change key
                var indexToremove = key.Length / 2;
                key = key.Remove(indexToremove, 1);
            }
        }
    }
}
