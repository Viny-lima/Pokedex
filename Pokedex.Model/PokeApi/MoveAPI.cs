using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class MoveAPI : ObservableObject
    {
        [JsonProperty("move")]
        public PropertiesMove Move { get; set; }
    }

}
