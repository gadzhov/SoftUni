using Problem_5.Border_Control.Interfaces;

namespace Problem_5.Border_Control.Models
{
    public class Robot : IRobots, ITracking
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
    }
}
