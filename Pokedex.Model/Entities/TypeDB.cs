using System.Collections.Generic;

namespace Pokedex.Model.Entities
{
    public class TypeDB : AttributesDB
    {
        public IList<TypePokemonDB> Pokemons { get; internal set; }
    }
}