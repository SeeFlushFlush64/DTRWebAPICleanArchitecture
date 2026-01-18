using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Commands.ClockOut
{
    /// <summary>
    /// Command to record an employee's clock-out time.
    /// </summary>
    /// <param name="EmployeeId">The unique identifier of the employee clocking out.</param>
    public record ClockOutCommand(Guid EmployeeId) : IRequest<bool>;
}
