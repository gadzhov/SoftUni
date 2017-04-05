using System;
using System.Collections.Generic;
using System.Linq;
using MassDefect.Data.DTO;
using MassDefect.Models;

namespace MassDefect.Data.Store
{
    public static class StarsStore
    {
        public static void AddStars(IEnumerable<StarDto> stars)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var star in stars)
                {
                    if (star.Name == null || star.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var solarSystem = SolarSystemsStore.GetSolarSystemByName(star.SolarSystem);
                        if (solarSystem == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                            continue;
                        }
                        var newStar = new Star()
                        {
                            Name = star.Name,
                            SolarSystemId = solarSystem.Id
                        };
                        context.Stars.Add(newStar);
                        Console.WriteLine($"Successfully imported Star {star.Name}.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static Star GetStarByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                return context.Stars
                    .FirstOrDefault(s => s.Name == name);
            }
        }
    }
}
