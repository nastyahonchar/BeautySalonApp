namespace BeautySalon.MAUI.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnCategoryTapped(object sender, TappedEventArgs e)
    {
        var categoryName = e.Parameter?.ToString() ?? "Category";
        await Shell.Current.GoToAsync($"ServicesPage?categoryName={Uri.EscapeDataString(categoryName)}");
    }
}
