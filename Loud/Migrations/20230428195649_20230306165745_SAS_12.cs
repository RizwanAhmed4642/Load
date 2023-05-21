using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class _20230306165745_SAS_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllHigh");

            migrationBuilder.DropTable(
                name: "aslChurch");

            migrationBuilder.DropTable(
                name: "ChurchNew");

            migrationBuilder.DropTable(
                name: "ChurchSAS");

            migrationBuilder.DropTable(
                name: "NewChurch");

            migrationBuilder.DropTable(
                name: "QuickFilters");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "tluAccessLevel");

            migrationBuilder.AlterColumn<int>(
                name: "Participate",
                table: "Church",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "Church",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Church",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "eid",
                table: "Church",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "eid",
                table: "Church");

            migrationBuilder.AlterColumn<bool>(
                name: "Participate",
                table: "Church",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AllHigh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(type: "int", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: false),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: false),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    SchoolType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    campus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postcode = table.Column<int>(type: "int", nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    studentnumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllHigh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aslChurch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: false),
                    MapLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MinisterFraternalID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: false),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    postaladdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aslChurch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ChurchNew",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donation = table.Column<decimal>(type: "money", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoAccuracyID = table.Column<double>(type: "float", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: false),
                    MapLink = table.Column<string>(type: "ntext", nullable: true),
                    MinisterFraternalID = table.Column<int>(type: "int", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: false),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<int>(type: "int", nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    WebSite = table.Column<string>(type: "ntext", nullable: true),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    eid = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    externalContactUpdated = table.Column<bool>(type: "bit", nullable: false),
                    externalContactUpdated2 = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    postaladdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurchNew", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChurchSAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donation = table.Column<decimal>(type: "money", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<float>(type: "real", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: false),
                    Lng = table.Column<float>(type: "real", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: false),
                    MapLink = table.Column<string>(type: "ntext", nullable: true),
                    MinisterFraternalID = table.Column<int>(type: "int", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: false),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<int>(type: "int", nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    eid = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurchSAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewChurch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attendance = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: false),
                    MapLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MinisterFraternalID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: false),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    postaladdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewChurch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "QuickFilters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FilterNm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FormNm = table.Column<int>(type: "int", nullable: true),
                    Sort1 = table.Column<int>(type: "int", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickFilters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessLevelID = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PWReset = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "ntext", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tluAccessLevel",
                columns: table => new
                {
                    AccessLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessLevel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tluAccessLevel", x => x.AccessLevelID);
                });
        }
    }
}
