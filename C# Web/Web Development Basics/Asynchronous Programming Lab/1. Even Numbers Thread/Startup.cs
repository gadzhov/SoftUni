namespace _1._Even_Numbers_Thread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            int[] numbersArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startIndex = numbersArgs[0];
            int endIndex = numbersArgs[1];

            Thread evens = new Thread(() => PrintEvenNumbers(startIndex, endIndex));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work!");
        }

        private static void PrintEvenNumbers(int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
