using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_ExerciseLogs_ExerciseLogId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_ExerciseLogId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "ExerciseLogId",
                table: "Workouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExerciseLogId",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ExerciseLogId",
                table: "Workouts",
                column: "ExerciseLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_ExerciseLogs_ExerciseLogId",
                table: "Workouts",
                column: "ExerciseLogId",
                principalTable: "ExerciseLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
