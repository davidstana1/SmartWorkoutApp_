using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class incercaredeletecascade3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseLogs_Exercises_ExerciseId",
                table: "ExerciseLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseLogs_Exercises_ExerciseId",
                table: "ExerciseLogs",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseLogs_Exercises_ExerciseId",
                table: "ExerciseLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseLogs_Exercises_ExerciseId",
                table: "ExerciseLogs",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
