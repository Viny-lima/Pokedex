using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.PokeApi
{
    class ListPokemonTypeAPI
    {
        [JsonProperty("pokemon")]
        public List<ListPokemonTypeItemAPI> Pokemons { get; set; }
    }
}
