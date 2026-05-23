namespace BeautySalon.MAUI.Views;

[QueryProperty(nameof(CategoryName), "categoryName")]
public partial class MastersPage : ContentPage
{
    private static readonly Dictionary<string, List<(string Name, string Degree, string Rating, string Photo)>> masters = new()
    {
        ["Hair Care"] = new()
        {
            ("Emma Watson",    "Top Hair Stylist",    "Rating: ⭐ 5.0", "master_hair1.png"),
            ("Anna Smith",     "Hair Stylist",        "Rating: ⭐ 4.8", "master_hair2.png"),
            ("Sarah Johnson",  "Expert Colorist",     "Rating: ⭐ 4.9", "master_hair3.png"),
            ("Michael Brown",  "Junior Hair Stylist", "Rating: ⭐ 4.4", "master_hair4.png"),
        },
        ["Nails"] = new()
        {
            ("Jessica Davis",  "Top Nail Master",        "Rating: ⭐ 5.0", "master_nails1.png"),
            ("Emily Miller",   "Senior Nail Technician", "Rating: ⭐ 4.8", "master_nails2.png"),
            ("Anna Wilson",    "Nail Technician",        "Rating: ⭐ 4.6", "master_nails3.png"),
            ("Sophia Taylor",  "Junior Nail Technician", "Rating: ⭐ 4.3", "master_nails4.png"),
        },
        ["Makeup"] = new()
        {
            ("Olivia Martinez",   "Celebrity Makeup Artist", "Rating: ⭐ 5.0", "master_makeup1.png"),
            ("Isabella Anderson", "Bridal Makeup Specialist","Rating: ⭐ 4.9", "master_makeup2.png"),
            ("Mia Thomas",        "Senior Makeup Artist",    "Rating: ⭐ 4.7", "master_makeup3.png"),
            ("Chloe Jackson",     "Junior Makeup Artist",    "Rating: ⭐ 4.5", "master_makeup4.png"),
        },
    };

    public string CategoryName { get; set; } = "";

    public MastersPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var category = Uri.UnescapeDataString(CategoryName ?? "");
        FillMasters(category);
    }

    private void FillMasters(string category)
    {
        if (!masters.TryGetValue(category, out var list)) return;

        var names = new[] { MasterName1, MasterName2, MasterName3, MasterName4 };
        var degrees = new[] { MasterDegree1, MasterDegree2, MasterDegree3, MasterDegree4 };
        var ratings = new[] { MasterRating1, MasterRating2, MasterRating3, MasterRating4 };
        var photos = new[] { MasterPhoto1, MasterPhoto2, MasterPhoto3, MasterPhoto4 };
        var cards = new[] { MasterCard1, MasterCard2, MasterCard3, MasterCard4 };

        for (int i = 0; i < 4; i++)
        {
            if (i < list.Count)
            {
                names[i].Text = list[i].Name;
                degrees[i].Text = list[i].Degree;
                ratings[i].Text = list[i].Rating;
                photos[i].Source = list[i].Photo;
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

    private async void OnMasterSelected(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("TimingPage");
    }
}