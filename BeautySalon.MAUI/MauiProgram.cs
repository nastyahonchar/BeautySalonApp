using BeautySalon.MAUI.Services;
using BeautySalon.MAUI.Views;
using BeautySalon.MAUI.ViewModels;
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
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ServicesPage>();
        builder.Services.AddTransient<MastersPage>();
        builder.Services.AddTransient<TimingPage>();
        builder.Services.AddTransient<ConfirmationPage>();
        builder.Services.AddTransient<MyAppointmentsPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<RegisterPage>();

        // Services
        builder.Services.AddSingleton<AuthApiService>();
        builder.Services.AddSingleton<CategoryApiService>();
        builder.Services.AddSingleton<ServiceApiService>();
        builder.Services.AddSingleton<EmployeeApiService>();
        builder.Services.AddSingleton<AppointmentApiService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();

        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
