using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using MassDefect.Data.DTO;
using MassDefect.Models;

namespace MassDefect.Data.Store
{
    public static class AnomalyStore
    {
        public static void AddAnomalies(IEnumerable<AnomalyDto> anomalies)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var anomalyDto in anomalies)
                {
                    if (anomalyDto.OriginPlanet == null || anomalyDto.TeleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    var originPlanet = PlanetsStore.GetPlanetByName(anomalyDto.OriginPlanet);
                    var teleportPlanet = PlanetsStore.GetPlanetByName(anomalyDto.TeleportPlanet);

                    if (originPlanet == null || teleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    var anomaly = new Anomaly()
                    {
                        OriginPlanetId = originPlanet.Id,
                        TeleportPlanetId = teleportPlanet.Id
                    };

                    context.Anomalies.Add(anomaly);
                    Console.WriteLine($"Successfully imported Anomaly between planet {originPlanet.Name} and planet {teleportPlanet.Name}");
                }
                context.SaveChanges();
            }
        }

        public static void AddVictims(IEnumerable<VictimDto> victims)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var victimDto in victims)
                {
                    if (victimDto.Person == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    var person = context.People.FirstOrDefault(p => p.Name == victimDto.Person);
                    var anomaly = context.Anomalies.Find(victimDto.Id);
                    if (person == null || anomaly == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    
                    anomaly.Victims.Add(person);
                    Console.WriteLine($"Successfully imported Victim {person.Name} to Anomaly {anomaly.Id}");
                }
                context.SaveChanges();
            }
        }

        public static void AddAnomaliesWithVictims(List<AnomalyWithVictimsDto> anomalies)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var anomaly in anomalies)
                {
                    var originPlanet = PlanetsStore.GetPlanetByName(anomaly.OriginPlanet);
                    var teleportPlanet = PlanetsStore.GetPlanetByName(anomaly.TeleportPlanet);

                    if (originPlanet == null || teleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }
                    var newAnomaly = new Anomaly()
                    {
                        OriginPlanetId = originPlanet.Id,
                        TeleportPlanetId = teleportPlanet.Id
                    };
                    context.Anomalies.Add(newAnomaly);

                    foreach (var victimName in anomaly.Victims)
                    {
                        var victim = context.People.FirstOrDefault(p => originPlanet.Name == victimName);
                        if (victim != null)
                        {
                            newAnomaly.Victims.Add(victim);
                        }
                    }
                    Console.WriteLine($"Successfully imported Anomaly");
                }
                context.SaveChanges();
            }
        }

        public static IEnumerable<object> GetAnomalyWichAffectedTheMostPeople()
        {
            using (var context = new MassDefectContext())
            {
                return context.Anomalies
                    .OrderByDescending(a => a.Victims.Count)
                    .Select(a => new
                    {
                        id = a.Id,
                        originPlanet = new
                        {
                            name = a.OriginPlanet.Name
                        },
                        teleportPlanet = new
                        {
                            name = a.TeleportPlanet.Name
                        },
                        victimsCount = a.Victims.Count
                    })
                    .ToList()
                    .Take(1);
            }
        }

        public static IEnumerable<AnomalyWithVictimsForXmlDto> GetAnomaliesWithTheirVictims()
        {
            using (var context = new MassDefectContext())
            {
                return context.Anomalies
                    .OrderBy(a => a.Id)
                    .Select(a => new AnomalyWithVictimsForXmlDto()
                    {
                        Id = a.Id,
                        OriginPlanet = a.OriginPlanet.Name,
                        TeleportPlanet = a.TeleportPlanet.Name,
                        Victims = a.Victims.Select(v => new VictimsForXmlDto()
                        {
                            Name = v.Name
                        })
                    })
                    .ToList();
            }
        }
    }
}
