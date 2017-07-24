using System;

namespace Problem_11.Tuple
{
    public class Startup
    {
        public static void Main()
        {
            var nameAndAdress = Console.ReadLine().Split();
            var fullName = nameAndAdress[0] + " " + nameAndAdress[1];
            var address = nameAndAdress[2];
            var firstTuple = new Tuple<string, string>(fullName, address);

            var personAndBeer = Console.ReadLine().Split();
            var name = personAndBeer[0];
            var beer = int.Parse(personAndBeer[1]);
            var secondTuple = new Tuple<string, int>(name, beer);

            var integerAndDouble = Console.ReadLine().Split();
            var firstNum = int.Parse(integerAndDouble[0]);
            var secondNum = double.Parse(integerAndDouble[1]);
            var thirdTuple = new Tuple<int, double>(firstNum, secondNum);

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2}");
        }
    }
}
