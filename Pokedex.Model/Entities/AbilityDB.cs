using System;
using System.Collections.Generic;

namespace Pokedex.Model.Entities
{
    public class AbilityDB : AttributesDB, IEntity
    {
        public IList<AbilityPokemonDB> Pokemons { get; set; }
        
    }
}