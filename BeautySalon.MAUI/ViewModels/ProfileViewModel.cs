using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public string FullName => UserSession.FullName;
        public string Email => UserSession.Email;
        public string Phone => UserSession.PhoneNumber;

        public string FirstNameInitial =>
            string.IsNullOrWhiteSpace(UserSession.FirstName)
                ? "?"
                : UserSession.FirstName.Substring(0, 1).ToUpper();
    }
}