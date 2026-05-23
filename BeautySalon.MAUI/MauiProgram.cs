using BeautySalon.MAUI.Services;
using Microsoft.Extensions.Logging;

namespace BeautySalon.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //Views
        builder.Services.AddTransient<Views.LoginPage>();
        builder.Services.AddTransient<Views.HomePage>();
        builder.Services.AddTransient<Views.ServicesPage>();
        builder.Services.AddTransient<Views.MastersPage>();
        builder.Services.AddTransient<Views.TimingPage>();
        builder.Services.AddTransient<Views.ConfirmationPage>();
        builder.Services.AddTransient<Views.MyAppointmentsPage>();
        builder.Services.AddTransient<Views.ProfilePage>();

        // Services
        builder.Services.AddSingleton<AuthApiService>();
        builder.Services.AddSingleton<CategoryApiService>();
        builder.Services.AddSingleton<ServiceApiService>();
        builder.Services.AddSingleton<EmployeeApiService>();
        builder.Services.AddSingleton<AppointmentApiService>();

        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
