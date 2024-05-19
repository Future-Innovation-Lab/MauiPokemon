using PokemonParser.Services;

namespace PokemonParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var etl = new PokemonEtl();
            etl.MovePokemonToLocalDb();
            Console.ReadLine();
        }

    }
}
