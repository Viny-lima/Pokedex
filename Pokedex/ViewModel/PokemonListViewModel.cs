using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pokedex.ViewModels
{
    public class PokemonListViewModel
    {
        private PokemonService _pokemonService = new PokemonService();
        private ObservableCollection<PokemonDB> _pokemons = new ObservableCollection<PokemonDB>();

        private int _start;
        private readonly int _quantity;

        public ObservableCollection<PokemonDB> Pokemons { get { return _pokemons; } }

        public PokemonListViewModel(int quantity = 10)
        {
            _start = 1;
            _quantity = quantity;

            IList<PokemonDB> listPokemons = _pokemonService.FindPokemonsById(_start, _quantity).Result;

            foreach (var pokemon in listPokemons)
            {
                this._pokemons.Add(pokemon);
            }
        }

        /// <summary>
        /// Redefine a lista em exibição basedo nas propriedades <see cref="_start"/> e <see cref="_quantity"/>.
        /// </summary>
        private void UpdateListPokemons()
        {
            IList<PokemonDB> listPokemons = _pokemonService.FindPokemonsById(_start, _quantity).Result;

            foreach (PokemonDB newPokemon in listPokemons)
            {
                this._pokemons.Add(newPokemon);
            }
        }

        /// <summary>
        /// O método adiciona 10 ao index que foi definido inicialmente no construtor. 
        /// Assim Criando uma nova exbição de dados.
        /// </summary>
        public void NextPageListPokemons()
        {
            _start += _quantity;

            UpdateListPokemons();
        }
        /// <summary>
        /// O método subtrai 10 ao index que foi definido inicialmente no construtor. 
        /// Assim Criando uma nova exbição de dados.
        /// </summary>
        public void PreviosPageListPokemons()
        {
            _start -= 10;
            if (_start < 0) _start = 0;

            UpdateListPokemons();
        }
    }

}