using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserMVC.Migrations
{
    public partial class TryExtendDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ReportCount",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LikeCount",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DislikeCount",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AmountRaised",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Projects",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectId");

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsReached = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => new { x.GoalId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_Goals_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Updates",
                columns: table => new
                {
                    UpdateId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Updates", x => new { x.UpdateId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_Updates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    MailAddress = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CardNumber = table.Column<int>(nullable: false),
                    CardSecNo = table.Column<int>(nullable: false),
                    CardExpDate = table.Column<int>(nullable: false),
                    LastLogin = table.Column<DateTimeOffset>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Reason = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<int>(nullable: true),
                    TopicTitle = table.Column<string>(nullable: false),
                    TopicBody = table.Column<string>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    NoOfReplies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                    table.ForeignKey(
                        name: "FK_Topics_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicReplies",
                columns: table => new
                {
                    ReplyId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ReplyBody = table.Column<string>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicReplies", x => new { x.ReplyId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_TopicReplies_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicReplies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ProjectId",
                table: "Goals",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProjectId",
                table: "Reports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicReplies_TopicId",
                table: "TopicReplies",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicReplies_UserId",
                table: "TopicReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ProjectId",
                table: "Topics",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Updates_ProjectId",
                table: "Updates",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "TopicReplies");

            migrationBuilder.DropTable(
                name: "Updates");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ReportCount",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LikeCount",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "DislikeCount",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AmountRaised",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProjId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjId");
        }
    }
}
