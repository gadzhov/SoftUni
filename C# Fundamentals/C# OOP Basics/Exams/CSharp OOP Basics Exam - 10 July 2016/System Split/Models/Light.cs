namespace System_Split.Models
{
    public class Light : Software
    {
        public Light(string name, int capacityConsumption, int memoryConsumption)
            : base(name)
        {
            this.CapacityConsumption = (int)(capacityConsumption * 1.5);
            this.MemoryConsumption = (int)(memoryConsumption - memoryConsumption * 0.5);
        }

        public override int CapacityConsumption { get; set; }
        public override int MemoryConsumption { get; set; }
    }
}
