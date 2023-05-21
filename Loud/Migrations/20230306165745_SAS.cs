using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class SAS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllHigh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    AreaID = table.Column<int>(type: "int", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    studentnumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SchoolType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postcode = table.Column<int>(type: "int", nullable: true),
                    campus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllHigh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartLat = table.Column<float>(type: "real", nullable: true),
                    StartLng = table.Column<float>(type: "real", nullable: true),
                    EndLat = table.Column<float>(type: "real", nullable: true),
                    EndLng = table.Column<float>(type: "real", nullable: true),
                    SASChurchPartnerID = table.Column<int>(type: "int", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "aslChurch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postaladdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MapLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    MinisterFraternalID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Attendance = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Donation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aslChurch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRegistered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chaplain",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chaplain", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChaplainTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    ChaplainTaskTypeID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignToID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChaplainTask", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChaplainTaskType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChaplainTaskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Church",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postaladdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    MapLink = table.Column<string>(type: "ntext", nullable: true),
                    WebSite = table.Column<string>(type: "ntext", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<double>(type: "float", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    MinisterFraternalID = table.Column<int>(type: "int", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SuburbID = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    postalcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Donation = table.Column<decimal>(type: "money", nullable: true),
                    externalContactUpdated = table.Column<bool>(type: "bit", nullable: true),
                    externalContactUpdated2 = table.Column<bool>(type: "bit", nullable: true),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Church", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Church_Minister",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChurchID = table.Column<int>(type: "int", nullable: true),
                    MinisterID = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Church_Minister", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChurchNew",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postaladdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    MapLink = table.Column<string>(type: "ntext", nullable: true),
                    WebSite = table.Column<string>(type: "ntext", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<double>(type: "float", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    MinisterFraternalID = table.Column<int>(type: "int", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postalcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Donation = table.Column<decimal>(type: "money", nullable: true),
                    externalContactUpdated = table.Column<bool>(type: "bit", nullable: true),
                    externalContactUpdated2 = table.Column<bool>(type: "bit", nullable: true),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    eid = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
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
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    MapLink = table.Column<string>(type: "ntext", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<float>(type: "real", nullable: true),
                    Lng = table.Column<float>(type: "real", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    MinisterFraternalID = table.Column<int>(type: "int", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Donation = table.Column<decimal>(type: "money", nullable: true),
                    eid = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurchSAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CurrentStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Opportunity = table.Column<bool>(type: "bit", nullable: true),
                    HighSchoolIcon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PrimSchoolIcon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PrivateHighIcon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PrivatePrimaryIcon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GeoAccuracy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleMeaning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoAccuracy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GeoStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meaning = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Action = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HighSchool",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<float>(type: "real", nullable: true),
                    Lng = table.Column<float>(type: "real", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    AreaID = table.Column<int>(type: "int", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighSchool", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HS_SchoolGrade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HSID = table.Column<int>(type: "int", nullable: true),
                    SchoolGradeID = table.Column<int>(type: "int", nullable: true),
                    SASTT = table.Column<byte>(type: "tinyint", nullable: true),
                    SRETT = table.Column<byte>(type: "tinyint", nullable: true),
                    Seminar = table.Column<byte>(type: "tinyint", nullable: true),
                    None = table.Column<byte>(type: "tinyint", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HS_SchoolGrade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HS_SRECoordinator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HSID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HS_SRECoordinator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Minister",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Current = table.Column<bool>(type: "bit", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minister", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MinisterFraternal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChurchID = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterFraternal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MinisterFraternalTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinisterFraternalID = table.Column<int>(type: "int", nullable: true),
                    MinisterFraternalTaskTypeID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignToID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterFraternalTask", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MinisterFraternalTaskType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterFraternalTaskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ministry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChurchID = table.Column<int>(type: "int", nullable: true),
                    MinistryTypeID = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MinistryType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewChurch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YPNum = table.Column<int>(type: "int", nullable: true),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postaladdress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pastor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Participate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MapLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    MinisterFraternalID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Attendance = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupporterNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Donation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewChurch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Overide",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overide", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrimarySchool",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SchoolCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    IsCombinedWithSelectedHS = table.Column<bool>(type: "bit", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<float>(type: "real", nullable: true),
                    Lng = table.Column<float>(type: "real", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimarySchool", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrivateHigh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    CurrentStatusID = table.Column<int>(type: "int", nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    AreaID = table.Column<int>(type: "int", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    studentnumber = table.Column<int>(type: "int", nullable: true),
                    SchoolType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    campus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    combtext = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    domain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    externalContactUpdated = table.Column<bool>(type: "bit", nullable: true),
                    externalContactUpdated2 = table.Column<bool>(type: "bit", nullable: true),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateHigh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrivatePrimary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SchoolCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASameAsSA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsCombinedWithSelectedHS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    website = table.Column<string>(type: "ntext", nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    CurrentStatusID = table.Column<int>(type: "int", nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    LockAreaID = table.Column<int>(type: "int", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    studentnumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SchoolType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    campus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    combtext = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    domain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    externalContactUpdated = table.Column<bool>(type: "bit", nullable: true),
                    externalContactUpdated2 = table.Column<bool>(type: "bit", nullable: true),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivatePrimary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PS_SchoolGrade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PSID = table.Column<int>(type: "int", nullable: true),
                    SchoolGradeID = table.Column<int>(type: "int", nullable: true),
                    SASTT = table.Column<byte>(type: "tinyint", nullable: true),
                    SRETT = table.Column<byte>(type: "tinyint", nullable: true),
                    Seminar = table.Column<byte>(type: "tinyint", nullable: true),
                    None = table.Column<byte>(type: "tinyint", nullable: true),
                    Deleted = table.Column<byte>(type: "tinyint", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_SchoolGrade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PS_SRECoordinator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PSID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PS_SRECoordinator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PublicHigh",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    CurrentStatusID = table.Column<int>(type: "int", nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    AreaID = table.Column<int>(type: "int", nullable: true),
                    LockAreaID = table.Column<bool>(type: "bit", nullable: true),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    studentnumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SchoolType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    campus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    combtext = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    domain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    externalContactUpdated = table.Column<bool>(type: "bit", nullable: true),
                    externalContactUpdated2 = table.Column<bool>(type: "bit", nullable: true),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicHigh", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PublicPrimary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    streetaddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    phone1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phone2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SchoolCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HighSchoolID = table.Column<int>(type: "int", nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    PASameAsSA = table.Column<int>(type: "int", nullable: true),
                    IsCombinedWithSelectedHS = table.Column<int>(type: "int", nullable: true),
                    website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GeoStatusID = table.Column<int>(type: "int", nullable: true),
                    GeoAccuracyID = table.Column<int>(type: "int", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true),
                    LatLongSetByUser = table.Column<bool>(type: "bit", nullable: true),
                    SREStatusID = table.Column<int>(type: "int", nullable: true),
                    CurrentStatusID = table.Column<int>(type: "int", nullable: true),
                    OverideID = table.Column<int>(type: "int", nullable: true),
                    WantsNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    LockAreaID = table.Column<int>(type: "int", nullable: true),
                    ChaplainID = table.Column<int>(type: "int", nullable: true),
                    suburb = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    studentnumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SchoolType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    postcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    campus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    combtext = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    domain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    externalContactUpdated = table.Column<bool>(type: "bit", nullable: true),
                    externalContactUpdated2 = table.Column<bool>(type: "bit", nullable: true),
                    lastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicPrimary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "QuickFilters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormNm = table.Column<int>(type: "int", nullable: true),
                    Sort1 = table.Column<int>(type: "int", nullable: true),
                    FilterNm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FilterDesc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickFilters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SASChurchPartner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SASChurchPartner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SASChurchPartnerTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SASChurchPartnerID = table.Column<int>(type: "int", nullable: true),
                    SASChurchPartnerTaskTypeID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignToID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SASChurchPartnerTask", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SASChurchPartnerTaskType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SASChurchPartnerTaskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SchoolGrade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MinYear = table.Column<int>(type: "int", nullable: true),
                    MaxYear = table.Column<int>(type: "int", nullable: true),
                    Default = table.Column<bool>(type: "bit", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolGrade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Num = table.Column<double>(type: "float", nullable: true),
                    Txt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SREBoard",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SREBoard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SREBoardTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SREBoardID = table.Column<int>(type: "int", nullable: true),
                    SREBoardTaskTypeID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignToID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SREBoardTask", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SREBoardTaskType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SREBoardTaskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SRECoordinator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    SRECoordinatorRepID = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRECoordinator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SRECoordinatorTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SRECoordinatorID = table.Column<int>(type: "int", nullable: true),
                    SRECoordinatorTaskTypeID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignToID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRECoordinatorTask", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SRECoordinatorTaskType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRECoordinatorTaskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SRERep",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SASuburbID = table.Column<int>(type: "int", nullable: true),
                    PASameAsSA = table.Column<bool>(type: "bit", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASuburbID = table.Column<int>(type: "int", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Current = table.Column<bool>(type: "bit", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRERep", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SREStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HighSchoolIcon = table.Column<int>(type: "int", nullable: true),
                    PrimSchoolIcon = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SREStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suburb",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTypeID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TripID = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoByDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VenueTypeID = table.Column<int>(type: "int", nullable: true),
                    VenueID = table.Column<int>(type: "int", nullable: true),
                    AssignToID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Complete = table.Column<bool>(type: "bit", nullable: true),
                    ItemListPos = table.Column<int>(type: "int", nullable: true),
                    ResponseRecieved = table.Column<bool>(type: "bit", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaskType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ResponseRequired = table.Column<bool>(type: "bit", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PWReset = table.Column<bool>(type: "bit", nullable: true),
                    AccessLevelID = table.Column<int>(type: "int", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Nm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Body = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tluAccessLevel", x => x.AccessLevelID);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    SRERepID = table.Column<int>(type: "int", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "ntext", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAreas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAuditEvents",
                columns: table => new
                {
                    UserAuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AuditEvent = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuditEvents", x => x.UserAuditId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllHigh");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "aslChurch");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Chaplain");

            migrationBuilder.DropTable(
                name: "ChaplainTask");

            migrationBuilder.DropTable(
                name: "ChaplainTaskType");

            migrationBuilder.DropTable(
                name: "Church");

            migrationBuilder.DropTable(
                name: "Church_Minister");

            migrationBuilder.DropTable(
                name: "ChurchNew");

            migrationBuilder.DropTable(
                name: "ChurchSAS");

            migrationBuilder.DropTable(
                name: "CurrentStatus");

            migrationBuilder.DropTable(
                name: "GeoAccuracy");

            migrationBuilder.DropTable(
                name: "GeoStatus");

            migrationBuilder.DropTable(
                name: "HighSchool");

            migrationBuilder.DropTable(
                name: "HS_SchoolGrade");

            migrationBuilder.DropTable(
                name: "HS_SRECoordinator");

            migrationBuilder.DropTable(
                name: "Minister");

            migrationBuilder.DropTable(
                name: "MinisterFraternal");

            migrationBuilder.DropTable(
                name: "MinisterFraternalTask");

            migrationBuilder.DropTable(
                name: "MinisterFraternalTaskType");

            migrationBuilder.DropTable(
                name: "Ministry");

            migrationBuilder.DropTable(
                name: "MinistryType");

            migrationBuilder.DropTable(
                name: "NewChurch");

            migrationBuilder.DropTable(
                name: "Overide");

            migrationBuilder.DropTable(
                name: "PrimarySchool");

            migrationBuilder.DropTable(
                name: "PrivateHigh");

            migrationBuilder.DropTable(
                name: "PrivatePrimary");

            migrationBuilder.DropTable(
                name: "PS_SchoolGrade");

            migrationBuilder.DropTable(
                name: "PS_SRECoordinator");

            migrationBuilder.DropTable(
                name: "PublicHigh");

            migrationBuilder.DropTable(
                name: "PublicPrimary");

            migrationBuilder.DropTable(
                name: "QuickFilters");

            migrationBuilder.DropTable(
                name: "SASChurchPartner");

            migrationBuilder.DropTable(
                name: "SASChurchPartnerTask");

            migrationBuilder.DropTable(
                name: "SASChurchPartnerTaskType");

            migrationBuilder.DropTable(
                name: "SchoolGrade");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "SREBoard");

            migrationBuilder.DropTable(
                name: "SREBoardTask");

            migrationBuilder.DropTable(
                name: "SREBoardTaskType");

            migrationBuilder.DropTable(
                name: "SRECoordinator");

            migrationBuilder.DropTable(
                name: "SRECoordinatorTask");

            migrationBuilder.DropTable(
                name: "SRECoordinatorTaskType");

            migrationBuilder.DropTable(
                name: "SRERep");

            migrationBuilder.DropTable(
                name: "SREStatus");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskType");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "tluAccessLevel");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "UserAreas");

            migrationBuilder.DropTable(
                name: "UserAuditEvents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
