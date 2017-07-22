namespace System_Split.Models
{
    public class Software : System
    {
        protected Software(string name)
            : base(name)
        {
        }

        public virtual int CapacityConsumption { get; set; }

        public virtual int MemoryConsumption { get; set; }
    }
}
