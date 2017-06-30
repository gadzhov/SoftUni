namespace Problem_10.Car_Salesman
{ 
    public class Engine
    {
        private string displacement = "n/a";
        private string efficiency = "n/a";

        public Engine()
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }
    }
}
