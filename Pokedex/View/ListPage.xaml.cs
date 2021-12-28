using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Pokedex.View
{

    public sealed partial class ListPage : Page
    {
        private PokemonService _service = new PokemonService();
        public ListPokemonViewModel ListPokemons;

        public ListPage()
        {            
            this.InitializeComponent();            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Tuple<PageOrigin,TypeNames> parameterNavigation =(Tuple<PageOrigin,TypeNames>) e.Parameter;

            ListPokemons = new ListPokemonViewModel(ref MyProgressRing, parameterNavigation.Item1, parameterNavigation.Item2);
        }        

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pokemonSelected = e.ClickedItem as PokemonDB;
            var pokemon = _service.FindPokemonById(pokemonSelected.Id).Result;            

            RootFrame.Navigate(typeof(PokemonPage), pokemon);
        }
    }
}
