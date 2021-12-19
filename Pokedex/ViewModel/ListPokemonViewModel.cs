using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pokedex.ViewModel
{
    public enum PageOrigin
    {
        MainPage,
        TypePage
    }
    

    public class ListPokemonViewModel
    {
        private PokemonService _pokemonService = new PokemonService();
        private ObservableCollection<PokemonDB> _pokemons = new ObservableCollection<PokemonDB>();

        private int _start;
        private PageOrigin _origin;
        private readonly int _quantity;

        public ObservableCollection<PokemonDB> Pokemons { get { return _pokemons; } }

        public ListPokemonViewModel(PageOrigin originPage, int quantity = 10)
        {
            _start = 1;
            _quantity = quantity;
            _origin = originPage;

            UpdateListPokemons();            
        }

        private void UpdateListPokemons()
        {
            switch (_origin)
            {
                case PageOrigin.MainPage:

                    IList<PokemonDB> listPokemons = _pokemonService.FindPokemonsById(_start, _quantity).Result;

                    foreach (var pokemon in listPokemons)
                    {
                        this._pokemons.Add(pokemon);
                    }

                    break;
                case PageOrigin.TypePage:
                    break;
            }
        }
        public void NextPageListPokemons()
        {
            _start += _quantity;

            UpdateListPokemons();
        }


    }

}