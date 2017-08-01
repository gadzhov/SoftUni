using System;
using Problem_2.Card_Rank.Enums;

namespace Problem_2.Card_Rank
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Card Ranks:");
            foreach (var r in Enum.GetValues(typeof(Rank)))
            {
                Console.WriteLine($"Ordinal value: {(int) r}; Name value: {r}");
            }
        }
    }
}
