using Microsoft.Extensions.Logging;

namespace BeautySalon.MAUI
{
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

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://10.0.2.2:7055/")
            });


            // builder.Services.AddSingleton<ApiService>();
            // builder.Services.AddSingleton<IDataService, ApiService>();

            // builder.Services.AddTransient<EmployeesViewModel>();
            // builder.Services.AddTransient<ServicesViewModel>();
            // builder.Services.AddTransient<CategoriesViewModel>();
            // builder.Services.AddTransient<AppointmentsViewModel>();
            // builder.Services.AddTransient<ClientsViewModel>();

            // builder.Services.AddTransient<EmployeesPage>();
            // builder.Services.AddTransient<ServicesPage>();
            // builder.Services.AddTransient<CategoriesPage>();
            // builder.Services.AddTransient<AppointmentsPage>();
            // builder.Services.AddTransient<ClientsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
