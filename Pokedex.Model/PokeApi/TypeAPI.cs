using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class TypeAPI : ObservableObject
    {
        [JsonProperty("slot")]
        private long _slot;
        public long Slot
        {
            get
            {
                return _slot;
            }
            set
            {
                SetProperty(ref _slot, value, nameof(Slot));
            }
        }

        [JsonProperty("type")]
        private PropertiesTypeAPI _type;
        public PropertiesTypeAPI Type
        {
            get
            {
                return _type;
            }
            set
            {
                SetProperty(ref _type, value, nameof(Type));
            }
        }

    }

}
