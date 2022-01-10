using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;
using Pokedex.Model.Service;

namespace Pokedex.ViewModels
{
    public class PokeViewModel : ObservableObject
    {
        private PokemonDB _pokemon;
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

        public PokeViewModel(int Id)
        {
            var pokemonDAO = new PokemonDAO();

            /*var pCreate = new PokemonDB(ApiRequest.GetPokemon(Id));
            pokemonDAO.Add(pCreate);*/

            Pokemon = pokemonDAO.FindById(Id).Result;

        }

    }
}