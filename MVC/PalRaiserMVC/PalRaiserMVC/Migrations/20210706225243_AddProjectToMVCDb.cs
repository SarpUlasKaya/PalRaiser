using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserMVC.Migrations
{
    public partial class AddProjectToMVCDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjName = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    About = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    AmountRaised = table.Column<string>(nullable: true),
                    LikeCount = table.Column<string>(nullable: true),
                    DislikeCount = table.Column<string>(nullable: true),
                    ReportCount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
