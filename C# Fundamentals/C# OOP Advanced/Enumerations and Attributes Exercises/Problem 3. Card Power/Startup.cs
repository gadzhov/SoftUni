using System;
using Problem_3.Card_Power.Enums;
using Problem_3.Card_Power.Models;

namespace Problem_3.Card_Power
{
    public  class Startup
    {
        public static void Main()
        {
            var rank = (Rank) Enum.Parse(typeof(Rank), Console.ReadLine());
            var suit = (Suit) Enum.Parse(typeof(Suit), Console.ReadLine());

            var card = new Card(suit, rank);
            Console.WriteLine(card);
        }
    }
}
