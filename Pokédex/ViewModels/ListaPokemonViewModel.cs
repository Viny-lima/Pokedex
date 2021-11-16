using Pokedex;
using Pokedex.Models;
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
        private ObservableCollection<Pokemon> _pokemons = new ObservableCollection<Pokemon>();
        private int _startindex;
        private readonly int _qtdPokemons;
        private ApiRequest _apiRequests;


        public ObservableCollection<Pokemon> ListaPokemons { get { return _pokemons; } }

        public ListaPokemonViewModel(ApiRequest api, int startIndex, int qtdPokeomns)
        {
            _startindex = startIndex;
            _qtdPokemons = qtdPokeomns;
            _apiRequests = api;

            PropertiesListPokemon propertiesList = api.GetListaPokemons(startIndex, qtdPokeomns);

            foreach (var pokemon in propertiesList.Results)
            {
                this._pokemons.Add(pokemon);
            }
        }

        /// <summary>
        /// Redefine a lista em exibição basedo nas propriedades <see cref="_startindex"/> e <see cref="_qtdPokemons"/>.
        /// </summary>
        private void UpdateListPokemons()
        {
            PropertiesListPokemon propertiesList = _apiRequests.GetListaPokemons(_startindex, _qtdPokemons);
            this._pokemons.Clear();

            foreach (var newPokemon in propertiesList.Results)
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
