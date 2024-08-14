using ClothFashionApp.ViewModels;

namespace ClothFashionApp.Views;

public partial class DetailsView : ContentPage
{
	public DetailsView(DetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}