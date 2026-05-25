using BeautySalon.MAUI.ViewModels;

namespace BeautySalon.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
[QueryProperty(nameof(ServiceId), "serviceId")]
public partial class TimingPage : ContentPage
{
    private readonly TimingViewModel viewModel;

    public string EmployeeId { get; set; } = "";
    public string ServiceId { get; set; } = "";

    private Frame? selectedDayFrame;
    private Frame? selectedHourFrame;
    private DateTime selectedDate;

    public TimingPage(TimingViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BuildDays();
    }

    private void BuildDays()
    {
        DaysContainer.Children.Clear();
        var dayNames = new[] { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
        var today = DateTime.Today;

        for (int i = 0; i < 7; i++)
        {
            var date = today.AddDays(i);
            var dayName = dayNames[(int)date.DayOfWeek == 0 ? 6 : (int)date.DayOfWeek - 1];

            var stack = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 2,
                Children =
                {
                    new Label { Text = dayName, FontSize = 12, TextColor = Colors.White, HorizontalOptions = LayoutOptions.Center },
                    new Label { Text = date.Day.ToString(), FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Colors.White, HorizontalOptions = LayoutOptions.Center }
                }
            };

            var frame = new Frame
            {
                Padding = new Thickness(10, 8),
                CornerRadius = 12,
                BackgroundColor = Color.FromArgb("#33FFFFFF"),
                BorderColor = Colors.Transparent,
                WidthRequest = 58,
                Content = stack
            };

            frame.ClassId = date.ToString("yyyy-MM-dd");

            var tap = new TapGestureRecognizer();
            tap.Tapped += OnDayTapped;
            frame.GestureRecognizers.Add(tap);

            DaysContainer.Children.Add(frame);
        }
    }

    private void BuildHours(List<string> slots)
    {
        HoursContainer.Children.Clear();

        if (slots.Count == 0)
        {
            HoursContainer.Children.Add(new Label
            {
                Text = "No available slots for this day",
                FontSize = 14,
                TextColor = Colors.White,
                Opacity = 0.7,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20)
            });
            return;
        }

        foreach (var slot in slots)
        {
            var label = new Label
            {
                Text = slot,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Colors.White
            };

            var frame = new Frame
            {
                Padding = new Thickness(14, 14),
                CornerRadius = 12,
                BackgroundColor = Color.FromArgb("#33FFFFFF"),
                BorderColor = Colors.Transparent,
                Content = label
            };

            frame.ClassId = slot;

            var tap = new TapGestureRecognizer();
            tap.Tapped += OnHourTapped;
            frame.GestureRecognizers.Add(tap);

            HoursContainer.Children.Add(frame);
        }
    }

    private async void OnDayTapped(object? sender, TappedEventArgs e)
    {
        if (sender is not Frame tapped) return;

        if (selectedDayFrame != null)
        {
            selectedDayFrame.BackgroundColor = Color.FromArgb("#33FFFFFF");
            foreach (var child in ((VerticalStackLayout)selectedDayFrame.Content).Children.OfType<Label>())
                child.TextColor = Colors.White;
        }

        tapped.BackgroundColor = Colors.White;
        foreach (var child in ((VerticalStackLayout)tapped.Content).Children.OfType<Label>())
            child.TextColor = Color.FromArgb("#462EB7");

        selectedDayFrame = tapped;
        selectedHourFrame = null;
        UpdateNextButton();

        if (DateTime.TryParse(tapped.ClassId, out selectedDate) &&
            int.TryParse(EmployeeId, out int empId) &&
            int.TryParse(ServiceId, out int svcId))
        {
            await viewModel.LoadSlotsAsync(empId, svcId, selectedDate);
            BuildHours(viewModel.AvailableSlots);
        }
    }

    private void OnHourTapped(object? sender, TappedEventArgs e)
    {
        if (sender is not Frame tapped) return;

        if (selectedHourFrame != null)
        {
            selectedHourFrame.BackgroundColor = Color.FromArgb("#33FFFFFF");
            ((Label)selectedHourFrame.Content).TextColor = Colors.White;
        }

        tapped.BackgroundColor = Colors.White;
        ((Label)tapped.Content).TextColor = Color.FromArgb("#462EB7");

        selectedHourFrame = tapped;
        viewModel.SelectedSlot = tapped.ClassId;
        UpdateNextButton();
    }

    private void UpdateNextButton()
    {
        bool ready = selectedDayFrame != null && selectedHourFrame != null;
        NextButtonLabel.TextColor = ready
            ? Color.FromArgb("#462EB7")
            : Color.FromArgb("#999999");
        viewModel.SelectedDate = selectedDate;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnNextClicked(object sender, TappedEventArgs e)
    {
        if (selectedDayFrame == null || selectedHourFrame == null) return;

        var success = await viewModel.CreateAppointmentAsync();
        if (success)
            await Shell.Current.GoToAsync("ConfirmationPage");
        else
            await DisplayAlert("Error", viewModel.ErrorMessage, "OK");
    }
}