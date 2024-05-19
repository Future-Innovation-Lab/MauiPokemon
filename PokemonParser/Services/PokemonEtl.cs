using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParser.Services
{
    public class PokemonEtl
    {

        public async void MovePokemonToLocalDb()
        {
            var remotePokemonApi = new RemotePokemonApi();
            var localPokemonDb = new LocalPokemonDatabase();
            localPokemonDb.CreateDatabase();
            localPokemonDb.ClearDatabase();

            var abilityList = await remotePokemonApi.GetAbilities();

            Console.WriteLine($"Abilities: {abilityList.count}");

            foreach (var abilityItem in abilityList.results)
            {
                Console.WriteLine($"Ability: {abilityItem.name}");

                var ability = await remotePokemonApi.GetAbility(abilityItem.url);

                if (ability != null)
                localPokemonDb.InsertAbility(ability);
            }
            
            var pokemonList = await remotePokemonApi.GetPokemonIndex();

            Console.WriteLine($"Pokemons: {pokemonList.count}");

            foreach (var pokemonItem in pokemonList.results)
            {
                Console.WriteLine($"Pokemon: {pokemonItem.name}");

                var pokemon = await remotePokemonApi.GetPokemon(pokemonItem.url);

                if (pokemon != null)
                {

                    Console.WriteLine($"Pokemon Id: {pokemon.id}");

                    var ability = await remotePokemonApi.GetAbility(pokemonItem.url);

                    if (ability != null)
                    {

                        Console.WriteLine($"Ability Id: {ability.id}");

                        localPokemonDb.InsertPokemon(pokemon, ability);
                    }
                }
            }
        }
    }
}
