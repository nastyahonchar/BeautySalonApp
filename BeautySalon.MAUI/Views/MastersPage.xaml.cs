using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.ViewModels;

namespace BeautySalon.MAUI.Views;

[QueryProperty(nameof(ServiceId), "serviceId")]
[QueryProperty(nameof(CategoryName), "categoryName")]
public partial class MastersPage : ContentPage
{
    private readonly MastersViewModel viewModel;

    public string ServiceId { get; set; } = "";
    public string CategoryName { get; set; } = "";

    public MastersPage(MastersViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (int.TryParse(ServiceId, out int id))
            await viewModel.LoadMastersAsync(id);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnMasterSelected(object sender, TappedEventArgs e)
    {
        if (e.Parameter is not EmployeeModel master) return;
        await Shell.Current.GoToAsync(
            $"TimingPage?employeeId={master.Id}&serviceId={ServiceId}");
    }
}