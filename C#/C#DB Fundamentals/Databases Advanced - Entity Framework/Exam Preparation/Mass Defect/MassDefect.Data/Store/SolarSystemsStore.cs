namespace MassDefect.Data.Store
{
    using DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    public static class SolarSystemsStore
    {
        public static void AddSolarSystems(IEnumerable<SolarSystemDto> systems)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var system in systems)
                {
                    if (system.Name == null)
                    {
                        Console.WriteLine("Invalid data.");
                    }
                    else
                    {
                        context.SolarSystems.Add(new SolarSystem() { Name = system.Name });
                        Console.WriteLine($"Successfully imported Solar System {system.Name}");
                    }
                }
                context.SaveChanges();
            }
        }

        public static SolarSystem GetSolarSystemByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                return context.SolarSystems
                            .FirstOrDefault(s => s.Name == name);
            }
        }
    }
}
