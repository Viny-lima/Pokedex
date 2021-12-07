using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Model.Entities;

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
    }
}
