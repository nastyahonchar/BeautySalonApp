namespace BeautySalon.MAUI.Views;

[QueryProperty(nameof(CategoryName), "categoryName")]
public partial class ServicesPage : ContentPage
{
    private static readonly Dictionary<string, List<(string Name, string Duration, string Price)>> services = new()
    {
        ["Hair Care"] = new()
        {
            ("Women's Haircut",   "Duration: 60 minutes", "Price from: $60"),
            ("Hair Coloring",     "Duration: 1:30 hours", "Price from: $85"),
            ("Wash & Blow Dry",   "Duration: 45 minutes", "Price from: $40"),
            ("Keratin Treatment", "Duration: 2 hours",    "Price from: $150"),
        },
        ["Nails"] = new()
        {
            ("Classic Manicure", "Duration: 45 minutes", "Price from: $25"),
            ("Gel Manicure",     "Duration: 1:30 hours", "Price from: $50"),
            ("Nail Extensions",  "Duration: 1:30 hours", "Price from: $85"),
            ("Gel Removal",      "Duration: 30 minutes", "Price from: $15"),
        },
        ["Makeup"] = new()
        {
            ("Everyday Makeup", "Duration: 45 minutes", "Price from: $50"),
            ("Evening Makeup",  "Duration: 2 hours",    "Price from: $150"),
            ("Bridal Makeup",   "Duration: 2 hours",    "Price from: $150"),
            ("Makeup Trial",    "Duration: 1:30 hours", "Price from: $100"),
        },
    };

    public string CategoryName { get; set; } = "";

    public ServicesPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var category = Uri.UnescapeDataString(CategoryName ?? "");
        CategoryTitleLabel.Text = $"Category: {category}";
        FillServices(category);
    }

    private void FillServices(string category)
    {
        if (!services.TryGetValue(category, out var list)) return;

        var names = new[] { ServiceName1, ServiceName2, ServiceName3, ServiceName4 };
        var durations = new[] { ServiceDuration1, ServiceDuration2, ServiceDuration3, ServiceDuration4 };
        var prices = new[] { ServicePrice1, ServicePrice2, ServicePrice3, ServicePrice4 };
        var cards = new[] { Card1, Card2, Card3, Card4 };

        for (int i = 0; i < 4; i++)
        {
            if (i < list.Count)
            {
                names[i].Text = list[i].Name;
                durations[i].Text = list[i].Duration;
                prices[i].Text = list[i].Price;
                cards[i].IsVisible = true;
            }
            else
            {
                cards[i].IsVisible = false;
            }
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnServiceSelected(object sender, EventArgs e)
    {
        var category = Uri.UnescapeDataString(CategoryName ?? "");
        await Shell.Current.GoToAsync($"MastersPage?categoryName={Uri.EscapeDataString(category)}");
    }
}