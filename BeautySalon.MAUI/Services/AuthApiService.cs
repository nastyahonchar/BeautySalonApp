using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Services
{
    public class AuthApiService : ApiService
    {
        public AuthApiService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<ClientModel?> LoginAsync(string email, string password)
        {
            return await PostAsync<ClientModel>("auth/login", new
            {
                Email = email,
                Password = password
            });
        }

        public async Task<ClientModel?> RegisterAsync(
            string firstName, string lastName,
            string phone, string email, string password)
        {
            return await PostAsync<ClientModel>("auth/register", new
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phone,
                Email = email,
                Password = password
            });
        }
    }
}