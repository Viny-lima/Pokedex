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
    public class PropertiesAbilityAPI
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
