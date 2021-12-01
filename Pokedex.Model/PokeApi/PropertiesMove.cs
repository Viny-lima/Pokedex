﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Model.PokeApi
{
    public class PropertiesMove : ObservableObject
    {
        [Key]
        public int Id_PropertiesMove { get; set; }

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