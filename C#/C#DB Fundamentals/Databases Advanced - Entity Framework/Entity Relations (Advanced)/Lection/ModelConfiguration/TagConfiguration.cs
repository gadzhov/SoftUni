using System.Data.Entity.ModelConfiguration;
using Lection.Models;

namespace Lection.ModelConfiguration
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            // Many-to-Many with custom FK names
            this.HasKey(t => t.TagRef)
                            .HasMany(t => t.Chirps)
                            .WithMany(c => c.Tags)
                            .Map(m =>
                            {
                                m.ToTable("ChirpTags");
                                m.MapLeftKey("TagRef");
                                m.MapRightKey("ChirpId");
                            });
        }
    }
}
