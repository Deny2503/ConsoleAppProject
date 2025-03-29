using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppProject.DAL.Entities;
using ConsoleAppProject.DAL.Migrations;

namespace Project
{
    public class MenuService
    {
        private FootballService footSer = new FootballService();
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("1. Пошук інформації про команду за назвою.");
                Console.WriteLine("2. Пошук команд за назвою міста.");
                Console.WriteLine("3. Пошук інформації за назвою команди і міста.");
                Console.WriteLine("4. Показати всі команди.");
                Console.WriteLine("5. Добавить команду");
                Console.WriteLine("6. Обновить данные");
                Console.WriteLine("7. Удалить комнаду");
                Console.WriteLine("8. Показать команды отсортированные");
                Console.WriteLine("0. Вихід.");
                Console.Write("Виберіть пункт меню: ");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        SearchTeam();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '2':
                        SearchCity();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '3':
                        SearchTeamAndCity();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '4':
                        ShowTeam(footSer.GetAll());
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '5':
                        Console.Clear();
                        Thread.Sleep(4000);
                        AddTeam();
                        break;
                    case '6':
                        Thread.Sleep(4000);
                        UpdateTeam();
                        Console.Clear();
                        break;
                    case '7':
                        DeleteTeam();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case '8':
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
                        break;
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
    }
}
