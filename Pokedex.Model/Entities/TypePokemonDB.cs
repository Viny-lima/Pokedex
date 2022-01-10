using System;

namespace Pokedex.Model.Entities
{
    public class TypePokemonDB : IEntity
    {
        public int PokemonId { get; set; }
        public PokemonDB Pokemon { get; set; }

        public int TypeId { get; set; }
        public TypeDB Type { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TypePokemonDB dB
                   && Type.Name == dB.Type.Name;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Type.Name);

            return hash.ToHashCode();
        }
    }
}
