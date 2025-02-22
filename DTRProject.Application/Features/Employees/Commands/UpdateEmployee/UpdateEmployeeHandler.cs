using DTRProject.Application.DTOs;
using DTRProject.Application.Mappers;
using DTRProject.Domain.Entities;
using DTRProject.Domain.Interfaces;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<UpdateEmployeeCommand, EmployeeDTO>
    {
        public async Task<EmployeeDTO> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var existingEmployee = await employeeRepository.GetByIdAsync(request.EmployeeId);
            if (existingEmployee is null)
            {
                return null; // Not found, controller will handle 404
            }

            // Update existing employee directly
            existingEmployee.UpdateEmployeeFromDTO(request.EmployeeDTO);

            // Save changes in repository
            var savedEmployee = await employeeRepository.UpdateAsync(existingEmployee);

            return savedEmployee.ToEmployeeDTO();
        }
    }
}
