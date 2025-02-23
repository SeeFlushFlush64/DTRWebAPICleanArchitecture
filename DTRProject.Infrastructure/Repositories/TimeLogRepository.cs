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
        private static readonly Guid UnassignedEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        public TimeLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignUnassignedLogsAsync(Guid employeeId)
        {
            var unassignedLogs = await _context.TimeLogs
                .Where(t => t.EmployeeId == UnassignedEmployeeId)
                .ToListAsync();

            if (unassignedLogs.Any())
            {
                foreach (var log in unassignedLogs)
                {
                    log.EmployeeId = employeeId;
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTimeLogAsync(TimeLog timeLog)
        {
            if (timeLog.EmployeeId == Guid.Empty) // If no EmployeeId is provided
            {
                timeLog.EmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"); // Assign to placeholder
            }
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
