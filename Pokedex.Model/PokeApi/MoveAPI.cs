using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class MoveAPI : ObservableObject
    {
        [JsonProperty("move")]
        private PropertiesMove _move;
        public PropertiesMove Move
        {
            get
            {
                return _move;
            }
            set
            {
                SetProperty(ref _move, value);
            }
        }
    }

}
