using System;
using Problem_5.Pizza_Calories.Models;

namespace Problem_5.Pizza_Calories
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs[0] == "Dough")
                {
                    try
                    {
                        var dough = new Dough(inputArgs[1], inputArgs[2], double.Parse(inputArgs[3]));
                        Console.WriteLine(dough.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (inputArgs[0] == "Topping")
                {
                    try
                    {
                        var topping = new Topping(inputArgs[1], double.Parse(inputArgs[2]));
                        Console.WriteLine(topping.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (inputArgs[0] == "Pizza")
                {
                    var pizzaName = inputArgs[1];
                    var pizza = new Pizza(pizzaName);
                    try
                    {
                        var count = int.Parse(inputArgs[2]);
                        if (count > 0 && count < 10)
                        {
                            inputArgs = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                            var dough = new Dough(inputArgs[1], inputArgs[2], double.Parse(inputArgs[3]));
                            pizza.Dough = dough;
                            for (int i = 0; i < count; i++)
                            {
                                inputArgs = Console.ReadLine()
                                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                                var topping = new Topping(inputArgs[1], double.Parse(inputArgs[2]));
                                pizza.AddTopping(topping);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Number of toppings should be in range [0..10].");
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    Console.WriteLine(pizza.ToString());
                }
            }
        }
    }
}
