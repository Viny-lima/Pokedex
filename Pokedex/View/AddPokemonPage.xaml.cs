using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pokedex.View
{

    public sealed partial class AddPokemonPage : Page
    {
        IList<TypeViewModel> typesFlipView = TypeViewModelManagement.GetImageSourceManagement();

        private PokemonService _service = new PokemonService();
        private PokemonViewModel pokemonDB = new PokemonViewModel();
        private ObservableCollection<String> AbilitiesField = new ObservableCollection<String>();
        private ObservableCollection<String> MovesField = new ObservableCollection<String>();
        private ObservableCollection<String> TypesField = new ObservableCollection<String>();
        private List<String> _listaNamesPokemons = new List<String>();

        public AddPokemonPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _listaNamesPokemons = _service.GetNames();
        }

        private async void ButtonFinished_Click(object sender, RoutedEventArgs e)
        {
            if (!RequiredName()) return;
            
            pokemonDB.This.Name = Name.Text.Trim().ToLower();
            pokemonDB.This.Attack = int.Parse(Attack.Text);
            pokemonDB.This.Defense = int.Parse(Defense.Text);
            pokemonDB.This.SpecialAttack = int.Parse(SpecialAttack.Text);
            pokemonDB.This.SpecialDefense = int.Parse(SpecialDefense.Text);
            pokemonDB.This.Speed = int.Parse(Speed.Text);
            pokemonDB.This.Height = int.Parse(Height.Text);
            pokemonDB.This.Weight = int.Parse(Weight.Text);
            pokemonDB.This.BaseExperience = int.Parse(BaseExperience.Text);
            pokemonDB.This.IsComplete = true;
            pokemonDB.This.IsCreatedByTheUser = true;

            AbilitiesField.Distinct().ToList().ForEach(a => pokemonDB.This.AddAbility(a));
            MovesField.Distinct().ToList().ForEach(m => pokemonDB.This.AddMove(m));
            TypesField.Distinct().ToList().ForEach(t => pokemonDB.This.AddType(t));

            await _service.RegisterIsCreatedByUser(pokemonDB.This);
            
            ShowPokemonIsCreatedByTheUser();
        }        

        private bool RequiredName()
        {
            var name = Name.Text;

            if (!ValidateString.Validate (ref name))
            {
                ViewErro.Visibility = Visibility.Visible;
                ViewErro.Text = $"Request {Name.Header}";

                return false;
            }
            if (_listaNamesPokemons.Contains(name))
            {
                ViewErro.Visibility = Visibility.Visible;
                ViewErro.Text = $"Name Exists";

                return false;
            }
            
            return true;
        }

        private void MyTypesView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var typeName = $"{(e.ClickedItem as TypeViewModel).Name}";

            TypesField.Add(typeName);
        }

        private void ButtonAddMove_Click(object sender, RoutedEventArgs e)
        {
            Move.Text = Move.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(Move.Text))
            {
                ViewErro.Visibility = Visibility.Visible;
                ViewErro.Text = $"Can't be empty";

                return;
            }            

            MovesField.Add(Move.Text);
        }

        private void ButtonAddAbility_Click(object sender, RoutedEventArgs e)
        {
            Abitily.Text = Abitily.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(Abitily.Text))
            {
                ViewErro.Visibility = Visibility.Visible;
                ViewErro.Text = $"Can't be empty";

                return;
            }

            AbilitiesField.Add(Abitily.Text);
        }

        private void ShowPokemonIsCreatedByTheUser()
        {
            var id = _service.ReturnIdByName(Name.Text.Trim().ToLower()).Result;

            ((Window.Current.Content as Frame).Content as MainPage).RootFrame.Navigate(typeof(PokemonPage), id);
        }


    }
}
