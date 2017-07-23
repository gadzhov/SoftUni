using Problem_6.Birthday_Celebrations.Interfaces;

namespace Problem_6.Birthday_Celebrations.Models
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
