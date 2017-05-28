using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Hands_of_cards
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var handsCards = new Dictionary<string, HashSet<string>>();

            while (input != "JOKER")
            {
                var name = input.Split(':').First();
                var tokens = input.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                // Put only unique items in the hashSet
                var hashCards = new HashSet<string>();
                for (int i = 1; i < tokens.Length; i++)
                {
                    hashCards.Add(tokens[i]);
                }
                // If doesn't exist create new one
                if (!handsCards.ContainsKey(name))
                {
                    handsCards.Add(name, hashCards);
                }
                else // override
                {
                    foreach (var hashCard in hashCards)
                    {
                        handsCards[name].Add(hashCard);
                    }
                }

                input = Console.ReadLine();
            }
            // Points calculation
            foreach (var handsCard in handsCards)
            {
                var totalPoints = 0;
                foreach (var card in handsCard.Value)
                {
                    int point;
                    var value = card.Last().ToString();
                    var power = card.Substring(0, card.Length - 1);
                    if (!int.TryParse(power, out point))
                    {
                        switch (power)
                        {
                            case "J":
                                point = 11;
                                break;
                            case "Q":
                                point = 12;
                                break;
                            case "K":
                                point = 13;
                                break;
                            case "A":
                                point = 14;
                                break;
                        }
                    }
                    switch (value)
                    {
                        case "S":
                            point *= 4;
                            break;
                        case "H":
                            point *= 3;
                            break;
                        case "D":
                            point *= 2;
                            break;
                        case "C":
                            point *= 1;
                            break;
                    }
                    totalPoints += point;
                }
                Console.WriteLine($"{handsCard.Key}: {totalPoints}");
            }
        }
    }
}
