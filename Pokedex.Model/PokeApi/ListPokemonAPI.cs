using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pokedex.Model.PokeApi
{
    public class ListPokemonAPI
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<ListPokemonItemAPI> Results { get; set; }
    }
}
