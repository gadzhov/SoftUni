namespace FootballBetting
{
    using FootballBetting.Data;

    public class Startup
    {
        public static void Main()
        {
            using (FootballBettingContext context = new FootballBettingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
