using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.ViewModels;

namespace BeautySalon.MAUI.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel viewModel;

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        GreetingLabel.Text = $"Hello, {UserSession.FirstName}!";
        await viewModel.LoadCategoriesAsync();
    }

    private async void OnCategoryTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not CategoryModel category) return;
        await Shell.Current.GoToAsync(
            $"ServicesPage?categoryId={category.Id}&categoryName={Uri.EscapeDataString(category.Name)}");
    }
}