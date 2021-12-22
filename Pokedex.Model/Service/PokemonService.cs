using Pokedex.Model.DAO;
using Pokedex.Model.Entities;
using Pokedex.Model.Enums;
using Pokedex.Model.Exceptions;
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
        private IDAO<TypeDB> _typeDAO;

        public PokemonService()
        {
            _pokemonDAO = new PokemonDAO();
            _typeDAO = new TypeDAO();
        }

        public async Task AddPokemon(PokemonDB pokemon)
        {
            await _pokemonDAO.Add(pokemon);
        }

        public async Task AddCustomPokemon(PokemonDB pokemon)
        {
            pokemon = await SetCustomPokemonId(pokemon);

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

            if (pokemonFound == null || pokemonFound.Types == null || pokemonFound.Types.Count == 0)
            {
                var pokemonApi = ApiRequest.GetPokemon(id);
                
                if (pokemonApi != null)
                {
                    var pokemonToAddOrUpdate = new PokemonDB(pokemonApi);

                    if (pokemonFound == null)
                    {
                        await _pokemonDAO.Add(pokemonToAddOrUpdate);
                    }
                    else
                    {
                        await _pokemonDAO.Update(pokemonToAddOrUpdate);
                    }
                }

                pokemonFound = await ((PokemonDAO)_pokemonDAO).FindById(id);
            }

            return pokemonFound;
        }

        public async Task<PokemonDB> FindPokemonByName(string name)
        {
            var pokemonFound = await ((PokemonDAO)_pokemonDAO).FindByName(name);

            if (pokemonFound == null || pokemonFound.Types == null || pokemonFound.Types.Count == 0)
            {
                var pokemonApi = ApiRequest.GetPokemon(name);

                if (pokemonApi != null)
                {
                    var pokemonToAddOrUpdate = new PokemonDB(pokemonApi);

                    if (pokemonFound == null)
                    {
                        await _pokemonDAO.Add(pokemonToAddOrUpdate);
                    }
                    else
                    {
                        await _pokemonDAO.Update(pokemonToAddOrUpdate);
                    }
                }

                pokemonFound = await ((PokemonDAO)_pokemonDAO).FindByName(name);
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
                    var pokemonDb = new PokemonDB(pokemon.Id, pokemon.Name);
                    pokemons.Add(pokemonDb);
                    await _pokemonDAO.Add(pokemonDb);
                }

                pokemons = pokemons.OrderBy(p => p.Id).ToList();

            }


            return pokemons;
        }

        public async Task<IList<PokemonDB>> FindPokemonsByType(string name, int start, int quantity)
        {
            var pokemons = await ((PokemonDAO)_pokemonDAO).FindByType(name, start - 1, quantity);

            return pokemons;
        }

        private async Task<PokemonDB> SetCustomPokemonId(PokemonDB pokemon)
        {
            var lastId = await ((PokemonDAO)_pokemonDAO).FindLastId();

            if (lastId < 100001)
            {
                pokemon.Id = 100001;
            }
            else
            {
                pokemon.Id = lastId + 1;
            }

            return pokemon;
        }

        private async Task SetCustomPokemonType(PokemonDB pokemon, string typeName)
        {
            var type = await ((TypeDAO)_typeDAO).FindByName(typeName);

            if (type == null)
            {
                if (Enum.IsDefined(typeof(TypeNames), typeName))
                {
                    pokemon.Types.Add(
                            new TypePokemonDB() { Type = new TypeDB() { Name = typeName } }
                        );
                }
                else
                {
                    throw new PokemonTypeNotFoundException("Pokemon type doesn't exist");
                }
            }
            else
            {
                pokemon.Types.Add(new TypePokemonDB() { TypeId = type.Id });
            }
        }
    }
}
