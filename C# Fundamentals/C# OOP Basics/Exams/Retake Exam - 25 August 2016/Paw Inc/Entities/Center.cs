using System.Collections.Generic;
using Paw_Inc.Entities.Centers;

namespace Paw_Inc.Entities
{
    public abstract class Center
    {
        public Center(string name)
        {
            this.Name = name;
            this.Animals = new Dictionary<string, List<Animal>>();
        }
        public string Name { get; set; }

        public Dictionary<string, List<Animal>> Animals { get; set; }
    }
}