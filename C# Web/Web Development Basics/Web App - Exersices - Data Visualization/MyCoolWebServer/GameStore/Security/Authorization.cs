namespace MyCoolWebServer.GameStore.Security
{
    using System.Collections.Generic;

    public class Authorization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public List<int> OwnedGamesId { get; set; }
    }
}
