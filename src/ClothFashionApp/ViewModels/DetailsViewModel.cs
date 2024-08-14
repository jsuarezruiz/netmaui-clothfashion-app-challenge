using ClothFashionApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ClothFashionApp.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Product product;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
