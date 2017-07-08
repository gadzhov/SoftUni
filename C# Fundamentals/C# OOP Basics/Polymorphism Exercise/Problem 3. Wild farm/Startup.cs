using System;
using System.Collections.Generic;
using Problem_3.Wild_farm.Models;

namespace Problem_3.Wild_farm
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    var oddLine = input
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // {AnimalType} {AnimalName} {AnimalWeight} {AnimalLivingRegion} [{CatBreed} = Only if its cat]
                    var animalType = oddLine[0];
                    var animalName = oddLine[1];
                    var animalWeight = double.Parse(oddLine[2]);
                    var animalLivingRegion = oddLine[3];

                    var evenLine = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //{FoodType} {Quantiy} 
                    var foodType = evenLine[0];
                    var quantity = int.Parse(evenLine[1]);
                    if (foodType == "Vegetable")
                    {
                        var food = new Vegetable(quantity);
                        switch (animalType)
                        {
                            case "Cat":
                                var catBreed = oddLine[4];
                                var cat = new Cat(animalName, animalType, animalWeight,animalLivingRegion, catBreed);
                                cat.MakeSound();
                                cat.Eat(food);
                                Console.WriteLine(cat);
                                break;
                            case "Tiger":
                                var tiger = new Tiger(animalName, animalType, animalWeight, animalLivingRegion);
                                tiger.MakeSound();
                                tiger.Eat(food);
                                Console.WriteLine(tiger);
                                break;
                            case "Zebra":
                                var zebra = new Zebra(animalName, animalType, animalWeight, animalLivingRegion);
                                zebra.MakeSound();
                                zebra.Eat(food);
                                Console.WriteLine(zebra);
                                break;
                            default:
                                var mouse = new Mouse(animalName, animalType, animalWeight, animalLivingRegion);
                                mouse.MakeSound();
                                mouse.Eat(food);
                                Console.WriteLine(mouse);
                                break;
                        }
                    }
                    else
                    {
                        var food = new Meat(quantity);
                        switch (animalType)
                        {
                            case "Cat":
                                var catBreed = oddLine[4];
                                var cat = new Cat(animalName, animalType, animalWeight,animalLivingRegion, catBreed);
                                cat.MakeSound();
                                cat.Eat(food);
                                Console.WriteLine(cat);
                                break;
                            case "Tiger":
                                var tiger = new Tiger(animalName, animalType, animalWeight, animalLivingRegion);
                                tiger.MakeSound();
                                tiger.Eat(food);
                                Console.WriteLine(tiger);
                                break;
                            case "Zebra":
                                var zebra = new Zebra(animalName, animalType, animalWeight, animalLivingRegion);
                                zebra.MakeSound();
                                zebra.Eat(food);
                                Console.WriteLine(zebra);
                                break;
                            default:
                                var mouse = new Mouse(animalName, animalType, animalWeight, animalLivingRegion);
                                mouse.MakeSound();
                                mouse.Eat(food);
                                Console.WriteLine(mouse);
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
