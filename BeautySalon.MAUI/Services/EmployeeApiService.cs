using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Services
{
    public class EmployeeApiService : ApiService
    {
        public EmployeeApiService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<EmployeeModel>?> GetByServiceAsync(int serviceId)
        {
            return await GetAsync<List<EmployeeModel>>($"employees/by-service/{serviceId}");
        }
    }
}