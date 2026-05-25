using BeautySalon.MAUI.ViewModels;
using BeautySalon.MAUI.Models;

namespace BeautySalon.MAUI.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert(
            "Log out", "Are you sure you want to log out?", "Yes", "Cancel");
        if (confirm)
        {
            UserSession.Clear();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}