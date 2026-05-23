namespace BeautySalon.MAUI.Views;

public partial class TimingPage : ContentPage
{
    private Frame? selectedDayFrame;
    private Frame? selectedHourFrame;
    private bool isNextEnabled = false;

    private readonly string[] availableHours =
    {
        "10:00 am", "11:00 am", "13:15 pm",
        "14:30 pm", "16:00 pm"
    };

    public TimingPage()
    {
        InitializeComponent();
        BuildDays();
        BuildHours();
    }

    private void BuildDays()
    {
        var dayNames = new[] { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
        var today = DateTime.Today;

        for (int i = 0; i < 7; i++)
        {
            var date = today.AddDays(i);
            var dayName = dayNames[(int)date.DayOfWeek == 0 ? 6 : (int)date.DayOfWeek - 1];

            var dayLabel = new Label
            {
                Text = dayName,
                FontSize = 12,
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            };
            var numLabel = new Label
            {
                Text = date.Day.ToString(),
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.White,
                HorizontalOptions = LayoutOptions.Center
            };

            var stack = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 2,
                Children = { dayLabel, numLabel }
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

    private void BuildHours()
    {
        foreach (var hour in availableHours)
        {
            var label = new Label
            {
                Text = hour,
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

            frame.ClassId = hour;

            var tap = new TapGestureRecognizer();
            tap.Tapped += OnHourTapped;
            frame.GestureRecognizers.Add(tap);

            HoursContainer.Children.Add(frame);
        }
    }

    private void OnDayTapped(object? sender, TappedEventArgs e)
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
        UpdateNextButton();
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
        UpdateNextButton();
    }

    private void UpdateNextButton()
    {
        isNextEnabled = selectedDayFrame != null && selectedHourFrame != null;
        NextButtonLabel.TextColor = isNextEnabled
            ? Color.FromArgb("#462EB7")
            : Color.FromArgb("#999999");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnNextClicked(object sender, TappedEventArgs e)
    {
        if (!isNextEnabled) return;
        await Shell.Current.GoToAsync("ConfirmationPage");
    }
}