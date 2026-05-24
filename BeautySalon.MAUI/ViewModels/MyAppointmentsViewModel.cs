using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.Services;

namespace BeautySalon.MAUI.ViewModels
{
    public class MyAppointmentsViewModel : BaseViewModel
    {
        private readonly AppointmentApiService appointmentService;

        private List<AppointmentModel> appointments = new();
        public List<AppointmentModel> Appointments
        {
            get => appointments;
            set => SetProperty(ref appointments, value);
        }

        private bool isEmpty;
        public bool IsEmpty
        {
            get => isEmpty;
            set => SetProperty(ref isEmpty, value);
        }

        public MyAppointmentsViewModel(AppointmentApiService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public async Task LoadAppointmentsAsync()
        {
            IsBusy = true;
            try
            {
                var result = await appointmentService.GetByClientAsync(
                    UserSession.ClientId);
                Appointments = result ?? new List<AppointmentModel>();
                IsEmpty = Appointments.Count == 0;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}