using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Pokedex.Model.DAO
{
    public class PokemonDAO : PokedexDAO<PokemonDB>
    {
        public async Task<PokemonDB> FindById(int id)
        {
            PokedexContext context = new PokedexContext();

            var pokemon = await context.Pokemons
                                .Include(prop => prop.Types)
                                .ThenInclude(prop => prop.Type)
                                .Include(prop => prop.Moves)
                                .ThenInclude(prop => prop.Move)
                                .Include(prop => prop.Abilities)
                                .ThenInclude(prop => prop.Ability)
                                .FirstOrDefaultAsync(p => p.Id == id);

            return pokemon;
        }

        public async Task<PokemonDB> FindByName(string name)
        {
            PokedexContext context = new PokedexContext();

            var pokemon = await context.Pokemons
                                .Include(prop => prop.Types)
                                .ThenInclude(prop => prop.Type)
                                .Include(prop => prop.Moves)
                                .ThenInclude(prop => prop.Move)
                                .Include(prop => prop.Abilities)
                                .ThenInclude(prop => prop.Ability)
                                .FirstOrDefaultAsync(p => p.Name == name);
            return pokemon;
        }

        public async Task<IList<PokemonDB>> FindInRange(int start, int end)
        {
            PokedexContext context = new PokedexContext();

            var list = await context.Set<PokemonDB>()
                .Where(p => p.Id >= start && p.Id < end)
                .ToListAsync();

            return list;
        }
        
        public async Task<IList<PokemonDB>> FindByType(string typeName, int start, int quantity)
        {
            PokedexContext context = new PokedexContext();

            var type = await context.Set<TypeDB>()
                .Include(prop => prop.Pokemons)
                .ThenInclude(prop => prop.Pokemon)
                .FirstOrDefaultAsync(t => t.Name == typeName);

            var list = type.Pokemons
                .Select(tp => tp.Pokemon)
                .Skip(start)
                .Take(quantity)
                .ToList();

            return list;
        }
    }
}
