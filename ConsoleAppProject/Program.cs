using ConsoleAppProject.DAL;
using ConsoleAppProject.DAL.Entities;

namespace ConsoleAppProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var footRep = new FootballRepository();

            using (var context = new FootballDbContext())
            {
                var team = new FootballTeam
                {
                    TeamName = "Barcelona",
                    City = "Barcelona",
                    Wins = 20,
                    Losses = 10,
                    Draws = 5
                };
                footRep.Add(team);
            }
        }
    }
}
