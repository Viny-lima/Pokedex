using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Enums;
using Pokedex.Model.Service;
using Pokedex.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokedex.View
{
    public sealed partial class HomePage : Page
    {
        private string _search;
        private PokemonService _service = new PokemonService();
        private PokemonDB _pokemon;
        private List<String> _listaNamesPokemons;

        public HomePage()
        {
            this.InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            _listaNamesPokemons = _service.GetNames();
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
                                new Tuple<PageOrigin, TypeNames>(PageOrigin.MainPage, TypeNames.All));
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
                    _pokemon = _service.FindById(Id).Result;
                }
                else
                {
                    _pokemon = _service.FindByName(_search).Result;
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
