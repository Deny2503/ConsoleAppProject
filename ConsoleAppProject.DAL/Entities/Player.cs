using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FullName { get; set; } // ПІБ гравця
        public string Country { get; set; }
        public int PlayerNumber { get; set; } 
        public string Position { get; set; }

        public int FootballTeamId { get; set; }
        public FootballTeam FootballTeam { get; set; }
    }
}
