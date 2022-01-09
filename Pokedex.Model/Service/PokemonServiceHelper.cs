using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    public static class PokemonServiceHelper
    {

        public static async Task<List<PokemonDB>> FindInRangeWithOffset(IDAO<PokemonDB> pokemonDAO, int start, int end)
        {
            List<PokemonDB> pokemons = await ((PokemonDAO)pokemonDAO).FindInRange(start, end);

            if (end > 898)
            {
                // número de pokemons normais - id inicial dos pokemons especiais
                var offset = 9102;

                var especialPokemons = await ((PokemonDAO)pokemonDAO).FindInRange(start + offset, end + offset);

                pokemons.AddRange(especialPokemons);

                if (end > 1118)
                {
                    // número de pokemons normais e especiais - id inicial dos pokemons criados pelos usuários
                    offset = 98882;

                    var customPokemons = await ((PokemonDAO)pokemonDAO).FindInRange(start + offset, end + offset);

                    pokemons.AddRange(customPokemons);
                }
            }

            return pokemons;
        }

        public static async Task<List<PokemonDB>> AddPokemonsInRangeFromAPI(IDAO<PokemonDB> pokemonDAO, List<PokemonDB> pokemons, int start, int quantity)
        {
            var pokemonsApi = ApiRequest.GetPokemonsList(start - 1, quantity);

            var pokemonsToBeAdded = pokemonsApi
                                    .Where(api => !pokemons.Any(p => p.Id == api.Id))
                                    .ToList();

            foreach (var pokemon in pokemonsToBeAdded)
            {
                var pokemonDb = new PokemonDB(pokemon.Id, pokemon.Name);
                pokemons.Add(pokemonDb);
                await pokemonDAO.Add(pokemonDb);
            }

            pokemons = pokemons.OrderBy(p => p.Id).ToList();

            return pokemons;
        }

    }
}
