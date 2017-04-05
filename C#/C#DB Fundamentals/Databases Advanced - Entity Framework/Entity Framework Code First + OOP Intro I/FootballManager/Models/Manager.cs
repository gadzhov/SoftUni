namespace FootballManager.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
