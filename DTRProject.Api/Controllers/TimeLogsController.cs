using DTRProject.Application.Features.TimeLogs.Commands.ClockIn;
using DTRProject.Application.Features.TimeLogs.Commands.ClockOut;
using DTRProject.Application.Features.TimeLogs.Queries.GetEmployeeLogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DTRProject.API.Controllers
{
    /// <summary>
    /// Manages employee time tracking operations including clock-in and clock-out.
    /// </summary>
    /// <param name="sender"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Records an employee's clock-in time.
        /// </summary>
        /// <param name="employeeId">The unique identifier of the employee clocking in.</param>
        /// <returns>Success message if clock-in is recorded.</returns>
        /// <response code="200">Clock-in successfully recorded.</response>
        /// <response code="400">Employee must clock out before clocking in again.</response>
        [HttpPost("ClockIn/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ClockIn(Guid employeeId)
        {
            var success = await sender.Send(new ClockInCommand(employeeId));
            if (!success) return BadRequest("You must clock out before clocking in again.");
            return Ok("Clock-in successful.");
        }



        
        [HttpPost("ClockOut/{employeeId}")]
        public async Task<IActionResult> ClockOut(Guid employeeId)
        {
            var success = await sender.Send(new ClockOutCommand(employeeId));
            if (!success) return BadRequest("No active clock-in found.");
            return Ok("Clock-out successful.");
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetLogs(Guid employeeId)
        {
            var logs = await sender.Send(new GetEmployeeLogsQuery(employeeId));
            return Ok(logs);
        }
    }
}
