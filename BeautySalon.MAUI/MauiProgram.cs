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

        builder.Services.AddTransient<Views.LoginPage>();
        builder.Services.AddTransient<Views.HomePage>();
        builder.Services.AddTransient<Views.ServicesPage>();
        builder.Services.AddTransient<Views.MastersPage>();
        builder.Services.AddTransient<Views.TimingPage>();
        builder.Services.AddTransient<Views.ConfirmationPage>();
        builder.Services.AddTransient<Views.MyAppointmentsPage>();
        builder.Services.AddTransient<Views.ProfilePage>();

        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
