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
            var unassignedEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            // Seed the placeholder employee (ensures it exists)
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = unassignedEmployeeId,
                    FirstName = "Unassigned",
                    LastName = "Employee",
                    Position = "N/A"
                }
            );

            // Ensure TimeLog.EmployeeId is NOT NULL and defaults to the Unassigned Employee
            modelBuilder.Entity<TimeLog>()
                .Property(t => t.EmployeeId)
                .HasDefaultValue(unassignedEmployeeId);

            modelBuilder.Entity<TimeLog>()
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent accidental deletion of logs when an employee is deleted
        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }
}
