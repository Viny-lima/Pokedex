using Pokédex.Models;
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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace Pokédex
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Pokemon pokemon = new Pokemon();

        public MainPage()
        {
            this.InitializeComponent();
            CreatePokemon();
        }

        private void CreatePokemon()
        {
            pokemon.Sprite = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png";
        }

        private void ChangePokemon(object sender, RoutedEventArgs e)
        {
            pokemon.Sprite = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{IdPokemon.Text}.png";
        }

        
    }
}
