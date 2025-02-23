using MediatR;

namespace DTRProject.Application.Features.TimeLogs.Commands.ClockOut
{
    public record ClockOutCommand(Guid EmployeeId) : IRequest<bool>;
}
