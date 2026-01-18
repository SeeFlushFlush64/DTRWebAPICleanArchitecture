using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.Employees.Queries.GetEmployeeById
{
    /// <summary>
    /// Handles retrieval of a single employee by ID.
    /// </summary>
    /// <param name="employeeRepository"></param>
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        /// <summary>
        /// Retrieves and employee by their unique identifier.
        /// </summary>
        /// <param name="request">The query containing the employee ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The employee entity if found.</returns>
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetByIdAsync(request.EmployeeId);
        }
    }
}
