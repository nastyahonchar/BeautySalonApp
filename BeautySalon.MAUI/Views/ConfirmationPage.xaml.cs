namespace BeautySalon.MAUI.Views;

public partial class ConfirmationPage : ContentPage
{
    public ConfirmationPage()
    {
        InitializeComponent();
    }

    private async void OnGoHomeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//HomePage");
    }
}