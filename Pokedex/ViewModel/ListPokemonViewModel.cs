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
        private TypeNames _typeSelected;

        public ObservableCollection<PokemonDB> Pokemons { get { return _pokemons; } }

        public ListPokemonViewModel(PageOrigin originPage, TypeNames typeSelected = TypeNames.normal,int quantity = 10)
        {
            _start = 1;
            _quantity = quantity;
            _origin = originPage;
            _typeSelected = typeSelected;

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

                    IList<PokemonDB> listTypesPokemons = _pokemonService.FindPokemonsByType($"{_typeSelected}", _start, _quantity).Result;

                    foreach (var pokemon in listTypesPokemons)
                    {
                        this._pokemons.Add(pokemon);
                    }

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