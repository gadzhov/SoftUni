using System;

namespace System_Split.Models
{
    public class Power : Hardware
    {
        public Power(string name, int maximumCapacity, int maximumMemory)
            : base(name)
        {
            this.MaximumCapacity = (int)Math.Round(maximumCapacity - maximumCapacity * 0.75); ;
            this.MaximumMemory = (int)Math.Round(maximumMemory * 1.75);
        }

        public override int MaximumCapacity { get; set; }

        public override int MaximumMemory { get; set; }
    }
}
