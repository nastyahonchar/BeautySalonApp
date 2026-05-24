using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Services
{
    public class EmployeeApiService : ApiService
    {
        public async Task<List<EmployeeModel>?> GetByServiceAsync(int serviceId)
        {
            return await GetAsync<List<EmployeeModel>>($"employees/by-service/{serviceId}");
        }
    }
}