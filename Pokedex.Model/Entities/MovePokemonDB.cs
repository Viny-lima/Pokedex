using System;

namespace Pokedex.Model.Entities
{
    public class MovePokemonDB : IEntity
    {
        public int PokemonId { get; set; }
        public PokemonDB Pokemon { get; set; }

        public int MoveId { get; set; }
        public MoveDB Move { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MovePokemonDB dB
                   && Move.Name == dB.Move.Name;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Move.Name);

            return hash.ToHashCode();
        }

    }
}
