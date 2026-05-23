using BeautySalon.BLL.DTOs.Clients;

namespace BeautySalon.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ClientDto?> LoginAsync(string email, string password);
        Task<ClientDto> RegisterAsync(CreateClientDto dto);
    }
}