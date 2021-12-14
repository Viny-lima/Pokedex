using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
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
    public sealed partial class Home : Page
    {
        private string search;

        public Home()
        {
            this.InitializeComponent();
        }

        private void BarSearchResponsive_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var pokemonDAO = new PokemonDAO();
            var ListNamesPokemonsInDataBase = new List<String>();
            
            foreach(var PokemonDataBase in pokemonDAO.FindAll().Result)
            {
                ListNamesPokemonsInDataBase.Add(PokemonDataBase.Name);
            }                     

            var autoSuggestBox = (AutoSuggestBox)sender;
            var filtered = ListNamesPokemonsInDataBase.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;

            search = autoSuggestBox.Text;
        }

        private void BarSearchResponsive_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                var id = int.Parse(search);
                var pokemonSearch = new PokemonDB();
                var pokemonDAO = new PokemonDAO();  

                pokemonSearch = pokemonDAO.FindById(id).Result;

                if (pokemonSearch == null)
                {
                    //Implementar tela de Erro e ExcetionPokemonNotFound
                    /*throw new Exception();*/
                }

                RootFrame.Navigate(typeof(PokemonPage), pokemonSearch);
            }
            catch (ArgumentNullException)
            {
                ERRO.Visibility = Visibility.Visible;
                ERRO.Text = "ERRO: This pokemon doesn't exist";
            }
            catch (FormatException)
            {
                var pokemonSearch = new PokemonDB();
                var pokemonDAO = new PokemonDAO();

                pokemonSearch = pokemonDAO.FindByName(search as String);

                RootFrame.Navigate(typeof(PokemonPage), pokemonSearch);
            }
            
        }
    }
}
