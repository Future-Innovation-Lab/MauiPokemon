using MauiPokemon.Views;

namespace MauiPokemon
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }


        private void RegisterRoutes()
        {
            Routing.RegisterRoute("allpokemons", typeof(AllPokemonView));
            Routing.RegisterRoute("pokemon", typeof(PokemonView));
        }
    }
}
