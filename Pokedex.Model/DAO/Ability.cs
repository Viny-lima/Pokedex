using System.Collections.Generic;

namespace Pokedex.Model.DAO
{
    public class Ability : Attributes
    {
        public IList<AbilityPokemon> Pokemons { get; set; }
    }
}