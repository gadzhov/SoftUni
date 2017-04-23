using System.Data.Entity.ModelConfiguration;
using Lection.Models;

namespace Lection.ModelConfiguration
{
    public class ChImgConfiguration : EntityTypeConfiguration<ChImg>
    {
        public ChImgConfiguration()
        {
            // One-to-Zero-or-One
            // this.HasRequired(c => c.Chirp).WithOptional(c => c.Image);

            // One-to-One
            this.HasKey(c => c.ChirpId) // Shared Key
                .HasRequired(c => c.Chirp)
                .WithRequiredDependent(c => c.Image);
        }
    }
}
