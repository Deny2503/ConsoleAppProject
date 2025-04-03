using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.DAL.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int Team1Id { get; set; }
        public FootballTeam Team1 { get; set; } // Команда 1

        public int Team2Id { get; set; }
        public FootballTeam Team2 { get; set; } // Команда 2

        public int Team1Goals { get; set; } // Кількість забитих Командою 1
        public int Team2Goals { get; set; } // Кількість забитих Командою 2

        public string Scorers { get; set; } // Інформація про того, хто забив
        public DateTime MatchDate { get; set; } // Дата матчу
    }
}
