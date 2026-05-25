namespace BeautySalon.MAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("ServicesPage", typeof(Views.ServicesPage));
        Routing.RegisterRoute("MastersPage", typeof(Views.MastersPage));
        Routing.RegisterRoute("TimingPage", typeof(Views.TimingPage));
        Routing.RegisterRoute("ConfirmationPage",typeof(Views.ConfirmationPage));
        Routing.RegisterRoute("RegisterPage", typeof(Views.RegisterPage));
    }
}
