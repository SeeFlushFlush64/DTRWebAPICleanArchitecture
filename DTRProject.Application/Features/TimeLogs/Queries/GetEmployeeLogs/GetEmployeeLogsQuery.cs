using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Queries.GetEmployeeLogs
{
    public record GetEmployeeLogsQuery(Guid EmployeeId) : IRequest<List<TimeLog>>;
}
