using System.Data.Entity.ModelConfiguration;
using Lection.Models;

namespace Lection.ModelConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // Do not include property
            this.Ignore(u => u.CurrentSessionId);

            this.ToTable("People");

            this.HasKey(u => u.Key);

            this.Property(u => u.Alias)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(50);

            // Self-To-Many
            this.HasMany(u => u.FriendRequestMade)
                .WithMany(u => u.FriendRequestsAccepted)
                .Map(m =>
                {
                    m.ToTable("UserFriends");
                    m.MapLeftKey("RequestedUserId");
                    m.MapRightKey("AcceptedUserId");
                });
        }
    }
}
