using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;

namespace Pokedex.ViewModels
{
    public class PokemonViewModel : ObservableObject
    {
        private Model.PokeApi.PokemonAPI _pokemon = new Model.PokeApi.PokemonAPI();
        public Model.PokeApi.PokemonAPI Pokemon
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