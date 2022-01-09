using Pokedex.Model.Entities;
using Pokedex.Model.Enums;
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
        private readonly int _quantity;
        private ProgressRing _progressRing;
        private PageOrigin _origin;
        private TypeNames _typeSelected;

        public ListPokemonViewModel(ref ProgressRing progressRing, PageOrigin originPage, TypeNames typeSelected = TypeNames.normal)
        {
            _start = 1;
            _quantity = 10;
            _origin = originPage;
            _typeSelected = typeSelected;
            _progressRing = progressRing;
        }

        private void UpdateListPokemons(ref CoreDispatcher coreDispatcher)
        {
            IList<PokemonDB> listPokemons = new List<PokemonDB>();

            coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                _progressRing.Visibility = Visibility.Visible;
            });

            switch (_origin)
            {
                case PageOrigin.MainPage:

                    listPokemons = _pokemonService.FindAllById(_start, _quantity).Result;

                    break;

                case PageOrigin.TypePage:

                    listPokemons = _pokemonService.FindAllByType(_typeSelected, _start, _quantity).Result;                                         

                    break;
            }

            coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {                
                foreach (PokemonDB p in listPokemons)
                {
                    this.Add(p);                    
                }

                _progressRing.Visibility = Visibility.Collapsed;
            });

        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            CoreDispatcher coreDispatcher = Window.Current.Dispatcher;

            return Task.Run(() =>
            {                
                UpdateListPokemons(ref coreDispatcher);

                _start += _quantity;

                return new LoadMoreItemsResult() { Count = (uint) _start };
            }).AsAsyncOperation();


        }

        public bool HasMoreItems => Count + 1 == _start;
    }       

}