using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.DAO;
using Pokedex.Model.PokeApi;

namespace Pokedex.ViewModels
{
    public class PokemonViewModel : ObservableObject
    {
        private Model.PokeApi.Pokemon _pokemon = new Model.PokeApi.Pokemon();
        public Model.PokeApi.Pokemon Pokemon
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