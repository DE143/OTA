using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTA_Portal_Service.Migrations
{
    /// <inheritdoc />
    public partial class mirated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraineeStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrainingCategoryId = table.Column<int>(type: "int", nullable: false),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchId1 = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainees_TrainingCategory_TrainingCategoryId",
                        column: x => x.TrainingCategoryId,
                        principalTable: "TrainingCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainees_batches_BatchId1",
                        column: x => x.BatchId1,
                        principalTable: "batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainees_personalProfiles_PersonId",
                        column: x => x.PersonId,
                        principalTable: "personalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingCenterCapacities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: false),
                    TrainingCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingCenterCapacities", x => x.id);
                    table.ForeignKey(
                        name: "FK_trainingCenterCapacities_TrainingCategory_TrainingCategoryId",
                        column: x => x.TrainingCategoryId,
                        principalTable: "TrainingCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainingCenterCapacities_trainingCenterLists_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "trainingCenterLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainees_BatchId1",
                table: "trainees",
                column: "BatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_PersonId",
                table: "trainees",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_TrainingCategoryId",
                table: "trainees",
                column: "TrainingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingCenterCapacities_TrainingCategoryId",
                table: "trainingCenterCapacities",
                column: "TrainingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingCenterCapacities_TrainingCenterId",
                table: "trainingCenterCapacities",
                column: "TrainingCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trainees");

            migrationBuilder.DropTable(
                name: "trainingCenterCapacities");
        }
    }
}
