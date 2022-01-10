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
        private PokemonService _service;
        private PokemonDB _pokemon;
        private List<String> _listaNamesPokemons;
        private SolidColorBrush _fundoEscuro;
        private SolidColorBrush _fundoClaro; 
        
        public HomePage()
        {
            this.InitializeComponent();
            _service = new PokemonService();
            _fundoEscuro = new SolidColorBrush(Windows.UI.Color.FromArgb(178, 0, 0, 0));
            _fundoClaro = new SolidColorBrush(Windows.UI.Color.FromArgb(120, 0, 0, 0));
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            _listaNamesPokemons = _service.GetNames();
        }

        private void BarSearch_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {            
            _search = args.QueryText;
            CheckedQuery();            
        }

        private void BarSearch_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autoSuggestBox = sender;
            var filtered = _listaNamesPokemons.Where(p => p.StartsWith(autoSuggestBox.Text.Trim().ToLower())).ToArray();
            autoSuggestBox.ItemsSource = filtered;
        }
        

        private void ButtonAllTwo_Click(object sender, RoutedEventArgs e)
        {
            ((Window.Current.Content as Frame).Content as MainPage)
            .RootFrame.Navigate(typeof(ListPage), new Tuple<PageOrigin, TypeNames>(PageOrigin.MainPage, TypeNames.All));
        }

        private void ButtonClosePopup_Click(object sender, RoutedEventArgs e)
        {
            HomeActions.IsEnabled = true;
            ShadowPage.Fill = _fundoClaro;
            PopupError.IsOpen = !PopupError.IsOpen;
        }

        private void OpenPopup()
        {
            HomeActions.IsEnabled = false;
            ShadowPage.Fill = _fundoEscuro;
            PopupError.IsOpen = !PopupError.IsOpen;
        }

        private void ChangePage()
        {
            try
            {
                if (int.TryParse(_search, out int Id))
                {
                    _pokemon = _service.FindById(Id).Result;
                }
                else
                {
                    _pokemon = _service.FindByName(_search).Result;
                }              


                ((Window.Current.Content as Frame).Content as MainPage)
                    .RootFrame.Navigate(typeof(PokemonPage), _pokemon.Id);                
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
        }

        private void CheckedQuery()
        {           
            try
            {                               
                if(!ValidateString.Validate(ref _search))
                {
                    throw new ArgumentException();
                }

                ChangePage();
            }
            catch (ArgumentException)
            {                
                ERROR.Text = "ERROR: invalid search";
                OpenPopup();
            }                                  
            
        }              
        
    }

}
