using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Pokedex.Tests")]
namespace Pokedex.Model.Service
{
    static class PokemonServiceHelper
    {

        internal static async Task<List<PokemonDB>> FindInRangeWithOffset(IDAO<PokemonDB> pokemonDAO, int start, int end)
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

        internal static async Task<List<PokemonDB>> AddPokemonsInRangeFromAPI(IDAO<PokemonDB> pokemonDAO, List<PokemonDB> pokemons, int start, int quantity)
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

        internal static async Task<PokemonDB> AddPokemonFromAPI(IDAO<PokemonDB> pokemonDAO, string search, bool pokemonExists)
        {
            var pokemonToAddOrUpdate = SearchAPI(search);

            if (pokemonExists)
            {
                await pokemonDAO.Update(pokemonToAddOrUpdate);
            }
            else
            {
                await pokemonDAO.Add(pokemonToAddOrUpdate);
            }

            return await ((PokemonDAO)pokemonDAO).FindById(pokemonToAddOrUpdate.Id);
        }

        internal static async Task<PokemonDB> AddPokemonFromAPI(IDAO<PokemonDB> pokemonDAO, int search, bool pokemonExists)
        {
            return await AddPokemonFromAPI(pokemonDAO, $"{search}", pokemonExists);
        }

        internal static async Task<List<PokemonDB>> AddPokemonsByTypeFromAPI(IDAO<PokemonDB> pokemonDAO, List<PokemonDB> pokemons, string typeName, int start)
        {
            var pokemonsApi = ApiRequest.GetPokemonsListByType(typeName.ToString());

            if (start >= pokemonsApi.Count)
            {
                return pokemons;
            }

            var pokemonsToBeAdded = pokemonsApi
                                    .Where(api => !pokemons.Any(p => p.Id == api.Id))
                                    .ToList();

            foreach (var pokemon in pokemonsToBeAdded)
            {
                var pokemonFound = ((PokemonDAO)pokemonDAO).FindById(pokemon.Id).Result;

                if (pokemonFound != null)
                {
                    await pokemonFound.AddType(typeName.ToString());
                    await pokemonDAO.Update(pokemonFound);
                }
                else
                {
                    pokemonFound = new PokemonDB(pokemon.Id, pokemon.Name);
                    await pokemonFound.AddType(typeName.ToString());
                    await pokemonDAO.Add(pokemonFound);
                }

                pokemons.Add(pokemonFound);
            }

            return pokemons;
        }

        //A ser testado
        internal static async Task SetId(this PokemonDB pokemon)
        {
            var lastId = await ((PokemonDAO)new PokemonDAO()).FindLastId();

            if (lastId < 100001)
            {
                pokemon.Id = 100001;
            }
            else
            {
                pokemon.Id = lastId + 1;
            }
        }

        //A ser testado
        internal static PokemonDB SearchAPI(string search)
        {
            var pokemonApi = ApiRequest.GetPokemon(search);

            if (pokemonApi == null) throw new PokemonNotFoundException();

            var pokemon = new PokemonDB(pokemonApi);
            pokemon.IsComplete = true;

            return pokemon;
        }

        //A ser testado
        internal static PokemonDB SearchAPI(int search)
        {
            return SearchAPI($"{search}");
        }
    }
}
