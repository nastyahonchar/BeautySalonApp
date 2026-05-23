using BeautySalon.BLL.DTOs.EmployeeSchedules;

namespace BeautySalon.BLL.Services.Interfaces
{
    public interface IEmployeeScheduleService
    {
        Task<IEnumerable<EmployeeScheduleDto>> GetByEmployeeIdAsync(int employeeId);
        Task<EmployeeScheduleDto> CreateAsync(CreateEmployeeScheduleDto dto);
        Task DeleteAsync(int id);
    }
}