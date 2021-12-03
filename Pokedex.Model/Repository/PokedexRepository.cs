using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Repository
{
    public class PokedexRepository : IRepositoryEntity
    {
        public List<AbilityDB> GetAbilities()
        {
            throw new NotImplementedException();
        }

        public List<MoveDB> GetMoves()
        {
            throw new NotImplementedException();
        }

        public List<PokemonDB> GetPokemons()
        {
            throw new NotImplementedException();
        }

        public List<TypeDB> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
}
