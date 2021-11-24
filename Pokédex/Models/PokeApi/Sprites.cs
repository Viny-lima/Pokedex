using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models.PokeApi
{
    public class Sprites : ObservableObject
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

        [JsonProperty("front_shiny")]
        private Uri _frontShiny;
        public Uri FrontShiny
        {
            get
            {
                return _frontShiny;
            }
            set
            {
                SetProperty(ref _frontShiny, value, nameof(FrontShiny));
            }
        }

        [JsonProperty("other")]
        private Other _other;
        public Other Other
        {
            get
            {
                return _other;
            }
            set
            {
                SetProperty(ref _other, value, nameof(Other));
            }
        }

    }

}
