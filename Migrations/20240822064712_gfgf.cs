using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTA_Portal_Service.Migrations
{
    /// <inheritdoc />
    public partial class gfgf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_batches_trainingCenterLists_TrainingCenterId1",
                table: "batches");

            migrationBuilder.DropForeignKey(
                name: "FK_trainees_batches_BatchId1",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_trainees_BatchId1",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_batches_TrainingCenterId1",
                table: "batches");

            migrationBuilder.DropColumn(
                name: "BatchId1",
                table: "trainees");

            migrationBuilder.DropColumn(
                name: "TrainingCenterId1",
                table: "batches");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "trainees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "TrainingCenterId",
                table: "batches",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "batches",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_BatchId",
                table: "trainees",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_batches_TrainingCenterId",
                table: "batches",
                column: "TrainingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_batches_trainingCenterLists_TrainingCenterId",
                table: "batches",
                column: "TrainingCenterId",
                principalTable: "trainingCenterLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_batches_BatchId",
                table: "trainees",
                column: "BatchId",
                principalTable: "batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_batches_trainingCenterLists_TrainingCenterId",
                table: "batches");

            migrationBuilder.DropForeignKey(
                name: "FK_trainees_batches_BatchId",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_trainees_BatchId",
                table: "trainees");

            migrationBuilder.DropIndex(
                name: "IX_batches_TrainingCenterId",
                table: "batches");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "trainees");

            migrationBuilder.AddColumn<int>(
                name: "BatchId1",
                table: "trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainingCenterId",
                table: "batches",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "batches",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TrainingCenterId1",
                table: "batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_trainees_BatchId1",
                table: "trainees",
                column: "BatchId1");

            migrationBuilder.CreateIndex(
                name: "IX_batches_TrainingCenterId1",
                table: "batches",
                column: "TrainingCenterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_batches_trainingCenterLists_TrainingCenterId1",
                table: "batches",
                column: "TrainingCenterId1",
                principalTable: "trainingCenterLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_batches_BatchId1",
                table: "trainees",
                column: "BatchId1",
                principalTable: "batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
