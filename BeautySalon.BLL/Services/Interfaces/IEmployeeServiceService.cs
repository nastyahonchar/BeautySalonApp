using BeautySalon.BLL.DTOs.EmployeeServices;

namespace BeautySalon.BLL.Services.Interfaces
{
    public interface IEmployeeServiceService
    {
        Task<IEnumerable<EmployeeServiceDto>> GetAllAsync();
        Task AddAsync(CreateEmployeeServiceDto dto);
        Task DeleteAsync(int employeeId, int serviceId);
    }
}