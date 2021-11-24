using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models
{
    public class TypeElement : ObservableObject
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

    }

}
