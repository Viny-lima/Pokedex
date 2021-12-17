﻿using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.ViewModel;
using System;
using System.Collections.Generic;
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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokedex.View
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        private PokemonService _service = new PokemonService();
        public ListPokemonViewModel viewList;

        public ListPage()
        {            
            this.InitializeComponent();            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Tuple<PageOrigin,TypeNames> parameterNavigation =(Tuple<PageOrigin,TypeNames>) e.Parameter;

            viewList = new ListPokemonViewModel(parameterNavigation.Item1, parameterNavigation.Item2);
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            viewList.NextPageListPokemons();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pokemonSelected = e.ClickedItem as PokemonDB;
            var pokemon = _service.FindPokemonById(pokemonSelected.Id).Result;            

            RootFrame.Navigate(typeof(PokemonPage), pokemon);
        }
    }
}
