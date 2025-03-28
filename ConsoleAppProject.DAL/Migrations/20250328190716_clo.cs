using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class clo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Goal",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalConceded",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalConceded",
                table: "Teams");
        }
    }
}
