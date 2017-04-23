using System;
using System.Collections.Generic;
using System.Linq;
using MassDefect.Data.DTO;
using MassDefect.Models;

namespace MassDefect.Data.Store
{
    public static class PeopleStore
    {
        public static void AddPeople(IEnumerable<PersonDto> persons)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var person in persons)
                {
                    if (person.Name == null || person.HomePlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    var planet = PlanetsStore.GetPlanetByName(person.HomePlanet);
                    if (planet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    var newPerson = new Person()
                    {
                        Name = person.Name,
                        HomePlanetId = planet.Id
                    };

                    context.People.Add(newPerson);
                    Console.WriteLine($"Successfully inported Person {person.Name}");
                }
                context.SaveChanges();
            }
        }

        public static Person GetPersonByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                return context.People
                    .FirstOrDefault(p => p.Name == name);
            }
        }

        public static IEnumerable<object> GetPeopleWichHaveNotBeenVictimsOfAnomalies()
        {
            using (var context = new MassDefectContext())
            {
                return context.People
                    .Where(p => p.Anomalies.All(a => !a.Victims.Contains(p)))
                    .Select(p => new
                    {
                        name = p.Name,
                        homePlanet = new
                        {
                            name = p.HomePlanet.Name
                        }
                    })
                    .ToList();
            }
        }
    }
}
