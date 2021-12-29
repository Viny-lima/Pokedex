using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class MoveAPI 
    {
        [JsonProperty("move")]
        public Names Move { get; set; }
    }

}
