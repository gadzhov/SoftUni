namespace FootballBetting.Models
{
    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }
    }
}
