using Problem_3.Ferrari.Entities.Interfaces;

namespace Problem_3.Ferrari.Entities
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Brand = "Ferrari";
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Driver { get; set; }

        public string Start()
        {
            return "Zadu6avam sA!";
        }

        public string Stop()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            // <model>/<brakes>/<gas pedal>/<driver's name>
            return $"{this.Model}/{this.Stop()}/{this.Start()}/{this.Driver}";
        }
    }
}
