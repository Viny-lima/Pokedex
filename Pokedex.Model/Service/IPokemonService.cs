using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    public interface IPokemonService<T> where T : class, IEntity
    {
        Task AddPokemon(T pokemon);
        Task UpdatePokemon(T pokemon);
        Task DeletePokemon(T pokemon);
        Task<IList<T>> FindPokemons();
        Task<IList<T>> FindPokemonsByType(string type);
        Task<T> FindPokemonByName(string name);
        Task<T> FindPokemonById(int id);
    }
}
