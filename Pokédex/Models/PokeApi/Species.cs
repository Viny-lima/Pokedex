using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models.PokeApi
{
    public class Species : ObservableObject
    {
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
        private Uri _url;
        public Uri Url
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