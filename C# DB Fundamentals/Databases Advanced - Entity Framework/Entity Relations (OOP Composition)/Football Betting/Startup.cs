namespace Football_Betting
{
    using Football_Betting.Data;
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new FootballContext();
            context.Database.Initialize(true);
        }
    }
}
