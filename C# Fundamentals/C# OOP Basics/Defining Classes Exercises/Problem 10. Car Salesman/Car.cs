namespace Problem_10.Car_Salesman
{
    public class Car
    {
        private string weight = "n/a";
        private string color = "n/a";

        public Car()
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            return $"{this.Model}:\n  {this.Engine.Model}:\n    Power: {this.Engine.Power}\n   Displacement: {this.Engine.Displacement}\n    Efficiency: {this.Engine.Efficiency}\n  Weight: {this.Weight}\n  Color: {this.Color}";
        }
    }
}
