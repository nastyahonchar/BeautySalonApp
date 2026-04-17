using BeautySalon.BLL.DTOs.Employees;

namespace BeautySalon.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto);
        Task UpdateAsync(int id, UpdateEmployeeDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetByServiceIdAsync(int serviceId);
    }
}