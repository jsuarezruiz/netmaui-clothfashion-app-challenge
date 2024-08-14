using ClothFashionApp.ViewModels;

namespace ClothFashionApp.Views;

public partial class WelcomeView : ContentPage
{
	public WelcomeView(WelcomeViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}