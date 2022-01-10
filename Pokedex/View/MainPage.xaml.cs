using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Connection;
using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Enums;
using Pokedex.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            
            using(PokedexContext context = new PokedexContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }

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
            RootFrame.Navigate(typeof(ListPage), new Tuple<PageOrigin,TypeNames>(PageOrigin.MainPage,TypeNames.All) );
        }        

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(AddPokemonPage));
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {           
            if (RootFrame.CanGoForward)
            {
                RootFrame.GoForward();
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
            }
        }
    }
}
