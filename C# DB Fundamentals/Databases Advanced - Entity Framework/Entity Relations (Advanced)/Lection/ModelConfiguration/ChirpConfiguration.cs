using System.Data.Entity.ModelConfiguration;
using Lection.Models;

namespace Lection.ModelConfiguration
{
    public class ChirpConfiguration : EntityTypeConfiguration<Chirp>
    {
        public ChirpConfiguration()
        {
            this.Property(c => c.Id).HasColumnName("Key");

            this.Property(c => c.Content)
                .HasMaxLength(130)
                .IsRequired();
        }
    }
}
