using System;
using System.Collections.Generic;
using System.Linq;
using Problem_8.Card_Game.Enums;
using Problem_8.Card_Game.Models;

namespace Problem_8.Card_Game
{
    public class Startup
    {
        public static void Main()
        {
            var game = new Dictionary<string, List<Card>>();
            var nameOfFirstPlayer = Console.ReadLine();
            game.Add(nameOfFirstPlayer, new List<Card>());
            var nameOfSecondPlayer = Console.ReadLine();
            game.Add(nameOfSecondPlayer, new List<Card>());
            var deck = new List<Card>();
            deck = FillDeck();

            var input = Console.ReadLine();
            var count = 5;
            // Fill first player's cards
            while (count > 0)
            {
                var cardArgs = input.Split(new[] { " of " }, StringSplitOptions.RemoveEmptyEntries);
                // TODO: Check if cardArgs.Lnegth == 2
                Rank rank;
                Suit suit;
                if (Enum.TryParse(cardArgs[0], out rank) && Enum.TryParse(cardArgs[1], out suit))
                {
                    var card = deck.FirstOrDefault(c => c.Rank == rank && c.Suit == suit);
                    if (card != null)
                    {
                        game[nameOfFirstPlayer].Add(card);
                        deck.Remove(card);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("No such card exists.");
                    count++;
                }
                count--;
                input = Console.ReadLine();
            }
            count = 5;
            // Fill second player's cards
            while (count > 0)
            {
                var cardArgs = input.Split(new[] { " of " }, StringSplitOptions.RemoveEmptyEntries);
                // TODO: Check if cardArgs.Lnegth == 2
                Rank rank;
                Suit suit;
                if (Enum.TryParse(cardArgs[0], out rank) && Enum.TryParse(cardArgs[1], out suit))
                {
                    var card = deck.FirstOrDefault(c => c.Rank == rank && c.Suit == suit);
                    if (card != null)
                    {
                        game[nameOfSecondPlayer].Add(card);
                        deck.Remove(card);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("No such card exists.");
                    count++;
                }
                count--;
                input = Console.ReadLine();
            }
            Console.WriteLine(game[nameOfFirstPlayer].Max(c => c.Power) > game[nameOfSecondPlayer].Max(c => c.Power) ? $"{nameOfFirstPlayer} wins with {game[nameOfFirstPlayer].FirstOrDefault(c => c.Power == game[nameOfFirstPlayer].Max(v => v.Power))}." : $"{nameOfSecondPlayer} wins with {game[nameOfSecondPlayer].FirstOrDefault(c => c.Power == game[nameOfSecondPlayer].Max(v => v.Power))}.");
        }

        private static List<Card> FillDeck()
        {
            var deck = new List<Card>();
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            return deck;
        }
    }
}
