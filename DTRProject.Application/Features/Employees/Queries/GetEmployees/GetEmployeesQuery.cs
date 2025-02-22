using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Queries.GetEmployees
{
    public record GetEmployeesQuery() : IRequest<IEnumerable<Employee>>;
    
}
