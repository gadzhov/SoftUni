using System;
using Problem_1.Card_Suit.Enums;

namespace Problem_1.Card_Suit
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Suit Suits:");
            foreach (var value in Enum.GetValues(typeof(Suit)))
            {
                Console.WriteLine($"Ordinal value: {(int) value}; Name value: {value}");
            }
        }
    }
}
