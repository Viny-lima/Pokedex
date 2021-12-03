using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    public interface IConvertDatabaseApi
    {
        Entities.PokemonDB ConvertPokemon(PokeApi.PokemonAPI pokemonAPI);
    }
}
