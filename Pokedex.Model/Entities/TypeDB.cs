using System.Collections.Generic;

namespace Pokedex.Model.Entities
{
    public class TypeDB : AttributesDB, IEntity
    {
        public IList<TypePokemonDB> Pokemons { get; internal set; }
    }
}