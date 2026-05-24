using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Services
{
    public class AppointmentApiService : ApiService
    {
        public async Task<List<string>?> GetAvailableSlotsAsync(
            int employeeId, int serviceId, DateTime date)
        {
            return await GetAsync<List<string>>(
                $"appointments/available-slots?employeeId={employeeId}&serviceId={serviceId}&date={date:yyyy-MM-dd}");
        }

        public async Task<List<AppointmentModel>?> GetByClientAsync(int clientId)
        {
            return await GetAsync<List<AppointmentModel>>(
                $"appointments/by-client/{clientId}");
        }

        public async Task<AppointmentModel?> CreateAsync(
            int clientId, int employeeId, int serviceId, DateTime startTime)
        {
            return await PostAsync<AppointmentModel>("appointments", new
            {
                ClientId = clientId,
                EmployeeId = employeeId,
                ServiceId = serviceId,
                StartTime = startTime
            });
        }
    }
}