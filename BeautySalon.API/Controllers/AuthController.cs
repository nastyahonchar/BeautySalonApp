using BeautySalon.BLL.DTOs.Clients;
using BeautySalon.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var client = await authService.LoginAsync(dto.Email, dto.Password);
            if (client == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(client);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateClientDto dto)
        {
            var client = await authService.RegisterAsync(dto);
            return Ok(client);
        }
    }
}