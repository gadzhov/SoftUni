using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class AlbumsParticipatesDeleteBehavior2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_OwnerId",
                table: "Albums");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_OwnerId",
                table: "Albums",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_OwnerId",
                table: "Albums");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_OwnerId",
                table: "Albums",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
