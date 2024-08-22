using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTA_Portal_Service.Migrations
{
    /// <inheritdoc />
    public partial class suzi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "rule",
                newName: "localDescription");

            migrationBuilder.AddColumn<string>(
                name: "localDescription",
                table: "vision",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localDescription",
                table: "testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localFullName",
                table: "testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localPosition",
                table: "testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localFullName",
                table: "teamMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localPosition",
                table: "teamMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localDescription",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localTitle",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localDescription",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localTitle",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "rule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localDescription",
                table: "mission",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localDescription",
                table: "goal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localBody",
                table: "contactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localFullName",
                table: "contactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localSubject",
                table: "contactUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localBody",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localFullName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localSubject",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "BlogsAndNews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localDescription",
                table: "BlogsAndNews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "localTitle",
                table: "BlogsAndNews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "localDescription",
                table: "vision");

            migrationBuilder.DropColumn(
                name: "localDescription",
                table: "testimonies");

            migrationBuilder.DropColumn(
                name: "localFullName",
                table: "testimonies");

            migrationBuilder.DropColumn(
                name: "localPosition",
                table: "testimonies");

            migrationBuilder.DropColumn(
                name: "localFullName",
                table: "teamMember");

            migrationBuilder.DropColumn(
                name: "localPosition",
                table: "teamMember");

            migrationBuilder.DropColumn(
                name: "localDescription",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "localTitle",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "localDescription",
                table: "services");

            migrationBuilder.DropColumn(
                name: "localTitle",
                table: "services");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "rule");

            migrationBuilder.DropColumn(
                name: "localDescription",
                table: "mission");

            migrationBuilder.DropColumn(
                name: "localDescription",
                table: "goal");

            migrationBuilder.DropColumn(
                name: "localBody",
                table: "contactUs");

            migrationBuilder.DropColumn(
                name: "localFullName",
                table: "contactUs");

            migrationBuilder.DropColumn(
                name: "localSubject",
                table: "contactUs");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "localBody",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "localFullName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "localSubject",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "BlogsAndNews");

            migrationBuilder.DropColumn(
                name: "localDescription",
                table: "BlogsAndNews");

            migrationBuilder.DropColumn(
                name: "localTitle",
                table: "BlogsAndNews");

            migrationBuilder.RenameColumn(
                name: "localDescription",
                table: "rule",
                newName: "Name");
        }
    }
}
