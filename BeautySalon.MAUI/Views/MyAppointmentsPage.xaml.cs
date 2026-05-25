using BeautySalon.MAUI.ViewModels;

namespace BeautySalon.MAUI.Views;

public partial class MyAppointmentsPage : ContentPage
{
    private readonly MyAppointmentsViewModel viewModel;

    public MyAppointmentsPage(MyAppointmentsViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.LoadAppointmentsAsync();
    }
}