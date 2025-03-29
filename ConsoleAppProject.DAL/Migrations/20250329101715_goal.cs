using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class goal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO Teams (TeamName, City, Wins, Losses, Draws, Goal, GoalConceded)
            VALUES
            ('Real Madrid', 'Madrid', 10, 2, 1, 26, 20),
            ('FC Barcelona', 'Barcelona', 8, 4, 2, 30, 10),
            ('Atletico Madrid', 'Madrid', 7, 5, 3, 24, 19),
            ('Sevilla FC', 'Sevilla', 9, 3, 2, 20, 23),
            ('Valencia CF', 'Valencia', 6, 6, 3, 19, 26);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
