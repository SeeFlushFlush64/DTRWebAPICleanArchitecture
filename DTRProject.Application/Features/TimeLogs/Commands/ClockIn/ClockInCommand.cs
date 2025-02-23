using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Commands.ClockIn
{
    public record ClockInCommand(Guid EmployeeId) : IRequest<bool>;
}
