using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class TraineramfacutsafiecaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Trainer",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Trainer",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Trainer");
        }
    }
}
