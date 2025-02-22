using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<Employee>;
}
