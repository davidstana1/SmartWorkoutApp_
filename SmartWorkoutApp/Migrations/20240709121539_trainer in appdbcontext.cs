using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class trainerinappdbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Trainer_TrainerId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainer",
                table: "Trainer");

            migrationBuilder.RenameTable(
                name: "Trainer",
                newName: "Trainers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Trainers_TrainerId",
                table: "Users",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Trainers_TrainerId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Trainer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainer",
                table: "Trainer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Trainer_TrainerId",
                table: "Users",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id");
        }
    }
}
