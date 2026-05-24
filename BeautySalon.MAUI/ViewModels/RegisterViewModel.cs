using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.Services;

namespace BeautySalon.MAUI.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly AuthApiService authService;

        private string firstName = "";
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        private string lastName = "";
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        private string phone = "";
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

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

        public RegisterViewModel(AuthApiService authService)
        {
            this.authService = authService;
        }

        public async Task<bool> RegisterAsync()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Please fill in all fields.";
                return false;
            }

            IsBusy = true;
            ErrorMessage = "";

            try
            {
                var client = await authService.RegisterAsync(
                    FirstName, LastName, Phone, Email, Password);

                if (client == null)
                {
                    ErrorMessage = "Registration failed. Please try again.";
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