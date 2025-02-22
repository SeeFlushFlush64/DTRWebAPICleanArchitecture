using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<bool>;
}
