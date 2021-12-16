using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    public class PokemonService : IPokemonService<PokemonDB>
    {
        private IDAO<PokemonDB> _pokemonDAO;

        public PokemonService()
        {
            _pokemonDAO = new PokemonDAO();
        }

        public async Task AddPokemon(PokemonDB pokemon)
        {
            await _pokemonDAO.Add(pokemon);
        }
       
        public async Task UpdatePokemon(PokemonDB pokemon)
        {
            await _pokemonDAO.Update(pokemon);
        }

        public async Task DeletePokemon(PokemonDB pokemon)
        {
            await _pokemonDAO.Delete(pokemon);
        }

        public async Task<PokemonDB> FindPokemonById(int id)
        {
            var pokemonFound = await ((PokemonDAO)_pokemonDAO).FindById(id);

            if (pokemonFound == null)
            {
                var pokemonApi = ApiRequest.GetPokemon(id);
                
                if (pokemonApi != null)
                {
                    pokemonFound = new PokemonDB(pokemonApi);
                    await _pokemonDAO.Add(pokemonFound);
                }
            }

            return pokemonFound;
        }

        public async Task<PokemonDB> FindPokemonByName(string name)
        {
            var pokemonFound = await ((PokemonDAO)_pokemonDAO).FindByName(name);

            if (pokemonFound == null)
            {
                var pokemonApi = ApiRequest.GetPokemon(name);

                if (pokemonApi != null)
                {
                    pokemonFound = new PokemonDB(pokemonApi);
                    await _pokemonDAO.Add(pokemonFound);
                }
            }

            return pokemonFound;
        }

        public async Task<IList<PokemonDB>> FindPokemonsById(int start, int quantity)
        {
            int end = start + quantity;

            var pokemons = await ((PokemonDAO)_pokemonDAO).FindInRange(start, end);

            if (pokemons.Count < quantity)
            {
                var pokemonsApi = ApiRequest.GetPokemonsList(start - 1, quantity);

                var pokemonsToBeAdded = pokemonsApi
                                        .Where(api => !pokemons.Any(p => p.Id == api.Id))
                                        .ToList();

                foreach (var pokemon in pokemonsToBeAdded)
                {
                    var pokemonDb = new PokemonDB(pokemon);
                    pokemons.Add(pokemonDb);
                    await _pokemonDAO.Add(pokemonDb);
                }

                pokemons = pokemons.OrderBy(p => p.Id).ToList();
            }            

            return pokemons;
        }

        public Task<IList<PokemonDB>> FindPokemonsByType(string name)
        {
            throw new NotImplementedException();
        }
    }
}
