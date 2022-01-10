using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class PokemonAPI
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("stats")]
        public List<StatsAPI> StatusBase { get; set; }

        [JsonProperty("abilities")]
        public List<AbilityAPI> Abilities { get; set; }

        [JsonProperty("types")]
        public List<TypeAPI> Types { get; set; }

        [JsonProperty("moves")]
        public List<MoveAPI> Moves { get; set; }
    }
}