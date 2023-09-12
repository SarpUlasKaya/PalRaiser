using Microsoft.EntityFrameworkCore.Migrations;

namespace PalRaiserMVC.Migrations
{
    public partial class Try1FixKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AppUsers_CommentorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowRequests_AppUsers_ReceiverId",
                table: "FollowRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRatings_AppUsers_UserId",
                table: "PostRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRatings_AppUsers_UserId",
                table: "ProjectRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AppUsers_UserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicRatings_AppUsers_UserId",
                table: "TopicRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicReplies_AppUsers_UserId",
                table: "TopicReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicReplyRatings_AppUsers_UserId",
                table: "TopicReplyRatings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TopicReplyRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TopicReplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TopicRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProjectRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PostRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "FollowRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CommentorId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AppUsers_CommentorId",
                table: "Comments",
                column: "CommentorId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowRequests_AppUsers_ReceiverId",
                table: "FollowRequests",
                column: "ReceiverId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRatings_AppUsers_UserId",
                table: "PostRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRatings_AppUsers_UserId",
                table: "ProjectRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AppUsers_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicRatings_AppUsers_UserId",
                table: "TopicRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicReplies_AppUsers_UserId",
                table: "TopicReplies",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicReplyRatings_AppUsers_UserId",
                table: "TopicReplyRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AppUsers_CommentorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowRequests_AppUsers_ReceiverId",
                table: "FollowRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRatings_AppUsers_UserId",
                table: "PostRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRatings_AppUsers_UserId",
                table: "ProjectRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AppUsers_UserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicRatings_AppUsers_UserId",
                table: "TopicRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicReplies_AppUsers_UserId",
                table: "TopicReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicReplyRatings_AppUsers_UserId",
                table: "TopicReplyRatings");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TopicReplyRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TopicReplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TopicRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProjectRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PostRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "FollowRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentorId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AppUsers_CommentorId",
                table: "Comments",
                column: "CommentorId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowRequests_AppUsers_ReceiverId",
                table: "FollowRequests",
                column: "ReceiverId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostRatings_AppUsers_UserId",
                table: "PostRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRatings_AppUsers_UserId",
                table: "ProjectRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AppUsers_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicRatings_AppUsers_UserId",
                table: "TopicRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicReplies_AppUsers_UserId",
                table: "TopicReplies",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicReplyRatings_AppUsers_UserId",
                table: "TopicReplyRatings",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");
        }
    }
}
