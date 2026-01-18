using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Queries.GetEmployeeById
{
    /// <summary>
    /// Query to retrieve a specific employee by their unique identifier.
    /// </summary>
    /// <param name="EmployeeId">The unique identifier of the employee.</param>
    public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<Employee>;
}
