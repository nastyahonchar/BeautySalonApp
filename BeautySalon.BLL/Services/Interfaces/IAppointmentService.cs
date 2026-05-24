using BeautySalon.BLL.DTOs.Appointments;

namespace BeautySalon.BLL.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto?> GetByIdAsync(int id);
        Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto);
        Task UpdateAsync(int id, UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<string>> GetAvailableSlotsAsync(int employeeId, int serviceId, DateTime date);
    }
}