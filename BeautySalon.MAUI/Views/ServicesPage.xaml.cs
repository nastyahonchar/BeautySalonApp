using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.ViewModels;

namespace BeautySalon.MAUI.Views;

[QueryProperty(nameof(CategoryId), "categoryId")]
[QueryProperty(nameof(CategoryName), "categoryName")]
public partial class ServicesPage : ContentPage
{
    private readonly ServicesViewModel viewModel;

    public string CategoryId { get; set; } = "";
    public string CategoryName { get; set; } = "";

    public ServicesPage(ServicesViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (int.TryParse(CategoryId, out int id))
            await viewModel.LoadServicesAsync(id, Uri.UnescapeDataString(CategoryName));
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnServiceSelected(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not ServiceModel service) return;
        await Shell.Current.GoToAsync(
            $"MastersPage?serviceId={service.Id}&categoryName={Uri.EscapeDataString(CategoryName)}");
    }
}