using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserMVC.Migrations
{
    public partial class TryToConnectUsersBetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AppUsers_AppUserUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppUserUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AuthId",
                table: "AppUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AuthId",
                table: "AppUsers",
                column: "AuthId",
                unique: true,
                filter: "[AuthId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AspNetUsers_AuthId",
                table: "AppUsers",
                column: "AuthId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AspNetUsers_AuthId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AuthId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserUserId",
                table: "AspNetUsers",
                column: "AppUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AppUsers_AppUserUserId",
                table: "AspNetUsers",
                column: "AppUserUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
