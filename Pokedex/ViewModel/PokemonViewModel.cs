using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.PokeApi;

namespace Pokedex.ViewModels
{
    public class PokemonViewModel : ObservableObject
    {
        private Pokemon _pokemon = new Pokemon();
        public Pokemon Pokemon
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