using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pokedex.Model.PokeApi
{
    public class PokemonPropertiesList : ObservableObject
    {
        [JsonProperty("count")]
        private long _tamanhoDaLista;
        public long TamanhoDaLista
        {
            get
            {
                return _tamanhoDaLista;
            }

            set
            {
                SetProperty(ref _tamanhoDaLista, value, nameof(TamanhoDaLista));
            }
        }

        [JsonProperty("next")]
        private string _next;
        public string Next
        {
            get
            {
                return _next;
            }

            set
            {
                SetProperty(ref _next, value, nameof(Next));
            }
        }

        [JsonProperty("previus")]
        private string _previos;
        public string Previous
        {
            get
            {
                return _previos;
            }

            set
            {
                SetProperty(ref _previos, value, nameof(Previous));
            }
        }

        [JsonProperty("results")]
        private List<PokemonAddress> _results;
        public List<PokemonAddress> Results
        {
            get
            {
                return _results;
            }

            set
            {
                SetProperty(ref _results, value, nameof(Results));
            }
        }
    }
}
