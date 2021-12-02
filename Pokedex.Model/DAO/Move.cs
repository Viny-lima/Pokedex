using System.Collections.Generic;

namespace Pokedex.Model.DAO
{
    public class Move : Attributes
    {
        public IList<MovePokemon> Pokemons { get; set; }
    }
}