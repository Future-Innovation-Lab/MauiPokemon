using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonParser.Models.PokemonApi
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PokemonIndexResult
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonIndex
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<PokemonIndexResult> results { get; set; }
    }


}
