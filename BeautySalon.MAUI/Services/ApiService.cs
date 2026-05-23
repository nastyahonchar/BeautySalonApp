using System.Text;
using System.Text.Json;

namespace BeautySalon.MAUI.Services
{
    public class ApiService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "http://192.168.0.163:5000/api/";

        private static readonly JsonSerializerOptions jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        protected async Task<T?> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await httpClient.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode) return default;

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json, jsonOptions);
            }
            catch
            {
                return default;
            }
        }

        protected async Task<T?> PostAsync<T>(string endpoint, object body)
        {
            try
            {
                var json = JsonSerializer.Serialize(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endpoint, content);

                if (!response.IsSuccessStatusCode) return default;

                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseJson, jsonOptions);
            }
            catch
            {
                return default;
            }
        }

        protected async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await httpClient.DeleteAsync(endpoint);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}