using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.Services;

namespace BeautySalon.MAUI.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthApiService authService;

        private string email = "";
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private string password = "";
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public LoginViewModel(AuthApiService authService)
        {
            this.authService = authService;
        }

        public async Task<bool> LoginAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Please fill in all fields.";
                return false;
            }

            IsBusy = true;
            ErrorMessage = "";

            try
            {
                var client = await authService.LoginAsync(Email, Password);

                if (client == null)
                {
                    ErrorMessage = "Invalid email or password.";
                    return false;
                }

                UserSession.ClientId = client.Id;
                UserSession.FirstName = client.FirstName;
                UserSession.LastName = client.LastName;
                UserSession.Email = client.Email ?? "";
                UserSession.PhoneNumber = client.PhoneNumber;

                return true;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}