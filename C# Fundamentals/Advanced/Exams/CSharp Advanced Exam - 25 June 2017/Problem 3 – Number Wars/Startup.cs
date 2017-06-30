using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Number_Wars
{
	// 70/100
    class Startup
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = new Queue<string>();
            var secondPlayerCards = new Queue<string>();

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            firstPlayerCards = AddCards(input, firstPlayerCards);
            input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            secondPlayerCards = AddCards(input, secondPlayerCards);
            var counter = 0;
            while (firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0 && counter < 1000000)
            {
                var firstCard = firstPlayerCards.Dequeue();
                var numOne = int.Parse(firstCard.Substring(0, firstCard.Length - 1));
                var secondCard = secondPlayerCards.Dequeue();
                var numTwo = int.Parse(secondCard.Substring(0, secondCard.Length - 1));

                if (numOne > numTwo)
                {
                    var cardsSorted = new string[] { firstCard, secondCard }.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1))).ThenByDescending(c => c.Last()).ToArray();
                    firstPlayerCards = AddCards(cardsSorted, firstPlayerCards);
                }
                else if (numOne < numTwo)
                {
                    var cardsSorted = new string[] { firstCard, secondCard }.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1))).ThenByDescending(c => c.Last()).ToArray();
                    secondPlayerCards = AddCards(cardsSorted, secondPlayerCards);
                }
                else
                {
                    var cardsToAdd = new List<string>();
                    cardsToAdd.Add(firstCard);
                    cardsToAdd.Add(secondCard);
                    while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
                    {
                        var firstCharSum = 0;
                        var secondCharSum = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            var nexCardOfPlayerOne = firstPlayerCards.Dequeue();
                            var firstChar = nexCardOfPlayerOne.Last() % 96;
                            var nextCardOfPlayerTwo = secondPlayerCards.Dequeue();
                            var secondChar = nextCardOfPlayerTwo.Last() % 96;
                            firstCharSum += firstChar;
                            secondCharSum += secondChar;
                            cardsToAdd.Add(nexCardOfPlayerOne);
                            cardsToAdd.Add(nextCardOfPlayerTwo);
                        }
                        if (firstCharSum > secondCharSum)
                        {
                            cardsToAdd = cardsToAdd.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1))).ThenByDescending(c => c.Last()).ToList();
                            firstPlayerCards = AddCards(cardsToAdd.ToArray(),
                                firstPlayerCards);
                            break;
                        }
                        else if (firstCharSum < secondCharSum)
                        {
                            cardsToAdd = cardsToAdd.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1))).ThenByDescending(c => c.Last()).ToList();
                            secondPlayerCards = AddCards(cardsToAdd.ToArray(),
                                secondPlayerCards);
                            break;
                        }
                    }
                }
                counter++;
            }

            if (firstPlayerCards.Count == secondPlayerCards.Count)
            {
                Console.WriteLine($"Draw after {counter} turns");
            }
            else
            {
                if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    Console.WriteLine($"First player wins after {counter} turns");
                }
                else
                {
                    Console.WriteLine($"Second player wins after {counter} turns");
                }
            }
        }

        private static Queue<string> AddCards(string[] input, Queue<string> playerCards)
        {
            for (int i = 0; i < input.Length; i++)
            {
                playerCards.Enqueue(input[i]);
            }

            return playerCards;
        }
    }
}
