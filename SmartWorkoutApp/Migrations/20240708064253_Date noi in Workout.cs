using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkoutApp.Migrations
{
    /// <inheritdoc />
    public partial class DatenoiinWorkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Workouts");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Workouts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
