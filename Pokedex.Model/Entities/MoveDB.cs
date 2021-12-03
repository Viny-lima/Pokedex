using System.Collections.Generic;

namespace Pokedex.Model.Entities
{
    public class MoveDB : AttributesDB
    {
        public IList<MovePokemonDB> Pokemons { get; set; }
    }
}