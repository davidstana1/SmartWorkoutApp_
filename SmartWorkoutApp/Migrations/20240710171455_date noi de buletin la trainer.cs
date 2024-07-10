using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class datenoidebuletinlatrainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNP",
                table: "Trainers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cetatenie",
                table: "Trainers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Judet",
                table: "Trainers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Trainers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Cetatenie",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Judet",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Trainers");
        }
    }
}
