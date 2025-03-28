using ConsoleAppProject.DAL;
using ConsoleAppProject.DAL.Entities;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var footRep = new FootballRepository();

            foreach (var team in footRep.GetAll())
            {
                Console.WriteLine($"Team {team.TeamName} from {team.City}" +
                    $", Wins {team.Wins}, Losses {team.Losses}, Draw {team.Draws}");
            }


        }
    }
}
