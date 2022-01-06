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

        public async Task Add(PokemonDB pokemon)
        {
            if (pokemon.IsCreatedByTheUser)
            {
                await SetId(pokemon);
                pokemon.IsComplete = true;
            }
            
            await _pokemonDAO.Add(pokemon);
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

            if (pokemonFoundDatabase == null || !pokemonFoundDatabase.IsComplete)
            {
                var pokemonToAddOrUpdate = SearchAPI(id);

                if (pokemonFoundDatabase == null)
                {
                    await _pokemonDAO.Add(pokemonToAddOrUpdate);
                }
                else if (!pokemonFoundDatabase.IsComplete)
                {
                    await _pokemonDAO.Update(pokemonToAddOrUpdate);
                }               

                pokemonFoundDatabase = await ((PokemonDAO)_pokemonDAO).FindById(id);
            }


            return pokemonFoundDatabase;
        }

        public async Task<PokemonDB> FindByName(string name)
        {
            var pokemonFoundDatabase = await ((PokemonDAO)_pokemonDAO).FindByName(name);

            if (pokemonFoundDatabase == null || !pokemonFoundDatabase.IsComplete)
            {
                var pokemonToAddOrUpdate = SearchAPI(name);

                if (pokemonFoundDatabase == null)
                {
                    await _pokemonDAO.Add(pokemonToAddOrUpdate);
                }
                else if(!pokemonFoundDatabase.IsComplete)
                {
                    await _pokemonDAO.Update(pokemonToAddOrUpdate);
                }

                pokemonFoundDatabase = await ((PokemonDAO)_pokemonDAO).FindByName(name);
            }

            return pokemonFoundDatabase;
        }

        public async Task<IList<PokemonDB>> FindAllById(int start, int quantity)
        {
            int end = start + quantity;

            List<PokemonDB> pokemons = await ((PokemonDAO)_pokemonDAO).FindInRange(start, end);

            if (end > 898)
            {
                // número de pokemons normais - id inicial dos pokemons especiais
                var offset = 9102;

                var especialPokemons = await ((PokemonDAO)_pokemonDAO).FindInRange(start + offset, end + offset);

                pokemons.AddRange(especialPokemons);

                if (end > 1118)
                {
                    // número de pokemons normais e especiais - id inicial dos pokemons criados pelos usuários
                    offset = 98882;

                    var customPokemons = await ((PokemonDAO)_pokemonDAO).FindInRange(start + offset, end + offset);

                    pokemons.AddRange(customPokemons);
                }
            }

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

        public async Task<IList<PokemonDB>> FindAllByType(string typeName, int start, int quantity)
        {
            var pokemons = await ((PokemonDAO)_pokemonDAO).FindByType(typeName, start - 1, quantity);

            if (pokemons.Count < quantity)
            {
                // temporário, substituir por TypeNames depois.
                var typeEnum = Enum.Parse(typeof(TypeNames), typeName);

                var pokemonsApi = ApiRequest.GetPokemonsListByType(typeEnum.ToString());

                var pokemonsToBeAdded = pokemonsApi
                                        .Where(api => !pokemons.Any(p => p.Id == api.Id))
                                        .ToList();

                foreach (var pokemon in pokemonsToBeAdded)
                {
                    var pokemonFound = ((PokemonDAO)_pokemonDAO).FindById(pokemon.Id).Result;

                    if (pokemonFound != null)
                    {
                        if (pokemonFound.Types.FirstOrDefault(t => t.Type.Name == typeName) == null)
                        {
                            await SetType(pokemonFound, typeName);
                            await _pokemonDAO.Update(pokemonFound);
                            pokemons.Add(pokemonFound);
                        }
                    }
                    else
                    {
                        var pokemonDb = new PokemonDB(pokemon.Id, pokemon.Name);
                        await SetType(pokemonDb, typeName);
                        pokemons.Add(pokemonDb);
                        await _pokemonDAO.Add(pokemonDb);
                    }
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

        private async Task SetId(PokemonDB pokemon)
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
        }

        private async Task SetType(PokemonDB pokemon, string typeName)
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

        private PokemonDB SearchAPI<T>(T search)
        {
            var pokemonApi = ApiRequest.GetPokemon(search);

            if (pokemonApi == null) throw new PokemonNotFoundException();

            var pokemon = new PokemonDB(pokemonApi);
            pokemon.IsComplete = true;

            return pokemon;
        } 
    }
}
