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
    public class DreamWorld : ObservableObject
    {
        [Key]
        public int Id_DreamWorld { get; set; }

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

    }
}
