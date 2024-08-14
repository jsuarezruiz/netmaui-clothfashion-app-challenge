using ClothFashionApp.Models;
using ClothFashionApp.Services;
using ClothFashionApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ClothFashionApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        Promotion _promotion;
        ObservableCollection<string> _categories;
        ObservableCollection<Product> _popularProducts;
        readonly ClothFashionService _clothFashionService;

        public HomeViewModel(ClothFashionService clothFashionService)
        {
            _clothFashionService = clothFashionService;

            LoadData();
        }

        public Promotion Promotion
        {
            get { return _promotion; }
            set
            {
                _promotion = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        string selectedCategory;

        public ObservableCollection<Product> PopularProducts
        {
            get { return _popularProducts; }
            set
            {
                _popularProducts = value;
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        Product selectedPopularProduct;

        [RelayCommand]
        async Task GoToDetails(Product product)
        {
            if (product is null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailsView), true, new Dictionary<string, object>
            {
                {"Product", product }
            });
        }

        void LoadData()
        {
            Promotion = _clothFashionService.GetPromotion();
            Categories = new ObservableCollection<string>(_clothFashionService.GetCategories());
            SelectedCategory = Categories.FirstOrDefault();
            PopularProducts = new ObservableCollection<Product>(_clothFashionService.GetPopularProducts());
        }
    }
}
