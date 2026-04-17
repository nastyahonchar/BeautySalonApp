using BeautySalon.BLL.DTOs.EmployeeServices;
using BeautySalon.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeServicesController : ControllerBase
    {
        private readonly IEmployeeServiceService service;

        public EmployeeServicesController(IEmployeeServiceService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeServiceDto dto)
        {
            await service.AddAsync(dto);
            return Ok();
        }

        [HttpDelete("{employeeId}/{serviceId}")]
        public async Task<IActionResult> Delete(int employeeId, int serviceId)
        {
            await service.DeleteAsync(employeeId, serviceId);
            return NoContent();
        }
    }
}