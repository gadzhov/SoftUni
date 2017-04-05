using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TeamBiulder.Models;

namespace TeamBiulder.Data.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            //Restrictions
            this.Property(u => u.UserName).IsRequired();
            this.Property(u => u.Password).IsRequired();

            this.Property(u => u.UserName)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Users_Username", 1) {IsUnique = true}))
                .HasMaxLength(25);

            this.Property(u => u.FirstName)
                .HasMaxLength(25);

            this.Property(u => u.LastName)
                .HasMaxLength(25);

            this.Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired();

            //***- Relations -***//
            
            //One to many
            this.HasMany(u => u.CreatedTeams)
                .WithRequired(t => t.Creator)
                .WillCascadeOnDelete(false);

            this.HasMany(u => u.CreatedEvents)
                .WithRequired(e => e.Creator)
                .WillCascadeOnDelete(false);

            this.HasMany(u => u.RecievedInvitations)
                .WithRequired(i => i.InvitedUser)
                .WillCascadeOnDelete(false);

            //Many to many
            this.HasMany(u => u.Teams)
                .WithMany(t => t.Members)
                .Map(map =>
                {
                    map.MapLeftKey("UserId");
                    map.MapRightKey("TeamId");
                    map.ToTable("UserTeams");
                });
        }
    }
}
