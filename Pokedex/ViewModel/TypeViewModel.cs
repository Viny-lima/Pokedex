using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.ViewModel
{
    public enum TypeNames
    {
        none = 0,
        normal = 1,
        fighting = 2,
        flying = 3,
        poison = 4,
        ground = 5,
        rock = 6,
        bug = 7,
        ghost = 8,
        steel = 9,
        fire = 10,
        water = 11,
        grass = 12,
        electric = 13,
        psychic = 14,
        ice = 15,
        gragon = 16,
        dark = 17,
        fairy = 18,
    }

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

            for(int i = 1; i <= 18; i++)
            {
                list.Add(new TypeViewModel { Name = (TypeNames)i, Source = $"{i}" });
            }

            return list;
        }

    }
}
