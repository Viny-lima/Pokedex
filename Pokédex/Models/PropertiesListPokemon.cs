using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PropertiesListPokemon : ObservableObject
    {

        [JsonProperty("count")]
        private long? _tamanhoDaLista;
        public long? TamanhoDaLista
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
        private Uri _next;
        public Uri Next
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
        private Uri _previos;
        public Uri Previous
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
        private List<AddressPokemon> _results;
        public List<AddressPokemon> Results
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
