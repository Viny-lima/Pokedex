using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.PokeApi
{
    public class Sprites : ObservableObject
    {
        [Key]
        public int Id_Sprites { get; set; }

        [JsonProperty("front_default")]
        private string _frontDefault;
        public string FrontDefault
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
        private string _frontShiny;
        public string FrontShiny
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
