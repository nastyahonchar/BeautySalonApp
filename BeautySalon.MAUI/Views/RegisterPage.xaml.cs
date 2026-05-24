using BeautySalon.MAUI.ViewModels;

namespace BeautySalon.MAUI.Views;

public partial class RegisterPage : ContentPage
{
    private readonly RegisterViewModel viewModel;

    public RegisterPage(RegisterViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var success = await viewModel.RegisterAsync();
        if (success)
            await Shell.Current.GoToAsync("//HomePage");
        else
            await DisplayAlert("Error", viewModel.ErrorMessage, "OK");
    }
}