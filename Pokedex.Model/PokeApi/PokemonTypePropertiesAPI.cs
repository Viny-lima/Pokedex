using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.PokeApi
{
    class PokemonTypePropertiesAPI
    {
        [JsonProperty("pokemon")]
        public PokemonUrlAPI PokemonAddress { get; set; }
    }
}
