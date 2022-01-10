using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Connection;

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

        public async Task<List<PokemonDB>> FindInRange(int start, int end)
        {
            PokedexContext context = new PokedexContext();

            var list = await context.Set<PokemonDB>()
                .Where(p => p.Id >= start && p.Id < end)
                .ToListAsync();

            return list;
        }
        
        public async Task<List<PokemonDB>> FindByType(string typeName, int start, int quantity)
        {
            PokedexContext context = new PokedexContext();

            var type = await context.Set<TypeDB>()
                .Include(prop => prop.Pokemons)
                .ThenInclude(prop => prop.Pokemon)
                .FirstOrDefaultAsync(t => t.Name == typeName);

            if (type != null)
            {
                var list = type.Pokemons
                    .Select(tp => tp.Pokemon)
                    .Skip(start)
                    .Take(quantity)
                    .ToList();

                return list;
            }

            return new List<PokemonDB>();
        }

        public async Task<int> FindLastId()
        {
            PokedexContext context = new PokedexContext();

            var lastPokemon = await context.Pokemons
                                      .OrderByDescending(p => p.Id)
                                      .FirstOrDefaultAsync();

            if (lastPokemon == null)
            {
                return 0;
            }

            return lastPokemon.Id;
        }

        public async Task<int> ReturnIdByName(string name)
        {
            PokedexContext context = new PokedexContext();

            var pokemon =  await context.Pokemons.FirstOrDefaultAsync(p => p.Name == name);

            return pokemon.Id;
        }
    }
}
