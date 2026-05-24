using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.Services;

namespace BeautySalon.MAUI.ViewModels
{
    public class ServicesViewModel : BaseViewModel
    {
        private readonly ServiceApiService serviceService;

        private List<ServiceModel> services = new();
        public List<ServiceModel> Services
        {
            get => services;
            set => SetProperty(ref services, value);
        }

        private string categoryTitle = "";
        public string CategoryTitle
        {
            get => categoryTitle;
            set => SetProperty(ref categoryTitle, value);
        }

        public ServicesViewModel(ServiceApiService serviceService)
        {
            this.serviceService = serviceService;
        }

        public async Task LoadServicesAsync(int categoryId, string categoryName)
        {
            IsBusy = true;
            CategoryTitle = $"Category: {categoryName}";
            try
            {
                var result = await serviceService.GetByCategoryAsync(categoryId);
                Services = result ?? new List<ServiceModel>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}