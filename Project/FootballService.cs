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
        public Dictionary<string, int> GetGoalDifference()
        {
            var teams = _footballrepository.GetAll();
            var goalDifferences = new Dictionary<string, int>();

            foreach (var team in teams)
            {
                int goalDifference = 0;

                if (team.Matches != null && team.Matches.Any())
                {
                    goalDifference += team.Matches
                        .Where(m => m.Team1Id == team.Id)
                        .Sum(m => m.Team1Goals - m.Team2Goals);

                    goalDifference += team.Matches
                        .Where(m => m.Team2Id == team.Id)
                        .Sum(m => m.Team2Goals - m.Team1Goals);
                }

                goalDifferences[team.TeamName] = goalDifference;
            }

            return goalDifferences;
        }
        public Match GetMatchDetails(int matchId)
        {
            return _footballrepository.GetMatchById(matchId);
        }
        public List<Match> GetMatchesByDate(DateTime date)
        {
            return _footballrepository.GetMatchesByDate(date);
        }
        public List<Match> GetMatchesForTeam(int teamId)
        {
            return _footballrepository.GetMatchesForTeam(teamId);
        }
        public List<Player> GetScorersByDate(DateTime date)
        {
            var matches = _footballrepository.GetMatchesByDate(date);

            if (matches == null || !matches.Any())
            {
                Console.WriteLine("Матчи на указанную дату не найдены.");
                return new List<Player>();
            }

            var scorers = new List<Player>();

            foreach (var match in matches)
            {
                if (!string.IsNullOrEmpty(match.Scorers))
                {
                    var playerNames = match.Scorers.Split(',');

                    foreach (var playerName in playerNames.Select(p => p.Trim()))
                    {
                        Player player = null;

                        if (match.Team1?.Players != null)
                        {
                            player = match.Team1.Players.FirstOrDefault(p => p.FullName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
                        }

                        if (player == null && match.Team2?.Players != null)
                        {
                            player = match.Team2.Players.FirstOrDefault(p => p.FullName.Equals(playerName, StringComparison.OrdinalIgnoreCase));
                        }

                        if (player != null)
                        {
                            scorers.Add(player);
                        }
                    }
                }
            }

            if (!scorers.Any())
            {
                Console.WriteLine("Игроки, забившие голы в указанную дату, не найдены.");
            }

            return scorers;
        }
        public string AddMatch(Match match)
        {
            var existingMatch = _footballrepository.GetAllMatches()
                .FirstOrDefault(m => m.Team1.TeamName == match.Team1.TeamName &&
                                     m.Team2.TeamName == match.Team2.TeamName &&
                                     m.MatchDate == match.MatchDate);

            if (existingMatch != null)
            {
                return "Такой матч уже существует!";
            }

            _footballrepository.Add(match);
            return "Матч успешно добавлен!";
        }
        public string UpdateMatch(Match match)
        {
            var existingMatch = _footballrepository.GetMatchById(match.Id);

            if (existingMatch == null)
            {
                return "Матч не найден!";
            }

            existingMatch.Team1Goals = match.Team1Goals;
            existingMatch.Team2Goals = match.Team2Goals;
            existingMatch.Scorers = match.Scorers;
            _footballrepository.Update(existingMatch);

            return "Данные матча успешно обновлены!";
        }
        public string DeleteMatch(string team1Name, string team2Name, DateTime matchDate)
        {
            var match = _footballrepository.GetAllMatches()
                .FirstOrDefault(m => m.Team1.TeamName == team1Name &&
                                     m.Team2.TeamName == team2Name &&
                                     m.MatchDate == matchDate);

            if (match == null)
            {
                return "Матч не найден!";
            }

            Console.WriteLine($"Вы уверены, что хотите удалить матч {team1Name} vs {team2Name} на {matchDate.ToShortDateString()}? (y/n)");
            var confirm = Console.ReadKey();
            if (confirm.KeyChar == 'y' || confirm.KeyChar == 'Y')
            {
                _footballrepository.Delete(match);
                return "Матч успешно удален!";
            }

            return "Удаление отменено.";
        }
    }
}
