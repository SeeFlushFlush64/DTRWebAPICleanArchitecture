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
    public class DeleteEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await employeeRepository.GetByIdAsync(request.EmployeeId);
            if (employee is null) return false;

            return await employeeRepository.DeleteAsync(employee);

        }
    }
}
