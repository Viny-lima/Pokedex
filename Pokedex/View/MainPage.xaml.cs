using Microsoft.EntityFrameworkCore;
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

namespace Pokedex.View
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {  
            //Limpando o banco de dados
            
            /*using(PokedexContext context = new PokedexContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }*/

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
            RootFrame.Navigate(typeof(ListPage), 
                                new Tuple<PageOrigin,TypeNames>(PageOrigin.MainPage,TypeNames.none) );
        }        

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(AddPokemonPage));
        }
    }
}
