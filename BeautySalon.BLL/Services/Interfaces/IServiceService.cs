using BeautySalon.BLL.DTOs.Services;

namespace BeautySalon.BLL.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllAsync();
        Task<ServiceDto?> GetByIdAsync(int id);
        Task<ServiceDto> CreateAsync(CreateServiceDto dto);
        Task UpdateAsync(int id, UpdateServiceDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ServiceDto>> GetByCategoryIdAsync(int categoryId);
    }
}