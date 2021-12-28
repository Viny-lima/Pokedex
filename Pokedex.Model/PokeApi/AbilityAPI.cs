using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class AbilityAPI
    {
        [JsonProperty("ability")]
        public PropertiesAbilityAPI PropertiesAbility { get; set; }
    }
}
