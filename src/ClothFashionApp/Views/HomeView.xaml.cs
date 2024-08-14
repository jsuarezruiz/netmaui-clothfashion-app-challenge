using ClothFashionApp.ViewModels;

namespace ClothFashionApp.Views;

public partial class HomeView : ContentPage
{
	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}