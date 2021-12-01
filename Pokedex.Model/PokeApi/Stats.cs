﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.PokeApi
{
    public class Stats : ObservableObject
    {
        [Key]
        public int Id_Stats { get; set; }

        [JsonProperty("base_stat")]
        private int _valueState;
        public int ValueState
        {
            get
            {
                return _valueState;
            }
            set
            {
                SetProperty(ref _valueState, value, nameof(ValueState));
            }
        }

        [JsonProperty("effort")]
        private int _efforState;
        public int EffortState
        {
            get
            {
                return _efforState;
            }
            set
            {
                SetProperty(ref _efforState, value, nameof(EffortState));
            }
        }

        [JsonProperty("stat")]
        private PropertiesAbility _propertiesState;
        public PropertiesAbility PropertiesState
        {
            get
            {
                return _propertiesState;
            }
            set
            {
                SetProperty(ref _propertiesState, value, nameof(PropertiesState));
            }
        }

    }

}