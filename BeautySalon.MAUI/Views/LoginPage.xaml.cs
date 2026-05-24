using BeautySalon.MAUI.ViewModels;

namespace BeautySalon.MAUI.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel viewModel;

    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var success = await viewModel.LoginAsync();
        if (success)
            await Shell.Current.GoToAsync("//HomePage");
        else
            await DisplayAlert("Error", viewModel.ErrorMessage, "OK");
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RegisterPage");
    }
}