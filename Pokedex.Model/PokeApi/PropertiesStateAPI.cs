using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class PropertiesStateAPI
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}