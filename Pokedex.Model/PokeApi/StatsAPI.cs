using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class StatsAPI
    {
        [JsonProperty("base_stat")]
        public int ValueState { get; set; }

        [JsonProperty("stat")]
        public Names NameState { get; set; }
    }

}
