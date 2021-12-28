using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class PropertiesTypeAPI
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}