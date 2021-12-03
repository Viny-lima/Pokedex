using System.Collections.Generic;

namespace Pokedex.Model.DAO
{
    public class AbilityDB : AttributesDB
    {
        public IList<AbilityPokemonDB> Pokemons { get; set; }
    }
}