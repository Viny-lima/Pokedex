using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
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
    public sealed partial class PokemonPage : Page
    {
        private PokemonService _service = new PokemonService();
        public PokemonViewModel pokemon = new PokemonViewModel();

        public PokemonPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var id = (int) e.Parameter;

            pokemon.This = _service.FindById(id).Result;
        }

        private void ButtonAbilities_Click(object sender, RoutedEventArgs e)
        {
            if(PanelAbilities.Visibility == Visibility.Collapsed)
            {
                PanelAbilities.Visibility = Visibility.Visible;
                ButtonAbilities.Content = "Hide Abilties";
            }
            else
            {
                PanelAbilities.Visibility = Visibility.Collapsed;
                ButtonAbilities.Content = "Show Abilties";
            }

        }

        private void ButtonMoves_Click(object sender, RoutedEventArgs e)
        {

            if (PanelMoves.Visibility == Visibility.Collapsed)
            {
                PanelMoves.Visibility = Visibility.Visible;
                ButtonMoves.Content = "Hide Moves";
            }
            else
            {
                PanelMoves.Visibility = Visibility.Collapsed;
                ButtonMoves.Content = "Show Moves";
            }
        }

    }
}
