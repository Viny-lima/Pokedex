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
using Pokedex.ViewModel;
using Pokedex.Model.Entities;
using Pokedex.Model.Service;

namespace Pokedex.View
{
    public sealed partial class TypePage : Page
    {
        private PokemonService _service = new PokemonService();
        IList<TypeViewModel> typesFlipView = TypeViewModelManagement.GetImageSourceManagement();
        ListTypeViewModel listPokemonsInType = new ListTypeViewModel();

        public TypePage()
        {
            this.InitializeComponent();
        }

        private void MyFlipView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var itemSelect = (sender as FlipView).SelectedItem as TypeViewModel;

            Test.Text = $"{itemSelect.Name}";
        }

    }
}
