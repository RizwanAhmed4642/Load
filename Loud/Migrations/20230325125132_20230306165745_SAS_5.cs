using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class _20230306165745_SAS_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "HighSchool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GooglePlusCode",
                table: "HighSchool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MapLink",
                table: "HighSchool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "HighSchool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalEmail",
                table: "HighSchool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalPhone",
                table: "HighSchool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Church",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PastorEmail",
                table: "Church",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PastorPhone",
                table: "Church",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Church",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "HighSchool");

            migrationBuilder.DropColumn(
                name: "GooglePlusCode",
                table: "HighSchool");

            migrationBuilder.DropColumn(
                name: "MapLink",
                table: "HighSchool");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "HighSchool");

            migrationBuilder.DropColumn(
                name: "PrincipalEmail",
                table: "HighSchool");

            migrationBuilder.DropColumn(
                name: "PrincipalPhone",
                table: "HighSchool");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "PastorEmail",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "PastorPhone",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Church");

        }
    }
}
