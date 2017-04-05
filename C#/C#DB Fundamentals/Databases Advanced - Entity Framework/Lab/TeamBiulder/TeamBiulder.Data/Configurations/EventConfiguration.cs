using System.Data.Entity.ModelConfiguration;
using TeamBiulder.Models;

namespace TeamBiulder.Data.Configurations
{
    class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            //Restrictions
            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(e => e.Description)
                .HasMaxLength(250);

            //***- Relations -***//

            this.HasRequired(e => e.Creator)
                .WithMany(c => c.CreatedEvents);

            this.HasMany(e => e.ParticipatingTeams)
                .WithMany(t => t.ParticipatingEvents)
                .Map(map =>
                {
                    map.MapLeftKey("EventId");
                    map.MapRightKey("TeamId");
                    map.ToTable("EventTeams");
                });

        }
    }
}
