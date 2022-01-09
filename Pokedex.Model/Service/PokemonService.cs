using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Enums;
using Pokedex.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    public class PokemonService : IPokemonService<PokemonDB>
    {
        private IDAO<PokemonDB> _pokemonDAO;
        private IDAO<TypeDB> _typeDAO;

        public PokemonService()
        {
            _pokemonDAO = new PokemonDAO();
            _typeDAO = new TypeDAO();
        }
        
        public async Task RegisterIsCreatedByUser(PokemonDB pokemon)
        {
            if (pokemon.IsCreatedByTheUser)
            {
                await pokemon.SetId();
                pokemon.IsComplete = true;

                await _pokemonDAO.Add(pokemon);
            }                      
        }
        
        public async Task Update(PokemonDB pokemon)
        {
            await _pokemonDAO.Update(pokemon);
        }
        
        public async Task Delete(PokemonDB pokemon)
        {
            await _pokemonDAO.Delete(pokemon);
        }

        
        public async Task<PokemonDB> FindById(int id)
        {
            var pokemonFoundDatabase = await ((PokemonDAO)_pokemonDAO).FindById(id);

            var pokemonExists = pokemonFoundDatabase != null;

            if (!pokemonExists || !pokemonFoundDatabase.IsComplete)
            {
                pokemonFoundDatabase = await PokemonServiceHelper.AddPokemonFromAPI(_pokemonDAO, id, pokemonExists);
            }

            return pokemonFoundDatabase;
        }
        
        public async Task<PokemonDB> FindByName(string name)
        {
            var pokemonFoundDatabase = await ((PokemonDAO)_pokemonDAO).FindByName(name);
            
            var pokemonExists = pokemonFoundDatabase != null;

            if (!pokemonExists || !pokemonFoundDatabase.IsComplete)
            {
                pokemonFoundDatabase = await PokemonServiceHelper.AddPokemonFromAPI(_pokemonDAO, name, pokemonExists);
            }

            return pokemonFoundDatabase;
        }

        //A ser testado
        public async Task<IList<PokemonDB>> FindAllById(int start, int quantity)
        {
            int end = start + quantity;

            List<PokemonDB> pokemons = await PokemonServiceHelper.FindInRangeWithOffset(_pokemonDAO, start, end);

            if (pokemons.Count < quantity)
            {
                var pokemonsApi = ApiRequest.GetPokemonsList(start - 1, quantity);

                var pokemonsToBeAdded = pokemonsApi
                                        .Where(api => !pokemons.Any(p => p.Id == api.Id))
                                        .ToList();

                foreach (var pokemon in pokemonsToBeAdded)
                {
                    var pokemonDb = new PokemonDB(pokemon.Id, pokemon.Name);
                    pokemons.Add(pokemonDb);
                    await _pokemonDAO.Add(pokemonDb);
                }

                pokemons = pokemons.OrderBy(p => p.Id).ToList();
            }


            return pokemons;
        }

        //A ser testado
        public async Task<IList<PokemonDB>> FindAllByType(TypeNames typeName, int start, int quantity)
        {
            var pokemons = await ((PokemonDAO)_pokemonDAO).FindByType(typeName.ToString(), start - 1, quantity);

            if (pokemons.Count < quantity)
            {
                var pokemonsApi = ApiRequest.GetPokemonsListByType(typeName.ToString());

                var pokemonsToBeAdded = pokemonsApi
                                        .Where(api => !pokemons.Any(p => p.Id == api.Id))
                                        .ToList();

                foreach (var pokemon in pokemonsToBeAdded)
                {
                    var pokemonFound = ((PokemonDAO)_pokemonDAO).FindById(pokemon.Id).Result;

                    if (pokemonFound != null)
                    {
                        await pokemonFound.AddType(typeName.ToString());
                        await _pokemonDAO.Update(pokemonFound);
                    }
                    else
                    {
                        pokemonFound = new PokemonDB(pokemon.Id, pokemon.Name);
                        await pokemonFound.AddType(typeName.ToString());
                        await _pokemonDAO.Add(pokemonFound);
                    }

                    pokemons.Add(pokemonFound);
                }

                pokemons = pokemons
                                .OrderBy(p => p.Id)
                                .Skip(start >= pokemons.Count ? 0 : start -1)
                                .Take(quantity)
                                .ToList();
            }

            return pokemons;
        }
        
        public List<string> GetNames()
        {
            List<string> namesPokemonsInDatabase = _pokemonDAO.FindAll().Result.Select(p => p.Name).ToList();

            return namesPokemonsInDatabase;
        }
        
    }
}
