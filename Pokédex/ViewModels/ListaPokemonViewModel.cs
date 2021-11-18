using Pokedex;
using Pokedex.Models;
using Pokedex.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.ViewModels
{
    public class ListaPokemonViewModel
    {
        private ObservableCollection<AddressPokemon> _pokemons = new ObservableCollection<AddressPokemon>();
        private int _startindex;
        private readonly int _qtdPokemons;


        public ObservableCollection<AddressPokemon> ListaPokemons { get { return _pokemons; } }

        public ListaPokemonViewModel(int startIndex, int qtdPokeomns)
        {
            _startindex = startIndex;
            _qtdPokemons = qtdPokeomns;

            List<AddressPokemon> ListaPokemons = ApiRequest.GetPropertiesListPokemons(_startindex, _qtdPokemons).Results;

            foreach (var pokemon in ListaPokemons)
            {
                this._pokemons.Add(pokemon);
            }
        }

        /// <summary>
        /// Redefine a lista em exibição basedo nas propriedades <see cref="_startindex"/> e <see cref="_qtdPokemons"/>.
        /// </summary>
        private void UpdateListPokemons()
        {
            List<AddressPokemon> listPokemon = ApiRequest.GetPropertiesListPokemons(_startindex, _qtdPokemons).Results;
            this._pokemons.Clear();

            foreach (AddressPokemon newPokemon in listPokemon)
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
            _startindex += 10;
            if (_startindex > 100) _startindex = 0;

            UpdateListPokemons();
        }
        /// <summary>
        /// O método subtrai 10 ao index que foi definido inicialmente no construtor. 
        /// Assim Criando uma nova exbição de dados.
        /// </summary>
        public void PreviosPageListPokemons()
        {
            _startindex -= 10;
            if (_startindex < 0) _startindex = 0;

            UpdateListPokemons();
        }
    }

}
