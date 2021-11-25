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
    public class Species : ObservableObject
    {
        [Key]
        public int Id_Species { get; set; }

        [JsonProperty("name")]
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value, nameof(Name));
            }
        }

        [JsonProperty("url")]
        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                SetProperty(ref _url, value, nameof(Url));
            }
        }

    }

}