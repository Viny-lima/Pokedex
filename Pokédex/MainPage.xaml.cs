using Pokédex.Context;
using Pokedex.Models;
using Pokedex.Service;
using Pokédex.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace Pokedex
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ListaPokemonViewModel listaPokemonViewModel = new ListaPokemonViewModel(0, 10);

        public PokemonContext context = new PokemonContext();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {            
            
        }

        private void Next_Pokemon_Click(object sender, RoutedEventArgs e)
        {
            listaPokemonViewModel.NextPageListPokemons();
        }

        private void Previus_Pokemon_Click(object sender, RoutedEventArgs e)
        {
            listaPokemonViewModel.PreviosPageListPokemons();
        } 

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pokemonSelected = e.ClickedItem as AddressPokemon;
            var pokemon = ApiRequest.Get<Pokemon>(pokemonSelected.Url);

            SpritePokemonView.UriSource = pokemon.Sprites.FrontDefault;
            NamePokemonView.Text = pokemonSelected.NamePokemon;
        }
    }
}
