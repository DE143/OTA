using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTA_Portal_Service.Migrations
{
    /// <inheritdoc />
    public partial class hgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NationalityName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalNationalityName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "educationalLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educationalLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personalProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AmharicMiddleName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AmharicLastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MotherFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherMiddleName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MotherLastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AmharicMotherFirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AmharicMotherMiddleName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AmharicMotherLastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationalLevelId = table.Column<int>(type: "int", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsiblePerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsiblePersonMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsibleIdNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FingerPrintId = table.Column<int>(type: "int", nullable: false),
                    RegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumAge = table.Column<int>(type: "int", nullable: false),
                    EducationLevelId = table.Column<int>(type: "int", nullable: false),
                    CapacityPerTraining = table.Column<int>(type: "int", nullable: false),
                    NoOfTrainingDays = table.Column<int>(type: "int", nullable: false),
                    NoOfTrainingDaysAdd = table.Column<int>(type: "int", nullable: false),
                    NoOfTrainingDaysUpgrade = table.Column<int>(type: "int", nullable: false),
                    PreRequisitYear = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCategory_educationalLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "educationalLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "zoneLists",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Seffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalSuffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsCity = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zoneLists", x => x.ZoneId);
                    table.ForeignKey(
                        name: "FK_zoneLists_regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingCenterLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingCenterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceZoneId = table.Column<int>(type: "int", nullable: false),
                    TinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longtuide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitiude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingCenterLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainingCenterLists_zoneLists_ServiceZoneId",
                        column: x => x.ServiceZoneId,
                        principalTable: "zoneLists",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "woredas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_woredas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_woredas_zoneLists_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "zoneLists",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingCenterId1 = table.Column<int>(type: "int", nullable: false),
                    TrainingCategoryId = table.Column<int>(type: "int", nullable: false),
                    BatchNo = table.Column<int>(type: "int", nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LetterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateAdd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateUpgrade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BatchStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_batches_TrainingCategory_TrainingCategoryId",
                        column: x => x.TrainingCategoryId,
                        principalTable: "TrainingCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_batches_trainingCenterLists_TrainingCenterId1",
                        column: x => x.TrainingCenterId1,
                        principalTable: "trainingCenterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    WoredaId = table.Column<int>(type: "int", nullable: true),
                    Kebele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    OfficePhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PoBox = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_addresses_regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "regions",
                        principalColumn: "RegionId");
                    table.ForeignKey(
                        name: "FK_addresses_woredas_WoredaId",
                        column: x => x.WoredaId,
                        principalTable: "woredas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_addresses_zoneLists_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "zoneLists",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_CountryId",
                table: "addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_RegionId",
                table: "addresses",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_WoredaId",
                table: "addresses",
                column: "WoredaId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_ZoneId",
                table: "addresses",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_batches_TrainingCategoryId",
                table: "batches",
                column: "TrainingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_batches_TrainingCenterId1",
                table: "batches",
                column: "TrainingCenterId1");

            migrationBuilder.CreateIndex(
                name: "IX_regions_CountryId",
                table: "regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCategory_EducationLevelId",
                table: "TrainingCategory",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingCenterLists_ServiceZoneId",
                table: "trainingCenterLists",
                column: "ServiceZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_woredas_ZoneId",
                table: "woredas",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_zoneLists_RegionId",
                table: "zoneLists",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "batches");

            migrationBuilder.DropTable(
                name: "personalProfiles");

            migrationBuilder.DropTable(
                name: "woredas");

            migrationBuilder.DropTable(
                name: "TrainingCategory");

            migrationBuilder.DropTable(
                name: "trainingCenterLists");

            migrationBuilder.DropTable(
                name: "educationalLevels");

            migrationBuilder.DropTable(
                name: "zoneLists");

            migrationBuilder.DropTable(
                name: "regions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
