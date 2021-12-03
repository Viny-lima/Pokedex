using System.Collections.Generic;

namespace Pokedex.Model.Entities
{
    public class AbilityDB : AttributesDB
    {
        public IList<AbilityPokemonDB> Pokemons { get; set; }
    }
}