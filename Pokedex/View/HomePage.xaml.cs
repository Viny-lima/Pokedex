﻿using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Service;
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

namespace Pokedex.View
{
    public sealed partial class HomePage : Page
    {
        private string _search;
        private PokemonService _service = new PokemonService();        
        private List<String> _listaNamesPokemons = new List<String>();
        private PokemonDB _pokemon = new PokemonDB();

        public HomePage()
        {
            this.InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            foreach(var p  in new PokedexContext().Pokemons.ToList())
            {
                _listaNamesPokemons.Add(p.Name); 
            }

        }

        private void BarSearchResponsive_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {                                
            var autoSuggestBox = sender;
            var filtered = _listaNamesPokemons.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;

            _search = autoSuggestBox.Text;
        }

        private void BarSearchResponsive_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                var id = int.Parse(_search);
                _pokemon = _service.FindPokemonById(id).Result;                
            }            
            catch (FormatException)
            {
                _pokemon = _service.FindPokemonByName(_search).Result;                              
            }
            catch (ArgumentNullException)
            {
                ERRO.Visibility = Visibility.Visible;
                ERRO.Text = "ERRO: This pokemon doesn't exist";
            }
            finally
            {
                if (_pokemon != null)
                {
                    RootFrame.Navigate(typeof(PokemonPage), _pokemon);
                }
            }

        }
        
    }
}