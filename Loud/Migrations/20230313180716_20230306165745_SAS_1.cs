using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class _20230306165745_SAS_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "streetaddress",
                table: "Church",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "postalcode",
                table: "Church",
                newName: "Postalcode");

            migrationBuilder.RenameColumn(
                name: "postaladdress",
                table: "Church",
                newName: "PostalAddress");

            migrationBuilder.AlterColumn<string>(
                name: "Nm",
                table: "SchoolGrade",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Church",
                newName: "streetaddress");

            migrationBuilder.RenameColumn(
                name: "Postalcode",
                table: "Church",
                newName: "postalcode");

            migrationBuilder.RenameColumn(
                name: "PostalAddress",
                table: "Church",
                newName: "postaladdress");

            migrationBuilder.AlterColumn<string>(
                name: "Nm",
                table: "SchoolGrade",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
