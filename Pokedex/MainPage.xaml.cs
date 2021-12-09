using Pokedex.Model;
using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;
using Pokedex.Model.Service;
using Pokedex.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokedex
{
    public sealed partial class MainPage : Page
    {
        public PokeViewModel PokeView = new PokeViewModel(1);


        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Pokemon_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Previus_Pokemon_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}