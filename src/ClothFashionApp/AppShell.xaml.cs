using ClothFashionApp.Views;

namespace ClothFashionApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
            Routing.RegisterRoute(nameof(DetailsView), typeof(DetailsView));
        }
    }
}
