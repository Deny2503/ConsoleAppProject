using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppProject.DAL.Entities;
using ConsoleAppProject.DAL;

namespace Project
{
    internal class FootballService
    {
        private readonly FootballRepository _footballrepository;
        public FootballService()
        {
            _footballrepository = new FootballRepository();
        }
        public void Add(FootballTeam team)
        {
            var existingTeam = _footballrepository.GetAll()
                .FirstOrDefault();
            if (existingTeam != null)
            {
                Console.WriteLine("Команда з такою назвою та містом вже існує");
            }
            else
            {
                _footballrepository.Add(team);
            }
        }
        public void AddRange(List<FootballTeam> streams)
        {
            _footballrepository.AddRange(streams);
        }
        public void Update(FootballTeam team)
        {
            var existingTeam = _footballrepository.GetAll()
                .FirstOrDefault();
            if (existingTeam != null)
            {
                existingTeam.Wins = team.Wins;
                existingTeam.Losses = team.Losses;
                existingTeam.Draws = team.Draws;
                existingTeam.Goal = team.Goal;
                existingTeam.GoalConceded = team.GoalConceded;
                _footballrepository.Update(existingTeam);
                Console.WriteLine("Дані команди успішно оновлено.");
            }
            else
            {
                Console.WriteLine("Команда не знайдена");
            }
        }
        public void Delete(FootballTeam team)
        {
            _footballrepository.Delete(team);
        }
        public void DeleteTeam(string teamName, string city)
        {
            var teamToDelete = _footballrepository.GetAll()
                .FirstOrDefault();
            if (teamToDelete != null)
            {
                Console.WriteLine($"Ви справді хочете видалити команду {teamToDelete.TeamName} з міста {teamToDelete.City}? (y/n)");
                var confirmation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (confirmation == 'y' || confirmation == 'Y')
                {
                    _footballrepository.Delete(teamToDelete);
                    Console.WriteLine("Команда успішно видалена.");
                }
                else
                {
                    Console.WriteLine("Видалення скасовано.");
                }
            }
            else
            {
                Console.WriteLine("Команда не знайдена.");
            }
        }
        public IEnumerable<FootballTeam> GetAll()
        {
            return _footballrepository.GetAll();
        }
        public List<FootballTeam> SearchTeam(string name)
        {
            return _footballrepository.GetAll().Where(x => x.TeamName.Contains(name)).ToList();
        }
        public List<FootballTeam> SearchCity(string city)
        {
            return _footballrepository.GetAll().Where(x => x.City.Contains(city)).ToList();
        }
        public List<FootballTeam> SearchTeamAndCity(string name, string city)
        {
            return _footballrepository.GetAll().Where(x => x.TeamName.Contains(name) && x.City.Contains(city)).ToList();
        }
        public FootballTeam GetTeamWithMostWins()
        {
            return _footballrepository.GetAll().OrderByDescending(t => t.Wins).FirstOrDefault();
        }
        public FootballTeam GetTeamWithMostLosses()
        {
            return _footballrepository.GetAll().OrderByDescending(t => t.Losses).FirstOrDefault();
        }
        public FootballTeam GetTeamWithMostDraws()
        {
            return _footballrepository.GetAll().OrderByDescending(t => t.Draws).FirstOrDefault();
        }
        public FootballTeam GetTeamWithMostGoals()
        {
            return _footballrepository.GetAll().OrderByDescending(t => t.Goal).FirstOrDefault();
        }
        public FootballTeam GetTeamWithMostMissedGoals()
        {
            return _footballrepository.GetAll().OrderByDescending(t => t.GoalConceded).FirstOrDefault();
        }



    }
}
