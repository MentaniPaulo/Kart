
using CorridaDeKart.Models;
using Microsoft.EntityFrameworkCore;

namespace CorridaDeKart.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<LogsOfRace>? logsOfRaces { get; set; }
    }
}
