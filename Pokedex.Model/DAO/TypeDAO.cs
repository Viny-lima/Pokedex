using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Connection;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.DAO
{
    public class TypeDAO : PokedexDAO<TypeDB>
    {
        internal bool Exists(TypeDB typeDB)
        {
            var types = FindAll().Result.Where(p => p.Name == typeDB.Name);

            return   types.ToList().Count > 0;
        }

        public async Task<TypeDB> FindByName(string name)
        {
            PokedexContext context = new PokedexContext();

            var type = await context.Types
                                    .FirstOrDefaultAsync(t => t.Name == name);

            return type;
        }

        public async Task<bool> PokemonHasType(string name, int pokemonId)
        {
            PokedexContext context = new PokedexContext();

            var type = await context.Types
                                       .Include(t => t.Pokemons)
                                       .FirstOrDefaultAsync(t => t.Name == name);

            if (type == null)
            {
                return false;
            }

            var hasType = type.Pokemons.FirstOrDefault(tp => tp.PokemonId == pokemonId) != null;

            return hasType;
        }
    }
}
