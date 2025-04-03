using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppProject.DAL.Entities;

namespace Project
{
    public class MenuService
    {
        private FootballService footSer = new FootballService();
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("1. Добавить новый матч.");
                Console.WriteLine("2. Изменить данные существующего матча.");
                Console.WriteLine("3. Удалить матч.");
                Console.WriteLine("5. Показати різницю забитих та пропущених голів для кожної команди.");
                Console.WriteLine("6. Показати повну інформацію про матч.");
                Console.WriteLine("7. Показати інформацію про матчі у конкретну дату.");
                Console.WriteLine("8. Показати всі матчі конкретної команди.");
                Console.WriteLine("9. Показати всіх гравців, які забили голи у конкретну дату.");
                /*Console.WriteLine("1. Пошук інформації про команду за назвою.");
                Console.WriteLine("2. Пошук команд за назвою міста.");
                Console.WriteLine("3. Пошук інформації за назвою команди і міста.");
                Console.WriteLine("4. Показати всі команди.");
                Console.WriteLine("8. Показать команды отсортированные");*/
                Console.WriteLine("0. Вихід.");
                Console.Write("Виберіть пункт меню: ");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        AddMatch();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '2':
                        UpdateMatch();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '3':
                        DeleteMatch();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    /*case '4':
                        ShowTeam(footSer.GetAll());
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;*/
                    case '5':
                        ShowGoalDifference();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '6':
                        ShowMatchDetails();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '7':
                        ShowMatchesByDate();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '8':
                        ShowMatchesByTeam();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '9':
                        ShowScorersByDate();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    /*case '8':
                        Console.WriteLine("Team with most Wins");
                        var teamWithMostWins = footSer.GetTeamWithMostWins();
                        Console.WriteLine($"Team {teamWithMostWins.TeamName} " +
                            $"from {teamWithMostWins.City}" +
                            $", Wins {teamWithMostWins.Wins}, " +
                            $"Losses {teamWithMostWins.Losses}, " +
                            $"Draw {teamWithMostWins.Draws}");
                        Console.WriteLine("Team with most Losses");
                        var teamWithMostLosses = footSer.GetTeamWithMostLosses();
                        Console.WriteLine($"Team {teamWithMostLosses.TeamName} " +
                            $"from {teamWithMostLosses.City}" +
                            $", Wins {teamWithMostLosses.Wins}, " +
                            $"Losses {teamWithMostLosses.Losses}, " +
                            $"Draw {teamWithMostLosses.Draws}");
                        Console.WriteLine("Team with most Draws");
                        var teamWithMostDraws = footSer.GetTeamWithMostDraws();
                        Console.WriteLine($"Team {teamWithMostDraws.TeamName} " +
                            $"from {teamWithMostDraws.City}" +
                            $", Wins {teamWithMostDraws.Wins}, " +
                            $"Losses {teamWithMostDraws.Losses}, " +
                            $"Draw {teamWithMostDraws.Draws}");
                        Console.WriteLine("Team with most Goals");
                        var teamWithMostGoals = footSer.GetTeamWithMostGoals();
                        Console.WriteLine($"Team {teamWithMostGoals.TeamName} " +
                            $"from {teamWithMostGoals.City}" +
                            $", Wins {teamWithMostGoals.Wins}, " +
                            $"Losses {teamWithMostGoals.Losses}, " +
                            $"Draw {teamWithMostGoals.Draws}");
                        Console.WriteLine("Team with most GoalConceded");
                        var teamWithMostGoalConceded = footSer.GetTeamWithMostMissedGoals();
                        Console.WriteLine($"Team {teamWithMostGoalConceded.TeamName} " +
                            $"from {teamWithMostGoalConceded.City}" +
                            $", Wins {teamWithMostGoalConceded.Wins}, " +
                            $"Losses {teamWithMostGoalConceded.Losses}, " +
                            $"Draw {teamWithMostGoalConceded.Draws}");
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;*/
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }

            }
        }
        public void AddTeam()
        {
            Console.Write("Введіть назву команди: ");
            var teamName = Console.ReadLine();
            Console.Write("Введіть місто команди: ");
            var city = Console.ReadLine();
            Console.Write("Введіть кількість перемог: ");
            var wins = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість поразок: ");
            var losses = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість нічиїх: ");
            var draws = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість забитих м'ячів: ");
            var goals = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість пропущених м'ячів: ");
            var goalConceded = int.Parse(Console.ReadLine());


            var team = new FootballTeam
            {
                TeamName = teamName,
                City = city,
                Wins = wins,
                Losses = losses,
                Draws = draws,
                Goal = goals,
                GoalConceded = goalConceded
            };

            footSer.Add(team);
        }
        public void UpdateTeam()
        {
            Console.Write("Введіть назву команди для оновлення: ");
            var teamName = Console.ReadLine();
            Console.Write("Введіть місто команди для оновлення: ");
            var city = Console.ReadLine();

            Console.Write("Введіть нову кількість перемог: ");
            var wins = int.Parse(Console.ReadLine());
            Console.Write("Введіть нову кількість поразок: ");
            var losses = int.Parse(Console.ReadLine());
            Console.Write("Введіть нову кількість нічиїх: ");
            var draws = int.Parse(Console.ReadLine());
            Console.Write("Введіть нову кількість забитих м'ячів: ");
            var goals = int.Parse(Console.ReadLine());
            Console.Write("Введіть нову кількість пропущених м'ячів: ");
            var goalConceded = int.Parse(Console.ReadLine());

            var team = new FootballTeam
            {
                TeamName = teamName,
                City = city,
                Wins = wins,
                Losses = losses,
                Draws = draws,
                Goal = goals,
                GoalConceded = goalConceded
            };

            footSer.Update(team);
        }
        public void DeleteTeam()
        {
            Console.Write("Введіть назву команди для видалення: ");
            var teamName = Console.ReadLine();
            Console.Write("Введіть місто команди для видалення: ");
            var city = Console.ReadLine();

            footSer.DeleteTeam(teamName, city);
        }
        public void SearchTeam()
        {
            Console.Write("Введіть назву команди: ");
            var name = Console.ReadLine();
            var teams = footSer.SearchTeam(name);
            ShowTeam(teams);
        }
        public void SearchCity()
        {
            Console.Write("Введіть назву міста: ");
            var name = Console.ReadLine();
            var teams = footSer.SearchCity(name);
            ShowTeam(teams);
        }
        public void SearchTeamAndCity()
        {
            Console.Write("Введіть назву команди: ");
            var name = Console.ReadLine();
            Console.Write("Введіть назву міста: ");
            var city = Console.ReadLine();
            var teams = footSer.SearchTeamAndCity(name, city);
            ShowTeam(teams);
        }
        private void ShowTeam(IEnumerable<FootballTeam> teams)
        {
            foreach (var team in teams)
            {
                Console.WriteLine($"Team {team.TeamName} from {team.City}" +
                    $", Wins {team.Wins}, Losses {team.Losses}, Draw {team.Draws}" +
                    $", Goal {team.Goal}, Goal Missed {team.GoalConceded}");
            }
            Console.WriteLine();
        }
        public void ShowGoalDifference()
        {
            var goalDifferences = footSer.GetGoalDifference();
            foreach (var team in goalDifferences)
            {
                Console.WriteLine($"{team.Key}: {team.Value} голів різниці");
            }
            Console.WriteLine();
        }
        public void ShowMatchDetails()
        {
            Console.Write("Введіть ID матчу: ");
            int matchId = int.Parse(Console.ReadLine());
            var match = footSer.GetMatchDetails(matchId);

            if (match != null)
            {
                Console.WriteLine($"Матч: {match.Team1.TeamName} vs {match.Team2.TeamName}");
                Console.WriteLine($"Рахунок: {match.Team1Goals}-{match.Team2Goals}");
                Console.WriteLine($"Дата матчу: {match.MatchDate}");
                Console.WriteLine($"Головні гравці: {match.Scorers}");
            }
            else
            {
                Console.WriteLine("Матч не знайдений.");
            }
        }
        public void ShowMatchesByDate()
        {
            Console.Write("Введіть дату матчу (yyyy-MM-dd): ");
            DateTime matchDate = DateTime.Parse(Console.ReadLine());
            var matches = footSer.GetMatchesByDate(matchDate);
            if (matches != null && matches.Count > 0)
            {
                foreach (var match in matches)
                {
                    Console.WriteLine($"Матч: {match.Team1.TeamName} vs {match.Team2.TeamName}");
                    Console.WriteLine($"Рахунок: {match.Team1Goals}-{match.Team2Goals}");
                    Console.WriteLine($"Дата матчу: {match.MatchDate}");
                    Console.WriteLine($"Головні гравці: {match.Scorers}");
                }
            }
            else
            {
                Console.WriteLine("Матчі не знайдені.");
            }
        }
        public void ShowMatchesByTeam()
        {
            Console.Write("Введіть ID команди: ");
            int teamId = int.Parse(Console.ReadLine());
            var matches = footSer.GetMatchesForTeam(teamId);

            foreach (var match in matches)
            {
                Console.WriteLine($"{match.Team1.TeamName} vs {match.Team2.TeamName} | {match.Team1Goals}-{match.Team2Goals} | {match.MatchDate}");
            }
        }
        public void ShowScorersByDate()
        {
            Console.Write("Введіть дату матчу (yyyy-MM-dd): ");
            DateTime matchDate = DateTime.Parse(Console.ReadLine());
            var scorers = footSer.GetScorersByDate(matchDate);
            if (scorers != null && scorers.Count > 0)
            {
                foreach (var scorer in scorers)
                {
                    Console.WriteLine($"Гравець: {scorer}");
                }
            }
            else
            {
                Console.WriteLine("Гравці не знайдені.");
            }
        }
        public void AddMatch()
        {
            Console.Write("Введіть ID команди 1: ");
            int team1Id = int.Parse(Console.ReadLine());
            Console.Write("Введіть ID команди 2: ");
            int team2Id = int.Parse(Console.ReadLine());
            Console.Write("Введіть дату матчу (yyyy-MM-dd): ");
            DateTime matchDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введіть рахунок команди 1: ");
            int team1Goals = int.Parse(Console.ReadLine());
            Console.Write("Введіть рахунок команди 2: ");
            int team2Goals = int.Parse(Console.ReadLine());
            Console.Write("Введіть гравців, які забили голи (через кому): ");
            string scorers = Console.ReadLine();
            var match = new Match
            {
                Team1Id = team1Id,
                Team2Id = team2Id,
                MatchDate = matchDate,
                Team1Goals = team1Goals,
                Team2Goals = team2Goals,
                Scorers = scorers
            };
            footSer.AddMatch(match);
        }
        public void UpdateMatch()
        {
            Console.Write("Введіть ID матчу для оновлення: ");
            int matchId = int.Parse(Console.ReadLine());
            Console.Write("Введіть новий рахунок команди 1: ");
            int team1Goals = int.Parse(Console.ReadLine());
            Console.Write("Введіть новий рахунок команди 2: ");
            int team2Goals = int.Parse(Console.ReadLine());
            Console.Write("Введіть нових гравців, які забили голи (через кому): ");
            string scorers = Console.ReadLine();
            var match = new Match
            {
                Id = matchId,
                Team1Goals = team1Goals,
                Team2Goals = team2Goals,
                Scorers = scorers
            };
            footSer.UpdateMatch(match);
        }
        public void DeleteMatch()
        {
            Console.Write("Введіть назву команди 1 для видалення: ");
            var team1Name = Console.ReadLine();
            Console.Write("Введіть назву команди 2 для видалення: ");
            var team2Name = Console.ReadLine();
            Console.Write("Введіть дату матча для відалення (yyyy-MM-dd): ");
            var matchDate = DateTime.Parse(Console.ReadLine());

            var result = footSer.DeleteMatch(team1Name, team2Name, matchDate);
            Console.WriteLine(result);
        }
    }
}
