using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MassDefect.Models
{
    public class Planet
    {
        public Planet()
        {
            this.Persons = new HashSet<Person>();
            this.OriginalAnomalies = new HashSet<Anomaly>();
            this.TargetAnomalies = new HashSet<Anomaly>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SunId { get; set; }
        public virtual  Star Sun { get; set; }
        public int SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<Anomaly> OriginalAnomalies { get; set; }
        public virtual ICollection<Anomaly> TargetAnomalies { get; set; }
    }
}
