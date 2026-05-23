namespace BeautySalon.MAUI.Views;

public enum ActiveTab { Home, Appointments, Profile }

public partial class BottomTabBar : ContentView
{
    public static readonly BindableProperty ActiveTabProperty =
        BindableProperty.Create(nameof(ActiveTab), typeof(ActiveTab), typeof(BottomTabBar),
            ActiveTab.Home, propertyChanged: OnActiveTabChanged);

    public ActiveTab ActiveTab
    {
        get => (ActiveTab)GetValue(ActiveTabProperty);
        set => SetValue(ActiveTabProperty, value);
    }

    public BottomTabBar()
    {
        InitializeComponent();
        UpdateTabVisuals(ActiveTab.Home);
    }

    private static void OnActiveTabChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is BottomTabBar bar)
            bar.UpdateTabVisuals((ActiveTab)newValue);
    }

    private void UpdateTabVisuals(ActiveTab active)
    {
        SetTabActive(HomeLabel, false);
        SetTabActive(AppointmentsLabel, false);
        SetTabActive(ProfileLabel, false);

        switch (active)
        {
            case ActiveTab.Home: SetTabActive(HomeLabel, true); break;
            case ActiveTab.Appointments: SetTabActive(AppointmentsLabel, true); break;
            case ActiveTab.Profile: SetTabActive(ProfileLabel, true); break;
        }
    }

    private static void SetTabActive(Label label, bool isActive)
    {
        label.TextColor = isActive ? Color.FromArgb("#462EB7") : Color.FromArgb("#999999");
        label.FontAttributes = isActive ? FontAttributes.Bold : FontAttributes.None;
    }

    private async void OnHomeTapped(object sender, TappedEventArgs e)
    {
        if (ActiveTab == ActiveTab.Home) return;
        await Shell.Current.GoToAsync("//HomePage");
    }

    private async void OnAppointmentsTapped(object sender, TappedEventArgs e)
    {
        if (ActiveTab == ActiveTab.Appointments) return;
        await Shell.Current.GoToAsync("//MyAppointmentsPage");
    }

    private async void OnProfileTapped(object sender, TappedEventArgs e)
    {
        if (ActiveTab == ActiveTab.Profile) return;
        await Shell.Current.GoToAsync("//ProfilePage");
    }
}