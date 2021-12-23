using Pokedex.Model.Entities;
using Pokedex.Model.Service;
using Pokedex.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class AddPokemonPage : Page
    {
        IList<TypeViewModel> typesFlipView = TypeViewModelManagement.GetImageSourceManagement();

        private PokemonService _service = new PokemonService();
        private PokemonDB _pokemonDB = new PokemonDB();
        private string _typeName;

        public AddPokemonPage()
        {
            this.InitializeComponent();
        }

        private async void MyTypesView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var typeName = $"{(e.ClickedItem as TypeViewModel).Name}";
            await _pokemonDB.AddType(typeName);        
        }

        private async void ButtonFinished_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == null || Name.Text == "")
            {
                ViewErro.Visibility = Visibility.Visible;
                ViewErro.Text = "Request Name";

                return;
            }

            _pokemonDB.Name = Name.Text;
            _pokemonDB.Hp = int.Parse(Hp.Text);
            

            await _service.AddCustomPokemon(_pokemonDB);

            RootFrame.Navigate(typeof(AddPokemonPage));
        }

        private async void ButtonAddMove_Click(object sender, RoutedEventArgs e)
        {
           await _pokemonDB.AddMove(Move.Text);
        }

        private async void ButtonAddAbility_Click(object sender, RoutedEventArgs e)
        {
            await _pokemonDB.AddAbility(Abitily.Text);
        }

    }
}
