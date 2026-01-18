using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Queries.GetEmployees
{
    /// <summary>
    /// Query to retrieve all employees in the system.
    /// </summary>
    public record GetEmployeesQuery() : IRequest<IEnumerable<Employee>>;
    
}
