using System;
using Problem_7.Deck_of_Cards.Enums;

namespace Problem_7.Deck_of_Cards
{
    public class Startup
    {
        public static void Main()
        {
            foreach (var s in Enum.GetValues(typeof(Suit)))
            {
                foreach (var r in Enum.GetValues(typeof(Rank)))
                {
                    Console.WriteLine($"{r} of {s}");
                }
            }
        }
    }
}
