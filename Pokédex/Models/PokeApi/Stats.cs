using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models.PokeApi
{
    public class Stats : ObservableObject
    {
        [JsonProperty("base_stat")]
        private long _valueState;
        public long ValueState
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
        private long _efforState;
        public long EffortState
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
        private NameUrl _propertiesState;
        public NameUrl PropertiesState
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
