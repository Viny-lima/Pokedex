using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Model.PokeApi
{
    public class PropertiesMove
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}