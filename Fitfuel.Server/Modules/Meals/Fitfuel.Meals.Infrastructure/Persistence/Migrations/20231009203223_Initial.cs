using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitfuel.Meals.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "meals");

            migrationBuilder.CreateTable(
                name: "meal_schedules",
                schema: "meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BreakfastTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    LunchTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DinnerTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsNotified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meal_schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                schema: "meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Calories = table.Column<int>(type: "integer", nullable: false),
                    Nutrients_Proteins = table.Column<double>(type: "double precision", nullable: false),
                    Nutrients_Fats = table.Column<double>(type: "double precision", nullable: false),
                    Nutrients_Carbs = table.Column<double>(type: "double precision", nullable: false),
                    CookingTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Recipe = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meal_schedules",
                schema: "meals");

            migrationBuilder.DropTable(
                name: "meals",
                schema: "meals");
        }
    }
}
