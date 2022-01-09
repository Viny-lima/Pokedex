using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Enums;
using Pokedex.Model.Exceptions;
using Pokedex.Model.Service;
using Pokedex.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Pokedex.View
{
    public sealed partial class HomePage : Page
    {
        private string _search;
        private PokemonService _service = new PokemonService();
        private PokemonDB _pokemon;
        private List<String> _listaNamesPokemons;
        private SolidColorBrush fundoEscuro = new SolidColorBrush(Windows.UI.Color.FromArgb(178, 0, 0, 0));
        private SolidColorBrush fundoClaro = new SolidColorBrush(Windows.UI.Color.FromArgb(120, 0, 0, 0));
        
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
                if(!ValidateString.Validate(ref _search) )
                {
                    throw new ArgumentException();
                }                             

                if (int.TryParse(_search, out int Id))
                {
                    _pokemon = _service.FindById(Id).Result;
                }
                else
                {
                    _pokemon = _service.FindByName(_search).Result;
                }

            }
            catch (ArgumentException)
            {                
                ERROR.Text = "ERROR: invalid search";
                OpenPopup();
            }                        
            catch (AggregateException aggregateException)
            {
                foreach (var e in aggregateException.InnerExceptions)
                {
                    // Handle the custom exception.
                    if (e is PokemonNotFoundException)
                    {                        
                        ERROR.Text = "ERROR: Pokemon not Found";
                    }
                    // Rethrow any other exception.
                    else
                    {
                        ERROR.Text = "ERROR: aggregate exception";
                    }
                }

                OpenPopup();
            }
            finally
            {
                if (_pokemon != null)
                {
                    RootFrame.Navigate(typeof(PokemonPage), _pokemon.Id);
                }
            }
        }

        private void ButtonClosePopup_Click(object sender, RoutedEventArgs e)
        {
            ShadowPage.Fill = fundoClaro;
            PopupError.IsOpen = !PopupError.IsOpen;
        }

        private void OpenPopup()
        {
            ShadowPage.Fill = fundoEscuro;
            PopupError.IsOpen = !PopupError.IsOpen;
        }


    }

}
