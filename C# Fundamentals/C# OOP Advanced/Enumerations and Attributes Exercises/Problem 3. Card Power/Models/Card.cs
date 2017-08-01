using Problem_3.Card_Power.Enums;

namespace Problem_3.Card_Power.Models
{
    public class Card
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

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
        }
    }
}
