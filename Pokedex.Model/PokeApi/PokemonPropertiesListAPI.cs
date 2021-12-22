using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pokedex.Model.PokeApi
{
    public class PokemonPropertiesList
    {
        [JsonProperty("count")]
        public long ListSize { get; set; }

        [JsonProperty("results")]
        public List<PokemonUrlAPI> Results { get; set; }
    }
}
