using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;

namespace Pokedex.ViewModel
{
    public class PokemonViewModel : ObservableObject
    {
        private PokemonDB _pokemon = new PokemonDB();
        public PokemonDB Pokemon
        {
            get
            {
                
                return _pokemon;
            }
            set
            {
                SetProperty(ref _pokemon, value, nameof(Pokemon));
            }
        }

        public PokemonViewModel() { }

    }
}