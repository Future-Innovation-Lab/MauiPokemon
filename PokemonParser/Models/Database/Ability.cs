
using SQLite;

namespace PokemonParser.Models.Database
{
    public class Ability
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Flavour { get; set; }

    }
}
