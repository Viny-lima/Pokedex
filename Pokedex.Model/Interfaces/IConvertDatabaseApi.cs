using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    public interface IConvertDatabaseApi
    {
       PokemonDb ConvertPokemon(Pokemon pokemonAPI);
    }
}
