using ClothFashionApp.Models;
using ClothFashionApp.Services;
using ClothFashionApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ClothFashionApp.ViewModels
{
    public partial class WelcomeViewModel : ObservableObject
    {
        readonly ClothFashionService _clothFashionService;
        ObservableCollection<Item> _items;

        public WelcomeViewModel(ClothFashionService clothFashionService)
        {
            _clothFashionService = clothFashionService;

            LoadData();
        }

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        async Task GoToHome()
        {
            await Shell.Current.GoToAsync(nameof(HomeView), true);

            // TODO: REMOVE WELCOME FROM STACK
        }

        void LoadData()
        {
            Items = new ObservableCollection<Item>(_clothFashionService.GetPromoItems());
        }
    }
}
