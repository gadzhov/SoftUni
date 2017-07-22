namespace System_Split.Models
{
    public class Express : Software
    {
        public Express(string name, int capacityConsumption, int memoryConsumption)
            : base(name)
        {
            this.MemoryConsumption = memoryConsumption * 2;
            this.CapacityConsumption = capacityConsumption;
        }

        public override int MemoryConsumption { get; set; }

        public override int CapacityConsumption { get; set; }
    }
}
