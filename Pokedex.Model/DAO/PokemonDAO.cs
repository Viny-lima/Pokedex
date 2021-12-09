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

            var pokemon = await context.FindAsync<PokemonDB>(id);

            return pokemon;
        }

        public PokemonDB FindByName(string name)
        {
            PokedexContext context = new PokedexContext();

            var pokemon = context.Pokemons
                .FirstOrDefault(p => p.Name == name);

            return pokemon;
        }

        public async override Task<IList<PokemonDB>> FindAll()
        {
            PokedexContext context = new PokedexContext();

            var list = await context
                                .Set<PokemonDB>()/*
                                .Include(prop => prop.Types)
                                .ThenInclude(prop => prop.Type)
                                .Include(prop => prop.Moves)
                                .ThenInclude(prop => prop.Move)
                                .Include(prop => prop.Abilities)
                                .ThenInclude(prop => prop.Ability)*/
                                .ToListAsync();
            return list;
        }
    }
}
