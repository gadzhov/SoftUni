using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System_Split.Models
{
    public class Hardware : System
    {
        protected Hardware(string name)
            : base(name)
        {
            this.Softwares = new List<Software>();
        }

        public List<Software> Softwares { get; private set; }

        public virtual int MaximumCapacity { get; set; }

        public virtual int MaximumMemory { get; set; }

        public void AddSoftWare(Software software)
        {
            if (this.Softwares.Sum(s => s.MemoryConsumption) + software.MemoryConsumption <= this.MaximumMemory && this.Softwares.Sum(s => s.CapacityConsumption) + software.CapacityConsumption <= this.MaximumCapacity)
            {
                this.Softwares.Add(software);
            }
        }

        public void DestroySoftware(Software software)
        {
            this.Softwares.Remove(software);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Hardware Component - {base.Name}")
                .AppendLine($"Express Software Components - {this.Softwares.Count(s => s.GetType().Name == "Express")}")
                .AppendLine($"Light Software Components - {this.Softwares.Count(s => s.GetType().Name == "Light")}")
                .AppendLine($"Memory Usage: {this.Softwares.Sum(s => s.MemoryConsumption)} / {this.MaximumMemory}")
                .AppendLine(
                    $"Capacity Usage: {this.Softwares.Sum(s => s.CapacityConsumption)} / {this.MaximumCapacity}")
                .AppendLine($"Type: {this.GetType().Name}")
                .Append($"Software Components: {(this.Softwares.Count == 0 ? "None" : string.Join(", ", this.Softwares.Select(s => s.Name)))}");

            return sb.ToString();
        }
    }
}
