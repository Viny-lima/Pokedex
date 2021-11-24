using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models
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
    }

}
