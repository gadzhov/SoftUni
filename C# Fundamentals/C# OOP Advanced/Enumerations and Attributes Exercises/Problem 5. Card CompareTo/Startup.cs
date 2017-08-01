using System;
using Problem_5.Card_CompareTo.Enums;
using Problem_5.Card_CompareTo.Models;

namespace Problem_5.Card_CompareTo
{
    public class Startup
    {
        public static void Main()
        {
            var rank1 = (Rank) Enum.Parse(typeof(Rank), Console.ReadLine());
            var suit1 = (Suit) Enum.Parse(typeof(Suit), Console.ReadLine());
            var rank2 = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine());
            var suit2 = (Suit) Enum.Parse(typeof(Suit), Console.ReadLine());

            var card1 = new Card(suit1, rank1);
            var card2 = new Card(suit2, rank2);

            Console.WriteLine(card1.CompareTo(card2) == 1 ? card1 : card2);
        }
    }
}
