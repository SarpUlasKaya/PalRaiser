using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserRazor.Migrations
{
    public partial class AddProjectToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjName = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    DetailedInfo = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    AmountRaised = table.Column<int>(nullable: true),
                    likeCount = table.Column<int>(nullable: true),
                    DislikeCount = table.Column<int>(nullable: true),
                    ReportCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
