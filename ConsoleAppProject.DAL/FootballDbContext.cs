using System;
using System.Data.Common;
using ConsoleAppProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppProject.DAL
{
    public class FootballDbContext : DbContext
    {
        public DbSet<FootballTeam> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionStr = connection.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballTeam>()
                .HasMany(t => t.Players)
                .WithOne(p => p.FootballTeam)
                .HasForeignKey(p => p.FootballTeamId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany()
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
