namespace Monopoly
{
    using System;

    public class MonopolyMain
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine().Split()[0]);
            var money = 50;
            var numberOfHotels = 0;
            var turns = 0;

            for (var row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine();
                for (var col = 0; col < currentRow.Length; col++)
                {
                    var index = row % 2 == 0 ? col : currentRow.Length - col - 1;
                    switch (currentRow[index])
                    {
                        case 'H':
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++numberOfHotels}.");
                            money = 0;
                            break;
                        case 'J':
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                            turns += 2;
                            money += 2 * (numberOfHotels * 10);
                            break;
                        case 'S':
                            int columnIndex = row % 2 == 0 ? col : index;
                            int moneyToSpend = Math.Min((columnIndex + 1) * (row + 1), money);
                            money -= moneyToSpend;
                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            break;
                    }
                    money += numberOfHotels * 10;
                    turns++;
                }
            }
            Console.WriteLine("Turns " + turns);
            Console.WriteLine("Money " + money);
        }
    }
}
