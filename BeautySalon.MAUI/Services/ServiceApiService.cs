using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Services
{
    public class ServiceApiService : ApiService
    {
        public async Task<List<ServiceModel>?> GetByCategoryAsync(int categoryId)
        {
            return await GetAsync<List<ServiceModel>>($"services?categoryId={categoryId}");
        }
    }
}