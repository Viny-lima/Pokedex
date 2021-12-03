using System.Collections.Generic;

namespace Pokedex.Model.DAO
{
    public class TypeDB : AttributesDB
    {
        public IList<TypePokemonDB> Pokemons { get; internal set; }
    }
}