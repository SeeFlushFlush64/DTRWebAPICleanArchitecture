using DTRProject.Application.Features.TimeLogs.Commands.ClockIn;
using DTRProject.Application.Features.TimeLogs.Commands.ClockOut;
using DTRProject.Application.Features.TimeLogs.Queries.GetEmployeeLogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DTRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogController(ISender sender) : ControllerBase
    {
        [HttpPost("clock-in/{employeeId}")]
        public async Task<IActionResult> ClockIn(Guid employeeId)
        {
            var success = await sender.Send(new ClockInCommand(employeeId));
            if (!success) return BadRequest("You must clock out before clocking in again.");
            return Ok("Clock-in successful.");
        }

        [HttpPost("clock-out/{employeeId}")]
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
