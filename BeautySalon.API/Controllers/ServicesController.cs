using BeautySalon.BLL.DTOs.Services;
using BeautySalon.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService service;

        public ServicesController(IServiceService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto dto)
        {
            var created = await service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateServiceDto dto)
        {
            var existing = await service.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await service.UpdateAsync(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await service.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await service.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var result = await service.GetByCategoryIdAsync(categoryId);
            return Ok(result);
        }
    }
}