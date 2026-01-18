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
    /// <summary>
    /// Manages employee records in the DTR system.
    /// </summary>
    /// <param name="sender"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Creates a new employee record.
        /// </summary>
        /// <param name="employeeDTO">The employee details to create.</param>
        /// <returns>The created employee information</returns>
        /// <response code="200">Employee successfully created.</response>
        /// <response code="400">Invalid employee data provided.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeRequest employeeDTO)
        {
            var result = await sender.Send(new CreateEmployeeCommand(employeeDTO));
            return Ok(result);
        }



        /// <summary>
        /// Retrieves all employees in the system.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        /// <response code="200">Successfully retrieved employee list.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var result = await sender.Send(new GetEmployeesQuery());
            return Ok(result);
        }


        /// <summary>
        /// Retrieves a specific employee by their ID.
        /// </summary>
        /// <param name="employeeId">The unique identifier of the employee.</param>
        /// <returns>The employee details if found.</returns>
        /// <response code="200">Employee found and returned.</response>
        /// <response code="400">Employee not found.</response>
        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new GetEmployeeByIdQuery(employeeId));
            if (result is null)
            { 
                return NotFound();
            }
            return Ok(result);
        }


        /// <summary>
        /// Updates an existing employee's information.
        /// </summary>
        /// <param name="employeeId">The unique identifier of the employee to update.</param>
        /// <param name="employeeDTO">The updated employee details.</param>
        /// <returns>The updated employee information.</returns>
        /// <response code="200">Employee successfully updated.</response>
        /// <response code="404">Employee not found.</response>
        /// <response code="400">Invalid employee data provided.</response>
        [HttpPut("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId, [FromBody] UpdateEmployeeRequest employeeDTO)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employeeId, employeeDTO));
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }



        /// <summary>
        /// Deletes an employee from the system.
        /// </summary>
        /// <param name="employeeId">he unique identifier of the employee to delete.</param>
        /// <returns>Success status of the deletion.</returns>
        /// <response code="200">Employee successfully deleted.</response>
        /// <response code="404">Employee not found.</response>
        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
