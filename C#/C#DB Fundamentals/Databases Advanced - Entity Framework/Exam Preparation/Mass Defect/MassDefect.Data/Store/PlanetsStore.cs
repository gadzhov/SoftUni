using System.Linq;

namespace MassDefect.Data.Store
{
    using System;
    using MassDefect.Models;
    using System.Collections.Generic;
    using DTO;
    public static class PlanetsStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planets)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var planet in planets)
                {
                    if (planet.Name == null || planet.SolarSystem == null || planet.Sun == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    var solarSystem = SolarSystemsStore.GetSolarSystemByName(planet.SolarSystem);
                    var star = StarsStore.GetStarByName(planet.Sun);

                    if (solarSystem == null || star == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    var newPlanet = new Planet()
                    {
                        Name = planet.Name,
                        SolarSystemId = solarSystem.Id,
                        SunId = star.Id
                    };
                    context.Planets.Add(newPlanet);
                    Console.WriteLine($"Successfully imported Planet {planet.Name}");
                }
                context.SaveChanges();
            }
        }

        public static Planet GetPlanetByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets
                    .FirstOrDefault(p => p.Name == name);
            }
        }

        public static IEnumerable<object> GetPlanetsWithNoVictims()
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets
                    .Where(p => p.OriginalAnomalies.All(a => a.Victims.Count == 0))
                    .Select(p => new
                    {
                        Name = p.Name
                    })
                    .ToList();
            }
        }
    }
}
