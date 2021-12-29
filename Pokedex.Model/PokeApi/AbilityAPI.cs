using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class AbilityAPI
    {
        [JsonProperty("ability")]
        public Names PropertiesAbility { get; set; }
    }
}
