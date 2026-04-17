using BeautySalon.BLL.DTOs.Clients;

namespace BeautySalon.BLL.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto?> GetByIdAsync(int id);
        Task<ClientDto> CreateAsync(CreateClientDto dto);
        Task UpdateAsync(int id, UpdateClientDto dto);
        Task DeleteAsync(int id);
    }
}
