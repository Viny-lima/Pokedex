using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class TypeAPI
    {
        [JsonProperty("type")]
        public Names NamesType { get; set; }
    }

}
