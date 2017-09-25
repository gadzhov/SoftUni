namespace FootballBetting.Data
{
    using FootballBetting.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballBettingContext : DbContext
    {
        public DbSet<Bet> Bets { get; set; }

        public DbSet<BetGame> BetGames { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<CompetitionType> CompetitionTypes { get; set; }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<ResultPrediction> ResultPredictions { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=FootballBetting;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<BetGame>()
                .HasKey(pk => pk.BetId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(pk => pk.GameId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.PrimaryKitColor)
                .WithMany()
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany()
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany()
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Town)
                .WithMany()
                .HasForeignKey(t => t.TownId);

            modelBuilder.Entity<Town>()
                .HasOne(t => t.Country)
                .WithMany()
                .HasForeignKey(t => t.CountryId);

            modelBuilder.Entity<CountriesContinets>()
                .HasKey(cc => new { cc.CountryId, cc.ContinentId });

            modelBuilder.Entity<CountriesContinets>()
                .HasOne(cc => cc.Country)
                .WithMany(c => c.Continetses)
                .HasForeignKey(cc => cc.CountryId);

            modelBuilder.Entity<CountriesContinets>()
                .HasOne(cc => cc.Continent)
                .WithMany(c => c.Countries)
                .HasForeignKey(cc => cc.ContinentId);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new {ps.GameId, ps.PlayerId});

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.Games)
                .HasForeignKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Game)
                .WithMany(g => g.Players)
                .HasForeignKey(ps => ps.GameId);

            modelBuilder.Entity<BetGame>()
                .HasKey(bg => new {bg.GameId, bg.BetId});

            modelBuilder.Entity<BetGame>()
                .HasOne(bg => bg.Bet)
                .WithMany(b => b.Games)
                .HasForeignKey(bg => bg.BetId);

            modelBuilder.Entity<BetGame>()
                .HasOne(bg => bg.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(bg => bg.GameId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
