using System;
using System.Linq;
using Data;

namespace Services
{
    public class BusService
    {
        public void PrintInfo(int id)
        {
            using (var context = new BusTicketContext())
            {
                var busStation = context.BusStations.Find(id);
                var arrivals = context.Trips.Where(t => t.DestinationBusStation.Id == busStation.Id);
                var departers = context.Trips.Where(t => t.OriginBusStation.Id == busStation.Id);

                Console.WriteLine($"{busStation.Name}, {busStation.Town.Name}");
                foreach (var arrival in arrivals)
                {
                    Console.WriteLine($"From {arrival.OriginBusStation.Name} | Arrive at: {arrival.ArrivalTime} | Status: {arrival.Status}");
                }
                Console.WriteLine("Departures:");
                foreach (var departer in departers)
                {
                    Console.WriteLine($"To {departer.DestinationBusStation} | Depart at: {departer.DepartureTime} | Status {departer.Status}");
                }

            }
        }
    }
}
