using Humanizer;
using PokemonParser.Models.Database;
using SQLite;

namespace PokemonParser.Services
{
    public class LocalPokemonDatabase
    {
        private SQLiteConnection _connection;

        public string GetDbPath()
        {
            return "pokemon.db";
        }

        public void ClearDatabase()
        {
            _connection.DeleteAll<Models.Database.Ability>();
        }

        public void CreateDatabase()
        {
            var dbPath = GetDbPath();
            _connection = new SQLiteConnection(dbPath);
            
            _connection.CreateTable<Models.Database.Ability>();
            _connection.CreateTable<Models.Database.Pokemon>();
        }

        public void InsertAbility(Models.PokemonApi.PokemonAbility.Ability ability)
        {
            var dbAbility = new Models.Database.Ability
            {
                Name = ability.name.Humanize(LetterCasing.Title)
            };

            if (ability.effect_entries.Count > 0)
                dbAbility.Effect = ability.effect_entries[0].effect;

            if(ability.flavor_text_entries.Count > 0)
            dbAbility.Flavour = ability.flavor_text_entries[0].flavor_text;

            _connection.Insert(dbAbility);
        }

        public void InsertPokemon(Models.PokemonApi.Pokemon pokemon, Models.PokemonApi.PokemonAbility.Ability ability)
        {
            string fmt = "000";
            string fileNumber = pokemon.id.ToString(fmt);
            var dbPokemon = new Models.Database.Pokemon
            {
                Name = pokemon.name.Humanize(LetterCasing.Title),
                Weight = pokemon.weight,
                Height = pokemon.height,
                AbilityId = ability.id,
                ImageName = $"img{fileNumber}.png",
                ImageThumbName = $"thumb{fileNumber}.png"
            };

            _connection.Insert(dbPokemon);
        }


    }
}
