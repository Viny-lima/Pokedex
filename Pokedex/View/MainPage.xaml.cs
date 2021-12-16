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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokedex.View
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {  
            RootFrame.Navigate(typeof(HomePage));
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(HomePage));
        }

        private void ButtonTypes_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(TypePage));
        }

        private void ButtonListPokemons_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(ListPage));
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(AboutPage));
        }
    }
}