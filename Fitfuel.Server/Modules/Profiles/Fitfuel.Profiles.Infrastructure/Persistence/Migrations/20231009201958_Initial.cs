using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitfuel.Profiles.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "profiles");

            migrationBuilder.CreateTable(
                name: "achievements",
                schema: "profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IconUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                schema: "profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight_Unit = table.Column<int>(type: "integer", nullable: false),
                    Weight_Value = table.Column<double>(type: "double precision", nullable: false),
                    Height_Unit = table.Column<int>(type: "integer", nullable: false),
                    Height_Value = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    MainPurpose = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "profile_achievements",
                schema: "profiles",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    AchievementId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile_achievements", x => new { x.ProfileId, x.AchievementId });
                    table.ForeignKey(
                        name: "FK_profile_achievements_achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalSchema: "profiles",
                        principalTable: "achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profile_achievements_profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "profiles",
                        principalTable: "profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_profile_achievements_AchievementId",
                schema: "profiles",
                table: "profile_achievements",
                column: "AchievementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profile_achievements",
                schema: "profiles");

            migrationBuilder.DropTable(
                name: "achievements",
                schema: "profiles");

            migrationBuilder.DropTable(
                name: "profiles",
                schema: "profiles");
        }
    }
}
