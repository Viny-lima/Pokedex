using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.PokeApi
{
    class TypePageAPI
    {
        [JsonProperty("pokemon")]
        public List<PokemonTypePropertiesAPI> Pokemons;
    }
}
