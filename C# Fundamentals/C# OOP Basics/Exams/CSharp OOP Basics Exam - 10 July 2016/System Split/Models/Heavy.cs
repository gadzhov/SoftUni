using System;

namespace System_Split.Models
{
    public class Heavy : Hardware
    {
        public Heavy(string name, int maximumCapacity, int maximumMemory) :
            base(name)
        {
            this.MaximumCapacity = maximumCapacity * 2;
            this.MaximumMemory = (int)Math.Round(maximumMemory - maximumMemory * 0.25);
        }

        public override int MaximumCapacity { get; set; }


        public override int MaximumMemory { get; set; }

    }
}
