﻿using Pokedex.Model.DAO;
using Pokedex.ViewModels;
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
    public sealed partial class PokemonPage : Page
    {
        public PokemonViewModel View = new PokemonViewModel();

        public PokemonPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var search = e.Parameter as String;

            var pokemonDAO = new PokemonDAO();

            try
            {

                var Id = int.Parse(search);
                View.Pokemon = pokemonDAO.FindById(Id).Result;

                if(View.Pokemon == null)
                {
                    //Implementar tela de Erro e ExcetionPokemonNotFound
                    /*throw new Exception();*/
                }
            }
            catch (FormatException)
            {
                View.Pokemon = pokemonDAO.FindByName(search as String);
            }
            
        }

        private void ButtonAbilities_Click(object sender, RoutedEventArgs e)
        {
            PanelAbilities.Visibility = Visibility.Visible;
        }

        private void ButtonMoves_Click(object sender, RoutedEventArgs e)
        {
            PanelMoves.Visibility = Visibility.Visible;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            PanelAbilities.Visibility= Visibility.Collapsed;
            PanelMoves.Visibility= Visibility.Collapsed;
        }
    }
}
