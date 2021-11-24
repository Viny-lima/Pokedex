using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models.PokeApi
{
    public class Ability : ObservableObject
    {

        [JsonProperty("ability")]
        private NameUrl _propertiesAbility;
        public NameUrl PropertiesAbility
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
