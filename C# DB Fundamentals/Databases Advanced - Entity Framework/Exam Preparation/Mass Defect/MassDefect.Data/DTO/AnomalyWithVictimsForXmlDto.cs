using System.Collections.Generic;

namespace MassDefect.Data.DTO
{
    public class AnomalyWithVictimsForXmlDto
    {
        public AnomalyWithVictimsForXmlDto()
        {
            this.Victims = new List<VictimsForXmlDto>();
        }
        public int Id { get; set; }
        public string OriginPlanet { get; set; }
        public string TeleportPlanet { get; set; }
        public IEnumerable<VictimsForXmlDto> Victims { get; set; }
    }
}
