using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;
using System.Collections.Generic;

namespace Pokedex.ViewModel
{
    public class PokemonViewModel : ObservableObject
    {
        private PokemonDB _pokemon = new PokemonDB();
        public PokemonDB This
        {
            get
            {
                
                return _pokemon;
            }
            set
            {
                SetProperty(ref _pokemon, value);
            }
        }

    }
}