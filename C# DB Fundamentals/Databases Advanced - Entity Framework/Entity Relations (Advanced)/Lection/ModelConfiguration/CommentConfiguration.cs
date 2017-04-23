using System.Data.Entity.ModelConfiguration;
using Lection.Models;

namespace Lection.ModelConfiguration
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            // One-to-Many with custom FK name
            this.HasRequired(c => c.Chirp)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ChirpRefId);
        }
    }
}
