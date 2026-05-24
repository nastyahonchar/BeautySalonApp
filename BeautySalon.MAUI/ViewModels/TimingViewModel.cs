using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.Services;

namespace BeautySalon.MAUI.ViewModels
{
    public class TimingViewModel : BaseViewModel
    {
        private readonly AppointmentApiService appointmentService;

        private List<string> availableSlots = new();
        public List<string> AvailableSlots
        {
            get => availableSlots;
            set => SetProperty(ref availableSlots, value);
        }

        public int SelectedEmployeeId { get; set; }
        public int SelectedServiceId { get; set; }
        public DateTime SelectedDate { get; set; }
        public string SelectedSlot { get; set; } = "";

        public TimingViewModel(AppointmentApiService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public async Task LoadSlotsAsync(int employeeId, int serviceId, DateTime date)
        {
            IsBusy = true;
            SelectedEmployeeId = employeeId;
            SelectedServiceId = serviceId;
            SelectedDate = date;
            try
            {
                var result = await appointmentService.GetAvailableSlotsAsync(
                    employeeId, serviceId, date);
                AvailableSlots = result ?? new List<string>();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<bool> CreateAppointmentAsync()
        {
            if (string.IsNullOrEmpty(SelectedSlot))
            {
                ErrorMessage = "Please select a time slot.";
                return false;
            }

            IsBusy = true;
            try
            {
                var timeParts = SelectedSlot.Split(':');
                var startTime = SelectedDate
                    .Date
                    .AddHours(int.Parse(timeParts[0]))
                    .AddMinutes(int.Parse(timeParts[1]));

                var result = await appointmentService.CreateAsync(
                    UserSession.ClientId,
                    SelectedEmployeeId,
                    SelectedServiceId,
                    startTime);

                if (result == null)
                {
                    ErrorMessage = "Failed to create appointment. Please try again.";
                    return false;
                }

                return true;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}