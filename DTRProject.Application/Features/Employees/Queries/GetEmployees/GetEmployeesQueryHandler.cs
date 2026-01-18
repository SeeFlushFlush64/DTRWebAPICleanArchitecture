using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.Employees.Queries.GetEmployees
{
    /// <summary>
    /// Handles retrieval of all employee records.
    /// </summary>
    /// <param name="employeeRepository"></param>
    public class GetEmployeesQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>
    {
        /// <summary>
        /// Retrieves all employees from the repository.
        /// </summary>
        /// <param name="request">The query request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A collection of all employees.</returns>
        public async Task<IEnumerable<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetAllAsync();
        }
    }
}
