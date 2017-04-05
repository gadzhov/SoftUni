namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModelsUsers : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserFriends");
            AddPrimaryKey("dbo.UserFriends", new[] { "UserId", "FriendId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserFriends");
            AddPrimaryKey("dbo.UserFriends", new[] { "FriendId", "UserId" });
        }
    }
}
