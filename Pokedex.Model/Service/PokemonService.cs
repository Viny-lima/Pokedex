using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    class PokemonService : IPokemonService<PokemonDB>
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
                
            }

            return pokemonFound;
        }

        public async Task<PokemonDB> FindPokemonByName(string name)
        {
            return await ((PokemonDAO)_pokemonDAO).FindByName(name);
        }

        public Task<IList<PokemonDB>> FindPokemons()
        {
            throw new NotImplementedException();
        }

        public Task<IList<PokemonDB>> FindPokemonsByType(string name)
        {
            throw new NotImplementedException();
        }
    }
}
