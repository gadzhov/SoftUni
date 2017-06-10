using System;

namespace _12.Character_Multiplier
{
    class Startup
    {
        static void Main(string[] args)
        {
            var inputTokens = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var leftWord = inputTokens[0];
            var rightWord = inputTokens[1];
            var sum = 0;

            for (int i = 0; i < Math.Max(leftWord.Length, rightWord.Length); i++)
            {
                try
                {
                    sum += leftWord[i] * rightWord[i];
                }
                catch
                {
                    if (leftWord.Length > rightWord.Length)
                    {
                        sum += leftWord[i];
                    }
                    else
                    {
                        sum += rightWord[i];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
