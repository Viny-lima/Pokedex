using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;
using Pokedex.Model.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Pokedex.ViewModels
{
    public class PokemonViewModelList
    {
        private ObservableCollection<PokemonDB> _pokemons = new ObservableCollection<PokemonDB>();

        private PokemonDAO _pokemonDAO;

        public ObservableCollection<PokemonDB> ListaPokemons { get { return _pokemons; } }

        public PokemonViewModelList()
        {
            _pokemonDAO = new PokemonDAO();

            IList<PokemonDB> ListaPokemons = _pokemonDAO.FindAll().Result;

            foreach (var pokemon in ListaPokemons)
            {
                Debug.WriteLine(pokemon.Name);
                this._pokemons.Add(pokemon);
            }
        }
        
    }

}