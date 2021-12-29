using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.PokeApi
{
    class ListPokemonTypeItemAPI
    {
        [JsonProperty("pokemon")]
        public ListPokemonItemAPI PokemonItemList { get; set; }
    }
}
