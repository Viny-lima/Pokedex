using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models.PokeApi
{
    public class DreamWorld : ObservableObject
    {

        [JsonProperty("front_default")]
        private Uri _frontDefault;
        public Uri FrontDefault
        {
            get
            {
                return _frontDefault;
            }
            set
            {
                SetProperty(ref _frontDefault, value, nameof(FrontDefault));
            }
        }

    }
}
