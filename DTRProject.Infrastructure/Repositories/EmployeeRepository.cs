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
            return await _context.Employees
                                 .Include(e => e.TimeLogs)
                                 .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            employee.IsDeleted = true; // Soft delete
            await _context.SaveChangesAsync();
            return true;
        }

     
    }
}
