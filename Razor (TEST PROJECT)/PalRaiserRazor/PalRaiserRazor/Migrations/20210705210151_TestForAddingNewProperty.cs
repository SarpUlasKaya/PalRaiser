using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserRazor.Migrations
{
    public partial class TestForAddingNewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestValue",
                table: "Project",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestValue",
                table: "Project");
        }
    }
}
