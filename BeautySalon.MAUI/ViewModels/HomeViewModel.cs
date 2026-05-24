using BeautySalon.MAUI.Models;
using BeautySalon.MAUI.Services;

namespace BeautySalon.MAUI.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly CategoryApiService categoryService;

        private List<CategoryModel> categories = new();
        public List<CategoryModel> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }

        public HomeViewModel(CategoryApiService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task LoadCategoriesAsync()
        {
            IsBusy = true;
            try
            {
                var result = await categoryService.GetAllAsync();
                Categories = result ?? new List<CategoryModel>();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}