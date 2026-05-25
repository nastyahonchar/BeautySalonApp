using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Services
{
    public class CategoryApiService : ApiService
    {
        public CategoryApiService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<CategoryModel>?> GetAllAsync()
        {
            return await GetAsync<List<CategoryModel>>("categories");
        }
    }
}