using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Status Status { get; set; }
        public virtual BusStation OriginBusStation { get; set; }
        public virtual BusStation DestinationBusStation { get; set; }
        public virtual BusCompany BusCompany { get; set; }
    }
}
