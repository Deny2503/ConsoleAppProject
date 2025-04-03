using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.DAL.Entities
{
    public class FootballTeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int Goal { get; set; }
        public int GoalConceded { get; set; }
        public List<Player> Players { get; set; }
        public List<Match> Matches { get; set; }
    }
}
