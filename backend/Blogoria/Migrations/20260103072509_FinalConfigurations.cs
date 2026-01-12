using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogoria.Migrations
{
    /// <inheritdoc />
    public partial class FinalConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Blogs_BlogId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Users_UserId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Blogs_BlogId",
                table: "UserReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions");

            migrationBuilder.DropIndex(
                name: "IX_UserReactions_UserId",
                table: "UserReactions");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "UserReactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserReactions_UserId_BlogId",
                table: "UserReactions",
                columns: new[] { "UserId", "BlogId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Blogs_BlogId",
                table: "UserComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Users_UserId",
                table: "UserComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Blogs_BlogId",
                table: "UserReactions",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Blogs_BlogId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Users_UserId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Blogs_BlogId",
                table: "UserReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions");

            migrationBuilder.DropIndex(
                name: "IX_UserReactions_UserId_BlogId",
                table: "UserReactions");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "UserReactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "UserComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserReactions_UserId",
                table: "UserReactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Blogs_BlogId",
                table: "UserComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Users_UserId",
                table: "UserComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Blogs_BlogId",
                table: "UserReactions",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
