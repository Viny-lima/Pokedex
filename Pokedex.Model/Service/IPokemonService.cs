﻿using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    public interface IPokemonService<T> where T : class, IEntity
    {
        Task AddPokemon(T pokemon);
        Task AddCustomPokemon(T pokemon, string typeName);
        Task UpdatePokemon(T pokemon);
        Task DeletePokemon(T pokemon);
        Task<IList<T>> FindPokemonsById(int start, int quantity);
        Task<IList<T>> FindPokemonsByType(string type, int start, int quantity);
        Task<T> FindPokemonByName(string name);
        Task<T> FindPokemonById(int id);
    }
}
