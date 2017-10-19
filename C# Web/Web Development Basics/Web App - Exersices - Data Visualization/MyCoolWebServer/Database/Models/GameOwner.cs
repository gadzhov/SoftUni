namespace MyCoolWebServer.Database.Models
{
    public class GameOwner
    {
        public int GameId { get; set; }

        public Game Game { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
