using CommunityToolkit.Mvvm.Input;
using MauiPokemon.Models;
using MauiPokemon.Services;
using System.Collections.ObjectModel;

namespace MauiPokemon.ViewModel
{

    [QueryProperty(nameof(Pokemon), "Pokemon")]
    public partial class PokemonViewModel : BaseViewModel
    {
        private PokemonDatabaseService _pokemonDatabaseService;
        private Pokemon _pokemon;

        public Pokemon Pokemon
        {
            get { return _pokemon; }
            set
            {
                _pokemon = value;

                _pokemon.Ability = _pokemonDatabaseService.GetAbility(_pokemon.AbilityId);

                OnPropertyChanged();
            }
        }


        public PokemonViewModel(PokemonDatabaseService pokemonDatabaseService)
        {
            _pokemonDatabaseService = pokemonDatabaseService;
        }

            
        public override void OnAppearing()
        {
            base.OnAppearing();

          

        }
    }
}
