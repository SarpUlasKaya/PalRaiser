using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserMVC.Migrations.ApplicationDB
{
    public partial class Try3ExpandDatabaseFullyVerOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentRatings_Comments_CommentId1_CommentPostId",
                table: "CommentRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Projects_ProjectId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicReplyRatings_TopicReplies_TopicReplyId1_TopicReplyTopicId",
                table: "TopicReplyRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Projects_ProjectId",
                table: "Topics");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TopicReplyTopicId",
                table: "TopicReplyRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TopicReplyId1",
                table: "TopicReplyRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentPostId",
                table: "CommentRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentId1",
                table: "CommentRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRatings_Comments_CommentId1_CommentPostId",
                table: "CommentRatings",
                columns: new[] { "CommentId1", "CommentPostId" },
                principalTable: "Comments",
                principalColumns: new[] { "CommentId", "PostId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Projects_ProjectId",
                table: "Reports",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicReplyRatings_TopicReplies_TopicReplyId1_TopicReplyTopicId",
                table: "TopicReplyRatings",
                columns: new[] { "TopicReplyId1", "TopicReplyTopicId" },
                principalTable: "TopicReplies",
                principalColumns: new[] { "TopicReplyId", "TopicId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Projects_ProjectId",
                table: "Topics",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentRatings_Comments_CommentId1_CommentPostId",
                table: "CommentRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Projects_ProjectId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicReplyRatings_TopicReplies_TopicReplyId1_TopicReplyTopicId",
                table: "TopicReplyRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Projects_ProjectId",
                table: "Topics");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Topics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TopicReplyTopicId",
                table: "TopicReplyRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TopicReplyId1",
                table: "TopicReplyRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommentPostId",
                table: "CommentRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId1",
                table: "CommentRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRatings_Comments_CommentId1_CommentPostId",
                table: "CommentRatings",
                columns: new[] { "CommentId1", "CommentPostId" },
                principalTable: "Comments",
                principalColumns: new[] { "CommentId", "PostId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Projects_ProjectId",
                table: "Reports",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicReplyRatings_TopicReplies_TopicReplyId1_TopicReplyTopicId",
                table: "TopicReplyRatings",
                columns: new[] { "TopicReplyId1", "TopicReplyTopicId" },
                principalTable: "TopicReplies",
                principalColumns: new[] { "TopicReplyId", "TopicId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Projects_ProjectId",
                table: "Topics",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
