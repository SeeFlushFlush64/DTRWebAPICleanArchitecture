using DTRProject.Application.DTOs.Request;
using DTRProject.Application.Features.Employees.Commands.CreateEmployee;
using DTRProject.Application.Features.Employees.Commands.DeleteEmployee;
using DTRProject.Application.Features.Employees.Commands.UpdateEmployee;
using DTRProject.Application.Features.Employees.Queries.GetEmployeeById;
using DTRProject.Application.Features.Employees.Queries.GetEmployees;
using DTRProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DTRProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeRequest employeeDTO)
        {
            var result = await sender.Send(new CreateEmployeeCommand(employeeDTO));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var result = await sender.Send(new GetEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));
            if (result is null)
            { 
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId, [FromBody] UpdateEmployeeRequest employeeDTO)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employeeId, employeeDTO));
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(employeeId));
            if (result is false)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
