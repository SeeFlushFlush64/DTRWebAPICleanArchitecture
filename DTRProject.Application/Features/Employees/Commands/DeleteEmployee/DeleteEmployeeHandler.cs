using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTRProject.Application.Features.Employees.Commands.DeleteEmployee
{
    /// <summary>
    /// Handles the deletion of an employee record.
    /// </summary>
    /// <param name="employeeRepository"></param>
    public class DeleteEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        /// <summary>
        /// Processes the employee deletion command.
        /// </summary>
        /// <param name="request">The delete employee command.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True if the employee was deleted successfully; otherwise, false.</returns>
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee is null) return false;

            return await employeeRepository.DeleteAsync(employee);

        }
    }
}
