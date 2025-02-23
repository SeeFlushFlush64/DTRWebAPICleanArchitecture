using DTRProject.Domain.Entities;

namespace DTRProject.Domain.Interfaces
{
    public interface ITimeLogRepository
    {
        Task AssignUnassignedLogsAsync(Guid employeeId);
        Task AddTimeLogAsync(TimeLog timeLog);
        Task<TimeLog?> GetLatestLogAsync(Guid employeeId);
        Task<List<TimeLog>> GetLogsByEmployeeAsync(Guid employeeId);
        Task SaveChangesAsync();
    }
}
