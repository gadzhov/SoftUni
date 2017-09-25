using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Migrations
{
    public partial class AlbumsParticipatesDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumParticipates_Albums_AlbumId",
                table: "AlbumParticipates");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumParticipates_Users_UserId",
                table: "AlbumParticipates");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumParticipates_Albums_AlbumId",
                table: "AlbumParticipates",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumParticipates_Users_UserId",
                table: "AlbumParticipates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumParticipates_Albums_AlbumId",
                table: "AlbumParticipates");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumParticipates_Users_UserId",
                table: "AlbumParticipates");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumParticipates_Albums_AlbumId",
                table: "AlbumParticipates",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumParticipates_Users_UserId",
                table: "AlbumParticipates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
