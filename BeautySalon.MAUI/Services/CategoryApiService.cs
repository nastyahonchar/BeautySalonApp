using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Services
{
    public class CategoryApiService : ApiService
    {
        public async Task<List<CategoryModel>?> GetAllAsync()
        {
            return await GetAsync<List<CategoryModel>>("categories");
        }
    }
}