using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTA_Portal_Service.Migrations
{
    /// <inheritdoc />
    public partial class comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogsAndNews_blodsAndNewsId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "blodsAndNewsId",
                table: "Comments",
                newName: "blogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_blodsAndNewsId",
                table: "Comments",
                newName: "IX_Comments_blogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogsAndNews_blogId",
                table: "Comments",
                column: "blogId",
                principalTable: "BlogsAndNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BlogsAndNews_blogId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "blogId",
                table: "Comments",
                newName: "blodsAndNewsId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_blogId",
                table: "Comments",
                newName: "IX_Comments_blodsAndNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BlogsAndNews_blodsAndNewsId",
                table: "Comments",
                column: "blodsAndNewsId",
                principalTable: "BlogsAndNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
