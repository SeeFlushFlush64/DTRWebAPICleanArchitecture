using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.DeleteEmployee
{
    /// <summary>
    /// Command to delete an employee from the system.
    /// </summary>
    /// <param name="EmployeeId">The unique identifier of the employee to delete.</param>
    public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<bool>;
}
