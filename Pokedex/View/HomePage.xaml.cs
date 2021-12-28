using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
        private PokemonDB _pokemon;
        private List<String> _listaNamesPokemons = new List<String>();

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
            CheckedQuery();
        }

        private void ButtonAllTwo_Click(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(ListPage),
                                new Tuple<PageOrigin, TypeNames>(PageOrigin.MainPage, TypeNames.none));
        }

        private void CheckedQuery()
        {           
            try
            {               
                if(_search != null)
                {
                    _search = _search.Trim().ToLower();
                }

                if (string.IsNullOrEmpty(_search) || Regex.IsMatch(_search, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
                {
                    throw new ArgumentNullException();
                }                

                if (int.TryParse(_search, out int Id))
                {
                    _pokemon = _service.FindPokemonById(Id).Result;
                }
                else
                {
                    _pokemon = _service.FindPokemonByName(_search).Result;
                }

                if(_pokemon == null)
                {
                    throw new ArgumentNullException();
                }

            }
            catch (ArgumentNullException)
            {
                ERROR.Visibility = Visibility.Visible;
                ERROR.Text = "ERROR: This query doesn't exist";
            }
            
            catch (NullReferenceException)
            {
                ERROR.Visibility = Visibility.Visible;
                ERROR.Text = "ERROR: Null Reference Exception";
            }
            catch (Exception)
            {
                ERROR.Visibility = Visibility.Visible;
                ERROR.Text = "ERROR: Pokemon not Found";
            }
            finally
            {
                if (_pokemon != null)
                {
                    RootFrame.Navigate(typeof(PokemonPage), _pokemon.Id);
                }
            }
        }
    }
}
