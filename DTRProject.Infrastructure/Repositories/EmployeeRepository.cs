using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using DTRProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DTRProject.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
                                 .Where(e => !e.IsDeleted) // Exclude deleted employees
                                 .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee is null)
            {
                return false;
            }

            employee.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AssignEmployeeToTimeLogs(Guid employeeId)
        {
            var timeLogs = await _context.TimeLogs
                .Where(t => t.EmployeeId == Guid.Parse("00000000-0000-0000-0000-000000000004")) // Placeholder EmployeeId
                .ToListAsync();

            foreach (var log in timeLogs)
            {
                log.EmployeeId = employeeId;
            }

            await _context.SaveChangesAsync();
        }
    }
}
