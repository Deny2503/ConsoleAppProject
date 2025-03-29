using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppProject.DAL.Entities;

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
    }
}
