using System.Collections.Generic;

namespace Pokedex.Model.DAO
{
    public class TypeElement : Attributes
    {
        public IList<TypeElementPokemon> Pokemons { get; internal set; }
    }
}