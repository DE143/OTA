using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTA_Portal_Service.Migrations
{
    /// <inheritdoc />
    public partial class djs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_batches_TrainingCategory_TrainingCategoryId",
                table: "batches");

            migrationBuilder.DropForeignKey(
                name: "FK_trainees_TrainingCategory_TrainingCategoryId",
                table: "trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCategory_educationalLevels_EducationLevelId",
                table: "TrainingCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_trainingCenterCapacities_TrainingCategory_TrainingCategoryId",
                table: "trainingCenterCapacities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingCategory",
                table: "TrainingCategory");

            migrationBuilder.RenameTable(
                name: "TrainingCategory",
                newName: "trainingCategories");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingCategory_EducationLevelId",
                table: "trainingCategories",
                newName: "IX_trainingCategories_EducationLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trainingCategories",
                table: "trainingCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_batches_trainingCategories_TrainingCategoryId",
                table: "batches",
                column: "TrainingCategoryId",
                principalTable: "trainingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_trainingCategories_TrainingCategoryId",
                table: "trainees",
                column: "TrainingCategoryId",
                principalTable: "trainingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainingCategories_educationalLevels_EducationLevelId",
                table: "trainingCategories",
                column: "EducationLevelId",
                principalTable: "educationalLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainingCenterCapacities_trainingCategories_TrainingCategoryId",
                table: "trainingCenterCapacities",
                column: "TrainingCategoryId",
                principalTable: "trainingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_batches_trainingCategories_TrainingCategoryId",
                table: "batches");

            migrationBuilder.DropForeignKey(
                name: "FK_trainees_trainingCategories_TrainingCategoryId",
                table: "trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_trainingCategories_educationalLevels_EducationLevelId",
                table: "trainingCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_trainingCenterCapacities_trainingCategories_TrainingCategoryId",
                table: "trainingCenterCapacities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trainingCategories",
                table: "trainingCategories");

            migrationBuilder.RenameTable(
                name: "trainingCategories",
                newName: "TrainingCategory");

            migrationBuilder.RenameIndex(
                name: "IX_trainingCategories_EducationLevelId",
                table: "TrainingCategory",
                newName: "IX_TrainingCategory_EducationLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingCategory",
                table: "TrainingCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_batches_TrainingCategory_TrainingCategoryId",
                table: "batches",
                column: "TrainingCategoryId",
                principalTable: "TrainingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_TrainingCategory_TrainingCategoryId",
                table: "trainees",
                column: "TrainingCategoryId",
                principalTable: "TrainingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCategory_educationalLevels_EducationLevelId",
                table: "TrainingCategory",
                column: "EducationLevelId",
                principalTable: "educationalLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainingCenterCapacities_TrainingCategory_TrainingCategoryId",
                table: "trainingCenterCapacities",
                column: "TrainingCategoryId",
                principalTable: "TrainingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
