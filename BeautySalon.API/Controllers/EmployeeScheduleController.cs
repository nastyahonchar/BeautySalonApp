using BeautySalon.BLL.DTOs.EmployeeSchedules;
using BeautySalon.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeScheduleController : ControllerBase
    {
        private readonly IEmployeeScheduleService scheduleService;

        public EmployeeScheduleController(IEmployeeScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetByEmployee(int employeeId)
        {
            var schedules = await scheduleService.GetByEmployeeIdAsync(employeeId);
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeScheduleDto dto)
        {
            var result = await scheduleService.CreateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await scheduleService.DeleteAsync(id);
            return NoContent();
        }
    }
}