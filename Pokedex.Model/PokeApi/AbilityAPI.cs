using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class AbilityAPI : ObservableObject
    {
        [JsonProperty("ability")]
        private PropertiesAbilityAPI _propertiesAbility;
        public PropertiesAbilityAPI PropertiesAbility
        {
            get
            {
                return _propertiesAbility;
            }
            set
            {
                SetProperty(ref _propertiesAbility, value, nameof(PropertiesAbility));
            }
        }

        [JsonProperty("is_hidden")]
        private bool _isHidden;
        public bool IsHidden
        {
            get
            {
                return _isHidden;
            }
            set
            {
                SetProperty(ref _isHidden, value, nameof(IsHidden));
            }
        }

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

    }
}
