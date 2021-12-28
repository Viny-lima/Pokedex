using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Pokedex.ViewModel
{
    public enum PageOrigin
    {
        MainPage,
        TypePage
    }
    

    public class ListPokemonViewModel : ObservableCollection<PokemonDB>, ISupportIncrementalLoading
    {
        private PokemonService _pokemonService = new PokemonService();

        private int _start;
        private PageOrigin _origin;
        private readonly int _quantity;
        private TypeNames _typeSelected;

        public ListPokemonViewModel(PageOrigin originPage, TypeNames typeSelected = TypeNames.normal)
        {
            _start = 1;
            _quantity = 10;
            _origin = originPage;
            _typeSelected = typeSelected;          
        }

        private void UpdateListPokemons(ref CoreDispatcher coreDispatcher)
        {

            switch (_origin)
            {
                case PageOrigin.MainPage:

                    IList<PokemonDB> listPokemons = _pokemonService.FindPokemonsById(_start, _quantity).Result;

                    coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        foreach (PokemonDB p in listPokemons)
                        {
                            this.Add(p);
                        }
                    });

                    break;

                case PageOrigin.TypePage:

                    IList<PokemonDB> listTypesPokemons = _pokemonService.FindPokemonsByType($"{_typeSelected}", _start, _quantity).Result;

                    coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        foreach (PokemonDB p in listTypesPokemons)
                        {
                            this.Add(p);
                        }
                    });

                    break;
            }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            CoreDispatcher coreDispatcher = Window.Current.Dispatcher;

            return Task.Run(() =>
            {                
                UpdateListPokemons(ref coreDispatcher);

                _start += _quantity;

                return new LoadMoreItemsResult() { Count = count };
            }).AsAsyncOperation();


        }

        public bool HasMoreItems => Count < _start;
    }       

}