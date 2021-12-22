using System;
using System.Collections.Generic;

namespace Pokedex.Model.Entities
{
    public class AbilityDB : AttributesDB, IEntity
    {
        public IList<AbilityPokemonDB> Pokemons { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            AbilityDB ability = (AbilityDB)obj;

            return Name.Equals(ability.Name) && Id.Equals(ability.Id);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Id, Name).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}