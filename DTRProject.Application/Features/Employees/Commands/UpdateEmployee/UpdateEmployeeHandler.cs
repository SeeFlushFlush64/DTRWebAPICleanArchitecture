using DTRProject.Application.DTOs;
using DTRProject.Application.Mappers;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.UpdateEmployee
{
    /// <summary>
    /// Handles updates to employee records.
    /// </summary>
    /// <param name="employeeRepository"></param>
    public class UpdateEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        /// <summary>
        /// Processes the employee update command and persists changes.
        /// </summary>
        /// <param name="request">The update employee command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The updated employee data transfer object, or null if the employee was not found.</returns>
        public async Task<EmployeeDTO?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var existingEmployee = await employeeRepository.GetByIdAsync(request.EmployeeId);

            if (existingEmployee is null)
            {
                return null;
            }

            existingEmployee.UpdateEmployeeFromDTO(request.EmployeeDTO);
            var savedEmployee = await employeeRepository.UpdateAsync(existingEmployee);

            return savedEmployee.ToEmployeeDTO();
        }

    }
}
