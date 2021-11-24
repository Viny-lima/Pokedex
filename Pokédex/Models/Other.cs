using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models
{
    public class Other : ObservableObject
    {

        [JsonProperty("dream_world")]
        private DreamWorld _dreamWorld;
        public DreamWorld DreamWorld
        {
            get
            {
                return _dreamWorld;
            }
            set
            {
                SetProperty(ref _dreamWorld, value, nameof(DreamWorld));
            }
        }
    }

}
