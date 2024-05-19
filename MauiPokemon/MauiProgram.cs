using MauiPokemon.Services;
using MauiPokemon.ViewModel;
using MauiPokemon.Views;
using Microsoft.Extensions.Logging;

namespace MauiPokemon
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<PokemonDatabaseService>();
            builder.Services.AddSingleton<AllPokemonViewModel>();
            builder.Services.AddTransient<AllPokemonView>();

            builder.Services.AddSingleton<PokemonViewModel>();
            builder.Services.AddTransient<PokemonView>();


            return builder.Build();
        }
    }
}
