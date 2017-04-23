using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TeamBiulder.Models;

namespace TeamBiulder.Data.Configurations
{
    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            this.Property(t => t.Name)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Teams_Name", 1) {IsUnique = true}))
                .HasMaxLength(25);

            this.Property(t => t.Description)
                .HasMaxLength(32);

            this.Property(t => t.Acronym)
                .HasMaxLength(3);
        }
    }
}
