using Newtonsoft.Json;
using PokemonParser.Models.PokemonApi;
using PokemonParser.Models.PokemonApi.PokemonAbility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParser.Services
{
    public  class RemotePokemonApi
    {
        public async Task<PokemonIndex> GetPokemonIndex()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=2000");

            PokemonIndex pokemonIndex = JsonConvert.DeserializeObject<PokemonIndex>(response);

            return pokemonIndex;
        }

        public async Task<PokemonIndex> GetAbilities()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://pokeapi.co/api/v2/ability?limit=1000");

            PokemonIndex pokemonIndex = JsonConvert.DeserializeObject<PokemonIndex>(response);

            return pokemonIndex;
        }


        public async Task<Models.PokemonApi.Pokemon> GetPokemon(string url)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetStringAsync(url);

                Models.PokemonApi.Pokemon pokemon = JsonConvert.DeserializeObject<Models.PokemonApi.Pokemon>(response);

                return pokemon;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Ability> GetAbility(string url)
        {

            try
            {

                var client = new HttpClient();
                var response = await client.GetStringAsync(url);

                Ability ability = JsonConvert.DeserializeObject<Ability>(response);

                return ability;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
