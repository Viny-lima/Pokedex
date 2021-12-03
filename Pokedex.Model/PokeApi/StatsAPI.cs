using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class StatsAPI : ObservableObject
    {
        [JsonProperty("base_stat")]
        private int _valueState;
        public int ValueState
        {
            get
            {
                return _valueState;
            }
            set
            {
                SetProperty(ref _valueState, value, nameof(ValueState));
            }
        }

        [JsonProperty("effort")]
        private int _efforState;
        public int EffortState
        {
            get
            {
                return _efforState;
            }
            set
            {
                SetProperty(ref _efforState, value, nameof(EffortState));
            }
        }

        [JsonProperty("stat")]
        private PropertiesAbilityAPI _propertiesState;
        public PropertiesAbilityAPI PropertiesState
        {
            get
            {
                return _propertiesState;
            }
            set
            {
                SetProperty(ref _propertiesState, value, nameof(PropertiesState));
            }
        }

    }

}
