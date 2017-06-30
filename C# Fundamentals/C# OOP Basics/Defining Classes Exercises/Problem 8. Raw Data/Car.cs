using System.Collections.Generic;

namespace Problem_8.Raw_Data
{
    class Car
    {
        public Car()
        {
            this.Tires = new List<Tire>(4);
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tire> Tires { get; set; }
    }
}
