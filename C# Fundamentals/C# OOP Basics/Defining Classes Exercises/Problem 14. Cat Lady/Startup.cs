using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_14.Cat_Lady
{
    class Startup
    {
        static void Main(string[] args)
        {
            var cats = new List<Cat>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var catArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var catBreed = catArgs[0];
                if (catBreed == "Siamese")
                {
                    var name = catArgs[1];
                    var earSize = int.Parse(catArgs[2]);
                    cats.Add(new Siamese
                    {
                        Name = name,
                        Type = Breed.Siamese,
                        EarSize = earSize
                    });
                }
                else if (catBreed == "Cymric")
                {
                    var name = catArgs[1];
                    var furLength = double.Parse(catArgs[2]);
                    cats.Add(new Cymric
                    {
                        Name = name,
                        Type = Breed.Cymric,
                        FurLenght = furLength
                    });
                }
                else
                {
                    var name = catArgs[1];
                    var decibels = int.Parse(catArgs[2]);
                    cats.Add(new StreetExtraordinaire
                    {
                        Name = name,
                        Type = Breed.StreetExtraordinaire,
                        DecibelsOfMeows = decibels
                    });
                }
            }
            var catToFinde = Console.ReadLine();
            var desiredCat = cats.FirstOrDefault(c => c.Name == catToFinde);
            Console.WriteLine(desiredCat.ToString());
        }
    }
}
