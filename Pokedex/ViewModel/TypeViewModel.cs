using Pokedex.Model.Enums;
using System.Collections.Generic;

namespace Pokedex.ViewModel
{    

    public class TypeViewModel
    {
        public TypeNames Name { get; set; }

        private string _source;
        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = $"../Assets/Components/Types/T{value}.png";
            }
        }

    }    

    public static class TypeViewModelManagement
    {
        public static IList<TypeViewModel> GetImageSourceManagement()
        {
            var list = new List<TypeViewModel>();

            for (int i = 1; i <= 18; i++)
            {
                list.Add(new TypeViewModel { Name = (TypeNames)i, Source = $"{i}" });
            }

            return list;
        }

    }


}
