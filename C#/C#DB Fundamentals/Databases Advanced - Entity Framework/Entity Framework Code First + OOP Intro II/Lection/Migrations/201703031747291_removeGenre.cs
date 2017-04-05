namespace Lection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GenreMovies", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.GenreMovies", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.GenreMovies", new[] { "Genre_Id" });
            DropIndex("dbo.GenreMovies", new[] { "Movie_Id" });
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            DropTable("dbo.GenreMovies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Movie_Id });
            
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            CreateIndex("dbo.GenreMovies", "Movie_Id");
            CreateIndex("dbo.GenreMovies", "Genre_Id");
            AddForeignKey("dbo.GenreMovies", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreMovies", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
