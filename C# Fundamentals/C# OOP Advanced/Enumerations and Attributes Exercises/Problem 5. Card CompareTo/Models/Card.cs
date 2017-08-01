using System;
using Problem_5.Card_CompareTo.Enums;

namespace Problem_5.Card_CompareTo.Models
{
    public class Card : IComparable<Card>
    {
        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.Power = (int)this.Suit + (int)this.Rank;
        }

        private Suit Suit { get; }

        private Rank Rank { get; }

        private int Power { get; }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
        }
    }
}
