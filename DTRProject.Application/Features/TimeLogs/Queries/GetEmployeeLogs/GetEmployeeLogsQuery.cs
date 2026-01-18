using DTRProject.Application.DTOs;
using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Queries.GetEmployeeLogs
{
    /// <summary>
    /// Query to retrieve all time log records for a specific employee.
    /// </summary>
    /// <param name="EmployeeId">The unique identifier of the employee.</param>
    public record GetEmployeeLogsQuery(Guid EmployeeId) : IRequest<List<TimeLogDTO>>;
}
