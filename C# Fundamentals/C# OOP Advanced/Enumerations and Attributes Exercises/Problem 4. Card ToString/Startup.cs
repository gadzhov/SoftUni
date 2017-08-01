using System;
using Problem_4.Card_ToString.Enums;
using Problem_4.Card_ToString.Models;

namespace Problem_4.Card_ToString
{
    public class Startup
    {
        public static void Main()
        {
            var rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            var suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine());

            var card = new Card(suit, rank);
            Console.WriteLine(card);
        }
    }
}
