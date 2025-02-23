using DTRProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DTRProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }
}
