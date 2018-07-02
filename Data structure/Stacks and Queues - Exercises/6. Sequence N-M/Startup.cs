using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Sequence_N_M
{
    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var startValue = input[0];
            var resultValue = input[1];

            var solutionItem = FindSolution(startValue, resultValue);
            PrintSolution(solutionItem);
        }

        private static Item FindSolution(int startValue, int resultValue)
        {
            var items = new Queue<Item>();
            items.Enqueue(new Item(startValue, null));

            while (items.Any())
            {
                var currentItem = items.Dequeue();

                if (currentItem.Value < resultValue)
                {
                    items.Enqueue(new Item(currentItem.Value + 1, currentItem));
                    items.Enqueue(new Item(currentItem.Value + 2, currentItem));
                    items.Enqueue(new Item(currentItem.Value * 2, currentItem));
                }
                else if (currentItem.Value == resultValue)
                {
                    return currentItem;
                }
            }

            return null;
        }

        private static void PrintSolution(Item solutionItem)
        {
            var operations = new Stack<int>();
            while (solutionItem != null)
            {
                operations.Push(solutionItem.Value);
                solutionItem = solutionItem.PreviousItem;
            }

            if (operations.Any())
            {
                Console.WriteLine(string.Join(" -> ", operations));
            }
        }

        private class Item
        {
            public Item(int value, Item item)
            {
                this.Value = value;
                this.PreviousItem = item;
            }

            public int Value { get; set; }

            public Item PreviousItem { get; set; }
        }
    }
}
