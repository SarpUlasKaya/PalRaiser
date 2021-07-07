using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserMVC.Migrations
{
    public partial class TryDeleteExtraForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Users_UserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CreatorId",
                table: "Topics",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PublisherId",
                table: "Projects",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_PublisherId",
                table: "Projects",
                column: "PublisherId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Users_CreatorId",
                table: "Topics",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_PublisherId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Users_CreatorId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_CreatorId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Projects_PublisherId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Topics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Users_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
