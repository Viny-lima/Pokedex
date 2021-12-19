using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.PokeApi
{
    class PokemonTypePropertiesAPI
    {
        [JsonProperty("pokemon")]
        public PokemonAddressAPI PokemonAddress { get; set; }
    }
}
