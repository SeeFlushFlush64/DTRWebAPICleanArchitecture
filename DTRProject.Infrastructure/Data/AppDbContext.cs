using DTRProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DTRProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.TimeLogs)
                        .WithOne(t => t.Employee)
                        .HasForeignKey(t => t.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict); // Prevent accidental deletion of logs when an employee is deleted

        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }
}
