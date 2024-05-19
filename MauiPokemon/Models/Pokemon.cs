
using MauiPokemon.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MauiPokemon.Models
{
    public class Pokemon
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string ImageName { get; set; }
        public string ImageThumbName { get; set; }

        [ForeignKey(typeof(Ability))]
        public int AbilityId { get; set; }

        public Ability Ability { get; set; }

    }
}
