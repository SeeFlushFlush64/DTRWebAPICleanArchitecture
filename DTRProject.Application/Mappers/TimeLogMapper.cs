using DTRProject.Application.DTOs;
using DTRProject.Domain.Entities;

namespace DTRProject.Application.Mappers
{
    public static class TimeLogMapper
    {
        public static TimeLogDTO ToTimeLogDTO(this TimeLog timeLog)
        {
            return new TimeLogDTO
            {
                TimeLogId = timeLog.TimeLogId,
                EmployeeId = timeLog.EmployeeId,
                ClockInTime = timeLog.ClockInTime,
                ClockOutTime = timeLog.ClockOutTime,
                EmployeeName = timeLog.Employee != null ? $"{timeLog.Employee.FirstName} {timeLog.Employee.LastName}" : null
            };
        }

        public static List<TimeLogDTO> ToTimeLogDTOList(this List<TimeLog> timeLogs)
        {
            return timeLogs.Select(log => log.ToTimeLogDTO()).ToList();
        }
    }
}
