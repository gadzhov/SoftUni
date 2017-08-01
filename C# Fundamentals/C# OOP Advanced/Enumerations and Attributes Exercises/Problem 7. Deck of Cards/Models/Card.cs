using Problem_7.Deck_of_Cards.Enums;

namespace Problem_7.Deck_of_Cards.Models
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
