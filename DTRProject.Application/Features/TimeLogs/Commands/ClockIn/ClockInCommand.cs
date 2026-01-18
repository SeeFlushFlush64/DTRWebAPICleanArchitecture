using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Commands.ClockIn
{
    /// <summary>
    /// Command to record an employee's clock-in time.
    /// </summary>
    /// <param name="EmployeeId">The unique identifier of the employee clocking in.</param>
    public record ClockInCommand(Guid EmployeeId) : IRequest<bool>;
}
