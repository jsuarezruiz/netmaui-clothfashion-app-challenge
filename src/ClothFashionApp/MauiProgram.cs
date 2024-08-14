using ClothFashionApp.Services;
using ClothFashionApp.Views;
using ClothFashionApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace ClothFashionApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("BebasNeue-Regular.ttf", "BebasNeueRegular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ClothFashionService>();
            builder.Services.AddSingleton<WelcomeViewModel>();
            builder.Services.AddSingleton<WelcomeView>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomeView>(); 
            builder.Services.AddSingleton<DetailsViewModel>();
            builder.Services.AddSingleton<DetailsView>();

            return builder.Build();
        }
    }
}
