namespace BeautySalon.MAUI.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Log out", "Are you sure you want to log out?", "Yes", "Cancel");
        if (confirm)
            await Shell.Current.GoToAsync("//LoginPage");
    }
}