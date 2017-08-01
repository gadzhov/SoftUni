using Problem_8.Card_Game.Enums;

namespace Problem_8.Card_Game.Models
{
    public class Card
    {
        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.Power = (int)this.Suit + (int)this.Rank;
        }

        public Suit Suit { get; }

        public Rank Rank { get; }

        public int Power { get; }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}
