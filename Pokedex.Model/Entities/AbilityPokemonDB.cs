using System;
using System.Collections.Generic;

namespace Pokedex.Model.Entities
{
    public class AbilityPokemonDB : IEntity
    {
        public int PokemonId { get; set; }
        public PokemonDB Pokemon { get; set; }

        public int AbilityId { get; set; }
        public AbilityDB Ability { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AbilityPokemonDB dB &&
                Ability.Name == dB.Ability.Name &&
                PokemonId == dB.PokemonId;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Ability.Name);

            return hash.ToHashCode();
        }
    }
}
