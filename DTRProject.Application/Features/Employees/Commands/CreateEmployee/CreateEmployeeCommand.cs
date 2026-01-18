using DTRProject.Application.DTOs;
using DTRProject.Application.DTOs.Request;
using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.CreateEmployee
{
    /// <summary>
    /// Command to create a new employee in the system.
    /// </summary>
    /// <param name="EmployeeDTO">The employee creation request containing employee details.</param>
    public record CreateEmployeeCommand(CreateEmployeeRequest EmployeeDTO) :  IRequest<EmployeeDTO>;
}
