using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppProject.DAL
{
    public class FootballRepository
    {
        private readonly FootballDbContext _context;
        public FootballRepository()
        {
            _context = new FootballDbContext();
        }
        public void Add(FootballTeam team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }
        public void AddRange(List<FootballTeam> streams)
        {
            _context.AddRange(streams);
            _context.SaveChanges();
        }
        public void Update(FootballTeam team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
        }
        public void Delete(FootballTeam team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
        public IEnumerable<FootballTeam> GetAll()
        {
            return _context.Teams.ToList();
        }
        public Match GetMatchById(int matchId)
        {
            return _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .FirstOrDefault(m => m.Id == matchId);
        }
        public List<Match> GetMatchesByDate(DateTime date)
        {
            return _context.Matches
                .Where(m => m.MatchDate.Date == date.Date)
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .ToList();
        }
        public List<Match> GetMatchesForTeam(int teamId)
        {
            return _context.Matches
                .Where(m => m.Team1Id == teamId || m.Team2Id == teamId)
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .ToList();
        }
        public void Add(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }
        public void Delete(Match match)
        {
            _context.Matches.Remove(match);
            _context.SaveChanges();
        }
        public void Update(Match match)
        {
            _context.Matches.Update(match);
            _context.SaveChanges();
        }
        public IEnumerable<Match> GetAllMatches()
        {
            return _context.Matches.Include(m => m.Team1).Include(m => m.Team2).ToList();
        }
    }
}
