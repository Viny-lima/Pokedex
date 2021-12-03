using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokedex.Model.PokeApi.Helper
{
    public static class TypeAPIHelper
    {
        private static PokedexContext context = new PokedexContext();
        public static List<TypeDB> TypesAPI;

        public static void InitializeTypesAPI()
        {
            TypesAPI = context.Types.ToList();           
        }

        public static bool CheckIfExists(TypeDB typeToCheck)
        {
            return TypesAPI.Contains(typeToCheck);
        }
    }
}
