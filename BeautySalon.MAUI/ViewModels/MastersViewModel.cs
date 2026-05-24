using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.Services;

namespace BeautySalon.MAUI.ViewModels
{
    public class MastersViewModel : BaseViewModel
    {
        private readonly EmployeeApiService employeeService;

        private List<EmployeeModel> masters = new();
        public List<EmployeeModel> Masters
        {
            get => masters;
            set => SetProperty(ref masters, value);
        }

        public MastersViewModel(EmployeeApiService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task LoadMastersAsync(int serviceId)
        {
            IsBusy = true;
            try
            {
                var result = await employeeService.GetByServiceAsync(serviceId);
                Masters = result ?? new List<EmployeeModel>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}