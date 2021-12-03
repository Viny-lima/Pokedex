using System.Collections.Generic;

namespace Pokedex.Model.DAO
{
    public class MoveDB : AttributesDB
    {
        public IList<MovePokemonDB> Pokemons { get; set; }
    }
}