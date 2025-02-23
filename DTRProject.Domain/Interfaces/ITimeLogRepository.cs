using DTRProject.Domain.Entities;

namespace DTRProject.Domain.Interfaces
{
    public interface ITimeLogRepository
    {
        Task AddTimeLogAsync(TimeLog timeLog);
        Task<TimeLog?> GetLatestLogAsync(Guid employeeId);
        Task<List<TimeLog>> GetLogsByEmployeeAsync(Guid employeeId);
        Task SaveChangesAsync();
    }
}
