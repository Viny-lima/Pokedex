using Pokedex.Models;
using Pokedex.Service;
using Pokédex.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokedex
{
    public sealed partial class MainPage : Page
    {
        public PokemonViewModelList PokeList = new PokemonViewModelList(0, 10);        
        public PokemonViewModel PokeView = new PokemonViewModel();


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Pokemon_Click(object sender, RoutedEventArgs e)
        {
            PokeList.NextPageListPokemons();
        }

        private void Previus_Pokemon_Click(object sender, RoutedEventArgs e)
        {
            PokeList.PreviosPageListPokemons();
        } 

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pokemonSelected = e.ClickedItem as PokemonAddress;

            PokeView.Pokemon = ApiRequest.Get<Pokemon>(pokemonSelected.Url);
        }
    }
}
