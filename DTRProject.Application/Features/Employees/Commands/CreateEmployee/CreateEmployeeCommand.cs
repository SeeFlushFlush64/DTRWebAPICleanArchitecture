using DTRProject.Application.DTOs;
using DTRProject.Application.DTOs.Request;
using DTRProject.Domain.Entities;
using MediatR;

namespace DTRProject.Application.Features.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(CreateEmployeeRequest EmployeeDTO) :  IRequest<EmployeeDTO>;
}
