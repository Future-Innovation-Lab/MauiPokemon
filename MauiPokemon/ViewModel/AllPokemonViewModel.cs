using CommunityToolkit.Mvvm.Input;
using MauiPokemon.Models;
using MauiPokemon.Services;
using System.Collections.ObjectModel;

namespace MauiPokemon.ViewModel
{
    public partial class AllPokemonViewModel : BaseViewModel
    {
        private PokemonDatabaseService _pokemonDatabaseService;
        private ObservableCollection<Pokemon> _pokemons;

        public ObservableCollection<Pokemon> Pokemons
        {
            get { return _pokemons; }
            set
            {
                _pokemons = value;

                OnPropertyChanged();
            }
        }


        public AllPokemonViewModel(PokemonDatabaseService pokemonDatabaseService)
        {
            _pokemonDatabaseService = pokemonDatabaseService;
        }

            [RelayCommand]
            public async Task PokemonSelected(Pokemon pokemon)
            {
                var navigationParameter = new Dictionary<string, object>
     {
         { "Pokemon", pokemon }
     };
                await Shell.Current.GoToAsync($"pokemon", navigationParameter);

            }

        
        public override void OnAppearing()
        {
            base.OnAppearing();

            Pokemons = new ObservableCollection<Pokemon>(_pokemonDatabaseService.GetAllPokemon());
        }
    }
}
