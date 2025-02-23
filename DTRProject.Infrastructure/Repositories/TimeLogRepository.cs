using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using DTRProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTRProject.Infrastructure.Repositories
{
    public class TimeLogRepository : ITimeLogRepository
    {
        private readonly AppDbContext _context;
    

        public TimeLogRepository(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task AddTimeLogAsync(TimeLog timeLog)
        {
            
            await _context.TimeLogs.AddAsync(timeLog);
        }


        public async Task<TimeLog?> GetLatestLogAsync(Guid employeeId)
        {
            return await _context.TimeLogs
                .Where(t => t.EmployeeId == employeeId)
                .OrderByDescending(t => t.ClockInTime) // Sort directly by ClockInTime
                .FirstOrDefaultAsync();
        }

        public async Task<List<TimeLog>> GetLogsByEmployeeAsync(Guid employeeId)
        {
            return await _context.TimeLogs
                .Where(t => t.EmployeeId == employeeId)
                .OrderByDescending(t => t.ClockInTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
